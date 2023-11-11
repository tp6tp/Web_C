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
    public class Classify_Info
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ClassifyId { get; set; }
        public long UserId { get; set; }
        public string ClassifyName { get; set; }
        public long ClassifyIconId {  get; set; }
        //public string ClassifyIcon {  get; set; }
        public long ClassifyTypeId {  get; set; }
        //public string ClassifyTypeColor { get; set; }
        public IncomeOrExpensesEnum IncomeOrExpenses { get; set; }
    }
}
