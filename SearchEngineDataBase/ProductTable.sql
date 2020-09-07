CREATE TABLE [dbo].[ProductTable]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Product] NVARCHAR(100) NULL, 
    [ProductType] INT NULL, 
    [Date] DATETIME NOT NULL,
    [IsActive] BIT NOT NULL
    )

GO

CREATE INDEX [IX_ItemTable_Id] ON [dbo].[ProductTable] ([Id])

GO

CREATE INDEX [IX_ItemTable_Product_IsActive] ON [dbo].[ProductTable] ([Product], [IsActive])

GO

CREATE INDEX [IX_ItemTable_ProductType_IsActive] ON [dbo].[ProductTable] ([ProductType], [IsActive])
