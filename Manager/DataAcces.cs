using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;

namespace Manager
{
    internal class DataAcces
    {
        public int InsertData (string connectionString)
        { 

        Console.WriteLine("Insert Email Address ");
            string Product_Name = Console.ReadLine();
        Console.WriteLine("Insert Password Address ");
            string Category_Id = Console.ReadLine();
        Console.WriteLine("Insert FirstName Address ");
            string Price = Console.ReadLine();
        Console.WriteLine("Insert LastName Address ");
            string Description = Console.ReadLine();
        Console.WriteLine("Insert LastName Address ");
            string Image_name = Console.ReadLine();

            string query = "INSERT INTO ayala_user(Email,Password,LastNamw,FirstName)"
                + "VALUES (@Product_Name, @Category_Id, @Price, @Description, @Image_name)";

            using (SqlConnection cn = new SqlConnection(connectionString)) 
            using (SqlCommand cmd = new SqlCommand(query,cn))
            {
                cmd.Parameters.Add("@Product_Name", SqlDbType.NVarChar, 50).Value = Product_Name;
                cmd.Parameters.Add("@Category_Id", SqlDbType.NVarChar, 50).Value = Category_Id;
                cmd.Parameters.Add("@Price",SqlDbType.NVarChar, 50).Value = Price;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 50).Value = Description;
                cmd.Parameters.Add("@Image_name", SqlDbType.NVarChar, 50).Value = Image_name;

                cn.Open();
                int rowsAffected=cmd.ExecuteNonQuery();
                cn.Close();
                return rowsAffected;
            }

           



        }
    }
}
