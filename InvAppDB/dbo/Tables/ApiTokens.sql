CREATE TABLE [dbo].[ApiTokens]
(
	[Id] INT IDENTITY(1,1) NOT NULL
	    CONSTRAINT [PK_ApiTokens] PRIMARY KEY CLUSTERED ([ID] ASC), 
    [CompanyID] INT NOT NULL, 
    [Token] NVARCHAR(MAX) NOT NULL
)
