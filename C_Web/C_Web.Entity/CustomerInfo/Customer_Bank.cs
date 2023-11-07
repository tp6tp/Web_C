using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Web.Entity.CustomerInfo
{
    public class Customer_Bank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public Guid Gid { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string BankAccName { get; set; }
        public string BankCode { get; set; }
        public string BankAcc { get; set; }
        public long Lid { get; set; }
        public int MUser { get; set; }
        public int CUser { get; set; }
        public string CTime { get; set; }
        public string MTime { get; set; }
        public int DeleteType { get; set; }

    }
}
