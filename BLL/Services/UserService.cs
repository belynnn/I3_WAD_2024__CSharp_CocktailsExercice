using BLL.Entities;
using BLL.Mappers;
using D = DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Repositories;
using DAL.Services;

namespace BLL.Services
{
    public class UserService : IUserRepository<User>
    {
		private ICommentRepository<DAL.Entities.Comment> _commentService;
		private ICocktailRepository<DAL.Entities.Cocktail> _cocktailService;
		private IUserRepository<DAL.Entities.User> _userService;

		public UserService(
			ICommentRepository<DAL.Entities.Comment> commentService,
			ICocktailRepository<DAL.Entities.Cocktail> cocktailService,
			IUserRepository<DAL.Entities.User> userService
			)
		{
			_commentService = commentService;
			_cocktailService = cocktailService;
			_userService = userService;
		}

		public IEnumerable<User> Get()
        {
            return _userService.Get().Select(dal => dal.ToBLL());
        }

        public User Get(Guid user_id) { 
            User user = _userService.Get(user_id).ToBLL();
            user.Cocktails = _cocktailService.GetFromUser(user_id).Select(dal => dal.ToBLL());
            return user;
        }

        public Guid Insert(User user)
        {
            return _userService.Insert(user.ToDAL());
        }

        public void Update(Guid user_id, User user)
        {
            _userService.Update(user_id, user.ToDAL());
        }

        public void Delete(Guid user_id) {
            _userService.Delete(user_id);
        }

        public Guid CheckPassword(string email, string password)
        {
            return _userService.CheckPassword(email, password);
        }
    }
}