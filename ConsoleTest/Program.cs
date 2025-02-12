// Test DAL
//using DAL.Entities;
//using DAL.Services;

// Test BLL
using D = DAL.Services;
using BLL.Entities;
using BLL.Services;

namespace ConsoleTest
{
    internal class Program
    {
		static void Main(string[] args)
		{
			#region Test DAL
			/*
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
			*/
			#endregion

			#region Test BLL
			// Initialisation des services DAL
			var commentDalService = new D.CommentService();
			var cocktailDalService = new D.CocktailService();
			var userDalService = new D.UserService();

			Console.WriteLine("\n=== Test BLL ===");

			// 🔹 Injecter la DAL dans la BLL
			var commentService = new BLL.Services.CommentService(commentDalService, cocktailDalService, userDalService);

			// 🔹 Créer un nouvel utilisateur et cocktail (existant dans la BD)
			Guid userId = new Guid("06141db4-c0c6-43be-8d25-4eb6b3cca397");
			Guid cocktailId = new Guid("5f773e1f-b2f9-4c97-8571-03cb30131088");

			// 1️ Ajouter un commentaire via la BLL
			var newBllComment = new Comment(Guid.NewGuid(), "Super Cocktail!", "J'adore ce cocktail, très rafraîchissant!", cocktailId, DateOnly.FromDateTime(DateTime.Now), userId, 4);
			Guid bllCommentId = commentService.Insert(newBllComment);
			Console.WriteLine($"[BLL] Commentaire ajouté avec ID: {bllCommentId}");

			// 2️ Récupérer les commentaires d’un utilisateur via la BLL
			Console.WriteLine("\n[BLL] Commentaires de l'utilisateur:");
			foreach (var comment in commentService.GetFromUser(userId))
			{
				Console.WriteLine($"- {comment.Title}: {comment.Content} (Note: {comment.Note})");
			}

			// 3️ Récupérer les commentaires d’un cocktail via la BLL
			Console.WriteLine("\n[BLL] Commentaires du cocktail:");
			foreach (var comment in commentService.GetFromCocktail(cocktailId))
			{
				Console.WriteLine($"- {comment.Title}: {comment.Content} (Note: {comment.Note})");
			}

			// 4️ Modifier un commentaire via la BLL
			newBllComment.Title = "Cocktail encore meilleur!";
			newBllComment.Content = "Après un second essai, je l'adore encore plus!";
			newBllComment.Note = 5;
			commentService.Update(bllCommentId, newBllComment);
			Console.WriteLine("\n[BLL] Commentaire modifié.");

			// Vérification après modification
			var updatedComment = commentService.Get(bllCommentId);
			Console.WriteLine($"[BLL] Après modification: {updatedComment.Title} - {updatedComment.Content} (Note: {updatedComment.Note})");

			// 5️ Supprimer un commentaire via la BLL
			commentService.Delete(bllCommentId);
			Console.WriteLine("\n[BLL] Commentaire supprimé.");
			#endregion
		}
	}
}