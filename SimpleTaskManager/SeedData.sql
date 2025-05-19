INSERT INTO TaskItems (Title, Description, CreationDate, DueDate, IsCompleted, PriorityId, CategoryId)
VALUES
('Zrobić zakupy spożywcze', 'Mleko, chleb, jajka, masło', STRFTIME('%Y-%m-%d %H:%M:%S', 'now', 'localtime'), STRFTIME('%Y-%m-%d %H:%M:%S', 'now', '+1 day', 'localtime'), 0, 
 (SELECT PriorityId FROM Priorities WHERE Name = 'Średni'), 
 (SELECT CategoryId FROM Categories WHERE Name = 'Zakupy')),

('Przygotować raport tygodniowy', 'Podsumowanie postępów projektu X', STRFTIME('%Y-%m-%d %H:%M:%S', 'now', 'localtime'), STRFTIME('%Y-%m-%d %H:%M:%S', 'now', '+4 days', 'localtime'), 0, 
 (SELECT PriorityId FROM Priorities WHERE Name = 'Wysoki'), 
 (SELECT CategoryId FROM Categories WHERE Name = 'Praca')),

('Zaplanować urlop', 'Sprawdzić oferty, zarezerwować hotel', STRFTIME('%Y-%m-%d %H:%M:%S', 'now', '-3 days', 'localtime'), STRFTIME('%Y-%m-%d %H:%M:%S', 'now', '+30 days', 'localtime'), 0,
 (SELECT PriorityId FROM Priorities WHERE Name = 'Niski'),
 (SELECT CategoryId FROM Categories WHERE Name = 'Osobiste'));