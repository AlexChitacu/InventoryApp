CREATE PROCEDURE [dbo].[GetCompanyByCIF]
	@CIF nvarchar(max)
AS
BEGIN
	SELECT * FROM Companies WHERE CIF = @CIF;
END
