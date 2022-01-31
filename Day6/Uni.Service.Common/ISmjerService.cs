using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Uni.Common;
using Uni.Model;

namespace Uni.Service.Common
{
    public interface ISmjerService
    {
        Task<List<Smjer>> GetAllAsync(string sortby, string sortmethod);



        Task<Smjer> GetByIdAsync(int id);



        Task<bool> PostAsync(Smjer smjer);



        Task<bool> PutAsync(int id, Smjer smjer);



        Task<bool> DeleteByIdAsync(int id);
    }
}
