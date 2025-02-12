using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
	public interface ICommentRepository<TComment>
	{
		IEnumerable<TComment> GetFromUser(Guid user_id);
		IEnumerable<TComment> GetFromCocktail(Guid cocktail_id);
		TComment Get(Guid id);
		Guid Insert(TComment entity);
		void Update(Guid id, TComment entity);
		void Delete(Guid id);
	}
}