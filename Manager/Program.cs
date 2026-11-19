using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {

                DataAcces dataAcces=new DataAcces();             
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=shop_prog;Integrated Security=True";
                int rowsAffected = dataAcces.InsertCategory(connectionString);
                dataAcces.readCategories(connectionString);
            int rowsAffected2 = dataAcces.InsertProduct(connectionString);  
                dataAcces.readProducts(connectionString);
            Console.WriteLine($"Rows affected in categories: {rowsAffected}, Products: {rowsAffected2}");
            
           
        }
    }
}
