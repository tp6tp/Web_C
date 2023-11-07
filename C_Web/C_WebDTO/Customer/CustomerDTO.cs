using C_Web.Entity.CustomerInfo.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_WebDTO.Customer
{
    public class CustomerDTO
    {
        public int UserId { get; set; }
        public long Tid { get; set; } 
        public long newTid { get; set; }
        public long InfoAttribute { get; set; }
        public string InfoName { get;set;}
        public string InfoCEO { get;set;}
        public string InfoSname { get;set;}
        public string InfoUnifNum { get;set;}
        public long InfoIndustrial { get; set; }
        public string InfoBusinessAddress { get; set; }
        public string InfoPhoneNum { get; set; }
        public string InfoEmail { get; set; }
        public Customer_InfoEnum Type { get; set; }
        public int CUser { get; set; }
        public int MUser { get; set; }
        public string CTime { get; set; }
        public string MTime { get; set; }
        #region 產品資訊Product
        public string ProductType { get; set; }
        public string ProductMarket { get; set; }
        public string ProductMainProduct { get; set; }
        #endregion

        #region 銀行資訊Bank
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string BankAccName { get; set; }
        public string BankCode { get; set; }
        public string BankAcc { get; set; }
        #endregion

        #region 股東及重要幹部Main
        public string MainName { get; set; }
        public string MainBirth { get; set; }
        public string MainIDnum { get; set; }
        public string MainPhone { get; set; }
        public string MainJobTitle { get; set; }
        public string MainResiAddress { get; set; }
        public string MainCurrAddress { get; set; }
        public string MainAff { get; set; }
        public string MainOther { get; set; }
        #endregion

        #region 聯絡人Contact
        public string ContactName { get; set; }
        public string ContactEnName { get; set; }
        public string ContactJobtitle { get; set; }
        public string ContactDept { get; set; }
        public string ContactPhone { get; set; }
        public string ContactTelephone { get; set; }
        public string ContactArea { get; set; }
        public string ContactAddress { get; set; }
        public string ContactEmail { get; set; }
        public string ContactConType { get; set; }
        #endregion

        # region 附件檔案Annex
        public string AnnexImg { get; set; }
        #nullable enable
        public List<IFormFile>? Annex { get; set; }
        #nullable enable
        #endregion
    }
}
