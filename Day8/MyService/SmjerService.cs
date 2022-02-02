using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni.Common;
using Uni.Model;
using Uni.Repository;
using Uni.Repository.Common;
using Uni.Service;
using Uni.Service.Common;

namespace Uni.Service
{
    public class SmjerService : ISmjerService
    {
        ISmjerRepository repository;
        public SmjerService(ISmjerRepository repository)
        {
            this.repository = repository;
        }


        public SmjerService()
        {
        }

         StudentRepository StudentRepository = new StudentRepository();
        

        

        public async Task<List<Smjer>> GetAllAsync(SmjerSort sort, Pager pager,SmjerFilter filter)
        {
            List<Smjer> smjerovi = new List<Smjer>();
            StudentSort sorter = new StudentSort("","");
            StudentFilter studFilter = new StudentFilter("");
            List<Smjer> smjeroviOld = await repository.GetAllAsync(sort,pager, filter); 
            List<Student> studenti = await StudentRepository.GetAllAsync(sorter,pager,studFilter);
                        
            foreach (Smjer smjer in smjeroviOld)
            {
              
                Smjer sm = new Smjer();
                List<Student> stud = new List<Student>();
                sm.Naziv = smjer.Naziv;

                sm.Studenti = studenti.Where(s => s.SmjerId == smjer.Id).ToList();

                smjerovi.Add(sm);
              
                
            }
            return smjerovi;
        }

        
        public async Task<Smjer> GetByIdAsync(int id)
        {
            Student stud = new Student();
            Smjer smjer = new Smjer();
            smjer = await repository.GetByIdAsync(id);
            stud = await StudentRepository.GetByIdAsync(stud.SmjerId);

            Smjer sm = new Smjer();
            sm.Naziv = smjer.Naziv;
            

            return sm;
           
        }

        
        public async Task<bool> PostAsync(Smjer smjer)
        {
            return await repository.PostAsync(smjer);
        }


        
        public async Task<bool> PutAsync(int id, Smjer smjer)
        {
            return await repository.PutAsync(id, smjer);
        }

        
        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await repository.DeleteByIdAsync(id);
        }

    }
}
