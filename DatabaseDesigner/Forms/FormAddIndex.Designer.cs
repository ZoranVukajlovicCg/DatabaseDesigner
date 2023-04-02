namespace DatabaseDesigner.Forms
{
    partial class FormAddIndex
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddIndex));
            this.cbIsUnique = new System.Windows.Forms.CheckBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.lbFields = new System.Windows.Forms.ListBox();
            this.lbAllColumns = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bRemove = new System.Windows.Forms.Button();
            this.bAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbIsUnique
            // 
            this.cbIsUnique.AutoSize = true;
            this.cbIsUnique.Location = new System.Drawing.Point(12, 360);
            this.cbIsUnique.Name = "cbIsUnique";
            this.cbIsUnique.Size = new System.Drawing.Size(60, 17);
            this.cbIsUnique.TabIndex = 7;
            this.cbIsUnique.Text = "Unique";
            this.cbIsUnique.UseVisualStyleBackColor = true;
            this.cbIsUnique.CheckedChanged += new System.EventHandler(this.IsUniqueCheckedChanged);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(479, 393);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 20;
            this.BtnCancel.Text = "Discard";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(398, 393);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 19;
            this.btnOk.Text = "Accept";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.ButtonOkClick);
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.White;
            this.il.Images.SetKeyName(0, "plus-2x.png");
            this.il.Images.SetKeyName(1, "ban-2x.png");
            this.il.Images.SetKeyName(2, "arrow-thick-bottom-2x.png");
            this.il.Images.SetKeyName(3, "arrow-thick-top-2x.png");
            // 
            // lbFields
            // 
            this.lbFields.FormattingEnabled = true;
            this.lbFields.Location = new System.Drawing.Point(304, 90);
            this.lbFields.Name = "lbFields";
            this.lbFields.Size = new System.Drawing.Size(250, 264);
            this.lbFields.TabIndex = 26;
            // 
            // lbAllColumns
            // 
            this.lbAllColumns.FormattingEnabled = true;
            this.lbAllColumns.Location = new System.Drawing.Point(12, 90);
            this.lbAllColumns.Name = "lbAllColumns";
            this.lbAllColumns.Size = new System.Drawing.Size(250, 264);
            this.lbAllColumns.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "All Columns";
            // 
            // bRemove
            // 
            this.bRemove.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.bRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.bRemove.Image = global::DatabaseDesigner.Properties.Resources.account_logout_2x;
            this.bRemove.Location = new System.Drawing.Point(268, 119);
            this.bRemove.Name = "bRemove";
            this.bRemove.Size = new System.Drawing.Size(30, 23);
            this.bRemove.TabIndex = 30;
            this.bRemove.UseVisualStyleBackColor = true;
            this.bRemove.Click += new System.EventHandler(this.ButtonRemoveClick);
            // 
            // bAdd
            // 
            this.bAdd.Image = global::DatabaseDesigner.Properties.Resources.account_login_2x;
            this.bAdd.Location = new System.Drawing.Point(268, 90);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(30, 23);
            this.bAdd.TabIndex = 29;
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.ButtonAddClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Selected Columns";
            // 
            // labName
            // 
            this.labName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(211)))), ((int)(((byte)(182)))));
            this.labName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labName.Location = new System.Drawing.Point(12, 30);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(542, 23);
            this.labName.TabIndex = 32;
            this.labName.Text = "label3";
            this.labName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormAddIndex
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(567, 428);
            this.Controls.Add(this.labName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bRemove);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbAllColumns);
            this.Controls.Add(this.lbFields);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbIsUnique);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddIndex";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormAddIndex";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbIsUnique;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.ListBox lbFields;
        private System.Windows.Forms.ListBox lbAllColumns;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bRemove;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labName;
    }
}