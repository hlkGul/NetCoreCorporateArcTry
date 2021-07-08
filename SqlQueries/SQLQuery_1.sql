CREATE TABLE [dbo].[Users]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [FirstName] VARCHAR(50) not NULL,
    [LastName] VARCHAR(50) not NULL,
    [Email] VARCHAR(50) not NULL,
    [PasswordHash] BINARY(500) not NULL,
    [PasswordSalt] BINARY(500) not NULL,
    [Status] BIT not NULL
)