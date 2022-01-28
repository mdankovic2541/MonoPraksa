using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Uni.Model;

namespace Uni.Service.Common
{
    public interface ISmjerService
    {
        Task<List<Smjer>> GetAll();



        Task<Smjer> GetById(int id);



        Task<bool> Post(Smjer smjer);



        Task<bool> Put(int id, Smjer smjer);



        Task<bool> DeleteById(int id);
    }
}
