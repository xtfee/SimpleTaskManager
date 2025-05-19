# Prosty Menedżer Zadań (SimpleTaskManager)

## Opis Aplikacji

SimpleTaskManager to desktopowa aplikacja napisana w języku C# (.NET 8.0, WinForms) służąca do zarządzania listą zadań do wykonania. Umożliwia dodawanie, edytowanie, usuwanie zadań, a także kategoryzowanie ich i przypisywanie priorytetów.

Główne funkcje:
* Wyświetlanie listy zadań z tytułem, kategorią, priorytetem, datą wykonania i statusem ukończenia.
* Dodawanie nowych zadań z określeniem tytułu, opisu, daty wykonania (opcjonalnie), kategorii i priorytetu.
* Edycja istniejących zadań.
* Oznaczanie zadań jako ukończone.
* Usuwanie zadań.
* Zarządzanie listą kategorii (dodawanie, usuwanie).
* Zarządzanie listą priorytetów (dodawanie, usuwanie, opcjonalny kod koloru).

## Opis Bazy Danych

Aplikacja korzysta z bazy danych SQLite (`taskmanager.db`) zarządzanej przez Entity Framework Core. Schemat bazy danych składa się z następujących tabel:

1.  **`Categories`**
    * `CategoryId` (INTEGER, PK, Autoincrement) - Identyfikator kategorii
    * `Name` (TEXT, NOT NULL, UNIQUE) - Nazwa kategorii

2.  **`Priorities`**
    * `PriorityId` (INTEGER, PK, Autoincrement) - Identyfikator priorytetu
    * `Name` (TEXT, NOT NULL, UNIQUE) - Nazwa priorytetu (np. Niski, Średni, Wysoki)
    * `ColorCode` (TEXT, NULL) - Kod koloru HEX (np. #FF0000) dla wizualizacji priorytetu (opcjonalnie)

3.  **`TaskItems`**
    * `TaskItemId` (INTEGER, PK, Autoincrement) - Identyfikator zadania
    * `Title` (TEXT, NOT NULL) - Tytuł zadania
    * `Description` (TEXT, NULL) - Opis zadania
    * `CreationDate` (TEXT, NOT NULL) - Data utworzenia zadania (format ISO8601)
    * `DueDate` (TEXT, NULL) - Termin wykonania zadania (format ISO8601)
    * `IsCompleted` (INTEGER, NOT NULL, DEFAULT 0) - Status ukończenia (0 = nieukończone, 1 = ukończone)
    * `PriorityId` (INTEGER, NULL, FK) - Klucz obcy do tabeli `Priorities`
    * `CategoryId` (INTEGER, NULL, FK) - Klucz obcy do tabeli `Categories`

**Relacje:**
* `TaskItems.CategoryId` --- `Categories.CategoryId` (jeden-do-wielu)
* `TaskItems.PriorityId` --- `Priorities.PriorityId` (jeden-do-wielu)

**Dane Początkowe (Seed Data):**
* Podstawowe kategorie (Praca, Osobiste, Zakupy) i priorytety (Niski, Średni, Wysoki) są dodawane automatycznie podczas tworzenia bazy danych przez migracje (zdefiniowane w `TaskManagerContext.OnModelCreating`).
* Dodatkowe przykładowe zadania można załadować ręcznie do bazy danych za pomocą skryptu `SeedData.sql` przy użyciu narzędzia do zarządzania SQLite (np. DB Browser for SQLite).

## Konfiguracja

1.  **Połączenie z bazą danych:**
    * Konfiguracja połączenia z bazą danych SQLite znajduje się w pliku `appsettings.json` w głównym katalogu projektu, w sekcji `ConnectionStrings`:
      ```json
      {
        "ConnectionStrings": {
          "DefaultConnection": "Data Source=taskmanager.db"
        }
      }
      ```
    * Plik `appsettings.json` musi mieć ustawioną właściwość "Copy to Output Directory" na "Copy if newer" w Visual Studio.
    * Plik bazy danych `taskmanager.db` (utworzony przez migracje w głównym katalogu projektu) również musi być dodany do projektu i mieć ustawioną właściwość "Copy to Output Directory" na "Copy if newer", aby był dostępny dla uruchomionej aplikacji w katalogu wyjściowym (np. `bin/Debug/net8.0-windows/`).

## Uruchomienie Aplikacji

1.  **Wymagania:**
    * Visual Studio (np. 2022 lub nowszy) z zainstalowanym komponentem ".NET desktop development".
    * .NET 8.0 SDK.

2.  **Kompilacja i uruchomienie:**
    * Otwórz plik `SimpleTaskManager.sln` w Visual Studio.
    * Zainstaluj wymagane pakiety NuGet (jeśli nie zostały przywrócone automatycznie):
        * `Microsoft.EntityFrameworkCore.Sqlite`
        * `Microsoft.EntityFrameworkCore.Tools`
        * `Microsoft.EntityFrameworkCore.Design`
        * `Microsoft.Extensions.Configuration.Json`
    * Jeśli baza danych nie została jeszcze utworzona, otwórz **Package Manager Console** (Narzędzia -> Menedżer Pakietów NuGet -> Konsola Menedżera Pakietów) i wykonaj polecenia:
        ```powershell
        Add-Migration NazwaTwojejMigracji # Np. Add-Migration InitialCreate (tylko za pierwszym razem lub przy zmianach modeli)
        Update-Database
        ```
        (Upewnij się, że plik `taskmanager.db` z głównego katalogu projektu jest dodany do projektu i ustawiony do kopiowania do katalogu wyjściowego).
    * Skompiluj projekt (Build -> Rebuild Solution).
    * Uruchom aplikację (Debug -> Start Debugging lub Ctrl+F5).

## Autor

Bartłomiej Dobranowski