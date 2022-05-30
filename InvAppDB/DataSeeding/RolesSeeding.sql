SET IDENTITY_INSERT [Roles] ON;

MERGE INTO [Roles] AS Target 
USING (VALUES 
(1,	'Admin'),
(2,	'Worker')
)
	AS Source (ID, RoleName)
ON Target.ID = Source.ID 
WHEN MATCHED AND (ISNULL(Target.RoleName, '') != ISNULL(Source.RoleName, '')) 
THEN
	UPDATE SET RoleName = Source.RoleName
WHEN NOT MATCHED BY TARGET THEN
	INSERT (ID, RoleName) VALUES (ID, RoleName)
WHEN NOT MATCHED BY SOURCE THEN
	DELETE;

SET IDENTITY_INSERT [Roles] OFF;