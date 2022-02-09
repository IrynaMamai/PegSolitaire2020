using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PegSolitaire.Entity;
using PegSolitaire.Service;

namespace PegSolitaireWeb.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private IScoreService _scoreService = new ScoreServiceEF();

        // GET: api/Score
        [HttpGet]
        public IEnumerable<Score> Get()
        {
            return _scoreService.GetTopScores();
        }

        // POST: api/Score
        [HttpPost]
        public void Post([FromBody] Score score)
        {
            _scoreService.AddScore(score);
        }
    }
}