// Plik: MainForm.cs
using SimpleTaskManager;
using SimpleTaskManager.Modele;
using SimpleTaskManager.Modele;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SimpleTaskManager
{
    public partial class MainForm : Form
    {
        private readonly DataService dataService;
        private int? edytowaneZadanieId = null;

        public MainForm()
        {
            InitializeComponent();
            dataService = new DataService();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dtpTermin.ShowCheckBox = true;
            dtpTermin.Checked = false;

            ZaladujKategorieDoGlownegoComboBoxa();     // ComboBox do przypisywania zadań
            ZaladujKategorieDoComboboxaUsuwania(); // ComboBox do zarządzania/usuwania kategorii
            ZaladujZadaniaDoListView();
            PrzelaczTrybEdycji(false);
        }

        // Ładuje kategorie do ComboBoxa używanego przy dodawaniu/edycji zadań
        private void ZaladujKategorieDoGlownegoComboBoxa()
        {
            var kategorie = dataService.GetCategories();
            object poprzednioWybranaWartosc = cmbKategorieZadania.SelectedValue;

            cmbKategorieZadania.DataSource = null;
            cmbKategorieZadania.DisplayMember = "Nazwa";
            cmbKategorieZadania.ValueMember = "Id";
            cmbKategorieZadania.DataSource = kategorie;

            if (kategorie != null && kategorie.Any())
            {
                if (poprzednioWybranaWartosc != null && kategorie.Any(k => k.Id.Equals(poprzednioWybranaWartosc)))
                {
                    cmbKategorieZadania.SelectedValue = poprzednioWybranaWartosc;
                }
                else
                {
                    cmbKategorieZadania.SelectedIndex = 0;
                }
            }
            else
            {
                cmbKategorieZadania.SelectedIndex = -1;
            }
        }

        // Ładuje kategorie do ComboBoxa służącego do wyboru kategorii do usunięcia
        private void ZaladujKategorieDoComboboxaUsuwania()
        {
            var kategorie = dataService.GetCategories();
            object poprzednioWybranaWartosc = cmbKategorieDoUsuniecia.SelectedValue;

            cmbKategorieDoUsuniecia.DataSource = null;
            cmbKategorieDoUsuniecia.DisplayMember = "Nazwa";
            cmbKategorieDoUsuniecia.ValueMember = "Id";
            cmbKategorieDoUsuniecia.DataSource = kategorie;

            if (kategorie != null && kategorie.Any())
            {
                if (poprzednioWybranaWartosc != null && kategorie.Any(k => k.Id.Equals(poprzednioWybranaWartosc)))
                {
                    cmbKategorieDoUsuniecia.SelectedValue = poprzednioWybranaWartosc;
                }
                else
                {
                    cmbKategorieDoUsuniecia.SelectedIndex = 0;
                }
            }
            else
            {
                cmbKategorieDoUsuniecia.SelectedIndex = -1;
            }
        }


        private void ZaladujZadaniaDoListView()
        {
            lstZadania.Items.Clear();
            var zadania = dataService.GetTasks();

            foreach (var zadanie in zadania)
            {
                var item = new ListViewItem(zadanie.CzyWykonane ? "✓" : "");
                item.SubItems.Add(zadanie.Opis);
                item.SubItems.Add(zadanie.DataZakonczenia.HasValue ? zadanie.DataZakonczenia.Value.ToString("yyyy-MM-dd") : "Brak");
                item.SubItems.Add(zadanie.Kategoria?.Nazwa ?? "N/A");
                item.SubItems.Add(zadanie.DataUtworzenia.ToString("yyyy-MM-dd HH:mm"));
                item.SubItems.Add(zadanie.Id.ToString());
                item.Tag = zadanie.Id;

                if (zadanie.CzyWykonane)
                {
                    item.ForeColor = Color.Gray;
                    item.Font = new Font(lstZadania.Font, FontStyle.Strikeout);
                }
                lstZadania.Items.Add(item);
            }
        }

        private void btnDodajKategorie_Click(object sender, EventArgs e)
        {
            string nazwaNowejKategorii = txtNowaKategoria.Text.Trim();
            if (string.IsNullOrWhiteSpace(nazwaNowejKategorii))
            {
                MessageBox.Show("Nazwa kategorii nie może być pusta.", "Walidacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNowaKategoria.Focus();
                return;
            }

            if (dataService.AddCategory(nazwaNowejKategorii)) // Komunikat o sukcesie/błędzie jest już w DataService
            {
                txtNowaKategoria.Clear();
                ZaladujKategorieDoGlownegoComboBoxa();
                ZaladujKategorieDoComboboxaUsuwania();
            }
        }

        // UWAGA: Upewnij się, że przycisk usuwania kategorii w projektancie jest podpięty do tej metody!
        private void btnUsunWybranaKategorie_Click(object sender, EventArgs e)
        {
            if (cmbKategorieDoUsuniecia.SelectedIndex == -1)
            {
                MessageBox.Show("Wybierz kategorię z listy rozwijalnej, którą chcesz usunąć.", "Brak zaznaczenia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!(cmbKategorieDoUsuniecia.SelectedValue is int kategoriaId))
            {
                MessageBox.Show("Nie udało się odczytać ID wybranej kategorii z listy rozwijalnej.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nazwaKategorii = (cmbKategorieDoUsuniecia.SelectedItem as Kategoria)?.Nazwa ?? "wybraną kategorię";

            var potwierdzenie = MessageBox.Show($"Czy na pewno chcesz usunąć kategorię: '{nazwaKategorii}'?",
                                               "Potwierdzenie usunięcia",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Warning);

            if (potwierdzenie == DialogResult.Yes)
            {
                var wynik = dataService.DeleteCategory(kategoriaId);

                MessageBox.Show(wynik.Message,
                                wynik.Success ? "Sukces" : "Operacja nieudana",
                                MessageBoxButtons.OK,
                                wynik.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                if (wynik.Success)
                {
                    ZaladujKategorieDoGlownegoComboBoxa();
                    ZaladujKategorieDoComboboxaUsuwania();
                    ZaladujZadaniaDoListView(); // Odśwież zadania, na wszelki wypadek
                }
            }
        }


        private void btnDodajZapiszZadanie_Click(object sender, EventArgs e)
        {
            string opis = txtOpis.Text.Trim();
            if (string.IsNullOrWhiteSpace(opis))
            {
                MessageBox.Show("Opis zadania nie może być pusty.", "Walidacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOpis.Focus();
                return;
            }

            if (cmbKategorieZadania.SelectedIndex == -1)
            {
                MessageBox.Show("Wybierz kategorię dla zadania. Jeśli lista jest pusta, najpierw dodaj kategorię.", "Walidacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbKategorieZadania.Focus();
                return;
            }

            if (!(cmbKategorieZadania.SelectedValue is int kategoriaId))
            {
                MessageBox.Show("Wystąpił problem z odczytaniem ID wybranej kategorii dla zadania.", "Błąd wewnętrzny", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime? termin = dtpTermin.Checked ? dtpTermin.Value.Date : (DateTime?)null;
            bool czyWykonaneBiezace = chkCzyWykonane.Checked;

            bool sukces;
            string komunikatSukcesu;

            if (edytowaneZadanieId.HasValue)
            {
                sukces = dataService.UpdateTask(edytowaneZadanieId.Value, opis, termin, kategoriaId, czyWykonaneBiezace);
                komunikatSukcesu = "Zadanie zaktualizowane pomyślnie.";
            }
            else
            {
                sukces = dataService.AddTask(opis, termin, kategoriaId);
                komunikatSukcesu = "Zadanie dodane pomyślnie.";
            }

            if (sukces)
            {
                MessageBox.Show(komunikatSukcesu, "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                WyczyscPolaFormularzaZadania();
                ZaladujZadaniaDoListView();
                PrzelaczTrybEdycji(false);
            }
        }

        private void PrzelaczTrybEdycji(bool trybEdycji, int? taskId = null)
        {
            edytowaneZadanieId = trybEdycji ? taskId : null;
            btnDodajZapiszZadanie.Text = trybEdycji ? "Zapisz zmiany" : "Dodaj zadanie";
            chkCzyWykonane.Enabled = trybEdycji;
            if (!trybEdycji)
            {
                chkCzyWykonane.Checked = false;
            }
        }

        private void WyczyscPolaFormularzaZadania()
        {
            txtOpis.Clear();
            if (cmbKategorieZadania.Items.Count > 0)
                cmbKategorieZadania.SelectedIndex = 0;
            else
                cmbKategorieZadania.SelectedIndex = -1;

            dtpTermin.Checked = false;
            dtpTermin.Value = DateTime.Now;
            chkCzyWykonane.Checked = false;
            txtOpis.Focus();
        }

        private void btnCzyscPola_Click(object sender, EventArgs e)
        {
            WyczyscPolaFormularzaZadania();
            PrzelaczTrybEdycji(false);
        }

        private void btnEdytujZadanie_Click(object sender, EventArgs e)
        {
            if (lstZadania.SelectedItems.Count > 0)
            {
                int taskId = (int)lstZadania.SelectedItems[0].Tag;
                var zadanie = dataService.GetTaskById(taskId);

                if (zadanie != null)
                {
                    txtOpis.Text = zadanie.Opis;
                    cmbKategorieZadania.SelectedValue = zadanie.KategoriaId;

                    if (zadanie.DataZakonczenia.HasValue)
                    {
                        dtpTermin.Checked = true;
                        dtpTermin.Value = zadanie.DataZakonczenia.Value;
                    }
                    else
                    {
                        dtpTermin.Checked = false;
                    }
                    chkCzyWykonane.Checked = zadanie.CzyWykonane;
                    PrzelaczTrybEdycji(true, taskId);
                }
            }
            else
            {
                MessageBox.Show("Wybierz zadanie z listy, które chcesz edytować.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOznaczWykonane_Click(object sender, EventArgs e)
        {
            if (lstZadania.SelectedItems.Count > 0)
            {
                int taskId = (int)lstZadania.SelectedItems[0].Tag;
                if (dataService.ToggleTaskStatus(taskId))
                {
                    ZaladujZadaniaDoListView();
                }
            }
            else
            {
                MessageBox.Show("Wybierz zadanie z listy, aby zmienić jego status.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUsunZadanie_Click(object sender, EventArgs e)
        {
            if (lstZadania.SelectedItems.Count > 0)
            {
                var potwierdzenie = MessageBox.Show("Czy na pewno chcesz usunąć zaznaczone zadanie?", "Potwierdzenie usunięcia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (potwierdzenie == DialogResult.Yes)
                {
                    int taskId = (int)lstZadania.SelectedItems[0].Tag;
                    if (dataService.DeleteTask(taskId))
                    {
                        ZaladujZadaniaDoListView();
                        if (edytowaneZadanieId.HasValue && edytowaneZadanieId.Value == taskId)
                        {
                            WyczyscPolaFormularzaZadania();
                            PrzelaczTrybEdycji(false);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Wybierz zadanie z listy, które chcesz usunąć.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOdswiez_Click(object sender, EventArgs e)
        {
            ZaladujKategorieDoGlownegoComboBoxa();
            ZaladujKategorieDoComboboxaUsuwania();
            ZaladujZadaniaDoListView();
            WyczyscPolaFormularzaZadania();
            PrzelaczTrybEdycji(false);
        }
    }
}