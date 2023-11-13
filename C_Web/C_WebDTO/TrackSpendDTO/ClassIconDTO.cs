using C_Web.Entity.TrackSpend.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_WebDTO.TrackSpendDTO
{
    public class ClassIconDTO
    {
        public string ClassName {  get; set; }
        public long ClassIcon {  get; set; }
        public long ClassColor {  get; set; }
        public long UserId {  get; set; }
        public string InOrEx { get; set; }
    }
    public class ClassifyDTO
    {
        public long ClassifyId { get; set; }
        public long UserId { get; set; }
        public string ClassifyName { get; set; }
        public long ClassifyIconId { get; set; }
        public long ClassfyTypeId { get; set; }
        public string IconCode { get; set; }
        public string TypeColorCode { get; set; }
        public IncomeOrExpensesEnum IncomeOrExpenses { get; set; }
    }
    public class TrackSpendDTO
    {
        public long TrackSpendId { get; set; }
        public long UserId { get; set; }
        public string Note { get; set; }
        public string NowDate { get; set; }
        public string Week { get; set; }
        public int TotalAmount { get; set; }
        public string Years { get; set; }
        public string Month { get; set; }
        public long ClassifyId { get; set; }

        public string InOrEx { get; set; }
        public int income { get; set; }

        public int expenses {get; set; }
        public IncomeOrExpensesEnum IncomeOrExpenses { get; set; }
        public string IconCode { get; set; }
        public string TypeColorCode { get; set; }
    }
}
