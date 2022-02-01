using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uni.WebWebApi.Models
{
    public class SmjerViewModel
    {
        public string Naziv { get; set; }

        public List<StudentViewModel> Studenti { get; set; }
    }
}