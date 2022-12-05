using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface ILandmarkDao
    {
        //get all landmarks method
        public List<Landmark> ListAllLandmarks();
        public Landmark LandmarkById(int landmarkId);
    }
}
