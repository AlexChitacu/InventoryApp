CREATE TRIGGER [dbo].[CoInv_ModifiedDate]
	ON [dbo].[CompanyInventory]
	FOR UPDATE AS
	 BEGIN
		 UPDATE [dbo].[CompanyInventory]
		 SET [ModifiedDate] = GETDATE()
		 FROM [dbo].[CompanyInventory] INNER JOIN deleted d ON [dbo].[CompanyInventory].[Id] = d.id
	 END
	 GO
	 ALTER TABLE [dbo].[CompanyInventory] ENABLE TRIGGER [CoInv_ModifiedDate]
	 GO
