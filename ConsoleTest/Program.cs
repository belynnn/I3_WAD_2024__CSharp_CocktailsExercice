﻿// Test DAL
using DAL.Entities;
using DAL.Services;

// Test BLL
//using BLL.Entities;
//using BLL.Services;

namespace ConsoleTest
{
    internal class Program
    {
		static void Main(string[] args)
		{
			// Test DAL
			CommentService commentService = new CommentService();

			Console.WriteLine("=== Test CommentService ===");

			// 1. Insérer un commentaire
			Guid userId = new Guid("e5d87746-d701-466c-9dde-1d3f6af9ade2");
			Guid cocktailId = new Guid("84b8d802-bab9-4c0a-8bc9-0556f8a61476");

			Comment newComment = new Comment
			{
				Title = "Super Cocktail!",
				Content = "J'ai adoré ce cocktail, très rafraîchissant!",
				Concern = cocktailId,
				CreatedBy = userId,
				Note = 5
			};

			Guid newCommentId = commentService.Insert(newComment);
			Console.WriteLine($"Commentaire inséré avec ID: {newCommentId}");

			// 2. Récupérer les commentaires d'un utilisateur
			Console.WriteLine("\nCommentaires de l'utilisateur:");
			foreach (var comment in commentService.GetFromUser(userId))
			{
				Console.WriteLine($"- {comment.Title}: {comment.Content} (Note: {comment.Note})");
			}

			// 3. Récupérer les commentaires d'un cocktail
			Console.WriteLine("\nCommentaires du cocktail:");
			foreach (var comment in commentService.GetFromCocktail(cocktailId))
			{
				Console.WriteLine($"- {comment.Title}: {comment.Content} (Note: {comment.Note})");
			}

			// 4. Mettre à jour un commentaire
			newComment.Title = "Cocktail revisité!";
			newComment.Content = "Après un deuxième essai, je l'aime encore plus!";
			newComment.Note = 4;
			commentService.Update(newCommentId, newComment);
			Console.WriteLine("\nCommentaire mis à jour.");

			// 5. Supprimer un commentaire
			commentService.Delete(newCommentId);
			Console.WriteLine("\nCommentaire supprimé.");
		}
	}
}