using Common.Repositories;
using BLL.Entities;
using BLL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class CommentService : ICommentRepository<Comment>
	{
		private ICommentRepository<DAL.Entities.Comment> _commentService;
		private ICocktailRepository<DAL.Entities.Cocktail> _cocktailService;
		private IUserRepository<DAL.Entities.User> _userService;

		public CommentService(
			ICommentRepository<DAL.Entities.Comment> commentService,
			ICocktailRepository<DAL.Entities.Cocktail> cocktailService,
			IUserRepository<DAL.Entities.User> userService
			)
		{
			_commentService = commentService;
			_cocktailService = cocktailService;
			_userService = userService;
		}

		public Comment Get(Guid comment_id)
		{
			Comment comment = _commentService.Get(comment_id).ToBLL();
			if (comment.CreatedBy is not null)
			{
				comment.Commentator = _userService.Get((Guid)comment.CreatedBy).ToBLL();
			}
			return comment;
		}

		public IEnumerable<Comment> GetFromUser(Guid user_id)
		{
			return _commentService.GetFromUser(user_id).Select(dal => dal.ToBLL());
		}

		public IEnumerable<Comment> GetFromCocktail(Guid cocktail_id)
		{
			return _commentService.GetFromCocktail(cocktail_id).Select(dal => dal.ToBLL());
		}

		public Guid Insert(Comment comment)
		{
			return _commentService.Insert(comment.ToDAL());
		}

		public void Update(Guid cocktail_id, Comment comment)
		{
			_commentService.Update(cocktail_id, comment.ToDAL());
		}

		public void Delete(Guid comment_id)
		{
			_commentService.Delete(comment_id);
		}
	}
}
