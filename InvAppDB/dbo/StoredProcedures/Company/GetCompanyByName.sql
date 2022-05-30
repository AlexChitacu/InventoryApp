CREATE PROCEDURE [dbo].[GetCompanyByName]
	@CompanyName nvarchar(max)
AS
BEGIN
	SELECT * FROM Companies WHERE CompanyName = @CompanyName
END