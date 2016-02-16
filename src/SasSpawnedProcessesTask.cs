using System;
using System.Text;
using SAS.Shared.AddIns;
using SAS.Tasks.Toolkit;

namespace SAS.Tasks.SASProcesses
{
    // unique identifier for this task
    [ClassId("f18e2b14-e505-4905-9291-41b3a17f0699")]
    // location of the task icon to show in the menu and process flow
    [IconLocation("SAS.Tasks.SASProcesses.task.ico")]
    [InputRequired(InputResourceType.None)]
    [SASMetadataRequired(true)]
    public class SasSpawnedProcessesTask : SAS.Tasks.Toolkit.SasTask
    {
        #region Initialization
        public SasSpawnedProcessesTask()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // 
            // SasSpawnedProcessesTask
            // 
            this.GeneratesSasCode = false;
            this.ProcsUsed = "IOMOPERATE";
            this.RequiresData = false;
            this.TaskCategory = "Utilities";
            this.TaskDescription = "List SAS processes and cancel them if needed";
            this.TaskName = "Show SAS Processes";

        }
        #endregion

        #region overrides
        public override bool Initialize()
        {
            return true;
        }

        /// <summary>
        /// Show the task user interface
        /// </summary>
        /// <param name="Owner"></param>
        /// <returns>whether to cancel the task, or run now</returns>
        public override ShowResult Show(System.Windows.Forms.IWin32Window Owner)
        {
            SasSpawnedProcessesTaskForm dlg = new SasSpawnedProcessesTaskForm(this.Consumer);
            dlg.ShowDialog(Owner);
            return ShowResult.Canceled;
        }

        #endregion

    }
}
