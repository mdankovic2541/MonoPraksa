using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni.Model.Common;

namespace Uni.Model
{
    public class Student : IStudent
    {
        public int Id { get ; set ; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string IdNumber { get; set ; }

        public int SmjerId { get; set ; }

        public Smjer Smjer { get; set; }
    }
}
