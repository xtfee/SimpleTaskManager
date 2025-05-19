namespace SimpleTaskManager.Forms
{
    partial class TaskForm
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
            lblTitle = new Label();
            txtTitle = new TextBox();
            txtDescription = new TextBox();
            lblDescription = new Label();
            lblDueDate = new Label();
            dtpDueDate = new DateTimePicker();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            lblPriority = new Label();
            cmbPriority = new ComboBox();
            chkIsCompleted = new CheckBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(12, 43);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(35, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Tytuł:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(119, 35);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(250, 23);
            txtTitle.TabIndex = 1;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(119, 151);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(250, 100);
            txtDescription.TabIndex = 2;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(12, 154);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(34, 15);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "Opis:";
            // 
            // lblDueDate
            // 
            lblDueDate.AutoSize = true;
            lblDueDate.Location = new Point(12, 70);
            lblDueDate.Name = "lblDueDate";
            lblDueDate.Size = new Size(94, 15);
            lblDueDate.TabIndex = 4;
            lblDueDate.Text = "Data wykonania:";
            // 
            // dtpDueDate
            // 
            dtpDueDate.Format = DateTimePickerFormat.Short;
            dtpDueDate.Location = new Point(119, 64);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.ShowCheckBox = true;
            dtpDueDate.Size = new Size(250, 23);
            dtpDueDate.TabIndex = 5;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(12, 96);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(60, 15);
            lblCategory.TabIndex = 6;
            lblCategory.Text = "Kategoria:";
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(119, 93);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(250, 23);
            cmbCategory.TabIndex = 7;
            // 
            // lblPriority
            // 
            lblPriority.AutoSize = true;
            lblPriority.Location = new Point(12, 125);
            lblPriority.Name = "lblPriority";
            lblPriority.Size = new Size(55, 15);
            lblPriority.TabIndex = 8;
            lblPriority.Text = "Priorytet:";
            // 
            // cmbPriority
            // 
            cmbPriority.FormattingEnabled = true;
            cmbPriority.Location = new Point(119, 122);
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Size = new Size(250, 23);
            cmbPriority.TabIndex = 9;
            // 
            // chkIsCompleted
            // 
            chkIsCompleted.AutoSize = true;
            chkIsCompleted.Location = new Point(119, 257);
            chkIsCompleted.Name = "chkIsCompleted";
            chkIsCompleted.Size = new Size(85, 19);
            chkIsCompleted.TabIndex = 10;
            chkIsCompleted.Text = "Ukończone";
            chkIsCompleted.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(31, 282);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 11;
            btnSave.Text = "Zapisz";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(119, 282);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Anuluj";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // TaskForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(390, 344);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(chkIsCompleted);
            Controls.Add(cmbPriority);
            Controls.Add(lblPriority);
            Controls.Add(cmbCategory);
            Controls.Add(lblCategory);
            Controls.Add(dtpDueDate);
            Controls.Add(lblDueDate);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(txtTitle);
            Controls.Add(lblTitle);
            Name = "TaskForm";
            Text = "TaskForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private TextBox txtTitle;
        private TextBox txtDescription;
        private Label lblDescription;
        private Label lblDueDate;
        private DateTimePicker dtpDueDate;
        private Label lblCategory;
        private ComboBox cmbCategory;
        private Label lblPriority;
        private ComboBox cmbPriority;
        private CheckBox chkIsCompleted;
        private Button btnSave;
        private Button btnCancel;
    }
}