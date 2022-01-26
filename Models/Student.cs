using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIByMe.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public int smjerId { get; set; }
    }
}