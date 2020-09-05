using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace MYSQL
{
    class Connections
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public Connections()
        {
            Init();
        }

        private void Init()
        {
            server = "localhost";
            database = "office";//"petshop";
            uid = "root";
            password = "Mazda636";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        public void Select()
        {
            List<Jobs> jobList = new List<Jobs>();

            string query = "SELECT jobName, jobDescription FROM jobs";

            if (this.Open() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    jobList.Add(new Jobs(reader["jobName"].ToString(), reader["jobDescription"].ToString()));
                }

                reader.Close();

                this.Close();

                foreach (Jobs job in jobList)
                {
                    Console.WriteLine(job.jobName + "," + job.jobDescr);
                }
            }
            else
            {
                Console.WriteLine("Cannot be opened");
            }
        }

        public void Insert()
        {
            string query = "INSERT INTO jobs (jobName, jobDescription) VALUES ('Electrician', 'Makes wires')";
            if (this.Open() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
      
                this.Close();                
            }
            else
            {
                Console.WriteLine("Cannot be opened");
            }
        }

        public bool Open()
        {
            try
            {
                connection.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Close()
        {
            try
            {
                connection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
