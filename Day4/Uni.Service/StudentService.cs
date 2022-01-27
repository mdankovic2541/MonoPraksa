using System;
using System.Collections.Generic;
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

        public List<Student> GetAll()
        {
            return Repository.GetAll();
        }


        public List<Student> GetById(int id)
        {
            return Repository.GetById(id);
        }


        public bool Post(Student smjer)
        {
            return Repository.Post(smjer);
        }



        public bool Put(int id, Student smjer)
        {
            return Repository.Put(id, smjer);
        }


        public bool DeleteById(int id)
        {
            return Repository.DeleteById(id);
        }

    }
}
