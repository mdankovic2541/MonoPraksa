using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni.Common;
using Uni.Model;

namespace Uni.Service.Common
{
    
    public interface IStudentService
    {
        Task<List<Student>> GetAllAsync(StudentSort sort, Pager pager, StudentFilter filter);



        Task<Student> GetByIdAsync(int id);



        Task<bool> PostAsync(Student smjer);



        Task<bool> PutAsync(int id, Student smjer);



        Task<bool> DeleteByIdAsync(int id);
    }
    
}
