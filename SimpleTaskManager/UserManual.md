# Instrukcja Obsługi - SimpleTaskManager

Niniejsza instrukcja opisuje sposób korzystania z aplikacji SimpleTaskManager, przeznaczonej do organizacji zadań.

## 1. Główne Okno Aplikacji

Po uruchomieniu aplikacji widoczne jest główne okno, które wyświetla listę zadań. Dla każdego zadania prezentowane są następujące informacje:
* Tytuł
* Kategoria (jeśli przypisano)
* Priorytet (jeśli przypisano)
* Termin wykonania (jeśli ustawiono)
* Status ukończenia (jako zaznaczone lub odznaczone pole)

Poniżej listy zadań znajdują się przyciski funkcyjne.

### Dostępne Akcje w Głównym Oknie:

* **Dodaj zadanie:** Kliknięcie tego przycisku otwiera nowe okno (`TaskForm`), umożliwiające wprowadzenie szczegółów nowego zadania.
* **Edytuj zadanie:** Aby edytować zadanie, należy je najpierw zaznaczyć na liście (poprzez kliknięcie), a następnie kliknąć przycisk "Edytuj zadanie". Otwierane jest okno (`TaskForm`) z wczytanymi danymi zaznaczonego zadania, gotowymi do edycji.
* **Usuń zadanie:** Zaznaczenie zadania na liście i kliknięcie przycisku "Usuń zadanie" powoduje wyświetlenie okna z prośbą o potwierdzenie operacji usunięcia.
* **Zarządzaj Kat./Prioryt.:** Kliknięcie tego przycisku otwiera nowe okno (`ManagementForm`), służące do dodawania lub usuwania kategorii i priorytetów dostępnych w aplikacji.

## 2. Dodawanie i Edycja Zadania (Okno `TaskForm`)

Okno `TaskForm` przeznaczone jest do tworzenia nowych zadań oraz modyfikowania istniejących.

### Pola Formularza:

* **Tytuł:** (Wymagane) Pole przeznaczone na krótki, zwięzły tytuł zadania.
* **Opis:** (Opcjonalne) Pole umożliwiające wprowadzenie bardziej szczegółowego opisu zadania.
* **Data wykonania:** (Opcjonalne) Umożliwia wybór daty z kalendarza. W przypadku braku chęci ustawienia terminu, należy odznaczyć pole wyboru znajdujące się obok daty. Data wykonania nie może być datą z przeszłości dla zadań, które nie zostały oznaczone jako ukończone.
* **Kategoria:** (Opcjonalne) Umożliwia wybór kategorii z listy rozwijanej. Nowe kategorie można dodać w oknie "Zarządzaj Kat./Prioryt.".
* **Priorytet:** (Opcjonalne) Umożliwia wybór priorytetu z listy rozwijanej. Nowe priorytety można dodać w oknie "Zarządzaj Kat./Prioryt.".
* **Ukończone:** Pole wyboru (`CheckBox`) służące do oznaczenia zadania jako wykonanego.

### Przyciski:

* **Zapisz:** Powoduje zapisanie wprowadzonych zmian (dla nowego zadania lub edytowanego) i zamknięcie okna.
* **Anuluj:** Powoduje zamknięcie okna bez zapisywania zmian.

## 3. Zarządzanie Kategoriami i Priorytetami (Okno `ManagementForm`)

Okno `ManagementForm` umożliwia zarządzanie listami kategorii i priorytetów wykorzystywanych w aplikacji.

### Sekcja "Kategorie":

* **Lista istniejących kategorii:** Prezentuje wszystkie zdefiniowane kategorie.
* **Nazwa kategorii (pole tekstowe):** Służy do wprowadzenia nazwy nowej kategorii.
* **Przycisk "Dodaj":** Powoduje dodanie nowej kategorii o wprowadzonej nazwie do listy. Nazwa kategorii musi być unikalna.
* **Przycisk "Usuń zaznaczoną":** Powoduje usunięcie zaznaczonej kategorii z listy. Kategoria nie może być usunięta, jeśli jest aktualnie przypisana do jakiegokolwiek zadania.

### Sekcja "Priorytety":

* **Lista istniejących priorytetów:** Prezentuje wszystkie zdefiniowane priorytety.
* **Nazwa priorytetu (pole tekstowe):** Służy do wprowadzenia nazwy nowego priorytetu.
* **Kolor (np. #RRGGBB) (pole tekstowe):** (Opcjonalne) Umożliwia podanie kodu koloru w formacie heksadecymalnym (np. `#FF0000` dla czerwonego).
* **Przycisk "Dodaj":** Powoduje dodanie nowego priorytetu o wprowadzonej nazwie i kolorze do listy. Nazwa priorytetu musi być unikalna.
* **Przycisk "Usuń zaznaczony":** Powoduje usunięcie zaznaczonego priorytetu z listy. Priorytet nie może być usunięty, jeśli jest aktualnie przypisany do jakiegokolwiek zadania.

### Przycisk:

* **Zamknij:** Powoduje zamknięcie okna zarządzania.

## 4. Walidacja Danych

Aplikacja przeprowadza podstawową walidację wprowadzanych danych:
* Tytuł zadania jest polem wymaganym.
* Nazwy kategorii i priorytetów są wymagane i muszą być unikalne (z ignorowaniem wielkości liter).
* Kod koloru dla priorytetu (jeśli został podany) musi odpowiadać poprawnemu formatowi HEX.
* Data wykonania dla nieukończonego zadania nie może być datą z przeszłości.

W przypadku próby zapisu danych niespełniających kryteriów walidacji, wyświetlany jest odpowiedni komunikat lub oznaczenie błędu przy danym polu formularza.

---
