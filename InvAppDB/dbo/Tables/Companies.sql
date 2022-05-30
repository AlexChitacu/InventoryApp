CREATE TABLE [dbo].[Companies] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [CompanyName] NVARCHAR (MAX) NOT NULL,
    [Email] NVARCHAR(MAX) NOT NULL, 
    [CIF] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED ([ID] ASC)
);

