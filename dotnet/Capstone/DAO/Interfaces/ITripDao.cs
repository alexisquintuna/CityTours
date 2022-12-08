using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface ITripDao
    {
        public List<Trip> TripsByUserId(int userId);
    }
}
