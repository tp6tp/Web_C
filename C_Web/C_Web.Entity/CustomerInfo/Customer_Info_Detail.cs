using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Web.Entity.CustomerInfo
{
    public class Customer_Info_Detail
    {
        public long Id { get; set; }
        /// <summary>
        /// Guid主Key
        /// </summary>
        [Key]
        public Guid Gid { get; set; }
        /// <summary>
        /// 時間主Key
        /// </summary>
        [Key]
        public long Tid { get; set; }
        /// <summary>
        /// 聯絡人姓名
        /// </summary>
        public string CalName { get; set; }
        /// <summary>
        /// 職位名稱
        /// </summary>
        public string JobName { get; set; }
        /// <summary>
        /// 聯絡人電話
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 更改人員
        /// </summary>
        public int MUser { get; set; }
        /// <summary>
        /// 新增人員
        /// </summary>
        public int CUser { get; set; }
        /// <summary>
        /// 更改時間
        /// </summary>
        public string MTime { get; set; }
        /// <summary>
        /// 新增時間
        /// </summary>
        public string CTime { get; set; }
        /// <summary>
        /// 關聯主表Tid
        /// </summary>
        public long Lid { get; set; }
        /// <summary>
        /// 部門Dept
        /// </summary>
        public string Dept { get; set; }
    }
}