using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Web.Entity.CustomerInfo
{
    public class Customer_Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public Guid Gid { get; set; }
        public string ContactName { get; set; }
        public string ContactEnName { get; set; }
        public string ContactJobtitle { get; set; }
        public string ContactDept { get; set; }
        public string ContactPhone { get; set; }
        public string ContactTelephone { get; set; }
        public string ContactArea { get; set; }
        public string ContactAddress { get; set; }
        public string ContactEmail { get; set; }
        public string ContactConType { get; set; }
        public long Lid { get; set; }
        public int CUser { get; set; }
        public int MUser { get; set; }
        public string MTime { get; set; }
        public string CTime { get; set; }
        public int DeleteType { get; set; }
    }
}
