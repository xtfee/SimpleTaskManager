using Microsoft.EntityFrameworkCore;
using SimpleTaskManager;
using SimpleTaskManager.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SimpleTaskManager
{
    public class DataService
    {
        private TaskContext CreateContext()
        {
            return new TaskContext();
        }

        public DataService()
        {
            using (var context = CreateContext())
            {
                context.Database.EnsureCreated();
            }
        }

        public List<Kategoria> GetCategories()
        {
            using (var context = CreateContext())
            {
                return context.Kategorie.OrderBy(k => k.Nazwa).ToList();
            }
        }

        public bool AddCategory(string nazwa)
        {
            if (string.IsNullOrWhiteSpace(nazwa))
            {
                return false;
            }

            using (var context = CreateContext())
            {
                string nazwaLower = nazwa.ToLower();
                if (context.Kategorie.Any(k => k.Nazwa.ToLower() == nazwaLower))
                {
                    MessageBox.Show("Kategoria o tej nazwie już istnieje.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                var kategoria = new Kategoria { Nazwa = nazwa };
                context.Kategorie.Add(kategoria);
                try
                {
                    return context.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas dodawania kategorii: {ex.Message}", "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public (bool Success, string Message) DeleteCategory(int kategoriaId)
        {
            using (var context = CreateContext())
            {
                bool maZadania = context.Zadania.Any(z => z.KategoriaId == kategoriaId);
                if (maZadania)
                {
                    return (false, "Nie można usunąć kategorii, ponieważ są do niej przypisane zadania. Najpierw usuń lub przenieś zadania.");
                }

                var kategoriaDoUsuniecia = context.Kategorie.Find(kategoriaId);
                if (kategoriaDoUsuniecia == null)
                {
                    return (false, "Nie znaleziono kategorii o podanym ID.");
                }

                context.Kategorie.Remove(kategoriaDoUsuniecia);
                try
                {
                    context.SaveChanges();
                    return (true, "Kategoria została pomyślnie usunięta.");
                }
                catch (Exception ex)
                {
                    return (false, $"Wystąpił błąd podczas usuwania kategorii: {ex.Message}");
                }
            }
        }

        public List<ElementZadania> GetTasks()
        {
            using (var context = CreateContext())
            {
                return context.Zadania
                              .Include(z => z.Kategoria)
                              .OrderBy(z => z.CzyWykonane)
                              .ThenBy(z => z.DataZakonczenia)
                              .ThenByDescending(z => z.DataUtworzenia)
                              .ToList();
            }
        }

        public ElementZadania GetTaskById(int taskId)
        {
            using (var context = CreateContext())
            {
                return context.Zadania
                              .Include(z => z.Kategoria)
                              .FirstOrDefault(z => z.Id == taskId);
            }
        }

        public bool AddTask(string opis, DateTime? dataZakonczenia, int kategoriaId)
        {
            if (string.IsNullOrWhiteSpace(opis)) return false;

            var zadanie = new ElementZadania
            {
                Opis = opis,
                DataUtworzenia = DateTime.Now,
                DataZakonczenia = dataZakonczenia,
                KategoriaId = kategoriaId,
                CzyWykonane = false
            };

            using (var context = CreateContext())
            {
                context.Zadania.Add(zadanie);
                try
                {
                    return context.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas dodawania zadania: {ex.Message}", "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public bool UpdateTask(int taskId, string opis, DateTime? dataZakonczenia, int kategoriaId, bool czyWykonane)
        {
            if (string.IsNullOrWhiteSpace(opis)) return false;

            using (var context = CreateContext())
            {
                var zadanieDoAktualizacji = context.Zadania.Find(taskId);
                if (zadanieDoAktualizacji == null) return false;

                zadanieDoAktualizacji.Opis = opis;
                zadanieDoAktualizacji.DataZakonczenia = dataZakonczenia;
                zadanieDoAktualizacji.KategoriaId = kategoriaId;
                zadanieDoAktualizacji.CzyWykonane = czyWykonane;
                try
                {
                    return context.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas aktualizacji zadania: {ex.Message}", "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public bool ToggleTaskStatus(int taskId)
        {
            using (var context = CreateContext())
            {
                var zadanie = context.Zadania.Find(taskId);
                if (zadanie == null) return false;

                zadanie.CzyWykonane = !zadanie.CzyWykonane;
                try
                {
                    return context.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas zmiany statusu zadania: {ex.Message}", "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public bool DeleteTask(int taskId)
        {
            using (var context = CreateContext())
            {
                var zadanieDoUsuniecia = context.Zadania.Find(taskId);
                if (zadanieDoUsuniecia == null) return false;

                context.Zadania.Remove(zadanieDoUsuniecia);
                try
                {
                    return context.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas usuwania zadania: {ex.Message}", "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    }
}