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

       
        public SmjerService()
        {
        }

        protected IStudentRepository StudentRepository = new StudentRepository();
        protected ISmjerRepository Repository = new SmjerRepository();

        public async Task<List<Smjer>> GetAllAsync(string sortby, string sortmethod)
        {
            List<Smjer> smjerovi = new List<Smjer>();
            Sorter sorter = new Sorter();
            sorter.SortBy = " firstName";
            sorter.SortMethod = " ASC";
            List<Smjer> smjeroviOld = await Repository.GetAllAsync(sortby,sortmethod); 
            List<Student> studenti = await StudentRepository.GetAllAsync(sorter.SortBy, sorter.SortMethod);
                        
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
            smjer = await Repository.GetByIdAsync(id);
            stud = await StudentRepository.GetByIdAsync(stud.SmjerId);

            Smjer sm = new Smjer();
            sm.Naziv = smjer.Naziv;
            

            return sm;
           
        }

        
        public async Task<bool> PostAsync(Smjer smjer)
        {
            return await Repository.PostAsync(smjer);
        }


        
        public async Task<bool> PutAsync(int id, Smjer smjer)
        {
            return await Repository.PutAsync(id, smjer);
        }

        
        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await Repository.DeleteByIdAsync(id);
        }

    }
}
