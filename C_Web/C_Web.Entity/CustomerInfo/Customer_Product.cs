using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Web.Entity.CustomerInfo
{
    public class Customer_Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public Guid Gid { get; set; }
        public string ProductType { get; set; }
        public string ProductMarket { get; set; }
        public string MainProduct { get; set; }
        public long Lid { get; set; }
        public int CUser { get; set; }
        public int MUser { get; set; }
        public string CTime { get; set; }
        public string MTime { get; set; }
        public int DeleteType { get; set; }
    }
}
