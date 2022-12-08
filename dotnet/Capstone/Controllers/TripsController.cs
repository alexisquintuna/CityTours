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

        [HttpGet("{id}")]
        public ActionResult<List<Trip>> GetTripsByUserId(int id)
        {
            List<Trip> trips = tripDao.TripsByUserId(id);

            if(trips != null)
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

        [HttpPost("{tripId}")]
        public ActionResult<List<Landmark>> AddLandmarkByTripId(int tripId, Landmark landmark)
        {

        }

    }
}
