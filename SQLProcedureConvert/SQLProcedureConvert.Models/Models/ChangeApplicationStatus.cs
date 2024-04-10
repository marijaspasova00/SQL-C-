using SQLProcedureConvert.Models.Models;
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
        [ForeignKey("Contact")]
        public int ContactID { get; set; }
        public Contact Contact { get; set; }
        public DateTime Date { get; set; }
        public int StatusFrom { get; set; }
        public int NewStatus { get; set; }
    }
}
