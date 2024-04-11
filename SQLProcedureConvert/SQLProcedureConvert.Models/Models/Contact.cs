using SQLProcedureConvert.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLProcedureConvert.Domain.Models
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; }
        //public List<Application> applications { get; set; }

    }
}
