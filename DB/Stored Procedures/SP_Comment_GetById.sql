CREATE PROCEDURE [dbo].[SP_Comment_GetById]
	@comment_id UNIQUEIDENTIFIER
AS
BEGIN
	SELECT	[Comment_Id],
			[Title], 
			[Content],
			[Concern],
			[CreatedBy],
			[CreatedAt],
			[Note]
		FROM [Comment]
	WHERE [Comment_Id] = @comment_id
END