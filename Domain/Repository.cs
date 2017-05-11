using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Repository : IRepository
    {
        SqlConnection connection;

        public Repository(string address)
        {
            connection = new SqlConnection(address);
        }

        public Product GetEntity(long id)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Products] WHERE id = " + id, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            Product buff = new Product();
            while (reader.Read())
            {
                buff.id = reader.GetInt32(0);
                buff.name = reader.GetString(1);
                buff.country = reader.GetString(2);
                buff.coust = reader.GetDouble(3);
            }
            connection.Close();
            return buff;
        }


        public List<Product> GetProducts()
        {
            List<Product> list = new List<Product>();

            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Products]", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Product buff = new Product();

                buff.id = reader.GetInt32(0);
                buff.name = reader.GetString(1);
                buff.country = reader.GetString(2);
                buff.coust = reader.GetDouble(3);

                list.Add(buff);
            }
            connection.Close();
            return list;
        }


        public void EditProduct(Product updatedEntity)
        {
            connection.Open();

            string com = string.Format("UPDATE[dbo].[Products] SET[Name] = '{0}', [Country] = '{1}', [Coust] = '{2}' WHERE[id] = {3}",
                updatedEntity.name, updatedEntity.country, updatedEntity.coust, updatedEntity.id);
            SqlCommand cmd = new SqlCommand(com, connection);
            cmd.ExecuteNonQuery();

            connection.Close();
        }


        public void RemoveProduct(Product updatedEntity)
        {
            connection.Open();

            string com = string.Format("DELETE FROM [dbo].[Products] WHERE  [id] = {0}, [Name] = '{1}', [Country] = '{2}', [Coust] = '{3}'",
                updatedEntity.id, updatedEntity.name, updatedEntity.country, updatedEntity.coust);
            SqlCommand cmd = new SqlCommand(com, connection);
            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}
