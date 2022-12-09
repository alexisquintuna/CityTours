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
    public class TripSqlDao : ITripDao
    {
        private readonly string connectionString;

        public TripSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Trip> TripsByUserId(int userId)
        {
            List<Trip> trips = new List<Trip>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT trip_id, trip_name FROM trips WHERE user_id = @user_id;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        trips.Add(GetTripFromReader(reader));
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return trips;
        }

        public void AddLandmarkToTrip(int tripId, int landmarkId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO trip_landmark(trip_id, landmark_id) " +
                        "VALUES(@trip_id, @landmark_id);";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@trip_id", tripId);
                    cmd.Parameters.AddWithValue("@landmark_id", landmarkId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public int CreateTrip(int userId, Trip trip)
        {
            int tripId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO trips(trip_name, user_id) " +
                        "OUTPUT INSERTED.trip_id " +
                        "VALUES(@trip_name, @user_id);";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@trip_name", trip.Name);
                    cmd.Parameters.AddWithValue("@user_id", userId);

                    tripId=(int)cmd.ExecuteScalar();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return tripId;
        }

        public void RemoveLandmark(int tripId, int landmarkId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM trip_landmark WHERE trip_id=@trip_id AND landmark_id=@landmark_id;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@trip_id", tripId);
                    cmd.Parameters.AddWithValue("@landmark_id", landmarkId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }
        public void RemoveTrip(int tripId, int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "BEGIN TRANSACTION; " +
                        "DELETE FROM trip_landmark WHERE trip_id=@trip_id;" +
                        "DELETE FROM trips WHERE trip_id=@trip_id AND user_id=@user_id;" +
                        "COMMIT;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@trip_id", tripId);
                    cmd.Parameters.AddWithValue("@user_id", userId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        private Trip GetTripFromReader(SqlDataReader reader)
        {
            Trip t = new Trip()
            {
                Id = Convert.ToInt32(reader["trip_id"]),
                Name = Convert.ToString(reader["trip_name"]),
            };

            return t;
        }
    }
}
