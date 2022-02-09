using PegSolitaire.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PegSolitaire.Service
{
    public interface ICommentService
    {
        void AddComment(Comment comment);

        IList<Comment> GetComment();

        void ClearComment();
    }
}
