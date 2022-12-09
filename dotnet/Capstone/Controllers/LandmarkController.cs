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
    //[Authorize]
    public class LandmarkController : ControllerBase
    {
        //constructor with dependency injection
        private readonly IUserDao userDao;
        private readonly ILandmarkDao landmarkDao;

        public LandmarkController(IUserDao _userDao, ILandmarkDao _landmarkDao)
        {
            userDao = _userDao;
            landmarkDao = _landmarkDao;
        }

        //http GET all landmarks

        [HttpGet]
        public ActionResult<List<Landmark>> GetListOfLandmarks()
        {
            List<Landmark> landmarks = landmarkDao.ListAllLandmarks();

            if(landmarks != null)
            {
                return Ok(landmarks);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult<Landmark> GetLandmarkById(int id)
        {
            Landmark landmark = landmarkDao.LandmarkById(id);

            if(landmark != null)
            {
                return Ok(landmark);
            }
            return NotFound();
        }

        [HttpGet("/hotspots")]
        public ActionResult<List<Landmark>> GetHotSpotList()
        {
            List<Landmark> hotspots = landmarkDao.LandmarksAdminAdded();
            if(hotspots != null)
            {
                return Ok(hotspots);
            }
            return NotFound();
        }
        //Double check landmark doesn't exist before adding to table
        [HttpPost]
        public ActionResult AddLandmark(Landmark landmark)
        {
            int landmarkId = landmarkDao.CreateLandmark(landmark);

            if(landmarkId != 0)
            {
                return Ok();
            }
            return BadRequest(new { message = "An error occurred and the landmark was not created." });
        }
    }
}
