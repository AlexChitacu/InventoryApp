CREATE TABLE [dbo].[CompanyInventory]
(
	[Id] INT IDENTITY(1,1) NOT NULL 
	CONSTRAINT [PK_CompanyInventory] PRIMARY KEY CLUSTERED ([ID] ASC), 
    [CompanyId] INT NOT NULL, 
    [ProductID] INT NOT NULL, 
    [Ammount] INT NOT NULL, 
    [DepoID] INT NOT NULL,
	[CreatedDate] DATETIME NOT NULL DEFAULT GETDATE(),
	[ModifiedDate] DATETIME NULL
)
