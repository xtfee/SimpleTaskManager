using Microsoft.EntityFrameworkCore;
using SimpleTaskManager.Modele;
using System;

namespace SimpleTaskManager
{
    public class TaskContext : DbContext
    {
        public DbSet<Kategoria> Kategorie { get; set; }
        public DbSet<ElementZadania> Zadania { get; set; }

        private readonly string dbPath = "taskManager.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategoria>()
                .HasIndex(k => k.Nazwa)
                .IsUnique();

            modelBuilder.Entity<ElementZadania>()
                .HasOne(z => z.Kategoria)
                .WithMany(k => k.Zadania)
                .HasForeignKey(z => z.KategoriaId);

            // Dane początkowe dla kategorii
            modelBuilder.Entity<Kategoria>().HasData(
                new Kategoria { Id = 1, Nazwa = "Dom" },
                new Kategoria { Id = 2, Nazwa = "Praca" },
                new Kategoria { Id = 3, Nazwa = "Nauka" },
                new Kategoria { Id = 4, Nazwa = "Prywatne" }
            );
        }
    }
}