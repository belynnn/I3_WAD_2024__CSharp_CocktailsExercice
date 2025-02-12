using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
	public class Comment
	{
		public Guid Comment_Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public Guid Concern { get; set; }
		public DateOnly CreatedAt { get; set; }
		public Guid? CreatedBy { get; set; }
		public int? Note { get; set; }
		public User? Commentator { get; set; }

		public Comment(Guid comment_Id, string title, string content, Guid concern, DateOnly createdAt, Guid? createdBy, int? note)
		{
			Comment_Id = comment_Id;
			Title = title;
			Content = content;
			Concern = concern;
			CreatedAt = createdAt;
			CreatedBy = createdBy;
			Note = note;
		}
	}
}