using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SAS.Shared.AddIns;
using SAS.Tasks.Toolkit.Controls;
using SAS.Tasks.Toolkit;
using System.Data.OleDb;
using SAS.Tasks.SASProcesses;

namespace SAS.Tasks.SASProcesses
{
    /// <summary>
    /// This windows form inherits from the TaskForm class, which
    /// includes a bit of special handling for SAS Enterprise Guide.
    /// </summary>
    public partial class SasSpawnedProcessesTaskForm : SAS.Tasks.Toolkit.Controls.TaskForm
    {
        // ex: iom://localhost:8581;bridge;user=sasadm@saspw,pass=Password1
        const string SpawnerUrl = "%let connection = 'iom://{0}:{1};bridge;user={2},pass={3}';";

        public SasSpawnedProcessesTaskForm(SAS.Shared.AddIns.ISASTaskConsumer3 consumer)
        {
            InitializeComponent();

            // provide a handle to the SAS Enterprise Guide application
            this.Consumer = consumer;
        }

        // initialize the form with the values from the settings
        protected override void OnLoad(EventArgs e)
        {
            // use the Toolkit class to get details of Metadata profile
            SAS.Tasks.Toolkit.Helpers.SasMetadataProfile prof = SAS.Tasks.Toolkit.Helpers.SasMetadataProfile.GetActiveProfile();
            txtHost.Text = prof.Host;
            // 8581 is the default port used by SAS Object Spawner.
            // can be configured differently, so check your environment
            txtPort.Text = "8581";
            txtUser.Text = prof.UserID;
            txtPW.Text = "";

            // restore saved fields if any
            RestoreSettings();

            // update status of End Process button
            UpdateKillButton();

            base.OnLoad(e);
        }

        // to hold current cursor while processing, showing WaitCursor
        Cursor _savedCursor = null;
        // SAS job ID in case we need to cancel
        int sasJobId = -1;

        private void btnConnect_Click(object sender, EventArgs e)
        {
            RefreshProcesses();
        }

        SubmitProgressForm progressdlg;

        /// <summary>
        /// This submits a bit of SAS code to run PROC IOMOPERATE
        /// The code is submitted asynchronously, so a cancel dialog is shown
        /// in case it runs longer than the user wants to wait
        /// </summary>
        private void RefreshProcesses()
        {
            string connectUrl = string.Format(SpawnerUrl, txtHost.Text, txtPort.Text, txtUser.Text, txtPW.Text);
            string code = SAS.Tasks.Toolkit.Helpers.UtilityFunctions.ReadFileFromAssembly("SAS.Tasks.SASProcesses.prociomoperate.sas");
            code = connectUrl + code;
            SasSubmitter s = new SasSubmitter(Consumer.AssignedServer);
            if (!s.IsServerBusy())
            {
                _savedCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                s.SubmitSasProgramComplete += handle_SubmitSasProgramComplete;
                sasJobId = s.SubmitSasProgram(code);

                // show the Progress dialog with cancel button
                progressdlg = new SubmitProgressForm();
                if (progressdlg.ShowDialog(this) == DialogResult.Cancel)
                {
                    s.CancelJob(sasJobId);
                    progressdlg = null;
                }
            }
            else
                MessageBox.Show(string.Format("The server {0} is busy; cannot check server processes.", Consumer.AssignedServer));
        }

        // Job done!
        private void handle_SubmitSasProgramComplete(object sender, SubmitCompleteEventArgs args)
        {
            // use BeginInvoke to move processing back to UI thread
            BeginInvoke(new MethodInvoker(
                delegate()
                {
                    // Close progress dialog if needed
                    if (progressdlg != null && progressdlg.Visible)
                    {
                        progressdlg.Close();
                        progressdlg = null;
                    }
                    sasJobId = -1;
                    Cursor.Current = _savedCursor;

                    if (args.Success)
                    {
                        SaveSettings();
                        AddProcesses();
                        UpdateKillButton();
                    }
                    else
                    {
                        MessageBox.Show("An error occurred while trying to retrieve the list of processes.", "Error");
                    }
                    
                }
            ));
        }

