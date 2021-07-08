CREATE TABLE [dbo].[UserOperationClaims]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [UserId] INT NOT NULL,
    [OperationClaimId] INT NOT NULL
)