namespace DatabaseDesigner.Forms
{
    partial class FormAddTable
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbEntityName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbParentTable = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbReferencePattern = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbEntityIconName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbAddToRepository = new System.Windows.Forms.CheckBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tbNamespace = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbIsAccessControlEnabled = new System.Windows.Forms.CheckBox();
            this.tbDisplayName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(12, 49);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(292, 20);
            this.tbName.TabIndex = 1;
            // 
            // tbEntityName
            // 
            this.tbEntityName.Location = new System.Drawing.Point(12, 135);
            this.tbEntityName.Name = "tbEntityName";
            this.tbEntityName.Size = new System.Drawing.Size(292, 20);
            this.tbEntityName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Entity Name";
            // 
            // tbParentTable
            // 
            this.tbParentTable.Location = new System.Drawing.Point(12, 221);
            this.tbParentTable.Name = "tbParentTable";
            this.tbParentTable.Size = new System.Drawing.Size(292, 20);
            this.tbParentTable.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Parent Table";
            // 
            // tbReferencePattern
            // 
            this.tbReferencePattern.Location = new System.Drawing.Point(12, 264);
            this.tbReferencePattern.Name = "tbReferencePattern";
            this.tbReferencePattern.Size = new System.Drawing.Size(292, 20);
            this.tbReferencePattern.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Reference Pattern";
            // 
            // tbEntityIconName
            // 
            this.tbEntityIconName.Location = new System.Drawing.Point(12, 307);
            this.tbEntityIconName.Name = "tbEntityIconName";
            this.tbEntityIconName.Size = new System.Drawing.Size(292, 20);
            this.tbEntityIconName.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Entity Icon Name";
            // 
            // cbAddToRepository
            // 
            this.cbAddToRepository.AutoSize = true;
            this.cbAddToRepository.Location = new System.Drawing.Point(12, 363);
            this.cbAddToRepository.Name = "cbAddToRepository";
            this.cbAddToRepository.Size = new System.Drawing.Size(114, 17);
            this.cbAddToRepository.TabIndex = 10;
            this.cbAddToRepository.Text = "Add To Repository";
            this.cbAddToRepository.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(229, 435);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 12;
            this.BtnCancel.Text = "Discard";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(148, 435);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Accept";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.ButtonOkClick);
            // 
            // tbNamespace
            // 
            this.tbNamespace.Location = new System.Drawing.Point(12, 92);
            this.tbNamespace.Name = "tbNamespace";
            this.tbNamespace.Size = new System.Drawing.Size(292, 20);
            this.tbNamespace.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Namespace";
            // 
            // cbIsAccessControlEnabled
            // 
            this.cbIsAccessControlEnabled.AutoSize = true;
            this.cbIsAccessControlEnabled.Location = new System.Drawing.Point(12, 341);
            this.cbIsAccessControlEnabled.Name = "cbIsAccessControlEnabled";
            this.cbIsAccessControlEnabled.Size = new System.Drawing.Size(150, 17);
            this.cbIsAccessControlEnabled.TabIndex = 9;
            this.cbIsAccessControlEnabled.Text = "Is Access Control Enabled";
            this.cbIsAccessControlEnabled.UseVisualStyleBackColor = true;
            // 
            // tbDisplayName
            // 
            this.tbDisplayName.Location = new System.Drawing.Point(12, 178);
            this.tbDisplayName.Name = "tbDisplayName";
            this.tbDisplayName.Size = new System.Drawing.Size(292, 20);
            this.tbDisplayName.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "DisplayName";
            // 
            // FormAddTable
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(316, 471);
            this.Controls.Add(this.tbDisplayName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbIsAccessControlEnabled);
            this.Controls.Add(this.tbNamespace);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbAddToRepository);
            this.Controls.Add(this.tbEntityIconName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbReferencePattern);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbParentTable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbEntityName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddTable";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Table";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbEntityName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbParentTable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbReferencePattern;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbEntityIconName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbAddToRepository;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox tbNamespace;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbIsAccessControlEnabled;
        private System.Windows.Forms.TextBox tbDisplayName;
        private System.Windows.Forms.Label label7;
    }
}