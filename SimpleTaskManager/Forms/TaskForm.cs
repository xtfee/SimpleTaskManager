using SimpleTaskManager.Data;
using SimpleTaskManager.Data.Models;
using Microsoft.EntityFrameworkCore; // Dla DbUpdateException
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;

namespace SimpleTaskManager.Forms
{
    public partial class TaskForm : Form
    {
        private readonly TaskManagerContext _context;
        private TaskItem _taskItem;
        private ErrorProvider errorProvider;

        public TaskForm(TaskManagerContext context, TaskItem taskItemToEdit = null)
        {
            InitializeComponent();
            _context = context;
            errorProvider = new ErrorProvider();

            if (taskItemToEdit == null)
            {
                _taskItem = new TaskItem { CreationDate = DateTime.Now };
                this.Text = "Dodaj nowe zadanie";
            }
            else
            {
                _taskItem = taskItemToEdit;
                this.Text = "Edytuj zadanie";
            }

            InitializeControlsData();
            if (taskItemToEdit != null)
            {
                PopulateFormFields();
            }
        }

        private void InitializeControlsData()
        {
            try
            {
                cmbCategory.DataSource = _context.Categories.OrderBy(c => c.Name).ToList();
                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "CategoryId";
                cmbCategory.SelectedItem = null;

                cmbPriority.DataSource = _context.Priorities.OrderBy(p => p.Name).ToList();
                cmbPriority.DisplayMember = "Name";
                cmbPriority.ValueMember = "PriorityId";
                cmbPriority.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd ładowania kategorii/priorytetów: {ex.Message}", "Błąd danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dtpDueDate.Format = DateTimePickerFormat.Short;
            dtpDueDate.ShowCheckBox = true;
            dtpDueDate.Checked = false;
        }

        private void PopulateFormFields()
        {
            txtTitle.Text = _taskItem.Title;
            txtDescription.Text = _taskItem.Description;
            chkIsCompleted.Checked = _taskItem.IsCompleted;

            if (_taskItem.DueDate.HasValue)
            {
                // Upewnij się, że wartość nie jest poza zakresem MinDate/MaxDate DateTimePicker
                if (_taskItem.DueDate.Value >= dtpDueDate.MinDate && _taskItem.DueDate.Value <= dtpDueDate.MaxDate)
                {
                    dtpDueDate.Value = _taskItem.DueDate.Value;
                }
                else
                {
                    // Jeśli data jest poza zakresem, ustaw na najbliższą możliwą lub zostaw nieustawioną
                    dtpDueDate.Value = DateTime.Now; // lub dtpDueDate.MinDate / dtpDueDate.MaxDate
                    System.Diagnostics.Debug.WriteLine($"Uwaga: Data {_taskItem.DueDate.Value} jest poza zakresem DateTimePicker.");
                }
                dtpDueDate.Checked = true;
            }
            else
            {
                dtpDueDate.Checked = false;
            }

            if (_taskItem.CategoryId.HasValue)
                cmbCategory.SelectedValue = _taskItem.CategoryId.Value;
            else
                cmbCategory.SelectedIndex = -1;

            if (_taskItem.PriorityId.HasValue)
                cmbPriority.SelectedValue = _taskItem.PriorityId.Value;
            else
                cmbPriority.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            _taskItem.Title = txtTitle.Text;
            _taskItem.Description = txtDescription.Text;
            _taskItem.IsCompleted = chkIsCompleted.Checked;

            if (dtpDueDate.Checked)
            {
                _taskItem.DueDate = dtpDueDate.Value.Date;
                if (!_taskItem.IsCompleted && _taskItem.DueDate.Value < DateTime.Now.Date)
                {
                    errorProvider.SetError(dtpDueDate, "Data wykonania nie może być z przeszłości dla nieukończonego zadania.");
                }
            }
            else
            {
                _taskItem.DueDate = null;
            }

            _taskItem.CategoryId = (int?)cmbCategory.SelectedValue;
            _taskItem.PriorityId = (int?)cmbPriority.SelectedValue;

            var validationContext = new ValidationContext(_taskItem, null, null);
            var validationResults = new List<ValidationResult>();
            bool isModelValid = Validator.TryValidateObject(_taskItem, validationContext, validationResults, true);

            bool customValidationPassed = true;
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                errorProvider.SetError(txtTitle, "Tytuł jest wymagany.");
                customValidationPassed = false;
            }

            bool noProviderErrors = !Controls.OfType<Control>().Any(c => !string.IsNullOrEmpty(errorProvider.GetError(c)));


            if (isModelValid && customValidationPassed && noProviderErrors)
            {
                try
                {
                    if (_taskItem.TaskItemId == 0)
                    {
                        _context.TaskItems.Add(_taskItem);
                    }
                    else
                    {
                        _context.TaskItems.Update(_taskItem);
                    }
                    _context.SaveChanges();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (DbUpdateException dbEx)
                {
                    var innerEx = dbEx.InnerException;
                    MessageBox.Show($"Błąd zapisu do bazy danych: {dbEx.Message}\nSzczegóły: {innerEx?.Message}", "Błąd Bazy Danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił nieoczekiwany błąd zapisu: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (validationResults.Any())
            {
                string attrErrors = string.Join("\n", validationResults.Select(r => r.ErrorMessage));
                MessageBox.Show($"Proszę poprawić następujące błędy:\n{attrErrors}", "Błąd Walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}