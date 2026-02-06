--Table for user information
CREATE TABLE Users (
	id INTEGER PRIMARY KEY,
	userID TEXT NOT NULL UNIQUE,
	passwrd_hash REAL NOT NULL

);

--Table for actions on the ToDo list
CREATE TABLE ActionsToDo (
	id INTEGER NOT NULL,
	userID INTEGER NOT NULL,
	title TEXT NOT NULL,
	description TEXT NULL,
	is_complete INTEGER NOT NULL DEFAULT 0,
	time_create INTEGER NOT NULL DEFAULT CURRENT_TIMESTAMP --could be text?

	FOREIGN KEY (userID) REFERENCES Users(id) --end of table foreign key
);