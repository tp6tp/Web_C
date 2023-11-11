using C_Web.Entity.TrackSpend.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Web.Entity.TrackSpend
{
    public class TrackSpend_Info
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TrackSpendId { get; set; }
        public long UserId { get; set; }
        public string Note { get; set; }
        public string NowDate { get; set; }
        public string Week { get; set; }
        public int TotalAmount { get; set; }
        public string Years { get; set; }
        public string Month { get; set; }
        public long ClassifyId { get; set; }
        public IncomeOrExpensesEnum IncomeOrExpenses { get; set; }
    }
}
