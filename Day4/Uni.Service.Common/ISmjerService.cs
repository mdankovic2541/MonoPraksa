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
        List<Smjer> GetAll();



        List<Smjer> GetById(int id);



        bool Post(Smjer smjer);



        bool Put(int id, Smjer smjer);



        bool DeleteById(int id);
    }
}
