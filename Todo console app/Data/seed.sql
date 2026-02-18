--Populating data for users
INSERT INTO Users (Username, UserID, Salt, Passwrd_Hash)	
VALUES
('Roy', 1,'Lebanon5','fehdhd'),
('Mark', 2,'Abfh34', 'password123');

--Populating data for TodoList
INSERT INTO TodoList (Id, UserID, Title, Description, Is_Complete, Time_Create)
VALUES
(1, 1, 'Make bed', 'Make the bed now', 0, 0),
(2, 2, 'Drink water', NULL, 0, 0),
(3, 1, 'Drink water', NULL, 0, 0);

--Expenses (to look into frequency amount)
INSERT INTO Expenses (Id, UserID, Amount, Frequency, Title)
VALUES
(1, 1, 50, 'Weekly', 'Cash ISA'),
(2, 1, 100, 'Monthly', 'Savings'),
(3, 2, 40, 'Weekly', 'Groceries')
;

