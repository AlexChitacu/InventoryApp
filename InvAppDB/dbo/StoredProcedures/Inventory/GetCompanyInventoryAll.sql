CREATE PROCEDURE [dbo].[GetCompanyInventoryAll]
	@companyID int = 0
AS
BEGIN
	SELECT * FROM CompanyInventory WHERE CompanyId = @companyID;
END
