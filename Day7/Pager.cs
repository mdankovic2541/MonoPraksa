using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni.Common
{
    public class Pager
    {
        private int itemsPerPage = 0, pageNumber = 3;


        public int ItemsPerPage
        {
            get { return itemsPerPage; }
            set { itemsPerPage = value; }
        }

        public int PageNumber
        {
            get { return pageNumber; }
            set { pageNumber = value; }
        }



        public Pager(int itemsPerPage, int pageNumber)
        {
            if (itemsPerPage != 0)
            {
                this.itemsPerPage = itemsPerPage;
            }
            if (pageNumber != 0)
            {
                this.pageNumber = pageNumber;
            }
        }


        

    }
}
