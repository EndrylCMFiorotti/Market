CREATE TABLE [dbo].[User]
(
	[IdUser]	 INT			IDENTITY (1, 1)		NOT NULL,
	[Name]		 VARCHAR(45)						NOT NULL,
	[Email]		 VARCHAR(45)						NOT NULL,
	[Password]	 VARCHAR(45)						NOT NULL,
	[IsLogged]	 BIT								NOT NULL
	CONSTRAINT PK_User_IdUser PRIMARY KEY (IdUser)
)
