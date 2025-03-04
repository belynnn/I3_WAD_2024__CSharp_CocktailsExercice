﻿CREATE TABLE [dbo].[Comment]
(
	[Comment_Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	[Title] NVARCHAR(64) NOT NULL,
	[Content] NVARCHAR(512) NOT NULL,
	[Concern] UNIQUEIDENTIFIER NOT NULL,
	[CreatedAt] DATETIME2 NOT NULL DEFAULT GETDATE(),
	[CreatedBy] UNIQUEIDENTIFIER,
	[Note] TINYINT,
	CONSTRAINT [CK_Comment_Note] CHECK ([Note] IS NULL OR [Note] BETWEEN 0 AND 5),
	CONSTRAINT [FK_Comment_User] FOREIGN KEY ([CreatedBy])
	REFERENCES [User]([User_Id])
	ON DELETE SET NULL,
	CONSTRAINT [FK_Comment_Cocktail] FOREIGN KEY ([Concern])
	REFERENCES [Cocktail]([Cocktail_Id])
	ON DELETE CASCADE,
	CONSTRAINT [PK_Comment] PRIMARY KEY ([Comment_Id])
)
