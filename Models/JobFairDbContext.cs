using System;
using MySql.Data.MySqlClient;

namespace JobFairApi.Models
{
    public class JobFairDbContext
    {
        public MySqlConnection AccessDatabase()
        {
            string connectionString = "server = localhost; port = 3306; database =jundlm60_job_fair; user = jundlm60_mahsa-kf; password = Mahsa5350315";
            return new MySqlConnection(connectionString);
        }
    }
}