using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Web.Entity.CustomerInfo
{
    public class Bank_Info
    {
        [Key]
        public long Id { get; set; }
        public string BankCode { get; set; }
        public string BranchCode { get; set; }
        public string BankName { get; set; }
    }
}
