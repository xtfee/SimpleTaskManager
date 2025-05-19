using SimpleTaskManager.Data;
using SimpleTaskManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;

namespace SimpleTaskManager.Forms
{
    public partial class ManagementForm : Form
    {
        private readonly TaskManagerContext _context;
        private ErrorProvider errorProvider;

        public ManagementForm(TaskManagerContext context)
        {
            InitializeComponent();
            _context = context;
            errorProvider = new ErrorProvider();
            LoadCategories();
            LoadPriorities();
        }

        private void LoadCategories()
        {
            try
            {
                lstCategories.DataSource = null;
                lstCategories.DataSource = _context.Categories.OrderBy(c => c.Name).ToList();
                lstCategories.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd ładowania kategorii: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            errorProvider.SetError(txtCategoryName, "");
            string categoryName = txtCategoryName.Text.Trim();

            var newCategory = new Category { Name = categoryName };
            var validationContext = new ValidationContext(newCategory);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(newCategory, validationContext, validationResults, true))
            {
                string errors = string.Join("\n", validationResults.Select(r => r.ErrorMessage));
                errorProvider.SetError(txtCategoryName, errors);
                // MessageBox.Show($"Błędy walidacji:\n{errors}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string normalizedCategoryName = categoryName.ToLower();
            if (_context.Categories.Any(c => c.Name.ToLower() == normalizedCategoryName))
            {
                errorProvider.SetError(txtCategoryName, "Kategoria o tej nazwie już istnieje.");
                return;
            }

            try
            {
                _context.Categories.Add(newCategory);
                _context.SaveChanges();
                LoadCategories();
                txtCategoryName.Clear();
            }
            catch (DbUpdateException dbEx)
            {
                MessageBox.Show($"Błąd dodawania kategorii (baza danych): {dbEx.InnerException?.Message ?? dbEx.Message}", "Błąd Bazy Danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd dodawania kategorii: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (lstCategories.SelectedItem is Category selectedCategory)
            {
                try
                {
                    bool isInUse = _context.TaskItems.Any(t => t.CategoryId == selectedCategory.CategoryId);
                    if (isInUse)
                    {
                        MessageBox.Show("Nie można usunąć kategorii, ponieważ jest używana przez istniejące zadania.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (MessageBox.Show($"Czy na pewno chcesz usunąć kategorię '{selectedCategory.Name}'?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        _context.Categories.Remove(selectedCategory);
                        _context.SaveChanges();
                        LoadCategories();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd usuwania kategorii: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadPriorities()
        {
            try
            {
                lstPriorities.DataSource = null;
                lstPriorities.DataSource = _context.Priorities.OrderBy(p => p.Name).ToList();
                lstPriorities.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd ładowania priorytetów: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddPriority_Click(object sender, EventArgs e)
        {
            errorProvider.SetError(txtPriorityName, "");
            errorProvider.SetError(txtPriorityColor, "");
            string priorityName = txtPriorityName.Text.Trim();
            string priorityColor = txtPriorityColor.Text.Trim();

            var newPriority = new Priority { Name = priorityName, ColorCode = string.IsNullOrWhiteSpace(priorityColor) ? null : priorityColor };
            var validationContext = new ValidationContext(newPriority);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(newPriority, validationContext, validationResults, true))
            {
                foreach (var validationResult in validationResults)
                {
                    if (validationResult.MemberNames.Contains("Name"))
                        errorProvider.SetError(txtPriorityName, validationResult.ErrorMessage);
                    if (validationResult.MemberNames.Contains("ColorCode"))
                        errorProvider.SetError(txtPriorityColor, validationResult.ErrorMessage);
                }
                // string errors = string.Join("\n", validationResults.Select(r => r.ErrorMessage));
                // MessageBox.Show($"Błędy walidacji:\n{errors}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string normalizedPriorityName = priorityName.ToLower();
            if (_context.Priorities.Any(p => p.Name.ToLower() == normalizedPriorityName))
            {
                errorProvider.SetError(txtPriorityName, "Priorytet o tej nazwie już istnieje.");
                return;
            }

            try
            {
                _context.Priorities.Add(newPriority);
                _context.SaveChanges();
                LoadPriorities();
                txtPriorityName.Clear();
                txtPriorityColor.Clear();
            }
            catch (DbUpdateException dbEx)
            {
                MessageBox.Show($"Błąd dodawania priorytetu (baza danych): {dbEx.InnerException?.Message ?? dbEx.Message}", "Błąd Bazy Danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd dodawania priorytetu: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletePriority_Click(object sender, EventArgs e)
        {
            if (lstPriorities.SelectedItem is Priority selectedPriority)
            {
                try
                {
                    bool isInUse = _context.TaskItems.Any(t => t.PriorityId == selectedPriority.PriorityId);
                    if (isInUse)
                    {
                        MessageBox.Show("Nie można usunąć priorytetu, ponieważ jest używany przez istniejące zadania.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (MessageBox.Show($"Czy na pewno chcesz usunąć priorytet '{selectedPriority.Name}'?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        _context.Priorities.Remove(selectedPriority);
                        _context.SaveChanges();
                        LoadPriorities();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd usuwania priorytetu: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}