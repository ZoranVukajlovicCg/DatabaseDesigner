namespace DatabaseDesigner.Forms
{
    partial class FormLoadUml
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
            this.BtnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tbValidationReport = new System.Windows.Forms.TextBox();
            this.bRawData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rbNew = new System.Windows.Forms.RadioButton();
            this.rbExisting = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(697, 562);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 22;
            this.BtnCancel.Text = "Discard";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(616, 562);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 21;
            this.btnOk.Text = "Accept";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.ButtonOkClick);
            // 
            // tbValidationReport
            // 
            this.tbValidationReport.Location = new System.Drawing.Point(15, 66);
            this.tbValidationReport.Multiline = true;
            this.tbValidationReport.Name = "tbValidationReport";
            this.tbValidationReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbValidationReport.Size = new System.Drawing.Size(755, 410);
            this.tbValidationReport.TabIndex = 23;
            // 
            // bRawData
            // 
            this.bRawData.Location = new System.Drawing.Point(12, 12);
            this.bRawData.Name = "bRawData";
            this.bRawData.Size = new System.Drawing.Size(758, 23);
            this.bRawData.TabIndex = 24;
            this.bRawData.Text = "View Raw Data";
            this.bRawData.UseVisualStyleBackColor = true;
            this.bRawData.Click += new System.EventHandler(this.ButtonViewRawDataClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Validation Report";
            // 
            // rbNew
            // 
            this.rbNew.AutoSize = true;
            this.rbNew.Checked = true;
            this.rbNew.Location = new System.Drawing.Point(15, 494);
            this.rbNew.Name = "rbNew";
            this.rbNew.Size = new System.Drawing.Size(139, 17);
            this.rbNew.TabIndex = 26;
            this.rbNew.TabStop = true;
            this.rbNew.Text = "Create New Data Model";
            this.rbNew.UseVisualStyleBackColor = true;
            this.rbNew.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // rbExisting
            // 
            this.rbExisting.AutoSize = true;
            this.rbExisting.Location = new System.Drawing.Point(15, 517);
            this.rbExisting.Name = "rbExisting";
            this.rbExisting.Size = new System.Drawing.Size(157, 17);
            this.rbExisting.TabIndex = 27;
            this.rbExisting.Text = "Update Existing Data Model";
            this.rbExisting.UseVisualStyleBackColor = true;
            this.rbExisting.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // FormLoadUml
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(784, 597);
            this.Controls.Add(this.rbExisting);
            this.Controls.Add(this.rbNew);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bRawData);
            this.Controls.Add(this.tbValidationReport);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLoadUml";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Load Uml";
            this.Shown += new System.EventHandler(this.FormShown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox tbValidationReport;
        private System.Windows.Forms.Button bRawData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbNew;
        private System.Windows.Forms.RadioButton rbExisting;
    }
}