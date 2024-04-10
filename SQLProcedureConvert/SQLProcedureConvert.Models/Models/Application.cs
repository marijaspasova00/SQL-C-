using SQLProcedureConvert.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLProcedureConvert.Domain.Models
{
    public class Application : BaseEntity
    {
        [ForeignKey("Contact")]
        public int ContactID { get; set; }
        public Contact Contact { get; set; }
        public int CurrentStatus { get; set; }
        public ICollection<ChangeApplicationStatus> ChangeApplicationStatus { get; set; }
    }
}
