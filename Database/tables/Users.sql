CREATE TABLE [dbo].[Users]
(
	[IdUsers]	INT			NOT NULL,
	[Name]		VARCHAR(45) NOT NULL,
	[Email]		VARCHAR(45)	NOT NULL,
	[Password]	VARCHAR(45)	NOT NULL,
	CONSTRAINT PK_Users_IdUsers PRIMARY KEY (IdUsers)
)
