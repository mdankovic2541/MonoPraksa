using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Uni.Model;
using Uni.Service;
using Uni.Service.Common;
using Uni.WebWebApi.Models;

namespace Uni.WebApi.Controllers
{

    public class SmjerController : ApiController
    {
        public SmjerController() { }

        protected ISmjerService Service = new SmjerService();

        [HttpGet]
        public async Task<List<SmjerViewModel>> GetAll()
        {
            //ISPISUJE SAMO SMJEROVE KOJI IMAJU STUDENTE 
            List<SmjerViewModel> smjeroviView = new List<SmjerViewModel>();
            List<Smjer> smjerovi = new List<Smjer>();
            smjerovi = await Service.GetAll();
            foreach (Smjer sm in smjerovi)
            {
                SmjerViewModel smView = new SmjerViewModel();

                smView.Naziv = sm.Naziv;
                
                smjeroviView.Add(smView);
            }
            return smjeroviView;
        }

        [HttpGet]
        public async Task<SmjerViewModel> GetById(int id)
        {

            Smjer smjer = new Smjer();
            smjer = await Service.GetById(id);

            SmjerViewModel smjerView = new SmjerViewModel();
            smjerView.Naziv = smjer.Naziv;
            
            return smjerView;
        }

        [HttpPost]
        public async Task<bool> Post(Smjer smjer)
        {
            return await Service.Post(smjer);
        }
    

        [HttpPut]
        public async Task<bool> Put(int id, Smjer smjer)
        {
            return await Service.Put(id,smjer);
        }

        [HttpDelete]
        public async Task<bool> DeleteById(int id)
        {
            return await Service.DeleteById(id);
        }

    }

}
