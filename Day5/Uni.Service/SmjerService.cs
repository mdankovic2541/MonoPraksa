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

        protected IStudentRepository StudentRepository = new StudentRepository();
        protected ISmjerRepository Repository = new SmjerRepository();

        public async Task<List<Smjer>> GetAll()
        {
            List<Smjer> smjerovi = new List<Smjer>();
            List<Smjer> smjeroviOld = new List<Smjer>();
            List<Student> studentiNovi = new List<Student>();
            smjeroviOld = await Repository.GetAll();
            studentiNovi = await StudentRepository.GetAll();
            foreach (Smjer smjer in smjeroviOld)
            {
                foreach (Student stud in studentiNovi)
                {
                    if (smjer.Id == stud.SmjerId)
                    {
                        Smjer sm = new Smjer();
                        sm.Naziv = smjer.Naziv;
                        sm.Studenti = new List<Student>();
                        sm.Studenti.Add(stud);
                        smjerovi.Add(sm);
                    }
                }
            }
            return smjerovi;
        }

        
        public async Task<Smjer> GetById(int id)
        {
            Student stud = new Student();
            Smjer smjer = new Smjer();
            smjer = await Repository.GetById(id);
            stud = await StudentRepository.GetById(stud.SmjerId);

            Smjer sm = new Smjer();
            sm.Naziv = smjer.Naziv;
            

            return sm;
           
        }

        
        public async Task<bool> Post(Smjer smjer)
        {
            return await Repository.Post(smjer);
        }


        
        public async Task<bool> Put(int id, Smjer smjer)
        {
            return await Repository.Put(id, smjer);
        }

        
        public async Task<bool> DeleteById(int id)
        {
            return await Repository.DeleteById(id);
        }

    }
}
