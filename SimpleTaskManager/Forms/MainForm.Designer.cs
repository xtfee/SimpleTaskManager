namespace SimpleTaskManager.Forms
{
    partial class MainForm
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
            dataGridViewTasks = new DataGridView();
            btnAddTask = new Button();
            btnEditTask = new Button();
            btnDeleteTask = new Button();
            btnManageCategoriesPriorities = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTasks).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewTasks
            // 
            dataGridViewTasks.AllowUserToAddRows = false;
            dataGridViewTasks.AllowUserToDeleteRows = false;
            dataGridViewTasks.AllowUserToResizeRows = false;
            dataGridViewTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTasks.Dock = DockStyle.Top;
            dataGridViewTasks.Location = new Point(0, 0);
            dataGridViewTasks.MultiSelect = false;
            dataGridViewTasks.Name = "dataGridViewTasks";
            dataGridViewTasks.ReadOnly = true;
            dataGridViewTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTasks.Size = new Size(800, 313);
            dataGridViewTasks.TabIndex = 0;
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(12, 328);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(120, 30);
            btnAddTask.TabIndex = 1;
            btnAddTask.Text = "Dodaj zadanie";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // btnEditTask
            // 
            btnEditTask.Location = new Point(138, 328);
            btnEditTask.Name = "btnEditTask";
            btnEditTask.Size = new Size(120, 30);
            btnEditTask.TabIndex = 2;
            btnEditTask.Text = "Edytuj zadanie";
            btnEditTask.UseVisualStyleBackColor = true;
            btnEditTask.Click += btnEditTask_Click;
            // 
            // btnDeleteTask
            // 
            btnDeleteTask.Location = new Point(264, 328);
            btnDeleteTask.Name = "btnDeleteTask";
            btnDeleteTask.Size = new Size(120, 30);
            btnDeleteTask.TabIndex = 3;
            btnDeleteTask.Text = "Usuń zadanie";
            btnDeleteTask.UseVisualStyleBackColor = true;
            btnDeleteTask.Click += btnDeleteTask_Click;
            // 
            // btnManageCategoriesPriorities
            // 
            btnManageCategoriesPriorities.Location = new Point(658, 328);
            btnManageCategoriesPriorities.Name = "btnManageCategoriesPriorities";
            btnManageCategoriesPriorities.Size = new Size(130, 30);
            btnManageCategoriesPriorities.TabIndex = 4;
            btnManageCategoriesPriorities.Text = "Zarządzaj Kat./Prioryt.";
            btnManageCategoriesPriorities.UseVisualStyleBackColor = true;
            btnManageCategoriesPriorities.Click += btnManageCategoriesPriorities_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 408);
            Controls.Add(btnManageCategoriesPriorities);
            Controls.Add(btnDeleteTask);
            Controls.Add(btnEditTask);
            Controls.Add(btnAddTask);
            Controls.Add(dataGridViewTasks);
            Name = "MainForm";
            Text = "MainForm";
            FormClosing += MainForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTasks).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewTasks;
        private Button btnAddTask;
        private Button btnEditTask;
        private Button btnDeleteTask;
        private Button btnManageCategoriesPriorities;
    }
}