using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SimpleTaskManager.Data
{
    public class TaskManagerContextFactory : IDesignTimeDbContextFactory<TaskManagerContext>
    {
        public TaskManagerContext CreateDbContext(string[] args)
        {
            string basePath = Directory.GetCurrentDirectory();

            System.Console.WriteLine($"[TaskManagerContextFactory] Używana ścieżka bazowa: {basePath}");
            System.Console.WriteLine($"[TaskManagerContextFactory] Szukam appsettings.json w: {Path.Combine(basePath, "appsettings.json")}");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<TaskManagerContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException(
                    $"Nie znaleziono connection string 'DefaultConnection' w appsettings.json. " +
                    $"Upewnij się, że plik istnieje w głównym katalogu projektu ('{basePath}') i jest poprawnie skonfigurowany. ");
            }

            System.Console.WriteLine($"[TaskManagerContextFactory] Używam connection string: {connectionString}");

            optionsBuilder.UseSqlite(connectionString);

            return new TaskManagerContext(optionsBuilder.Options);
        }
    }
}