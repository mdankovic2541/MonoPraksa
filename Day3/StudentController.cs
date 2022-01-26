using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIByMe.Models;

namespace WebAPIByMe.Controllers
{



    public class StudentController : ApiController
    {


        static List<Student> students = new List<Student>()
        {

        };


        [HttpGet]
        public HttpResponseMessage GetAllStudents()
        {
            string queryString = "SELECT student.id, student.firstName, student.lastName, student.idNumber, naziv FROM student, smjer WHERE smjer.id = student.smjerId;";

            using (SqlConnection connection = new SqlConnection("Server = localhost; Database = webapi; Trusted_Connection = True;"))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);

                    DataSet studenti = new DataSet();
                    adapter.Fill(studenti, "Students");
                    connection.Close();
                    return Request.CreateResponse(HttpStatusCode.OK, studenti);
                }
                catch (SqlException ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }
            }

        }

        [HttpGet]
        public HttpResponseMessage GetStudentById(int id)
        {
            string queryString = "SELECT student.id, student.firstName, student.lastName, student.idNumber, naziv FROM student, smjer WHERE smjer.id = student.smjerId AND student.id=" + id + ";";

            using (SqlConnection connection = new SqlConnection("Server = localhost; Database = webapi; Trusted_Connection = True;"))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);

                    DataSet studenti = new DataSet();
                    adapter.Fill(studenti, "Students");
                    connection.Close();
                    return Request.CreateResponse(HttpStatusCode.OK, studenti);
                }
                catch (SqlException ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }

            }
        }

        [HttpPost]
        public HttpResponseMessage PostNewStudent(Student stud)
        {   //U studenta unosim smjer u obliku broja (1,2,3..)
            string queryString = "INSERT INTO student VALUES('" + stud.FirstName + "','" + stud.LastName + "','" + stud.IdNumber + "','" + stud.smjerId + "');";

            using (SqlConnection connection = new SqlConnection("Server = localhost; Database = webapi; Trusted_Connection = True;"))
            {
                try
                {
                    connection.Open();
                    SqlCommand myCommand = new SqlCommand(queryString, connection);

                    myCommand.ExecuteNonQuery();
                    connection.Close();
                    return GetAllStudents();
                    
                }
                catch (SqlException ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }

            }
        }
    

        [HttpPut]
        public HttpResponseMessage PutStudent(int id, Student stud)
        {

            string queryString = "UPDATE student SET firstName='"+stud.FirstName+"', lastName='"+stud.LastName+"', idNumber='"+stud.IdNumber+ "',smjerId='" + stud.smjerId + "' WHERE id='" + id+"';";

            using (SqlConnection connection = new SqlConnection("Server = localhost; Database = webapi; Trusted_Connection = True;"))
            {
                try
                {
                    connection.Open();
                    SqlCommand myCommand = new SqlCommand(queryString, connection);

                    myCommand.ExecuteNonQuery();
                    connection.Close();
                    return GetAllStudents();
                }
                catch (SqlException ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }

            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteStudentById(int id)
        {
            string queryString = "DELETE FROM student WHERE id=" + id + ";";
            //DELETE WORKS ONLY WHEN STUDENT IS NOT CONNECTED WITH ANY COURSE
            using (SqlConnection connection = new SqlConnection("Server = localhost; Database = webapi; Trusted_Connection = True;"))
            {
                try
                {
                    connection.Open();
                    SqlCommand myCommand = new SqlCommand(queryString, connection);
                    myCommand.ExecuteNonQuery();
                    connection.Close();
                    return GetAllStudents();
                }
                catch (SqlException ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }

            }

        }

    }
}
    

