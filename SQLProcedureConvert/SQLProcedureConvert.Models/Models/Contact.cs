using SQLProcedureConvert.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLProcedureConvert.Models.Models
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Application> applications { get; set; }
    }
}
