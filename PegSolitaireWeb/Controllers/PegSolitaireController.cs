using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PegSolitaire.Core;
using PegSolitaire.Entity;
using PegSolitaire.Service;
using PegSolitaireWeb.Models;

namespace PegSolitaireWeb.Controllers
{
    public class PegSolitaireController : Controller
    {
        IScoreService _scoreService = new ScoreServiceEF();
        ICommentService _commentService = new CommentServiceEF();
        IRatingService _ratingService = new RatingServiceEF();
       
        [BindProperty]
        public string User_Name { get; set; }

        [BindProperty, Required]
        public string Star { get; set; }

        public IActionResult Index(int map)
        {
            if (map == 0)  map = 6;
                   
            Field field = new Field(map);
            HttpContext.Session.SetObject("field", field);

            var model = PrepareModel("New field created (map : " + map + ")");
            return View(model);
        }

        public IActionResult Move(int row, int column, bool type, int score)
        {
            var field = (Field)HttpContext.Session.GetObject("field");

            field.MoveTileForWeb(row, column, type); 
            field.Score = score;

            HttpContext.Session.SetObject("field", field);

            var  model = PrepareModel("Moved");
            return View("Index", model);
        }


        public IActionResult AddScore()
        {

            var field = (Field)HttpContext.Session.GetObject("field");
            _scoreService.AddScore(new Score { Name = User_Name, Points = field.Score });
            

            var model = PrepareModel("Add score");
            return View("Index", model);
        }



        public IActionResult AddCommentAndRating()
        {
            _commentService.AddComment(new Comment { Name = User_Name, Comments = Request.Form["Comment"] });
            _ratingService.AddOrSetRating(new Rating { Name = User_Name, Rating_player = Int32.Parse(Star) });
           
            var model = PrepareModel("Add comment");
            return View("Index", model);
        }


        private PegSolitaireModel PrepareModel(string message)
        {
            return new PegSolitaireModel
            {
                Field = (Field)HttpContext.Session.GetObject("field"),
                Message = message,
                Scores = _scoreService.GetTopScores(),
                Comments = _commentService.GetComment()
            };
        }
    }
}