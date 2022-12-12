using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;

namespace Capstone.DAO
{
    public class LandmarkSqlDao : ILandmarkDao
    {
        //get all landmarks from sql database
        private readonly string connectionString;

        public LandmarkSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Landmark> ListAllLandmarks()
        {
            List<Landmark> landmarks = new List<Landmark>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT landmark_id, name, description, category, latitude, longitude, address, link, photo FROM landmarks;";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        landmarks.Add(GetLandmarkFromReader(reader));
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return landmarks;
        }

        public Landmark LandmarkById(int landmarkId)
        {
            Landmark landmark = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT landmark_id, name, description, category, latitude, longitude, address, link, photo FROM landmarks WHERE landmark_id = @landmark_id;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@landmark_id", landmarkId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        landmark = GetLandmarkFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return landmark;
        }

        public List<Landmark> LandmarksAdminAdded()
        {
            List<Landmark> hotspots = new List<Landmark>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT landmark_id, name, description, category, latitude, longitude, address, link, photo FROM landmarks WHERE added_by=@added_by;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@added_by", "admin");
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        hotspots.Add(GetLandmarkFromReader(reader));
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return hotspots;
        }

        public List<Landmark> LandmarksByTripId(int tripId)
        {
            List<Landmark> landmarks = new List<Landmark>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT landmarks.landmark_id, name, description, category, latitude, longitude, address, link, photo FROM landmarks JOIN trip_landmark ON landmarks.landmark_id = trip_landmark.landmark_id WHERE trip_landmark.trip_id = @trip_id;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@trip_id", tripId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        landmarks.Add(GetLandmarkFromReader(reader));
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return landmarks;
        }
        
        public int CreateLandmark(Landmark landmark)
        {
            int landmarkId=0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO landmarks(name, description, category, latitude, longitude, address, link, added_by, photo) " +
                        "OUTPUT INSERTED.landmark_id " +
                        "VALUES(@name, @description, @category, @latitude, @longitude, @address, @link, @added_by, @photo);";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", landmark.Name);
                    cmd.Parameters.AddWithValue("@description", landmark.Description);
                    cmd.Parameters.AddWithValue("@category", landmark.Category);
                    cmd.Parameters.AddWithValue("@latitude", landmark.Latitude);
                    cmd.Parameters.AddWithValue("@longitude", landmark.Longitude);
                    cmd.Parameters.AddWithValue("@address", landmark.Address);
                    cmd.Parameters.AddWithValue("@link", landmark.Link);
                    cmd.Parameters.AddWithValue("@added_by", "admin");
                    cmd.Parameters.AddWithValue("@photo", landmark.Photo);

                    landmarkId =(int)cmd.ExecuteScalar();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return landmarkId;
        }

        private Landmark GetLandmarkFromReader(SqlDataReader reader)
        {
            Landmark l = new Landmark()
            {
                Id = Convert.ToInt32(reader["landmark_id"]),
                Name = Convert.ToString(reader["name"]),
                Description = Convert.ToString(reader["description"]),
                Category = Convert.ToString(reader["category"]),
                Latitude = Convert.ToString(reader["latitude"]),
                Longitude = Convert.ToString(reader["longitude"]),
                Address = Convert.ToString(reader["address"]),
                Link = Convert.ToString(reader["link"]),
                //AddedBy = Convert.ToString(reader["added_by"]),
                Photo = Convert.ToString(reader["photo"]),
            };

            return l;
        }
    }
}
