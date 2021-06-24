using System;
using System.Collections.Generic;

using JobFairApi.Models;
using MySql.Data.MySqlClient;

namespace JobFairApi.Repository
{
    public class RegistrationRepository
    {
        private JobFairDbContext dbContex = new JobFairDbContext();

        public IEnumerable<Registration> GetRegistrations()
        {
            MySqlConnection Conn = dbContex.AccessDatabase();
            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "Select * from Registration";
            cmd.Prepare();
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            List<Registration> registrations = new List<Registration>();

            while (ResultSet.Read())
            {
                Registration newRegistration = new Registration();
                newRegistration.RegistrationID = (int)ResultSet["RegistrationID"];
                newRegistration.FirstName = (string)ResultSet["FirstName"];
                newRegistration.LastName = (string)ResultSet["LastName"];
                newRegistration.Email = (string)ResultSet["Email"];
                newRegistration.PhoneNumber = (string)ResultSet["PhoneNumber"];
                newRegistration.Website = (string)ResultSet["Website"];
                newRegistration.UserTyple = (string)ResultSet["UserTyple"];
                newRegistration.Message = (string)ResultSet["Message"];

                registrations.Add(newRegistration);
            }

            Conn.Close();

            return registrations;
        }

        public void AddRegistration(Registration newRegistration)
        {
            MySqlConnection Conn = dbContex.AccessDatabase();
            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();
            //SQL QUERY
            cmd.CommandText = "insert into Registration (FirstName, LastName, Email, PhoneNumber, Website, UserTyple, Message, CreatedDateTime) values (@FirstName, @LastName, @Email, @PhoneNumber, @Website, @UserTyple, @Message, NOW())";

            cmd.Parameters.AddWithValue("@FirstName", newRegistration.FirstName);
            cmd.Parameters.AddWithValue("@LastName", newRegistration.LastName);
            cmd.Parameters.AddWithValue("@Email", newRegistration.Email);
            cmd.Parameters.AddWithValue("@PhoneNumber", newRegistration.PhoneNumber);
            cmd.Parameters.AddWithValue("@Website", newRegistration.Website);
            cmd.Parameters.AddWithValue("@UserTyple", newRegistration.UserTyple);
            cmd.Parameters.AddWithValue("@Message", newRegistration.Message);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
            Conn.Close();
        }
    }
}