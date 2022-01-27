using System.Collections.Generic;
using System.Web.Http;
using Uni.Model;
using Uni.Service;
using Uni.Service.Common;

namespace Uni.WebApi.Controllers
{

    public class SmjerController : ApiController
    {
        public SmjerController() { }

        protected ISmjerService Service = new SmjerService();

        [HttpGet]
        public List<Smjer> GetAll()
        {
            return Service.GetAll();
        }

        [HttpGet]
        public List<Smjer> GetById(int id)
        {
            return Service.GetById(id);
        }

        [HttpPost]
        public bool Post(Smjer smjer)
        {
            return Service.Post(smjer);
        }
    

        [HttpPut]
        public bool Put(int id, Smjer smjer)
        {
            return Service.Put(id,smjer);
        }

        [HttpDelete]
        public bool DeleteById(int id)
        {
            return Service.DeleteById(id);
        }

    }

}
