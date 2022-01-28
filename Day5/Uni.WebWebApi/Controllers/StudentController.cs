using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Uni.Model;
using Uni.Service;
using Uni.Service.Common;
using Uni.WebWebApi.Models;

namespace Uni.WebApi.Controllers
{



    public class StudentController : ApiController
    {



        public StudentController() { }
        protected IStudentService Service = new StudentService();

        [HttpGet]
        public async Task<List<StudentViewModel>> GetAll()
        {
            List<StudentViewModel> studentiView = new List<StudentViewModel>();
            List<Student> studenti = new List<Student>();
            studenti = await Service.GetAll();
            foreach(Student  stud in studenti)
            {
                StudentViewModel studView = new StudentViewModel();
                  
                studView.FirstName = stud.FirstName;
                studView.LastName = stud.LastName;
                studView.Smjer = stud.Smjer.Naziv;
                
                studentiView.Add(studView);
            }
            return  studentiView;
        }

        [HttpGet]
        public async Task<StudentViewModel> GetById(int id)
        {
           

            Student stud = new Student();
            stud = await Service.GetById(id);
           
            StudentViewModel studView = new StudentViewModel();
            studView.FirstName = stud.FirstName;
            studView.LastName = stud.LastName;
            studView.Smjer = stud.Smjer.Naziv;
            return studView;
        }

        [HttpPost]
        public async Task<bool> Post(Student smjer)
        {
            return await Service.Post(smjer);
        }


        [HttpPut]
        public async Task<bool> Put(int id, Student smjer)
        {
            return await Service.Put(id, smjer);
        }

        [HttpDelete]
        public async Task<bool> DeleteById(int id)
        {
            return await Service.DeleteById(id);
        }

    }
}
    

