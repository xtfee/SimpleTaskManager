namespace SimpleTaskManager.Forms
{
    partial class ManagementForm
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
            grpCategories = new GroupBox();
            btnDeleteCategory = new Button();
            lstCategories = new ListBox();
            btnAddCategory = new Button();
            txtCategoryName = new TextBox();
            lblCategoryName = new Label();
            grpPriorities = new GroupBox();
            btnDeletePriority = new Button();
            lstPriorities = new ListBox();
            btnAddPriority = new Button();
            txtPriorityColor = new TextBox();
            lblPriorityColor = new Label();
            txtPriorityName = new TextBox();
            lblPriorityName = new Label();
            btnClose = new Button();
            grpCategories.SuspendLayout();
            grpPriorities.SuspendLayout();
            SuspendLayout();
            // 
            // grpCategories
            // 
            grpCategories.Controls.Add(btnDeleteCategory);
            grpCategories.Controls.Add(lstCategories);
            grpCategories.Controls.Add(btnAddCategory);
            grpCategories.Controls.Add(txtCategoryName);
            grpCategories.Controls.Add(lblCategoryName);
            grpCategories.Location = new Point(12, 12);
            grpCategories.Name = "grpCategories";
            grpCategories.Size = new Size(389, 235);
            grpCategories.TabIndex = 0;
            grpCategories.TabStop = false;
            grpCategories.Text = "Kategorie";
            // 
            // btnDeleteCategory
            // 
            btnDeleteCategory.Location = new Point(106, 174);
            btnDeleteCategory.Name = "btnDeleteCategory";
            btnDeleteCategory.Size = new Size(110, 23);
            btnDeleteCategory.TabIndex = 4;
            btnDeleteCategory.Text = "Usuń zaznaczoną";
            btnDeleteCategory.UseVisualStyleBackColor = true;
            btnDeleteCategory.Click += btnDeleteCategory_Click;
            // 
            // lstCategories
            // 
            lstCategories.FormattingEnabled = true;
            lstCategories.ItemHeight = 15;
            lstCategories.Location = new Point(106, 74);
            lstCategories.Name = "lstCategories";
            lstCategories.Size = new Size(200, 94);
            lstCategories.TabIndex = 3;
            // 
            // btnAddCategory
            // 
            btnAddCategory.Location = new Point(106, 45);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(75, 23);
            btnAddCategory.TabIndex = 2;
            btnAddCategory.Text = "Dodaj";
            btnAddCategory.UseVisualStyleBackColor = true;
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(106, 16);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(200, 23);
            txtCategoryName.TabIndex = 1;
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(6, 19);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(94, 15);
            lblCategoryName.TabIndex = 0;
            lblCategoryName.Text = "Nazwa kategorii:";
            // 
            // grpPriorities
            // 
            grpPriorities.Controls.Add(btnDeletePriority);
            grpPriorities.Controls.Add(lstPriorities);
            grpPriorities.Controls.Add(btnAddPriority);
            grpPriorities.Controls.Add(txtPriorityColor);
            grpPriorities.Controls.Add(lblPriorityColor);
            grpPriorities.Controls.Add(txtPriorityName);
            grpPriorities.Controls.Add(lblPriorityName);
            grpPriorities.Location = new Point(407, 12);
            grpPriorities.Name = "grpPriorities";
            grpPriorities.Size = new Size(381, 235);
            grpPriorities.TabIndex = 1;
            grpPriorities.TabStop = false;
            grpPriorities.Text = "Priorytety";
            // 
            // btnDeletePriority
            // 
            btnDeletePriority.Location = new Point(132, 174);
            btnDeletePriority.Name = "btnDeletePriority";
            btnDeletePriority.Size = new Size(105, 23);
            btnDeletePriority.TabIndex = 6;
            btnDeletePriority.Text = "Usuń zaznaczony";
            btnDeletePriority.UseVisualStyleBackColor = true;
            btnDeletePriority.Click += btnDeletePriority_Click;
            // 
            // lstPriorities
            // 
            lstPriorities.FormattingEnabled = true;
            lstPriorities.ItemHeight = 15;
            lstPriorities.Location = new Point(132, 74);
            lstPriorities.Name = "lstPriorities";
            lstPriorities.Size = new Size(200, 94);
            lstPriorities.TabIndex = 5;
            // 
            // btnAddPriority
            // 
            btnAddPriority.Location = new Point(40, 124);
            btnAddPriority.Name = "btnAddPriority";
            btnAddPriority.Size = new Size(75, 23);
            btnAddPriority.TabIndex = 4;
            btnAddPriority.Text = "Dodaj";
            btnAddPriority.UseVisualStyleBackColor = true;
            btnAddPriority.Click += btnAddPriority_Click;
            // 
            // txtPriorityColor
            // 
            txtPriorityColor.Location = new Point(132, 45);
            txtPriorityColor.Name = "txtPriorityColor";
            txtPriorityColor.Size = new Size(200, 23);
            txtPriorityColor.TabIndex = 3;
            // 
            // lblPriorityColor
            // 
            lblPriorityColor.AutoSize = true;
            lblPriorityColor.Location = new Point(6, 49);
            lblPriorityColor.Name = "lblPriorityColor";
            lblPriorityColor.Size = new Size(120, 15);
            lblPriorityColor.TabIndex = 2;
            lblPriorityColor.Text = "Kolor (np. #RRGGBB):";
            // 
            // txtPriorityName
            // 
            txtPriorityName.Location = new Point(132, 16);
            txtPriorityName.Name = "txtPriorityName";
            txtPriorityName.Size = new Size(200, 23);
            txtPriorityName.TabIndex = 1;
            // 
            // lblPriorityName
            // 
            lblPriorityName.AutoSize = true;
            lblPriorityName.Location = new Point(6, 19);
            lblPriorityName.Name = "lblPriorityName";
            lblPriorityName.Size = new Size(100, 15);
            lblPriorityName.TabIndex = 0;
            lblPriorityName.Text = "Nazwa priorytetu:";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(366, 253);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 2;
            btnClose.Text = "Zamknij";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // ManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 301);
            Controls.Add(btnClose);
            Controls.Add(grpPriorities);
            Controls.Add(grpCategories);
            Name = "ManagementForm";
            Text = "ManagementForm";
            grpCategories.ResumeLayout(false);
            grpCategories.PerformLayout();
            grpPriorities.ResumeLayout(false);
            grpPriorities.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpCategories;
        private Button btnDeleteCategory;
        private ListBox lstCategories;
        private Button btnAddCategory;
        private TextBox txtCategoryName;
        private Label lblCategoryName;
        private GroupBox grpPriorities;
        private TextBox txtPriorityColor;
        private Label lblPriorityColor;
        private TextBox txtPriorityName;
        private Label lblPriorityName;
        private Button btnDeletePriority;
        private ListBox lstPriorities;
        private Button btnAddPriority;
        private Button btnClose;
    }
}