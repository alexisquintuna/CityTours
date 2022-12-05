using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Landmark
    {
        //create a model using the sql data columns as properties
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Address { get; set; }
        public string Link { get; set; }
    }
}
