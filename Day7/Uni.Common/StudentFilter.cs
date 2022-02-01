using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni.Common
{
    public class StudentFilter
    {

        private string search = "";
        private string query = "";


        public string Search
        {
            get { return search; }
            set { search = value; }
        }

        public string Query
        {
            get { return query; }
        }




        public StudentFilter(string search)
        {
            if (search != "")
            {
                this.search = search;
                query = "WHERE firstName LIKE '%" + search + "%'";
            }
        }
       

    }
}
