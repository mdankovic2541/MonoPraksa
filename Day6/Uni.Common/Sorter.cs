using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni.Common
{
    public class Sorter
    {

        public string SortBy { get; set; }

        public string SortMethod { get; set; } 

        public string Sort(string sortby, string sortmethod)
        {
            return "ORDER BY " + sortby + " " + sortmethod;
        }

    }
}
