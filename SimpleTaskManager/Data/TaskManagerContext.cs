using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; // Dla IConfigurationRoot
using SimpleTaskManager.Data.Models;
using System.IO; // Dla Path.Combine i Directory.GetCurrentDirectory() / AppContext.BaseDirectory

namespace SimpleTaskManager.Data
{
    public class TaskManagerContext : DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Priority> Priorities { get; set; }

        public TaskManagerContext(DbContextOptions<TaskManagerContext> options) : base(options)
        {
        }

        public TaskManagerContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string basePath = AppContext.BaseDirectory;

                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(basePath)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection");

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException(
                        $"Nie znaleziono connection string 'DefaultConnection' w appsettings.json. " +
                        $"Upewnij się, że plik istnieje w katalogu wyjściowym aplikacji ('{basePath}') i jest poprawnie skonfigurowany, " +
                        $"oraz że jego właściwość 'Copy to Output Directory' jest ustawiona na 'Copy if newer' lub 'Copy always'.");
                }

                optionsBuilder.UseSqlite(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfiguracja unikalności dla nazw Kategorii
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();

            // Konfiguracja unikalności dla nazw Priorytetów
            modelBuilder.Entity<Priority>()
                .HasIndex(p => p.Name)
                .IsUnique();

            // Dane początkowe (seed data) - zostaną dodane do bazy danych podczas pierwszej migracji
            modelBuilder.Entity<Priority>().HasData(
                new Priority { PriorityId = 1, Name = "Niski", ColorCode = "#00FF00" },
                new Priority { PriorityId = 2, Name = "Średni", ColorCode = "#FFFF00" },
                new Priority { PriorityId = 3, Name = "Wysoki", ColorCode = "#FF0000" }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Praca" },
                new Category { CategoryId = 2, Name = "Osobiste" },
                new Category { CategoryId = 3, Name = "Zakupy" }
            );

            // Tutaj możesz dodać dalsze konfiguracje dla swoich encji, jeśli będą potrzebne
            // np. dotyczące kluczy obcych, typów danych kolumn, ograniczeń itp.
            // Przykład (choć EF Core często sam dobrze sobie z tym radzi przez konwencje):
            // modelBuilder.Entity<TaskItem>()
            //     .Property(t => t.Title)
            //     .IsRequired()
            //     .HasMaxLength(200);
        }
    }
}