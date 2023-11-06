using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW.MIS.Entity.LicenseInfo
{
    public class License_Info
    { 
        /// <summary>
        /// Guid Key
        /// </summary>       
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LicenseId { get; set; }
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
        public string CustomerId { get; set; }
        ///<summary>
        ///開始時間
        /// </summary>
        public string STime { get; set; }
        ///<summary>
        ///結束時間
        /// </summary>
        public string ETime { get; set; }
        ///<summary>
        ///是否啟用
        /// </summary>    
        public bool UseType { get; set; }
        ///<summary>
        ///0=正式/1=測試
        /// </summary>
        public int Version { get; set; }
    }
}
