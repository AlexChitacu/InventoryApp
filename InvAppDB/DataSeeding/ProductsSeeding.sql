SET IDENTITY_INSERT [Products] ON;

MERGE INTO [Products] AS Target 
USING (VALUES 
(1,	'Materii Prime'),
(2,	'Materii Secundare'),
(3,	'Ambalaje'),
(4,	'Materii Prelucrate'),
(5,	'Deseuri'),
(6,	'Materii reciclabile')
)
	AS Source (ID, ProductName)
ON Target.ID = Source.ID 
WHEN MATCHED AND (ISNULL(Target.ProductName, '') != ISNULL(Source.ProductName, '')) 
THEN
	UPDATE SET ProductName = Source.ProductName
WHEN NOT MATCHED BY TARGET THEN
	INSERT (ID, ProductName) VALUES (ID, ProductName);
--WHEN NOT MATCHED BY SOURCE THEN
--	DELETE;

SET IDENTITY_INSERT [Products] OFF;