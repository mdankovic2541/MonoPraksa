using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni.Model;
using Uni.Repository;
using Uni.Repository.Common;
using Uni.Service;
using Uni.Service.Common;

namespace Uni.Service
{
    public class SmjerService : ISmjerService
    {

       
        public SmjerService()
        {
        }

        protected ISmjerRepository Repository = new SmjerRepository();

        public List<Smjer> GetAll()
        {
            return Repository.GetAll();
        }

        
        public List<Smjer> GetById(int id)
        {
            return Repository.GetById(id);
        }

        
        public bool Post(Smjer smjer)
        {
            return Repository.Post(smjer);
        }


        
        public bool Put(int id, Smjer smjer)
        {
            return Repository.Put(id, smjer);
        }

        
        public bool DeleteById(int id)
        {
            return Repository.DeleteById(id);
        }

    }
}
