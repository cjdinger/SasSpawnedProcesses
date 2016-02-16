namespace SAS.Tasks.SASProcesses
{
    partial class SasSpawnedProcessesTaskForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.lblOption = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPW = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.listProcesses = new System.Windows.Forms.ListView();
            this.chPID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAccount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUptime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUUID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnKill = new System.Windows.Forms.Button();
            this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDetails = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(647, 369);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(69, 23);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(215, 20);
            this.txtHost.TabIndex = 1;
            // 
            // lblOption
            // 
            this.lblOption.AutoSize = true;
            this.lblOption.Location = new System.Drawing.Point(5, 26);
            this.lblOption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOption.Name = "lblOption";
            this.lblOption.Size = new System.Drawing.Size(61, 13);
            this.lblOption.TabIndex = 0;
            this.lblOption.Text = "Host name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(309, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(344, 23);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(60, 20);
            this.txtPort.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "User ID:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(69, 52);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(155, 20);
            this.txtUser.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password:";
            // 
            // txtPW
            // 
            this.txtPW.Location = new System.Drawing.Point(69, 82);
            this.txtPW.Name = "txtPW";
            this.txtPW.PasswordChar = '*';
            this.txtPW.Size = new System.Drawing.Size(157, 20);
            this.txtPW.TabIndex = 7;
            this.txtPW.UseSystemPasswordChar = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.lblOption);
            this.groupBox1.Controls.Add(this.txtPW);
            this.groupBox1.Controls.Add(this.txtHost);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(704, 119);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SAS Object Spawner details";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(288, 80);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(116, 23);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "Show Processes";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // listProcesses
            // 
            this.listProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPID,
            this.chType,
            this.chNode,
            this.chAccount,
            this.chUptime,
            this.chUUID});
            this.listProcesses.FullRowSelect = true;
            this.listProcesses.Location = new System.Drawing.Point(12, 151);
            this.listProcesses.Name = "listProcesses";
            this.listProcesses.Size = new System.Drawing.Size(704, 213);
            this.listProcesses.TabIndex = 1;
            this.listProcesses.UseCompatibleStateImageBehavior = false;
            this.listProcesses.View = System.Windows.Forms.View.Details;
            this.listProcesses.SelectedIndexChanged += new System.EventHandler(this.listProcesses_SelectedIndexChanged);
            this.listProcesses.DoubleClick += new System.EventHandler(this.OnListDoubleClick);
            // 
            // chPID
            // 
            this.chPID.Text = "Process ID";
            this.chPID.Width = 103;
            // 
            // chNode
            // 
            this.chNode.Text = "Node";
            this.chNode.Width = 129;
            // 
            // chAccount
            // 
            this.chAccount.Text = "Owner";
            this.chAccount.Width = 135;
            // 
            // chUptime
            // 
            this.chUptime.Text = "Up time";
            this.chUptime.Width = 125;
            // 
            // chUUID
            // 
            this.chUUID.Text = "Unique ID";
            this.chUUID.Width = 86;
            // 
            // btnKill
            // 
            this.btnKill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnKill.Location = new System.Drawing.Point(12, 368);
            this.btnKill.Name = "btnKill";
            this.btnKill.Size = new System.Drawing.Size(163, 23);
            this.btnKill.TabIndex = 2;
            this.btnKill.Text = "End SAS process";
            this.btnKill.UseVisualStyleBackColor = true;
            this.btnKill.Click += new System.EventHandler(this.btnKill_Click);
            // 
            // chType
            // 
            this.chType.Text = "Type";
            this.chType.Width = 106;
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(181, 367);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(115, 23);
            this.btnDetails.TabIndex = 4;
            this.btnDetails.Text = "Show Details...";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // SasSpawnedProcessesTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 402);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.btnKill);
            this.Controls.Add(this.listProcesses);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(440, 440);
            this.Name = "SasSpawnedProcessesTaskForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View SAS Processes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label lblOption;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPW;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ListView listProcesses;
        private System.Windows.Forms.ColumnHeader chPID;
        private System.Windows.Forms.ColumnHeader chNode;
        private System.Windows.Forms.ColumnHeader chAccount;
        private System.Windows.Forms.ColumnHeader chUptime;
        private System.Windows.Forms.Button btnKill;
        private System.Windows.Forms.ColumnHeader chUUID;
        private System.Windows.Forms.ColumnHeader chType;
        private System.Windows.Forms.Button btnDetails;
    }
}