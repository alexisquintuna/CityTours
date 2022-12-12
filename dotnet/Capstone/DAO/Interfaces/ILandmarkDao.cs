using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface ILandmarkDao
    {
        //get all landmarks method
        public List<Landmark> ListAllLandmarks();
        public Landmark LandmarkById(int landmarkId);
        public List<Landmark> LandmarksByTripId(int tripId);
        public int CreateLandmark(Landmark landmark);
        public int AdminCreateLandmark(Landmark landmark);
        public List<Landmark> LandmarksAdminAdded();
    }
}
