using SimpleTaskManager.Data;
using Microsoft.EntityFrameworkCore; // Dla Include i AsNoTracking
using System;
using System.Linq;
using System.Windows.Forms;

namespace SimpleTaskManager.Forms
{
    public partial class MainForm : Form
    {
        private TaskManagerContext _context;

        public MainForm()
        {
            InitializeComponent(); // Ta linia jest generowana przez projektanta
            _context = new TaskManagerContext();
            try
            {
                // Update-Database powinno już utworzyć bazę.
                // EnsureCreated można użyć, ale może kolidować z migracjami, jeśli baza już istnieje.
                // _context.Database.EnsureCreated(); 
                // Sprawdzenie połączenia jest lepsze.
                if (!_context.Database.CanConnect())
                {
                    MessageBox.Show("Nie można połączyć się z bazą danych. Sprawdź konfigurację.", "Błąd Bazy Danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Można rozważyć zamknięcie aplikacji
                    // Environment.Exit(1); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Nie można połączyć się z bazą danych lub ją utworzyć: {ex.Message}\nSprawdź konfigurację i plik bazy danych.", "Błąd Bazy Danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadTasks();
        }

        private void LoadTasks()
        {
            try
            {
                var tasks = _context.TaskItems
                                    .Include(t => t.Category)
                                    .Include(t => t.Priority)
                                    .AsNoTracking()
                                    .ToList();

                dataGridViewTasks.DataSource = tasks.Select(t => new {
                    Id = t.TaskItemId,
                    t.Title,
                    Category = t.Category?.Name,
                    Priority = t.Priority?.Name,
                    DueDate = t.DueDate,
                    IsCompleted = t.IsCompleted
                }).ToList();

                if (dataGridViewTasks.Columns["Id"] != null)
                    dataGridViewTasks.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd ładowania zadań: {ex.Message}\n{ex.InnerException?.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            using (var taskForm = new TaskForm(_context))
            {
                if (taskForm.ShowDialog() == DialogResult.OK)
                {
                    LoadTasks();
                }
            }
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.SelectedRows.Count > 0)
            {
                var selectedRowCell = dataGridViewTasks.SelectedRows[0].Cells["Id"];
                if (selectedRowCell != null && selectedRowCell.Value != null)
                {
                    int taskId = (int)selectedRowCell.Value;
                    var taskToEdit = _context.TaskItems
                                             .Include(t => t.Category)
                                             .Include(t => t.Priority)
                                             .FirstOrDefault(t => t.TaskItemId == taskId);

                    if (taskToEdit != null)
                    {
                        using (var taskForm = new TaskForm(_context, taskToEdit))
                        {
                            if (taskForm.ShowDialog() == DialogResult.OK)
                            {
                                LoadTasks();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nie znaleziono zadania w bazie danych.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoadTasks();
                    }
                }
                else
                {
                    MessageBox.Show("Nie można pobrać ID wybranego zadania (komórka 'Id' jest pusta lub nie istnieje).", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Proszę wybrać zadanie do edycji.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Czy na pewno chcesz usunąć wybrane zadanie?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var selectedRowCell = dataGridViewTasks.SelectedRows[0].Cells["Id"];
                    if (selectedRowCell != null && selectedRowCell.Value != null)
                    {
                        int taskId = (int)selectedRowCell.Value;
                        var taskToDelete = _context.TaskItems.Find(taskId);
                        if (taskToDelete != null)
                        {
                            try
                            {
                                _context.TaskItems.Remove(taskToDelete);
                                _context.SaveChanges();
                                LoadTasks();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Błąd usuwania zadania: {ex.Message}\n{ex.InnerException?.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nie można pobrać ID wybranego zadania do usunięcia.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Proszę wybrać zadanie do usunięcia.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnManageCategoriesPriorities_Click(object sender, EventArgs e)
        {
            using (var mgmtForm = new ManagementForm(_context))
            {
                mgmtForm.ShowDialog();
                // Po zamknięciu ManagementForm, odświeżenie może być potrzebne,
                // jeśli TaskForm używa tych danych (ładuje je na nowo przy każdym otwarciu).
                // LoadTasks(); // Bezpośrednie odświeżenie głównej listy może nie być konieczne,
                // ale nie zaszkodzi, jeśli kategorie/priorytety są tam wyświetlane.
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context?.Dispose();
        }
    }
}