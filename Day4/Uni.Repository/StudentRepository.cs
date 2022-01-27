using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Uni.Model;
using Uni.Model.Common;
using Uni.Repository.Common;

namespace Uni.Repository
{
    public class StudentRepository : IStudentRepository
    {

        public StudentRepository() { }

        protected IStudent student = new Student();

        public List<Student> GetAll()
        {
            List<Student> studentiLista = new List<Student>();

            string queryString = "SELECT * FROM student";

            using (SqlConnection connection = new SqlConnection("Server = localhost; Database = webapi; Trusted_Connection = True;"))
            {

                connection.Open();
                SqlCommand myCommand = new SqlCommand(queryString, connection);
                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    Student stud = new Student();
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
        
        public List<Student> GetById(int id)
        {

            List<Student> studentiLista = new List<Student>();
            string queryString = "SELECT * FROM student;";

            using (SqlConnection connection = new SqlConnection("Server = localhost; Database = webapi; Trusted_Connection = True;"))
            {

                connection.Open();
                SqlCommand myCommand = new SqlCommand(queryString, connection);
                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    Student stud = new Student();
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

        
        public bool Post(Student stud)
        {  
            string queryString = "INSERT INTO student VALUES('" + stud.FirstName + "','" + stud.LastName + "','" + stud.IdNumber + "','" + stud.SmjerId + "');";

            using (SqlConnection connection = new SqlConnection("Server = localhost; Database = webapi; Trusted_Connection = True;"))
            {
                try
                {
                    connection.Open();
                    SqlCommand myCommand = new SqlCommand(queryString, connection);

                    myCommand.ExecuteNonQuery();
                    connection.Close();
                    return true;

                }
                catch (SqlException ex)
                {
                    return false;
                }

            }
        }


        
        public bool Put(int id, Student stud)
        {

            string queryString = "UPDATE student SET firstName='" + stud.FirstName + "', lastName='" + stud.LastName + "', idNumber='" + stud.IdNumber + "',smjerId='" + stud.SmjerId + "' WHERE id='" + id + "';";

            using (SqlConnection connection = new SqlConnection("Server = localhost; Database = webapi; Trusted_Connection = True;"))
            {
                try
                {
                    connection.Open();
                    SqlCommand myCommand = new SqlCommand(queryString, connection);

                    myCommand.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch (SqlException ex)
                {
                    return false;
                }

            }
        }

        
        public bool DeleteById(int id)
        {
            string queryString = "DELETE FROM student WHERE id=" + id + ";";
            using (SqlConnection connection = new SqlConnection("Server = localhost; Database = webapi; Trusted_Connection = True;"))
            {
                try
                {
                    connection.Open();
                    SqlCommand myCommand = new SqlCommand(queryString, connection);
                    myCommand.ExecuteNonQuery();
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
