CREATE TABLE [dbo].[ProductTypePriotry]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ProductType] INT NOT NULL, 
    [Priotry] INT NOT NULL
)

GO

CREATE INDEX [IX_ProductTypePriotry_ProductType] ON [dbo].[ProductTypePriotry] ([ProductType])
