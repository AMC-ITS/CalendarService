using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DateMicroservice.Data
{
    public class BaseDataAccess
    {
        public string ConnectionString { get; set; }

        public BaseDataAccess(string connectionString = null)
        {
            ConnectionString = connectionString;
        }

        public List<T> RunQuery<T>(string commandText, List<SqlParameter> parameters = null) where T: BaseSqlQueryResult
        {
            var myList = new List<T>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                if (parameters != null)
                {
                    foreach (SqlParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        myList.Add((T)Activator.CreateInstance<T>().HandleReader(reader));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return myList;
        }

        public T RunSingleRowQuery<T>(string commandText, List<SqlParameter> parameters = null) where T : BaseSqlQueryResult
        {
            var myList = new List<T>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                if (parameters != null)
                {
                    foreach (SqlParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        myList.Add((T)Activator.CreateInstance<T>().HandleReader(reader));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return myList.Count > 0 ? myList[0] : null;
        }
    }
}
