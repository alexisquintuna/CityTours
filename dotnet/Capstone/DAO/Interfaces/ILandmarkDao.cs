using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface ILandmarkDao
    {
        //get all landmarks method
        public List<Landmark> ListAllLandmarks();
    }
}
