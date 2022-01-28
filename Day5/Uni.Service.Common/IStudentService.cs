using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni.Model;

namespace Uni.Service.Common
{
    
    public interface IStudentService
    {
        Task<List<Student>> GetAll();



        Task<Student> GetById(int id);



        Task<bool> Post(Student smjer);



        Task<bool> Put(int id, Student smjer);



        Task<bool> DeleteById(int id);
    }
    
}
