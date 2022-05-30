CREATE PROCEDURE [dbo].[CreateCompanyUser]
	@CompanyId int,
	@UserName nvarchar(max),
	@UserEmail nvarchar(max),
	@UserPassword nvarchar(max),
	@UserRole nvarchar(max)
AS
BEGIN
	INSERT INTO Users(UserName, UserPassword, Email) 
	VALUES (@UserName, @UserPassword, @UserEmail)

	INSERT INTO CompanyUsers(CompanyID, UserID, RoleID)
	VALUES 
	(@CompanyId,
	(SELECT ID FROM Users WHERE	UserName = @UserName),
	(SELECT ID FROM Roles WHERE RoleName = @UserRole)
	)
END
