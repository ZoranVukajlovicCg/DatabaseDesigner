namespace DatabaseDesigner.Forms
{
    partial class FormAddColumn
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDisplayName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDataType = new System.Windows.Forms.ComboBox();
            this.tbSize = new System.Windows.Forms.TextBox();
            this.labSize = new System.Windows.Forms.Label();
            this.tbPrecision = new System.Windows.Forms.TextBox();
            this.labPrecision = new System.Windows.Forms.Label();
            this.tbDefaultValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbIsNullable = new System.Windows.Forms.CheckBox();
            this.cbIsRequired = new System.Windows.Forms.CheckBox();
            this.cbIsSearchable = new System.Windows.Forms.CheckBox();
            this.cbIsFullTextSearch = new System.Windows.Forms.CheckBox();
            this.cbIsSystem = new System.Windows.Forms.CheckBox();
            this.cbAddToRepository = new System.Windows.Forms.CheckBox();
            this.cbIsReference = new System.Windows.Forms.CheckBox();
            this.tbRefField = new System.Windows.Forms.TextBox();
            this.labRefField = new System.Windows.Forms.Label();
            this.tbRefTable = new System.Windows.Forms.TextBox();
            this.labRefTable = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tbRefTableSchema = new System.Windows.Forms.TextBox();
            this.labRefTableSchema = new System.Windows.Forms.Label();
            this.cbIsConstraint = new System.Windows.Forms.CheckBox();
            this.tbDataType = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(12, 52);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(292, 20);
            this.tbName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // tbDisplayName
            // 
            this.tbDisplayName.Location = new System.Drawing.Point(12, 98);
            this.tbDisplayName.Name = "tbDisplayName";
            this.tbDisplayName.Size = new System.Drawing.Size(292, 20);
            this.tbDisplayName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Display Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Data Type";
            // 
            // cbDataType
            // 
            this.cbDataType.FormattingEnabled = true;
            this.cbDataType.Items.AddRange(new object[] {
            "string",
            "int",
            "bool",
            "DateTime",
            "Money",
            "decimal",
            "Date",
            "Time"});
            this.cbDataType.Location = new System.Drawing.Point(12, 331);
            this.cbDataType.Name = "cbDataType";
            this.cbDataType.Size = new System.Drawing.Size(292, 21);
            this.cbDataType.TabIndex = 2;
            this.cbDataType.SelectionChangeCommitted += new System.EventHandler(this.DataTypeSelectionChanged);
            // 
            // tbSize
            // 
            this.tbSize.Location = new System.Drawing.Point(12, 190);
            this.tbSize.Name = "tbSize";
            this.tbSize.Size = new System.Drawing.Size(132, 20);
            this.tbSize.TabIndex = 3;
            // 
            // labSize
            // 
            this.labSize.AutoSize = true;
            this.labSize.Location = new System.Drawing.Point(9, 174);
            this.labSize.Name = "labSize";
            this.labSize.Size = new System.Drawing.Size(27, 13);
            this.labSize.TabIndex = 9;
            this.labSize.Text = "Size";
            // 
            // tbPrecision
            // 
            this.tbPrecision.Location = new System.Drawing.Point(172, 190);
            this.tbPrecision.Name = "tbPrecision";
            this.tbPrecision.Size = new System.Drawing.Size(132, 20);
            this.tbPrecision.TabIndex = 4;
            // 
            // labPrecision
            // 
            this.labPrecision.AutoSize = true;
            this.labPrecision.Location = new System.Drawing.Point(169, 174);
            this.labPrecision.Name = "labPrecision";
            this.labPrecision.Size = new System.Drawing.Size(50, 13);
            this.labPrecision.TabIndex = 11;
            this.labPrecision.Text = "Precision";
            // 
            // tbDefaultValue
            // 
            this.tbDefaultValue.Location = new System.Drawing.Point(12, 236);
            this.tbDefaultValue.Name = "tbDefaultValue";
            this.tbDefaultValue.Size = new System.Drawing.Size(292, 20);
            this.tbDefaultValue.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Default Value";
            // 
            // cbIsNullable
            // 
            this.cbIsNullable.AutoSize = true;
            this.cbIsNullable.Location = new System.Drawing.Point(328, 55);
            this.cbIsNullable.Name = "cbIsNullable";
            this.cbIsNullable.Size = new System.Drawing.Size(64, 17);
            this.cbIsNullable.TabIndex = 7;
            this.cbIsNullable.Text = "Nullable";
            this.cbIsNullable.UseVisualStyleBackColor = true;
            this.cbIsNullable.CheckedChanged += new System.EventHandler(this.IsRequiredOrNullableCheckChanged);
            // 
            // cbIsRequired
            // 
            this.cbIsRequired.AutoSize = true;
            this.cbIsRequired.Location = new System.Drawing.Point(328, 100);
            this.cbIsRequired.Name = "cbIsRequired";
            this.cbIsRequired.Size = new System.Drawing.Size(69, 17);
            this.cbIsRequired.TabIndex = 8;
            this.cbIsRequired.Text = "Required";
            this.cbIsRequired.UseVisualStyleBackColor = true;
            this.cbIsRequired.CheckedChanged += new System.EventHandler(this.IsRequiredOrNullableCheckChanged);
            // 
            // cbIsSearchable
            // 
            this.cbIsSearchable.AutoSize = true;
            this.cbIsSearchable.Location = new System.Drawing.Point(328, 146);
            this.cbIsSearchable.Name = "cbIsSearchable";
            this.cbIsSearchable.Size = new System.Drawing.Size(80, 17);
            this.cbIsSearchable.TabIndex = 9;
            this.cbIsSearchable.Text = "Searchable";
            this.cbIsSearchable.UseVisualStyleBackColor = true;
            this.cbIsSearchable.CheckedChanged += new System.EventHandler(this.IsSearchableCheckedChanged);
            // 
            // cbIsFullTextSearch
            // 
            this.cbIsFullTextSearch.AutoSize = true;
            this.cbIsFullTextSearch.Location = new System.Drawing.Point(328, 193);
            this.cbIsFullTextSearch.Name = "cbIsFullTextSearch";
            this.cbIsFullTextSearch.Size = new System.Drawing.Size(103, 17);
            this.cbIsFullTextSearch.TabIndex = 10;
            this.cbIsFullTextSearch.Text = "Full Text Search";
            this.cbIsFullTextSearch.UseVisualStyleBackColor = true;
            this.cbIsFullTextSearch.Visible = false;
            // 
            // cbIsSystem
            // 
            this.cbIsSystem.AutoSize = true;
            this.cbIsSystem.Location = new System.Drawing.Point(328, 239);
            this.cbIsSystem.Name = "cbIsSystem";
            this.cbIsSystem.Size = new System.Drawing.Size(60, 17);
            this.cbIsSystem.TabIndex = 11;
            this.cbIsSystem.Text = "System";
            this.cbIsSystem.UseVisualStyleBackColor = true;
            // 
            // cbAddToRepository
            // 
            this.cbAddToRepository.AutoSize = true;
            this.cbAddToRepository.Location = new System.Drawing.Point(483, 278);
            this.cbAddToRepository.Name = "cbAddToRepository";
            this.cbAddToRepository.Size = new System.Drawing.Size(114, 17);
            this.cbAddToRepository.TabIndex = 17;
            this.cbAddToRepository.Text = "Add To Repository";
            this.cbAddToRepository.UseVisualStyleBackColor = true;
            // 
            // cbIsReference
            // 
            this.cbIsReference.AutoSize = true;
            this.cbIsReference.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(211)))), ((int)(((byte)(182)))));
            this.cbIsReference.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbIsReference.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbIsReference.Location = new System.Drawing.Point(483, 54);
            this.cbIsReference.Name = "cbIsReference";
            this.cbIsReference.Size = new System.Drawing.Size(82, 18);
            this.cbIsReference.TabIndex = 12;
            this.cbIsReference.Text = "Reference";
            this.cbIsReference.UseVisualStyleBackColor = true;
            this.cbIsReference.CheckedChanged += new System.EventHandler(this.IsReferenceCheckedChanged);
            // 
            // tbRefField
            // 
            this.tbRefField.Location = new System.Drawing.Point(483, 236);
            this.tbRefField.Name = "tbRefField";
            this.tbRefField.Size = new System.Drawing.Size(292, 20);
            this.tbRefField.TabIndex = 15;
            // 
            // labRefField
            // 
            this.labRefField.AutoSize = true;
            this.labRefField.Location = new System.Drawing.Point(480, 220);
            this.labRefField.Name = "labRefField";
            this.labRefField.Size = new System.Drawing.Size(82, 13);
            this.labRefField.TabIndex = 24;
            this.labRefField.Text = "Reference Field";
            // 
            // tbRefTable
            // 
            this.tbRefTable.Location = new System.Drawing.Point(483, 190);
            this.tbRefTable.Name = "tbRefTable";
            this.tbRefTable.Size = new System.Drawing.Size(292, 20);
            this.tbRefTable.TabIndex = 14;
            // 
            // labRefTable
            // 
            this.labRefTable.AutoSize = true;
            this.labRefTable.Location = new System.Drawing.Point(480, 174);
            this.labRefTable.Name = "labRefTable";
            this.labRefTable.Size = new System.Drawing.Size(87, 13);
            this.labRefTable.TabIndex = 22;
            this.labRefTable.Text = "Reference Table";
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(700, 374);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 20;
            this.BtnCancel.Text = "Discard";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(619, 374);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 19;
            this.btnOk.Text = "Accept";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.ButtonOkClick);
            // 
            // tbRefTableSchema
            // 
            this.tbRefTableSchema.Location = new System.Drawing.Point(483, 144);
            this.tbRefTableSchema.Name = "tbRefTableSchema";
            this.tbRefTableSchema.Size = new System.Drawing.Size(292, 20);
            this.tbRefTableSchema.TabIndex = 13;
            // 
            // labRefTableSchema
            // 
            this.labRefTableSchema.AutoSize = true;
            this.labRefTableSchema.Location = new System.Drawing.Point(480, 128);
            this.labRefTableSchema.Name = "labRefTableSchema";
            this.labRefTableSchema.Size = new System.Drawing.Size(129, 13);
            this.labRefTableSchema.TabIndex = 32;
            this.labRefTableSchema.Text = "Reference Table Schema";
            // 
            // cbIsConstraint
            // 
            this.cbIsConstraint.AutoSize = true;
            this.cbIsConstraint.Location = new System.Drawing.Point(483, 98);
            this.cbIsConstraint.Name = "cbIsConstraint";
            this.cbIsConstraint.Size = new System.Drawing.Size(73, 17);
            this.cbIsConstraint.TabIndex = 33;
            this.cbIsConstraint.Text = "Constraint";
            this.cbIsConstraint.UseVisualStyleBackColor = true;
            // 
            // tbDataType
            // 
            this.tbDataType.Location = new System.Drawing.Point(12, 144);
            this.tbDataType.Name = "tbDataType";
            this.tbDataType.Size = new System.Drawing.Size(292, 20);
            this.tbDataType.TabIndex = 34;
            // 
            // FormAddColumn
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(788, 403);
            this.Controls.Add(this.tbDataType);
            this.Controls.Add(this.cbIsConstraint);
            this.Controls.Add(this.tbRefTableSchema);
            this.Controls.Add(this.labRefTableSchema);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tbRefField);
            this.Controls.Add(this.labRefField);
            this.Controls.Add(this.tbRefTable);
            this.Controls.Add(this.labRefTable);
            this.Controls.Add(this.cbIsReference);
            this.Controls.Add(this.cbAddToRepository);
            this.Controls.Add(this.cbIsSystem);
            this.Controls.Add(this.cbIsFullTextSearch);
            this.Controls.Add(this.cbIsSearchable);
            this.Controls.Add(this.cbIsRequired);
            this.Controls.Add(this.cbIsNullable);
            this.Controls.Add(this.tbDefaultValue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbPrecision);
            this.Controls.Add(this.labPrecision);
            this.Controls.Add(this.tbSize);
            this.Controls.Add(this.labSize);
            this.Controls.Add(this.cbDataType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbDisplayName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddColumn";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Column";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDisplayName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbDataType;
        private System.Windows.Forms.TextBox tbSize;
        private System.Windows.Forms.Label labSize;
        private System.Windows.Forms.TextBox tbPrecision;
        private System.Windows.Forms.Label labPrecision;
        private System.Windows.Forms.TextBox tbDefaultValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbIsNullable;
        private System.Windows.Forms.CheckBox cbIsRequired;
        private System.Windows.Forms.CheckBox cbIsSearchable;
        private System.Windows.Forms.CheckBox cbIsFullTextSearch;
        private System.Windows.Forms.CheckBox cbIsSystem;
        private System.Windows.Forms.CheckBox cbAddToRepository;
        private System.Windows.Forms.CheckBox cbIsReference;
        private System.Windows.Forms.TextBox tbRefField;
        private System.Windows.Forms.Label labRefField;
        private System.Windows.Forms.TextBox tbRefTable;
        private System.Windows.Forms.Label labRefTable;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox tbRefTableSchema;
        private System.Windows.Forms.Label labRefTableSchema;
        private System.Windows.Forms.CheckBox cbIsConstraint;
        private System.Windows.Forms.TextBox tbDataType;
    }
}