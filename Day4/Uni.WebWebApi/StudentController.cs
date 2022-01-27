using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Uni.Model;
using Uni.Service;
using Uni.Service.Common;

namespace Uni.WebApi.Controllers
{



    public class StudentController : ApiController
    {



        public StudentController() { }
        protected IStudentService Service = new StudentService();

        [HttpGet]
        public List<Student> GetAll()
        {
            return Service.GetAll();
        }

        [HttpGet]
        public List<Student> GetById(int id)
        {
            return Service.GetById(id);
        }

        [HttpPost]
        public bool Post(Student smjer)
        {
            return Service.Post(smjer);
        }


        [HttpPut]
        public bool Put(int id, Student smjer)
        {
            return Service.Put(id, smjer);
        }

        [HttpDelete]
        public bool DeleteById(int id)
        {
            return Service.DeleteById(id);
        }

    }
}
    

