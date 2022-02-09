using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PegSolitaire.Entity;
using PegSolitaire.Service;

namespace PegSolitaireWeb.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private IRatingService _ratingService = new RatingServiceEF();

        // GET: api/Rating
        [HttpGet]
        public IEnumerable<Rating> Get()
        {
            return _ratingService.GetRatings();
        }

        /////////////////Averege rating////////////////////////////
        /*
        
        [HttpGet]
        public IEnumerable<double> GetAverage()
        {
            yield return _ratingService.GetAverageRating();
        }

        */
        //////////////////////////////////////////////////////////


        // POST: api/Rating
        [HttpPost]
        public void Post([FromBody] Rating rating)
        {
            _ratingService.AddOrSetRating(rating);
        }
    }
}