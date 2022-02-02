using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uni.Common;
using Uni.Model;
using Uni.Repository;
using Uni.Repository.Common;
using Uni.Service.Common;

namespace Uni.Service
{
    public class StudentService : IStudentService
    {
        IStudentRepository repository;
        public StudentService(IStudentRepository repository)
        {
            this.repository = repository;
        }

       

        public StudentService()
        {
        }


        protected ISmjerRepository SmjerRepository = new SmjerRepository();

        public async Task<List<Student>> GetAllAsync(StudentSort sort, Pager pager, StudentFilter filter)
        {
            List<Smjer> smjerovi;
            List<Student> studenti;
            List<Student> studentiNovi = new List<Student>();
            SmjerSort sorterSmjer = new SmjerSort("","");
            var smjerPaging = new Pager(100, 0);
            SmjerFilter smjerFilter = new SmjerFilter("");
            
            smjerovi = await SmjerRepository.GetAllAsync(sorterSmjer,smjerPaging,smjerFilter);
            studenti = await repository.GetAllAsync(sort,pager,filter);
            foreach (Student student in studenti)
            {
                Student stud = new Student();
                stud.FirstName = student.FirstName;
                stud.LastName = student.LastName;
                stud.IdNumber = student.IdNumber;
                stud.SmjerId = student.SmjerId;
                stud.Smjer = smjerovi.Where(s => s.Id == student.SmjerId).FirstOrDefault();
               
                studentiNovi.Add(stud);
            }



            return studentiNovi;
        }


        public async Task<Student> GetByIdAsync(int id)
        {

            Student stud;
            Smjer smjer;         
            stud = await repository.GetByIdAsync(id);
            smjer = await SmjerRepository.GetByIdAsync(stud.SmjerId);
            
            Student student = new Student();
            student.Smjer = smjer;
            student.FirstName = stud.FirstName;
            student.LastName = stud.LastName;
            student.IdNumber = stud.IdNumber;
            student.SmjerId = smjer.Id;

            return student;
        }


        public async Task<bool> PostAsync(Student smjer)
        {
            return await repository.PostAsync(smjer);
        }



        public async Task<bool> PutAsync(int id, Student smjer)
        {
            return await repository.PutAsync(id, smjer);
        }


        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await repository.DeleteByIdAsync(id);
        }

    }
}
