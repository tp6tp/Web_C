using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace C_Web.Entity.SYS
{
    public class SYS_List
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SYSListId { get; set; }
        public int? FAID { get; set; }
        [DisplayName("功能名稱")]
        [Required(ErrorMessage ="請輸入功能名稱")]
        public string Name { get; set; }
        [DisplayName("導向網址")]
        [Required(ErrorMessage = "請輸入導向網址")]
        public string Url { get; set; }
        [DisplayName("圖示")]
        public string Icon { get; set; }
        public bool OnOff { get; set; }
        public int Orders { get; set; }
        public long MUser {  get; set; }
        public string MTime { get; set; }
    }
}
