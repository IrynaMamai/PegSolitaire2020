using Microsoft.EntityFrameworkCore;
using PegSolitaire.Entity;
using System.Collections.Generic;
using System.Linq;


namespace PegSolitaire.Service
{
    public class CommentServiceEF : ICommentService
    {
        public void AddComment(Comment comment)
        {
            using (var context = new PegSolitaireDbContext())
            {
                context.Comments.Add(comment);
                context.SaveChanges();
                ///ClearComment();
            }
        }

        public void ClearComment()
        {
            using (var context = new PegSolitaireDbContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM Comments");
            }
        }

        public IList<Comment> GetComment()
        {
            using (var context = new PegSolitaireDbContext())
            {
                return (from c in context.Comments
                        orderby c.Id
                            descending
                        select c).Take(10).ToList();
            }
        }
    }
}
