CREATE TABLE [dbo].[Users] (
    [ID]           INT IDENTITY (1, 1) NOT NULL,
    [UserName]     NVARCHAR (MAX) NOT NULL,
    [UserPassword] NVARCHAR (MAX) NOT NULL,
    [Email] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([ID] ASC)
);

