--Populating data for users
INSERT INTO Users (Username, UserID, Salt, Passwrd_Hash)	
VALUES
('Roy', 1,'gQ92APxf8MD2ZGDmj21fMA==','o/JPtMorjiZWx7+b5lbkc2OEruNXWnyaFMSYUeLRmwc='),
('Mark', 2,'Nz82pjygneainRAfiCwSBQ==', 'eqYmE1yPU7gBynINBa1ZhUL6znNuC/gFbe1aQgHErUw=');

--Populating data for TodoList
INSERT INTO ActionsToDo (Id, UserID, Title, Description, Is_Complete, Time_Create)
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

