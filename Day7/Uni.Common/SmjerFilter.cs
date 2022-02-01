using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni.Common
{
    public class SmjerFilter
    {

        private string search = "";
        private string query = "";


        public string Name
        {
            get { return search; }
            set { search = value; }
        }

        public string Query
        {
            get { return query; }
        }



        public SmjerFilter(string search)
        {
            if (search != "")
            {
                this.search = search;
                query = "WHERE naziv LIKE '%" + search + "%'";
            }
        }
      

    }

}
