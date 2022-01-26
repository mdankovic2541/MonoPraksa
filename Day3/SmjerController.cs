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

    public class SmjerController : ApiController
    {


        static List<Smjer> smjerovi = new List<Smjer>()
        {

        };


        [HttpGet]
        public HttpResponseMessage GetAllSmjerovi()
        {
            string queryString = "SELECT * FROM Smjer;";

            using (SqlConnection connection = new SqlConnection("Server = localhost; Database = webapi; Trusted_Connection = True;"))
            {
                try
                {
                    connection.Open();
                    SqlCommand myCommand = new SqlCommand(queryString, connection);
                    SqlDataReader myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        Smjer smjer = new Smjer();
                        smjer.Id = int.Parse(myReader["id"].ToString());
                        smjer.Naziv = myReader["naziv"].ToString();
                        smjerovi.Add(smjer);
                    }
                    myReader.Close();
                    connection.Close();
                    return Request.CreateResponse(HttpStatusCode.OK, smjerovi);
                }
                catch (SqlException ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }
            }

        }

        [HttpGet]
        public HttpResponseMessage GetSmjerById(int id)
        {
            string queryString = "SELECT * FROM smjer WHERE id=" + id + ";";

            using (SqlConnection connection = new SqlConnection("Server = localhost; Database = webapi; Trusted_Connection = True;"))
            {
                try
                {
                    connection.Open();
                    SqlCommand myCommand = new SqlCommand(queryString, connection);
                    SqlDataReader myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        Smjer smjer = new Smjer();
                        smjer.Id = int.Parse(myReader["id"].ToString());
                        smjer.Naziv = myReader["naziv"].ToString();
                        smjerovi.Add(smjer);
                    }
                    myReader.Close();
                    connection.Close();
                    return Request.CreateResponse(HttpStatusCode.OK, smjerovi);
                }
                catch (SqlException ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }

            }
        }

        [HttpPost]
        public HttpResponseMessage PostNewSmjer(Smjer smjer)
        {
            string queryString = "INSERT INTO smjer VALUES('" + smjer.Naziv + "');";

            using (SqlConnection connection = new SqlConnection("Server = localhost; Database = webapi; Trusted_Connection = True;"))
            {
                try
                {
                    connection.Open();
                    SqlCommand myCommand = new SqlCommand(queryString, connection);

                    myCommand.ExecuteNonQuery();
                    connection.Close();
                    return GetAllSmjerovi();
                    
                }
                catch (SqlException ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }

            }
        }
    

        [HttpPut]
        public HttpResponseMessage PutSmjer(int id, Smjer smjer)
        {

            string queryString = "UPDATE smjer SET naziv='"+smjer.Naziv+"'WHERE id='"+id+"';";

            using (SqlConnection connection = new SqlConnection("Server = localhost; Database = webapi; Trusted_Connection = True;"))
            {
                try
                {
                    connection.Open();
                    SqlCommand myCommand = new SqlCommand(queryString, connection);

                    myCommand.ExecuteNonQuery();
                    connection.Close();
                    return GetAllSmjerovi();
                }
                catch (SqlException ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }

            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteSmjerById(int id)
        {
            string queryString = "DELETE FROM smjer WHERE id=" + id + ";";
            //DELETE WORKS ONLY WHEN SMJER IS NOT CONNECTED WITH ANY STUDENT
            using (SqlConnection connection = new SqlConnection("Server = localhost; Database = webapi; Trusted_Connection = True;"))
            {
                try
                {
                    connection.Open();
                    SqlCommand myCommand = new SqlCommand(queryString, connection);
                    myCommand.ExecuteNonQuery();
                    connection.Close();
                    return GetAllSmjerovi();
                }
                catch (SqlException ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }

            }

        }

    }

}
