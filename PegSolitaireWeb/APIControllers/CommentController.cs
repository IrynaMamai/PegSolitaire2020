using Microsoft.AspNetCore.Mvc;
using PegSolitaire.Entity;
using PegSolitaire.Service;
using System.Collections.Generic;

namespace PegSolitaireWeb.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentService _commentService = new CommentServiceEF();

        // GET: api/Comment
        [HttpGet]
        public IEnumerable<Comment> Get()
        {
            return _commentService.GetComment();
        }

        // POST: api/Comment
        [HttpPost]
        public void Post([FromBody] Comment comment)
        {
            _commentService.AddComment(comment);
        }
    }
}