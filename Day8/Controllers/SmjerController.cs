using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Uni.Common;
using Uni.Model;
using Uni.Model.Common;
using Uni.Service;
using Uni.Service.Common;
using Uni.WebWebApi.Models;

namespace Uni.WebApi.Controllers
{

    public class SmjerController : ApiController
    {
        private ISmjerService service;

        public SmjerController(ISmjerService service)
        {
            this.service = service;
        }

        
        public SmjerController() { }

       
        

        

        [HttpGet]
        public async Task<HttpResponseMessage> GetAllAsync(string sortby= "", string sortmethod = "",int itemsperpage=5,int pagenumber = 1,string search ="")
        {
            SmjerSort sort = new SmjerSort(sortby,sortmethod);
            Pager pager = new Pager(itemsperpage,pagenumber);
            SmjerFilter filter = new SmjerFilter(search);
           
            List<SmjerViewModel> smjeroviView = new List<SmjerViewModel>();
           
            List <Smjer> smjerovi = new List<Smjer>();
            smjerovi = await service.GetAllAsync(sort, pager, filter);

            foreach (Smjer sm in smjerovi)
            {
                SmjerViewModel smView = new SmjerViewModel();            
                smView.Naziv = sm.Naziv;

                smView.Studenti = sm.Studenti.Select(s => new StudentViewModel
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    IdNumber = s.IdNumber,
                    SmjerId = s.SmjerId
                    //Smjer = s.Smjer
             
                }).ToList();
                
                

                smjeroviView.Add(smView);
            }
            return Request.CreateResponse(HttpStatusCode.OK, smjeroviView);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetByIdAsync(int id)
        {

            Smjer smjer;
            smjer = await service.GetByIdAsync(id);

            SmjerViewModel smjerView = new SmjerViewModel();
            smjerView.Naziv = smjer.Naziv;

            return Request.CreateResponse(HttpStatusCode.OK, smjerView);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> PostAsync(SmjerViewModel smjerView)
        {
            Smjer smjer = new Smjer();
            smjer.Naziv = smjerView.Naziv;

            return Request.CreateResponse(HttpStatusCode.OK, await service.PostAsync(smjer));
        }
    

        [HttpPut]
        public async Task<HttpResponseMessage> PutAsync(int id, SmjerViewModel smjerView)
        {
            Smjer smjer = new Smjer();
            smjer.Naziv = smjerView.Naziv;

            return Request.CreateResponse(HttpStatusCode.OK, await service.PutAsync(id, smjer));
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteByIdAsync(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await service.DeleteByIdAsync(id));
        }

    }

}
