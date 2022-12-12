using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly IUserDao userDao;
        private readonly ILandmarkDao landmarkDao;
        private readonly ITripDao tripDao;

        public TripsController(IUserDao _userDao, ILandmarkDao _landmarkDao, ITripDao _tripDao)
        {
            userDao = _userDao;
            landmarkDao = _landmarkDao;
            tripDao = _tripDao;
        }
        
        [HttpGet]
        public ActionResult<List<Trip>> GetTripsByUserId()
        {
            string username = User.Identity.Name;
            User user = userDao.GetUser(username);
            List<Trip> trips = tripDao.TripsByUserId(user.UserId);

            if (trips != null)
            {
                return Ok(trips);
            }
            return NotFound();
        }

        [HttpGet("{tripId}")]
        public ActionResult<List<Landmark>> GetLandmarksByTripId(int tripId)
        {
            List<Landmark> landmarks = landmarkDao.LandmarksByTripId(tripId);

            if(landmarks != null)
            {
                return Ok(landmarks);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<List<Trip>> AddTrip(Trip trip)
        {
            string username = User.Identity.Name;
            User user = userDao.GetUser(username);
            int tripId=tripDao.CreateTrip(user.UserId, trip);
            List<Trip> trips = tripDao.TripsByUserId(user.UserId);

            if (tripId != 0)
            {
                return Ok(trips);
            }
            return BadRequest(new { message = "An error occurred and the trip was not created." });
        }
        
        [HttpPost("{tripId}")]
        public ActionResult AddLandmarkToTrip(int tripId, Landmark landmark)
        {
            int landmarkId = landmarkDao.CreateLandmark(landmark);
            tripDao.AddLandmarkToTrip(tripId, landmarkId);

            List<Landmark> landmarks = landmarkDao.LandmarksByTripId(tripId);

            if (landmarks != null) //<---this doesn't do what you think
            {
                return Ok();
            }
            return BadRequest(new { message = "An error occurred and the landmark was not created." });
        }
        //Todo action results for both delete routes
        [HttpDelete("{tripId}/{landmarkId}")]
        public ActionResult<List<Landmark>> DeleteLandmarkFromTrip(int tripId, int landmarkId)
        {
            tripDao.RemoveLandmark(tripId, landmarkId);
            List<Landmark> landmarks = landmarkDao.LandmarksByTripId(tripId);

            if (landmarks != null)
            {
                return Ok(landmarks);
            }
            return NotFound();
        }

        [HttpDelete("{tripId}")]
        public ActionResult<List<Trip>> DeleteTrip(int tripId)
        {
            string username = User.Identity.Name;
            User user = userDao.GetUser(username);
            tripDao.RemoveTrip(tripId, user.UserId);
            List<Trip> trips = tripDao.TripsByUserId(user.UserId);

            if (tripId != 0)
            {
                return Ok(trips);
            }
            return BadRequest(new { message = "Not a valid trip." });
        }

    }
}
