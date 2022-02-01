using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni.Model.Common;

namespace Uni.Model
{
    public class Smjer : ISmjer
    {
        public int Id { get; set; }

        public string Naziv { get; set; }

        public List<Student> Studenti { get; set; }
    }
}
