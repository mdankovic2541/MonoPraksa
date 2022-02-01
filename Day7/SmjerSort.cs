using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni.Common
{
    public class SmjerSort
    {
        private string sortby= "naziv";
        private string sortmethod = "ASC";

        public string SortBy { get { return sortby; } set { sortby = value; } }

        public string SortMethod { get { return sortmethod; } set { sortmethod = value; } }


        public SmjerSort(string sortby, string sortmethod)
        {
            if (sortby != "")
            {
                this.sortby = sortby;
            }
            if (sortmethod != "")
            {
                this.sortmethod = sortmethod;
            }
        }

       
    }
}