        // These routines save the settings from the fields to task-specific
        // settings file in the %APPDATA% user profile area
        const string taskKey = "IOMOPERATE_TASK";
        private void SaveSettings()
        {
            string key = string.Format("{0}_{1}", taskKey, SAS.Tasks.Toolkit.Helpers.SasMetadataProfile.GetActiveProfile().Host);
            SAS.Tasks.Toolkit.Helpers.TaskUserSettings.WriteValue(key, "HOST", txtHost.Text);
            SAS.Tasks.Toolkit.Helpers.TaskUserSettings.WriteValue(key, "PORT", txtPort.Text);
            SAS.Tasks.Toolkit.Helpers.TaskUserSettings.WriteValue(key, "USERID", txtUser.Text);
        }
        private void RestoreSettings()
        {
            string key = string.Format("{0}_{1}", taskKey, SAS.Tasks.Toolkit.Helpers.SasMetadataProfile.GetActiveProfile().Host);
            txtHost.Text = SAS.Tasks.Toolkit.Helpers.TaskUserSettings.ReadValue(key, "HOST").Length > 0 ?
                SAS.Tasks.Toolkit.Helpers.TaskUserSettings.ReadValue(key, "HOST") : txtHost.Text;
            txtUser.Text = SAS.Tasks.Toolkit.Helpers.TaskUserSettings.ReadValue(key, "USERID").Length > 0 ?
                SAS.Tasks.Toolkit.Helpers.TaskUserSettings.ReadValue(key, "USERID") : txtUser.Text;
            txtPort.Text = SAS.Tasks.Toolkit.Helpers.TaskUserSettings.ReadValue(key, "PORT").Length > 0 ?
                SAS.Tasks.Toolkit.Helpers.TaskUserSettings.ReadValue(key, "PORT") : txtPort.Text;
        }

        // When code query is complete, read the process details from 
        // a SAS data set on the server session.
        // Use this to populate the list view of processes.
        private void AddProcesses()
        {
            listProcesses.BeginUpdate();
            listProcesses.Items.Clear();
             SasServer s = new SasServer(Consumer.AssignedServer);
            using (OleDbConnection conn = s.GetOleDbConnection())
            {
                try
                {
                    //----- make provider connection
                    conn.Open();

                    //----- Read values from query command
                    string sql = @"select * from work._allpids_";
                    OleDbCommand cmdDB = new OleDbCommand(sql, conn);
                    OleDbDataReader dataReader = cmdDB.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dataReader.Read())
                    {
                        // create an in-memory object of the process
                        // so we can use this in a PropertyGrid control later
                        SasProcess proc = new SasProcess();
                        proc.PID = dataReader["ProcessIdentifier"].ToString().Trim();
                        proc.Host = dataReader["HostKnownBy"].ToString().Trim();
                        proc.Type = dataReader["ServerComponentName"].ToString().Trim();
                        proc.ServerPort = dataReader["ServerPort"].ToString().Trim();
                        proc.UUID = dataReader["UniqueIdentifier"].ToString().Trim();
                        proc.CPUs = dataReader["CPUCount"].ToString().Trim();
                        proc.Command = dataReader["Command"].ToString().Trim();
                        proc.Owner = dataReader["ProcessOwner"].ToString().Trim();
                        proc.SASVersion = dataReader["VersionLong"].ToString().Trim();
                        proc.StartTime = dataReader["UpTime"].ToString().Trim();

                        ListViewItem li = new ListViewItem(proc.PID);
                        li.Tag = proc;
                        li.SubItems.Add(proc.Type);
                        li.SubItems.Add(proc.Host);
                        li.SubItems.Add(proc.Owner);
                        li.SubItems.Add(proc.StartTime);
                        li.SubItems.Add(proc.UUID);
                        listProcesses.Items.Add(li);
                    }
                }
                catch { }
                finally
                {
                   conn.Close();
                }
            }       
            listProcesses.EndUpdate();
        }

        private void listProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateKillButton();
        }

        private void UpdateKillButton()
        {
            if (listProcesses.SelectedItems.Count == 1)
            {
                btnKill.Enabled = true;
                btnKill.Text = string.Format("End SAS process {0}", listProcesses.SelectedItems[0].Text);
            }
            else
            {
                btnKill.Text = "<select a process>";
                btnKill.Enabled = false;
            }
        }

        // This kills a SAS process with PROC IOMOPERATE.
        // SAS code is submitted, this time synchronously
        string killProgram = "proc iomoperate uri=&connection.; stop spawned server id='{0}'; quit";
        private void btnKill_Click(object sender, EventArgs e)
        {
            if (listProcesses.SelectedItems.Count == 1)
            {
                string log = "";
                string UUID = (listProcesses.SelectedItems[0].Tag as SasProcess).UUID;
                string program = string.Format(killProgram, UUID );
                SasSubmitter s = new SasSubmitter(Consumer.AssignedServer);
                bool success = s.SubmitSasProgramAndWait(program, out log);
                if (success) 
                    RefreshProcesses();
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            ShowProcessProperties();
        }

        private void OnListDoubleClick(object sender, EventArgs e)
        {
            ShowProcessProperties();
        }

        // Show the PropertyGrid with the process fields and values
        private void ShowProcessProperties()
        {
            if (listProcesses.SelectedItems.Count == 1)
            {
                ProcessDetailsDlg dlg = new ProcessDetailsDlg();
                dlg.Process = listProcesses.SelectedItems[0].Tag as SasProcess;
                dlg.ShowDialog();
                // dialog is dismissed

                UpdateKillButton();
            }
        }
    }
}
