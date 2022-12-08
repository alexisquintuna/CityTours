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
