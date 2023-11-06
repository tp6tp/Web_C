using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW.MIS.Entity.LicenseInfo
{
    public class License_Info_Record
    {
        /// <summary>
        /// PKey
        /// </summary>       
        [Key]
        public string Id { get; set; }
        /// <summary>
        /// 修改時間
        /// </summary>
        public string ModifyTime { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string ModifyName { get; set; }
        /// <summary>
        /// Guid Key
        /// </summary>
        public Guid License { get; set; }
        ///<summary>
        ///數量
        /// </summary>
        public int Quantity { get; set; }
        ///<summary>
        ///客戶
        /// </summary>
        public string Customer { get; set; }
        ///<summary>
        ///開始時間
        /// </summary>
        public string StartTime { get; set; }
        ///<summary>
        ///結束時間
        /// </summary>
        public string EndTime { get; set; }
        ///<summary>
        ///是否啟用
        /// </summary>
        public string UseType { get; set; }
        ///<summary>
        ///0=正式/1=測試
        /// </summary>
        public int Version { get; set; }
        /// <summary>
        /// 假刪除
        /// </summary>
        public int DeleteType { get; set; }
    }
}
