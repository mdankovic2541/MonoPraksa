using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Uni.Model;

namespace Uni.Repository.Common
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAll();


        Task<Student> GetById(int id);


        Task<bool> Post(Student smjer);


        Task<bool> Put(int id, Student smjer);


        Task<bool> DeleteById(int id);
        
    }
}
