CREATE PROCEDURE [dbo].[GetCompanyUsersForDisplay]
	@CompanyID int
AS
BEGIN
	SELECT U.ID as ID, U.UserName as UserName, U.Email as UserEmail, R.RoleName as [Role] FROM CompanyUsers CU 
	INNER JOIN Users U ON CU.UserID = U.ID
	INNER JOIN Companies C ON C.ID = CU.CompanyID
	INNER JOIN Roles R ON R.Id = CU.RoleID
	WHERE C.ID = @CompanyID
END
