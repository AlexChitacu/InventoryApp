CREATE PROCEDURE [dbo].[GetCompanyUserRole]
	@CompanyId int,
	@UserId int
AS
BEGIN
	SELECT R.* FROM CompanyUsers CU INNER JOIN Roles R
	ON CU.RoleID = R.Id
	WHERE CU.CompanyID = @CompanyId AND CU.UserID = @UserId;
END
