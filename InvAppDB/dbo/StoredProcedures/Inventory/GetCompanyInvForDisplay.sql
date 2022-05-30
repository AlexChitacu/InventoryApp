CREATE PROCEDURE [dbo].[GetCompanyInvForDisplay]
	@CompanyID int
AS
BEGIN
	SELECT CI.ID as ID, P.ProductName as ProductName,
	CI.Ammount as ProductQuantity, D.DepoName as DepoName
	FROM CompanyInventory CI 
	INNER JOIN Companies C ON C.ID = CI.CompanyId
	INNER JOIN Products P ON P.Id = CI.ProductID
	INNER JOIN Depos D ON D.Id = CI.DepoID
	WHERE C.ID = @CompanyID
END