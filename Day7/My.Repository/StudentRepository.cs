using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Uni.Common;
using Uni.Model;
using Uni.Model.Common;
using Uni.Repository.Common;

namespace Uni.Repository
{
    public class StudentRepository : IStudentRepository
    {

        public StudentRepository() { }

        protected IStudent student = new Student();

        public async Task<List<Student>> GetAllAsync(StudentSort sort, Pager pager, StudentFilter filter)
        {
            List<Student> studentiLista = new List<Student>();
            string queryString = $"SELECT * FROM student {filter.Query} ORDER BY {sort.SortBy} {sort.SortMethod} OFFSET {(pager.PageNumber - 1) * pager.ItemsPerPage} ROWS FETCH NEXT {pager.ItemsPerPage} ROWS ONLY;";

            using (SqlConnection connection = new SqlConnection("Server = localhost; Database = webapi; Trusted_Connection = True;"))
            {

                connection.Open();
                SqlCommand myCommand = new SqlCommand(queryString, connection);
                SqlDataReader myReader = await myCommand.ExecuteReaderAsync();
                    
                while (myReader.Read())
                {
                    Student stud = new Student();
                    stud.Smjer = new Smjer();
                    stud.Id = int.Parse(myReader["id"].ToString());
                    stud.FirstName = myReader["firstName"].ToString();
                    stud.LastName = myReader["lastName"].ToString();
                    stud.IdNumber = myReader["idNumber"].ToString();      
                    stud.SmjerId = int.Parse(myReader["smjerId"].ToString());
                    studentiLista.Add(stud);
                }
                myReader.Close();
                connection.Close();
                return studentiLista;

            }

        }
        
        public async Task<Student> GetByIdAsync(int id)
        {


            string queryString = "SELECT * FROM student WHERE id=" + id+";";
            using (SqlConnection connection = new SqlConnection("Server = localhost; Database = webapi; Trusted_Connection = True;"))
            {

                Student stud = new Student();
                connection.Open();
                SqlCommand myCommand = new SqlCommand(queryString, connection);
                SqlDataReader myReader = await myCommand.ExecuteReaderAsync();

                while (myReader.Read())
                {
                   
                    stud.Smjer = new Smjer();
                    stud.Id = int.Parse(myReader["id"].ToString());
                    stud.FirstName = myReader["firstName"].ToString();
                    stud.LastName = myReader["lastName"].ToString();
                    stud.IdNumber = myReader["idNumber"].ToString();
                    stud.SmjerId = int.Parse(myReader["smjerId"].ToString());
                    
                    
                }
                myReader.Close();
                connection.Close();
                return stud;
            }
            
           
        }

        
        public async Task<bool> PostAsync(Student stud)
        {  
            string queryString = "INSERT INTO student VALUES('" + stud.FirstName + "','" + stud.LastName + "','" + stud.IdNumber + "','" + stud.SmjerId + "');";

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


        
        public async Task<bool> PutAsync(int id, Student stud)
        {

            string queryString = "UPDATE student SET firstName='" + stud.FirstName + "', lastName='" + stud.LastName + "', idNumber='" + stud.IdNumber + "',smjerId='" + stud.SmjerId + "' WHERE id='" + id + "';";

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

        
        public async Task<bool> DeleteByIdAsync(int id)
        {
            string queryString = "DELETE FROM student WHERE id=" + id + ";";
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
