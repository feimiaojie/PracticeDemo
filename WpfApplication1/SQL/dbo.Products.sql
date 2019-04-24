CREATE TABLE [dbo].[Products] (
    [ProductId]    INT             NOT NULL,
    [CategoryId]   INT             NULL,
    [ModelNumber]  NVARCHAR (50)   NULL,
    [ModelName]    NVARCHAR (50)   NULL,
    [ProductImage] NVARCHAR (50)   NULL,
    [UnitCost]     MONEY           NULL,
    [Description]  NVARCHAR (3800) NULL,
    PRIMARY KEY CLUSTERED ([ProductId] ASC),
    CONSTRAINT [FK_Products_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([CategoryId])
);

