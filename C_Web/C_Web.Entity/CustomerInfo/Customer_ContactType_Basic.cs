using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Web.Entity.CustomerInfo
{
    public class Customer_ContactType_Basic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CusContactTypeId { get; set; }
        public string ContactType { get; set; }
        public int CUser { get; set; }
        public int MUser { get; set; }
        public string CTime { get; set; }
        public string MTime { get; set; }
    }
}
