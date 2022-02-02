using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Uni.Common;
using Uni.Model;
using Uni.Service;
using Uni.Service.Common;
using Uni.WebWebApi.Models;

namespace Uni.WebApi.Controllers
{



    public class StudentController : ApiController
    {
        IStudentService service;
        public StudentController(IStudentService service)
        {
            this.service = service;
        }

        

        public StudentController() { }


        [HttpGet]
        public async Task<HttpResponseMessage> GetAllAsync(string sortby="", string sortmethod="",int itemsPerPage=5, int pageNumber=1,string search = "")
        {
            List<StudentViewModel> studentiView = new List<StudentViewModel>();
            StudentSort sort = new StudentSort(sortby,sortmethod);
            Pager pager = new Pager(itemsPerPage,pageNumber);
            StudentFilter filter = new StudentFilter(search);
            List<Student> studenti = await service.GetAllAsync(sort,pager,filter);

            foreach (Student stud in studenti)
            {
                StudentViewModel studView = new StudentViewModel();
                  
                studView.FirstName = stud.FirstName;
                studView.LastName = stud.LastName;
                studView.IdNumber = stud.IdNumber;
                studView.Smjer = stud.Smjer.Naziv;
                studView.SmjerId = stud.SmjerId;

                studentiView.Add(studView);
            }
            return Request.CreateResponse(HttpStatusCode.OK, studentiView);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetByIdAsync(int id)
        {
           

            Student stud;
            stud = await service.GetByIdAsync(id);
           
            StudentViewModel studView = new StudentViewModel();
            studView.FirstName = stud.FirstName;
            studView.LastName = stud.LastName;
            studView.IdNumber = stud.IdNumber;
            studView.Smjer = stud.Smjer.Naziv;
            studView.SmjerId = stud.SmjerId;


            return Request.CreateResponse(HttpStatusCode.OK, studView);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> PostAsync(StudentViewModel student)
        {
            Student stud = new Student();
            stud.FirstName = student.FirstName;
            stud.LastName = student.LastName;
            stud.IdNumber = student.IdNumber;
            stud.SmjerId= student.SmjerId;
            

            return Request.CreateResponse(HttpStatusCode.OK,await service.PostAsync(stud));
        }


        [HttpPut]
        public async Task<HttpResponseMessage> PutAsync(int id, StudentViewModel student)
        {
            Student stud = new Student();
            stud.FirstName = student.FirstName;
            stud.LastName = student.LastName;
            stud.IdNumber = student.IdNumber;
            stud.SmjerId = student.SmjerId;
            

            return Request.CreateResponse(HttpStatusCode.OK,await service.PutAsync(id,stud));
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteByIdAsync(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await service.DeleteByIdAsync(id));
        }

    }
}
    

