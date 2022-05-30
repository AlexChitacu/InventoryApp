CREATE PROCEDURE [dbo].[GetUserCompany]
	@UserId int
AS
BEGIN
	SELECT C.* FROM Companies C INNER JOIN CompanyUsers CU ON C.ID = CU.CompanyID
	WHERE CU.UserID = @UserId;
END