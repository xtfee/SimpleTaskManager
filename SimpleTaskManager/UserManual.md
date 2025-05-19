# Instrukcja Obsługi - SimpleTaskManager

Witaj w ProstyMenedżerze Zadań! Ta aplikacja pomoże Ci zorganizować Twoje zadania do wykonania.

## 1. Główne Okno Aplikacji

Po uruchomieniu aplikacji zobaczysz główne okno, które wyświetla listę Twoich zadań. Dla każdego zadania widoczne są:
* Tytuł
* Kategoria (jeśli przypisano)
* Priorytet (jeśli przypisano)
* Termin wykonania (jeśli ustawiono)
* Status ukończenia (jako zaznaczone lub odznaczone pole)

### Dostępne Akcje w Głównym Oknie:

* **Dodaj zadanie:** Kliknięcie tego przycisku otwiera nowe okno (`TaskForm`), w którym możesz wprowadzić szczegóły nowego zadania.
* **Edytuj zadanie:** Najpierw zaznacz zadanie na liście (klikając na nie), a następnie kliknij ten przycisk. Otworzy się okno (`TaskForm`) z wczytanymi danymi zaznaczonego zadania, gotowe do edycji.
* **Usuń zadanie:** Zaznacz zadanie na liście, a następnie kliknij ten przycisk. Pojawi się okno z prośbą o potwierdzenie usunięcia.
* **Zarządzaj Kat./Prioryt.:** Kliknięcie tego przycisku otwiera nowe okno (`ManagementForm`), w którym możesz dodawać lub usuwać kategorie i priorytety dostępne w aplikacji.

## 2. Dodawanie i Edycja Zadania (Okno `TaskForm`)

To okno służy do tworzenia nowych zadań lub modyfikowania istniejących.

### Pola Formularza:

* **Tytuł:** (Wymagane) Krótki, zwięzły tytuł zadania.
* **Opis:** (Opcjonalne) Bardziej szczegółowy opis zadania.
* **Data wykonania:** (Opcjonalne) Możesz wybrać datę z kalendarza. Jeśli nie chcesz ustawiać terminu, odznacz pole wyboru obok daty. Data nie może być z przeszłości dla zadań nieukończonych.
* **Kategoria:** (Opcjonalne) Wybierz kategorię z listy rozwijanej. Nowe kategorie możesz dodać w oknie "Zarządzaj Kat./Prioryt.".
* **Priorytet:** (Opcjonalne) Wybierz priorytet z listy rozwijanej. Nowe priorytety możesz dodać w oknie "Zarządzaj Kat./Prioryt.".
* **Ukończone:** Zaznacz to pole, jeśli zadanie zostało już wykonane.

### Przyciski:

* **Zapisz:** Zapisuje wprowadzone zmiany (dla nowego zadania lub edytowanego) i zamyka okno.
* **Anuluj:** Zamyka okno bez zapisywania zmian.

## 3. Zarządzanie Kategoriami i Priorytetami (Okno `ManagementForm`)

To okno pozwala na zarządzanie listami kategorii i priorytetów używanych w aplikacji.

### Sekcja "Kategorie":

* **Lista istniejących kategorii:** Wyświetla wszystkie zdefiniowane kategorie.
* **Nazwa kategorii (pole tekstowe):** Wpisz tutaj nazwę nowej kategorii.
* **Przycisk "Dodaj":** Dodaje nową kategorię o wpisanej nazwie do listy. Nazwa kategorii musi być unikalna.
* **Przycisk "Usuń zaznaczoną":** Usuwa zaznaczoną kategorię z listy. Kategoria nie może być usunięta, jeśli jest aktualnie przypisana do jakiegokolwiek zadania.

### Sekcja "Priorytety":

* **Lista istniejących priorytetów:** Wyświetla wszystkie zdefiniowane priorytety.
* **Nazwa priorytetu (pole tekstowe):** Wpisz tutaj nazwę nowego priorytetu.
* **Kolor (np. #RRGGBB) (pole tekstowe):** (Opcjonalne) Możesz podać kod koloru w formacie heksadecymalnym (np. `#FF0000` dla czerwonego), który może być użyty w przyszłości do wizualizacji.
* **Przycisk "Dodaj":** Dodaje nowy priorytet o wpisanej nazwie i kolorze do listy. Nazwa priorytetu musi być unikalna.
* **Przycisk "Usuń zaznaczony":** Usuwa zaznaczony priorytet z listy. Priorytet nie może być usunięty, jeśli jest aktualnie przypisany do jakiegokolwiek zadania.

### Przycisk:

* **Zamknij:** Zamyka okno zarządzania.

## 4. Walidacja Danych

Aplikacja wykonuje podstawową walidację wprowadzanych danych:
* Tytuł zadania jest wymagany.
* Nazwy kategorii i priorytetów są wymagane i muszą być unikalne.
* Kod koloru dla priorytetu (jeśli podany) musi być w poprawnym formacie HEX.
* Data wykonania nieukończonego zadania nie może być datą z przeszłości.

W przypadku próby zapisu niepoprawnych danych, użytkownik zostanie o tym poinformowany odpowiednim komunikatem lub oznaczeniem błędu przy danym polu.

---