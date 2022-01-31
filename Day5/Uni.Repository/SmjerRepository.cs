using System.Collections.Generic;
using System.Data.SqlClient;
using Uni.Model;
using Uni.Repository.Common;
using Uni.Model.Common;
using System.Threading.Tasks;

namespace Uni.Repository
{
    public class SmjerRepository : ISmjerRepository
    {
        public SmjerRepository() { }

        protected ISmjer smjer = new Smjer();


        public async Task<List<Smjer>> GetAll()
        {
            List<Smjer> smjerovi = new List<Smjer>();
            
            string queryString = "SELECT * FROM Smjer;";

            using (SqlConnection connection = new SqlConnection("Server = localhost; Database = webapi; Trusted_Connection = True;"))
            {
                
                connection.Open();
                SqlCommand myCommand = new SqlCommand(queryString, connection);
                SqlDataReader myReader = await myCommand.ExecuteReaderAsync();

                while (myReader.Read())
                {
                    Smjer smjer = new Smjer();
                    smjer.Studenti = new List<Student>();
                    smjer.Id = int.Parse(myReader["id"].ToString());
                    smjer.Naziv = myReader["naziv"].ToString();
                    
                    smjerovi.Add(smjer);
                }
                myReader.Close();
                connection.Close();
                return smjerovi;
                             
            }

        }

       
        public async Task<Smjer> GetById(int id)
        {
            

            string queryString = "SELECT * FROM smjer WHERE id=" + id + ";";

            using (SqlConnection connection = new SqlConnection("Server = localhost; Database = webapi; Trusted_Connection = True;"))
            {
               
                connection.Open();
                SqlCommand myCommand = new SqlCommand(queryString, connection);
                SqlDataReader myReader = await myCommand.ExecuteReaderAsync();
                Smjer smjer = new Smjer();
                while (myReader.Read())
                {

                    smjer.Id = int.Parse(myReader["id"].ToString());
                    smjer.Naziv = myReader["naziv"].ToString();

                }
                connection.Close();
                return smjer;
                
            }
        }

        
        public async Task<bool> Post(Smjer smjer)
        {
            
            string queryString = "INSERT INTO smjer VALUES('" + smjer.Naziv + "');";

            using (SqlConnection connection = new SqlConnection("Server = localhost; Database = webapi; Trusted_Connection = True;"))
            {
                try 
                { 
                
                    connection.Open();
                    SqlCommand myCommand = new SqlCommand(queryString, connection);

                    await myCommand.ExecuteNonQueryAsync();
                    connection.Close();
                    return true;

                }
                catch (SqlException ex)
                {
                return false;
                }

            }
        }


        
        public async Task<bool> Put(int id, Smjer smjer)
        {
            List<Smjer> smjerovi = new List<Smjer>();

            string queryString = "UPDATE smjer SET naziv='" + smjer.Naziv + "'WHERE id='" + id + "';";

            using (SqlConnection connection = new SqlConnection("Server = localhost; Database = webapi; Trusted_Connection = True;"))
            {
                try
                {
                    connection.Open();
                    SqlCommand myCommand = new SqlCommand(queryString, connection);

                    await myCommand.ExecuteNonQueryAsync();
                    connection.Close();
                    return true;
                }
                catch (SqlException ex)
                {
                    return false;
                }

            }
        }

        
        public async Task<bool> DeleteById(int id)
        {
            string queryString = "DELETE FROM smjer WHERE id=" + id + ";";
            
            using (SqlConnection connection = new SqlConnection("Server = localhost; Database = webapi; Trusted_Connection = True;"))
            {
                try
                {
                    connection.Open();
                    SqlCommand myCommand = new SqlCommand(queryString, connection);
                    await myCommand.ExecuteNonQueryAsync();
                    connection.Close();
                    return true;
                }
                catch (SqlException ex)
                {
                    return false;
                }

            }

        }

    }

}



