using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni.Model;

namespace Uni.Model.Common
{
    public interface IStudent
    {
        int Id { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string IdNumber { get; set; }

        
    }
}
