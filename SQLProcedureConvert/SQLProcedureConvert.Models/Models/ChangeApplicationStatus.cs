
using SQLProcedureConvert.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLProcedureConvert.Domain.Models
{
    public class ChangeApplicationStatus : BaseEntity
    {
        [ForeignKey("Application")]
        public int ApplicationID { get; set; }
        public Application Application { get; set; }
        //[ForeignKey("Contact")]
        //public int ContactID { get; set; }
        //public Contact contact { get; set; }
        public DateTime Date { get; set; }
        public Status StatusFrom { get; set; }
        public Status NewStatus { get; set; }
    }
}
