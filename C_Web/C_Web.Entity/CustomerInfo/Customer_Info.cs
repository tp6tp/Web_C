using C_Web.Entity.CustomerInfo.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Web.Entity.CustomerInfo
{
    public class Customer_Info
    {
        /// <summary>
        /// 時間主Key
        /// </summary>
        [Key]
        public long CustomerId { get; set; }
        /// <summary>
        /// 客戶屬性(關聯Attribute_Basic)
        /// </summary>
        public long Attribute { get; set; }
        /// <summary>
        /// 公司名稱
        /// </summary>
        public string Name { get; set; }
        ///<summary>
        ///負責人
        ///</summary>
        public string CEO { get; set; }
        /// <summary>
        /// 公司簡稱
        /// </summary>
        public string SName { get; set; }
        /// <summary>
        /// 公司統一編號
        /// </summary>
        public string UnifNum { get; set; }
        /// <summary>
        /// 客戶產業(關聯Industrial_Basic)
        /// </summary>
        public long Industrial { get; set; }
        /// <summary>
        /// 營業地址
        /// </summary>
        public string BusinessAddress { get; set; }
        ///<summary>
        ///電話
        /// </summary>
        public string PhoneNum { get; set; }
        ///<summary>
        ///E-mail
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 類型
        /// </summary>
        public Customer_InfoEnum Type { get; set; }
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

    }
}
