using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Web.Entity.SYS
{
    public class SYS_UserManager
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string AccountName { get; set; }
        public string Email { get; set; }
        public string Salt { get; set; }
        public bool ValidationStatus { get; set; }
        public bool DevOnOff { get; set; }
        /// <summary>
        /// 索引鍵 Account 開頭 A-Z or 0-9
        /// </summary>
        public string AccStartsIndex { get; set; }
    }
}
