CREATE TABLE [dbo].[CompanyUsers] (
    [ID]        INT IDENTITY (1, 1) NOT NULL,
    [CompanyID] INT NOT NULL,
    [UserID]    INT NOT NULL,
    [RoleID] INT NOT NULL, 
    CONSTRAINT [PK_CompanyUsers] PRIMARY KEY CLUSTERED ([ID] ASC)
);

