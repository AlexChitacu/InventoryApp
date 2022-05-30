DECLARE @tableList nvarchar(MAX)
SET @tableList = 'AND ((Schema_Id=Schema_id(''dbo'') AND o.Name IN (''Roles'', ''Depo'', ''Products'')))'

--PRINT @tableList

EXEC sp_msforeachtable 
	@command1 = "ALTER TABLE ? NOCHECK CONSTRAINT all",
	@command2 = "PRINT 'Disabled constraints on table ?'",
	@whereand = @tableList

:r .\RolesSeeding.sql
:r .\DepoSeeding.sql
:r .\ProductsSeeding.sql

EXEC sp_msforeachtable 
	@command1 = "ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all",
	@command2 = "PRINT 'Enabled constraints on table ?'",
	@whereand = @tableList