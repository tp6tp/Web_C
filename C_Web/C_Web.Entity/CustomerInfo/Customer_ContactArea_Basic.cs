using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Web.Entity.CustomerInfo
{
    public class Customer_ContactArea_Basic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CusContactAreaId { get; set; }
        public string ContactArea { get; set; }
        public int CUser { get; set; }
        public int MUser { get; set; }
        public string CTime { get; set; }
        public string MTime { get; set; }
    }
}
