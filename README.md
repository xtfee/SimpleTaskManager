# Prosty Menedżer Zadań (SimpleTaskManager)

## Opis Aplikacji

SimpleTaskManager to aplikacja desktopowa, napisana w języku C# (.NET 8.0, WinForms), przeznaczona do zarządzania listą zadań do wykonania. Umożliwia dodawanie, edytowanie, usuwanie zadań, a także ich kategoryzację oraz przypisywanie priorytetów.

Główne funkcje aplikacji obejmują:
* Wyświetlanie listy zadań z uwzględnieniem tytułu, kategorii, priorytetu, daty wykonania i statusu ukończenia.
* Dodawanie nowych zadań z możliwością określenia tytułu, opisu, daty wykonania (opcjonalnie), kategorii i priorytetu.
* Edycję istniejących zadań.
* Oznaczanie zadań jako ukończone.
* Usuwanie zadań.
* Zarządzanie listą kategorii (dodawanie, usuwanie).
* Zarządzanie listą priorytetów (dodawanie, usuwanie, przypisywanie opcjonalnego kodu koloru).

## Opis Bazy Danych

Aplikacja wykorzystuje bazę danych SQLite (`taskmanager.db`), zarządzaną przez Entity Framework Core. Schemat bazy danych składa się z następujących tabel:

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
* Dodatkowe przykładowe zadania można załadować ręcznie do bazy danych za pomocą skryptu `SeedData.sql`, przy użyciu narzędzia do zarządzania SQLite (np. DB Browser for SQLite).

## Konfiguracja

1.  **Połączenie z bazą danych:**
    * Konfiguracja połączenia z bazą danych SQLite znajduje się w pliku `appsettings.json`, umieszczonym w głównym katalogu projektu, w sekcji `ConnectionStrings`:
      ```json
      {
        "ConnectionStrings": {
          "DefaultConnection": "Data Source=taskmanager.db"
        }
      }
      ```
    * Dla pliku `appsettings.json` konieczne jest ustawienie właściwości "Copy to Output Directory" na "Copy if newer" w środowisku Visual Studio.
    * Plik bazy danych `taskmanager.db` (utworzony przez migracje w głównym katalogu projektu) również wymaga dodania do projektu oraz ustawienia właściwości "Copy to Output Directory" na "Copy if newer". Zapewnia to jego dostępność dla uruchomionej aplikacji w katalogu wyjściowym (np. `bin/Debug/net8.0-windows/`).

## Uruchomienie Aplikacji

1.  **Wymagania Systemowe:**
    * Środowisko Visual Studio (np. 2022 lub nowsze) z zainstalowanym komponentem ".NET desktop development".
    * Zainstalowany .NET 8.0 SDK.

2.  **Kompilacja i Uruchomienie:**
    * Należy otworzyć plik `SimpleTaskManager.sln` w środowisku Visual Studio.
    * Wymagane jest zainstalowanie pakietów NuGet (jeśli nie zostały przywrócone automatycznie):
        * `Microsoft.EntityFrameworkCore.Sqlite`
        * `Microsoft.EntityFrameworkCore.Tools`
        * `Microsoft.EntityFrameworkCore.Design`
        * `Microsoft.Extensions.Configuration.Json`
    * W przypadku, gdy baza danych nie została jeszcze utworzona, należy otworzyć **Package Manager Console** (Narzędzia -> Menedżer Pakietów NuGet -> Konsola Menedżera Pakietów) i wykonać następujące polecenia:
        ```powershell
        Add-Migration NazwaMigracji # Np. Add-Migration InitialCreate (tylko przy pierwszym tworzeniu lub zmianach modeli)
        Update-Database
        ```
        (Należy upewnić się, że plik `taskmanager.db` z głównego katalogu projektu jest dodany do projektu i skonfigurowany do kopiowania do katalogu wyjściowego).
    * Projekt kompiluje się poprzez wybranie opcji Build -> Rebuild Solution.
    * Aplikację uruchamia się poprzez Debug -> Start Debugging (lub Ctrl+F5).

## Instrukcje dla Prowadzącego/Testera

1.  **Klonowanie Repozytorium:**
    Repozytorium klonuje się za pomocą polecenia:
    ```bash
    git clone https://github.com/xtfee/SimpleTaskManager
    ```
2.  **Wymagania:**
    * Visual Studio (np. 2022 lub nowszy).
    * Zainstalowany .NET 8.0 SDK.
3.  **Uruchomienie Projektu:**
    * Należy otworzyć plik `SimpleTaskManager.sln` w Visual Studio.
    * Projekt zawiera plik bazy danych `taskmanager.db` w głównym katalogu, skonfigurowany do kopiowania do katalogu wyjściowego (`bin/Debug/net8.0-windows/`) podczas budowania. Plik ten zawiera już schemat oraz dane początkowe (kategorie, priorytety) zdefiniowane w `OnModelCreating`.
    * Należy wykonać **Build > Rebuild Solution**.
    * Aplikację uruchamia się standardowo (F5 lub Ctrl+F5).
4.  **Dane Testowe (`SeedData.sql`):**
    * Repozytorium zawiera plik `SeedData.sql` z przykładowymi zadaniami. Aby dodać je do bazy danych:
        1.  Należy otworzyć plik `taskmanager.db` (z katalogu `SimpleTaskManager/bin/Debug/net8.0-windows/`) za pomocą narzędzia do zarządzania SQLite (np. DB Browser for SQLite).
        2.  Następnie należy przejść do zakładki "Execute SQL".
        3.  Zawartość pliku `SeedData.sql` kopiuje się i wykonuje jako zapytania SQL.
5.  **(Opcjonalnie) Tworzenie bazy danych od zera:**
    * Należy usunąć plik `taskmanager.db` z głównego katalogu projektu ORAZ z katalogu `bin/Debug/net8.0-windows/`.
    * W Package Manager Console w Visual Studio wykonuje się polecenie:
        ```powershell
        Update-Database
        ```
    * Następnie projekt należy skompilować i uruchomić. W przypadku usunięcia pliku `taskmanager.db` z głównego katalogu projektu, konieczne jest jego ponowne dodanie do projektu i ustawienie właściwości "Copy to Output Directory" na "Copy if newer" po tym, jak `Update-Database` go utworzy. (Prostszym podejściem dla testera jest skorzystanie z bazy danych dostarczonej w repozytorium).

---
Data realizacji projektu: Maj 2025
Bartłomiej Dobranowski
