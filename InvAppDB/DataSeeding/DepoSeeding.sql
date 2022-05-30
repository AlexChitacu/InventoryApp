SET IDENTITY_INSERT [Depos] ON;

MERGE INTO [Depos] AS Target 
USING (VALUES 
(1,	'Transit', 'N/A'),
(2,	'Headquarters', 'N/A'),
(3, 'Brico Depo', 'Romania, Bucharest, Calea Giulesti 3'),
(4, 'DEPO (SC Compact SRL)', 'Romania, Bucharest, Street Lunca Oltului 28'),
(5, 'Green Office Solution', 'Romania, Bucharest, Main Street Petre Povat 79'),
(6, 'AMF Office Logistics,', 'Romania, Bucharest, Street Cornu Luncii 39')
)
	AS Source (ID, DepoName, [Address])
ON Target.ID = Source.ID 
WHEN MATCHED AND (ISNULL(Target.DepoName, '') != ISNULL(Source.DepoName, '') OR ISNULL(Target.[Address], '') != ISNULL(Source.[Address], '')) 
THEN
	UPDATE SET DepoName = Source.DepoName,
	[Address] = Source.[Address] 
WHEN NOT MATCHED BY TARGET THEN
	INSERT (ID, DepoName, [Address] ) VALUES (ID, DepoName, [Address]);
--WHEN NOT MATCHED BY SOURCE THEN
	--DELETE;

SET IDENTITY_INSERT [Depos] OFF;