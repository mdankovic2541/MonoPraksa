using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Uni.Model;
using Uni.Repository;
using Uni.Repository.Common;
using Uni.Service.Common;

namespace Uni.Service
{
    public class StudentService : IStudentService
    {
       

        public StudentService()
        {
        }

        protected IStudentRepository Repository = new StudentRepository();
        protected ISmjerRepository SmjerRepository = new SmjerRepository();

        public async Task<List<Student>> GetAll()
        {
            List<Smjer> smjerovi = new List<Smjer>();
            List<Student> studenti = new List<Student>();
            List<Student> studentiNovi = new List<Student>();
            smjerovi = await SmjerRepository.GetAll();
            studenti = await Repository.GetAll();
            foreach (Student student in studenti)
            {
                foreach (Smjer sm in smjerovi)
                {
                    if (student.SmjerId == sm.Id)
                    {
                        Student stud = new Student();
                        stud.Smjer = new Smjer();
                        stud.FirstName = student.FirstName;
                        stud.LastName = student.LastName;
                        stud.IdNumber = student.IdNumber;
                        stud.Smjer = sm;
                        stud.Smjer.Naziv = sm.Naziv;
                        studentiNovi.Add(stud);
                    }
                }
            }



            return studentiNovi;
        }


        public async Task<Student> GetById(int id)
        {
           
            Student stud = new Student();
            Smjer smjer = new Smjer();           
            stud = await Repository.GetById(id);
            smjer = await SmjerRepository.GetById(stud.SmjerId);
            
            Student student = new Student();
            student.Smjer = new Smjer();
            student.FirstName = stud.FirstName;
            student.LastName = stud.LastName;
            student.Smjer = smjer;
                
            return student;
        }


        public async Task<bool> Post(Student smjer)
        {
            return await Repository.Post(smjer);
        }



        public async Task<bool> Put(int id, Student smjer)
        {
            return await Repository.Put(id, smjer);
        }


        public async Task<bool> DeleteById(int id)
        {
            return await Repository.DeleteById(id);
        }

    }
}
