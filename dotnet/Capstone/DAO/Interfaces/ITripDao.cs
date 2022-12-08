using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface ITripDao
    {
        public List<Trip> TripsByUserId(int userId);
        public void AddLandmarkToTrip(int tripId, int landmarkId);
        public int CreateTrip(int userId, Trip trip);
        public void RemoveLandmark(int tripId, int landmarkId);
        public void RemoveTrip(int tripId, int userId);
    }
}
