﻿CREATE TABLE [dbo].[Products] (
	[Id] INT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(32) NOT NULL,
	[Code] NVARCHAR(16) NOT NULL,
	[Amount] INT NOT NULL,
	[Price] FLOAT(53) NOT NULL,
	[Category] INT NOT NULL,
	[CreationDate] DATETIME NOT NULL,
	PRIMARY KEY CLUSTERED([Id] ASC),
	UNIQUE NONCLUSTERED([Code] ASC),
	CONSTRAINT [FK_Products_Category] FOREIGN KEY([Category]) REFERENCES [dbo].[Categories]([Id])
);

