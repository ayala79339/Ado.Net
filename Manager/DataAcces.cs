using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;

namespace Manager
{
    internal class DataAcces
    {
        public int InsertProduct(string connectionString)
        {
            int rowsAffected = 0;
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Insert Product_Name ");
                string Product_Name = Console.ReadLine();
                Console.WriteLine("Insert Category_Id ");
                int Category_Id = int.Parse(Console.ReadLine());
                Console.WriteLine("Insert Price ");
                int Price = int.Parse(Console.ReadLine());
                Console.WriteLine("Insert Description ");
                string Description = Console.ReadLine();
                Console.WriteLine("Insert Image_name ");
                string Image_name = Console.ReadLine();

                string query = "INSERT INTO Products( ProductName, CategoryId, Price, Description, ImageName )"
                    + "VALUES (@Product_Name, @Category_Id, @Price, @Description, @Image_name)";

                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@Product_Name", SqlDbType.NVarChar, 50).Value = Product_Name;
                    cmd.Parameters.Add("@Category_Id", SqlDbType.NVarChar, 50).Value = Category_Id;
                    cmd.Parameters.Add("@Price", SqlDbType.NVarChar, 50).Value = Price;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 50).Value = Description;
                    cmd.Parameters.Add("@Image_name", SqlDbType.NVarChar, 50).Value = Image_name;

                    cn.Open();                    
                    rowsAffected += cmd.ExecuteNonQuery();
                                     
                }
                Console.WriteLine("Do you want to insert data? (y/n)");
                string input = Console.ReadLine();
                if (input.ToLower() == "y")
                {
                    isRunning = true;
                }
                else if (input.ToLower() == "n")
                {
                    isRunning = false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                }
            }
            return rowsAffected;
        }
        public int InsertCategory(string connectionString)
        {
            int rowsAffected = 0;
            bool isRunning = true;
            while (isRunning)
            { 
                Console.WriteLine("Insert Category Name ");
                string CategoryName = Console.ReadLine();
                

                string query = "INSERT INTO Categories(CategoryName) VALUES (@CategoryName)";

                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@CategoryName", SqlDbType.NVarChar, 50).Value = CategoryName;

                    cn.Open();
                    rowsAffected += cmd.ExecuteNonQuery();
                   
                }
                Console.WriteLine("Do you want to insert data? (y/n)");
                string input = Console.ReadLine();
                if (input.ToLower() == "y")
                {
                    isRunning = true;
                }
                else if (input.ToLower() == "n")
                {
                    isRunning = false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                }
            }
            return rowsAffected;
        }

        public void readCategories(string connectionString)
        {

            string queryString = "select * from Categories";
            using (SqlConnection connection =new SqlConnection(connectionString))

            {

                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}",
                        reader[0], reader[1]);

                    }


                    reader.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }

                Console.ReadLine();
            }
        }
        public void readProducts(string connectionString)
        {

            string queryString = "select * from Products";
            using (SqlConnection connection = new SqlConnection(connectionString))

            {

                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                        reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);

                    }


                    reader.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }

                Console.ReadLine();
            }
        }
    }
}
 
