--Table for user information

DROP TABLE IF EXISTS ActionsToDo;
DROP TABLE IF EXISTS Expenses;
DROP TABLE IF EXISTS Users;

CREATE TABLE Users (
	Username TEXT NOT NULL,
	UserId INTEGER PRIMARY KEY,
	Salt TEXT NOT NULL,
	Passwrd_Hash REAL NOT NULL
	--created_at INTEGER not null
);

--Table for actions on the ToDo list
CREATE TABLE ActionsToDo (
	Id INTEGER NOT NULL,
	UserId INTEGER NOT NULL,
	Title TEXT NOT NULL,
	Description TEXT NULL,
	Is_Complete INTEGER NOT NULL DEFAULT 0,
	Time_Create INTEGER NOT NULL DEFAULT CURRENT_TIMESTAMP, --could be text?

	FOREIGN KEY (UserId) REFERENCES Users(UserId) --end of table foreign key
);

CREATE TABLE Expenses (
	Id INTEGER UNIQUE,
	UserId INTEGER NOT NULL,
	Amount INTEGER NOT NULL,
	Frequency TEXT DEFAULT 0,
	Title TEXT NOT NULL UNIQUE,

	FOREIGN KEY (UserId) REFERENCES Users(UserId)
);