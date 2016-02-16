namespace SAS.Tasks.SASProcesses
{
    partial class ProcessDetailsDlg
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
            this.pgProcess = new System.Windows.Forms.PropertyGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pgProcess
            // 
            this.pgProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgProcess.HelpVisible = false;
            this.pgProcess.Location = new System.Drawing.Point(13, 28);
            this.pgProcess.Name = "pgProcess";
            this.pgProcess.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.pgProcess.Size = new System.Drawing.Size(373, 295);
            this.pgProcess.TabIndex = 1;
            this.pgProcess.ToolbarVisible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Properties of the selected process:";
            // 
            // ProcessDetailsDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 335);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pgProcess);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProcessDetailsDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SAS Process Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid pgProcess;
        private System.Windows.Forms.Label label1;
    }
}