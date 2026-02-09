--Populating data for users
INSERT INTO Users (UserID, passwrd_hash)	
VALUES
('Roy', 'fehdhd'),
('Mark', 'password123');

--Populating data for TodoList
INSERT INTO TodoList (id, userID, title, description, is_complete, time_create)
VALUES
(1,'Roy', 'Make bed', 'Make the bed now', 0, 0),
(2, 'Roy', 'Drink water', NULL, 0, 0),
(3, 'Mark', 'Drink water', NULL, 0, 0);



