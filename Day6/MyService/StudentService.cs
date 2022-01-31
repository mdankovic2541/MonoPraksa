using System;
using System.Collections.Generic;
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
       

        public StudentService()
        {
        }

        protected IStudentRepository Repository = new StudentRepository();
        protected ISmjerRepository SmjerRepository = new SmjerRepository();

        public async Task<List<Student>> GetAllAsync(string sortby, string sortmethod)
        {
            List<Smjer> smjerovi;
            List<Student> studenti;
            List<Student> studentiNovi = new List<Student>();
            Sorter sorter = new Sorter();
            sorter.SortBy = " naziv";
            sorter.SortMethod = " ASC";
            smjerovi = await SmjerRepository.GetAllAsync(sorter.SortBy, sorter.SortMethod);
            studenti = await Repository.GetAllAsync(sortby,sortmethod);
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
                        stud.Smjer= sm;                       
                        stud.SmjerId = sm.Id;
                        studentiNovi.Add(stud);
                    }
                }
            }



            return studentiNovi;
        }


        public async Task<Student> GetByIdAsync(int id)
        {

            Student stud;
            Smjer smjer;         
            stud = await Repository.GetByIdAsync(id);
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
            return await Repository.PostAsync(smjer);
        }



        public async Task<bool> PutAsync(int id, Student smjer)
        {
            return await Repository.PutAsync(id, smjer);
        }


        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await Repository.DeleteByIdAsync(id);
        }

    }
}
