using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Uni.Common;
using Uni.Model;

namespace Uni.Repository.Common
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync(string sortby, string sortmethod);


        Task<Student> GetByIdAsync(int id);


        Task<bool> PostAsync(Student smjer);


        Task<bool> PutAsync(int id, Student smjer);


        Task<bool> DeleteByIdAsync(int id);
        
    }
}
