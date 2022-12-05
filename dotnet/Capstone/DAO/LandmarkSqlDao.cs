﻿using System;
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
                    string sql = "SELECT id, name, description, category, latitude, longitude, address, link FROM landmarks;";
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

        private Landmark GetLandmarkFromReader(SqlDataReader reader)
        {
            Landmark l = new Landmark()
            {
                Id = Convert.ToInt32(reader["id"]),
                Name = Convert.ToString(reader["name"]),
                Description = Convert.ToString(reader["description"]),
                Category = Convert.ToString(reader["category"]),
                Latitude = Convert.ToString(reader["latitude"]),
                Longitude = Convert.ToString(reader["longitude"]),
                Address = Convert.ToString(reader["address"]),
                Link = Convert.ToString(reader["link"]),
            };

            return l;
        }
    }
}
