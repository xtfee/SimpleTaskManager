# Simple Task Manager
Prosta aplikacja okienkowa (Windows Forms) do zarządzania listą zadań, stworzona w C# z wykorzystaniem .NET i Entity Framework Core oraz bazy danych SQLite.

## Opis projektu

Aplikacja "Simple Task Manager" umożliwia użytkownikowi tworzenie zadań do wykonania, kategoryzowanie ich, oznaczanie jako wykonane oraz zarządzanie kategoriami. Jest to projekt pokazujący podstawy tworzenia aplikacji WinForms z użyciem EF Core do operacji na bazie danych.

## Funkcjonalności

* **Zarządzanie zadaniami:**
    * Dodawanie nowych zadań z opisem, opcjonalnym terminem wykonania i przypisaniem do kategorii.
    * Edycja istniejących zadań.
    * Oznaczanie zadań jako wykonane/niewykonane.
    * Usuwanie zadań.
    * Wyświetlanie listy zadań.
* **Zarządzanie kategoriami:**
    * Dodawanie nowych kategorii.
    * Usuwanie istniejących kategorii (tylko jeśli nie są do nich przypisane żadne zadania).
    * Wyświetlanie listy kategorii.

## Technologie

* **Język programowania:** C#
* **Framework:** .NET 8 (lub nowsza wersja LTS)
* **Interfejs użytkownika:** Windows Forms (WinForms)
* **Dostęp do danych:** Entity Framework Core (EF Core)
* **Baza danych:** SQLite (plik `taskManager.db` tworzony automatycznie w katalogu uruchomieniowym aplikacji)

## Jak uruchomić projekt?

1.  **Wymagania:**
    * .NET SDK (w wersji zgodnej z projektem, np. .NET 8).
    * Visual Studio 2022 (lub nowsze, z zainstalowanym obciążeniem ".NET desktop development").

2.  **Kroki:**
    * Sklonuj repozytorium na swój komputer:
        ```bash
        git clone https://github.com/xtfee/SimpleTaskManager.git
        ```
    * Otwórz plik rozwiązania w Visual Studio.
    * Przy pierwszym uruchomieniu projektu, Entity Framework Core automatycznie utworzy plik bazy danych SQLite (`taskManager.db`) wraz z wymaganym schematem (tabelami) oraz wypełni go początkowymi kategoriami (Dom, Praca, Nauka, Prywatne). Dzieje się tak dzięki metodzie `EnsureCreated()` oraz konfiguracji `HasData` w `TaskContext.cs`.
    * Skompiluj projekt (Build > Build Solution lub `Ctrl+Shift+B`).
    * Uruchom projekt (Debug > Start Debugging lub `F5`).

## Struktura bazy danych (Model Entity Framework Core)

Baza danych składa się z dwóch głównych tabel (encji) zarządzanych przez EF Core:

* **`Kategorie`**
    * `Id` (int, klucz główny, autoinkrementacja) - Unikalny identyfikator kategorii.
    * `Nazwa` (string, wymagane, max 100 znaków, unikalna) - Nazwa kategorii.
    * `Zadania` (kolekcja `ElementZadania`) - Właściwość nawigacyjna do zadań należących do tej kategorii.

* **`ElementZadania`**
    * `Id` (int, klucz główny, autoinkrementacja) - Unikalny identyfikator zadania.
    * `Opis` (string, wymagane, max 500 znaków) - Treść/opis zadania.
    * `CzyWykonane` (bool) - Status wykonania zadania.
    * `DataUtworzenia` (DateTime) - Data i czas utworzenia zadania.
    * `DataZakonczenia` (DateTime?, opcjonalne) - Termin wykonania zadania.
    * `KategoriaId` (int) - Klucz obcy wskazujący na `Id` w tabeli `Kategorie`.
    * `Kategoria` (obiekt `Kategoria`) - Właściwość nawigacyjna do kategorii, do której należy zadanie.

**Relacja:** Pomiędzy tabelami `Kategorie` i `ElementZadania` istnieje relacja jeden-do-wielu (1:N) – jedna kategoria może zawierać wiele zadań, ale każde zadanie należy do dokładnie jednej kategorii.

## Możliwe przyszłe ulepszenia

* Sortowanie zadań na liście po kliknięciu w nagłówki kolumn.
* Filtrowanie zadań (np. pokaż tylko aktywne, pokaż zadania na dziś/jutro).
* Ustawianie priorytetów dla zadań.
* Możliwość edycji nazw istniejących kategorii.
* Przypomnienia o terminach zadań.
* Zapisywanie ustawień użytkownika (np. rozmiar okna, ostatnio używane filtry).
