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
        List<Student> GetAll();



        List<Student> GetById(int id);



        bool Post(Student smjer);



        bool Put(int id, Student smjer);



        bool DeleteById(int id);
    }
    
}
