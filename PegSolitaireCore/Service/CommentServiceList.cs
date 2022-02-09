using PegSolitaire.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace PegSolitaire.Service
{
    public class CommentServiceList : ICommentService
    {
        private const string FileName = "comment.bin";

        private List<Comment> comments = new List<Comment>();

        public void AddComment(Comment comment)
        {
            if (comment == null)
                throw new CommentException("Comment must be not null!");
            if (comment.Name == null)
                throw new CommentException("Comment contains null Name!");
            comments.Add(comment);
            SaveComment();
        }

        public IList<Comment> GetComment()
        {
            LoadComment();
            return (from c in comments orderby c.Comments descending select c).ToList();

        }

        public void ClearComment()
        {
            comments.Clear();
            File.Delete(FileName);
        }

        private void SaveComment()
        {
            using (var fs = File.OpenWrite(FileName))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(fs, comments);
            }
        }

        private void LoadComment()
        {
            if (File.Exists(FileName))
            {
                using (var fs = File.OpenRead(FileName))
                {
                    var bf = new BinaryFormatter();
                    comments = (List<Comment>)bf.Deserialize(fs);
                }
            }
        }

    }
}