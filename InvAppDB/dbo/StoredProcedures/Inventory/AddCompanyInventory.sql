CREATE PROCEDURE [dbo].[AddCompanyInventory]
	@CompanyId int,
	@ProductId int,
	@DepoId int,
	@Ammount int
AS
BEGIN
	DECLARE @CurrentAmmount int;

	IF EXISTS (SELECT * FROM CompanyInventory WHERE CompanyId = @CompanyId AND ProductID = @ProductId AND DepoID = @DepoId)
	BEGIN
		SET @CurrentAmmount = (SELECT Ammount FROM CompanyInventory WHERE CompanyId = @CompanyId AND ProductID = @ProductId AND DepoID = @DepoId)

		UPDATE CompanyInventory SET Ammount = (@CurrentAmmount + @Ammount) WHERE CompanyId = @CompanyId AND ProductID = @ProductId AND DepoID = @DepoId
	END
	ELSE
	BEGIN
		INSERT INTO CompanyInventory (CompanyId, ProductID, DepoID, Ammount) VALUES (@CompanyId, @ProductId, @DepoId, @Ammount);
	END
END
