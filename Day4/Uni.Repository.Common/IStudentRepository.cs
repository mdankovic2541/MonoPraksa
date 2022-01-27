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
        List<Student> GetAll();


        List<Student> GetById(int id);

        
        bool Post(Student smjer);

        
        bool Put(int id, Student smjer);


        bool DeleteById(int id);
        
    }
}
