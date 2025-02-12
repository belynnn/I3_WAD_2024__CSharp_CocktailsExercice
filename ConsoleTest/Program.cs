// Test DAL
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

			//// 1. Insérer un commentaire
			Guid userId = new Guid("31d7e0f4-529c-4384-97ae-379d72a0dd8d");
			Guid cocktailId = new Guid("21c3f40b-d45b-4823-8216-00f510ecd8db");

			Comment newComment = new Comment
			{
				Title = "Super Cocktail!",
				Content = "J'ai adoré ce cocktail, très rafraîchissant!",
				Concern = cocktailId,
				CreatedBy = userId,
				Note = 3
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
			newComment.Note = 5;
			commentService.Update(newCommentId, newComment);
			Console.WriteLine("\nCommentaire mis à jour.");
			Console.WriteLine("\n=== Commentaire après modification ===");
			Console.WriteLine($"ID: {newCommentId}");
			Console.WriteLine($"Titre: {newComment.Title}");
			Console.WriteLine($"Contenu: {newComment.Content}");
			Console.WriteLine($"Note: {newComment.Note}");

			// 5. Supprimer un commentaire
			commentService.Delete(newCommentId);
			Console.WriteLine("\nCommentaire supprimé.");
		}
	}
}