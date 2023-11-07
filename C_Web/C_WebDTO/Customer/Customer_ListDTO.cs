using C_Web.Entity.CustomerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_WebDTO.Customer
{
    public class Customer_CreateViewListDTO
    {
        public List<Customer_Industrial_Basic> CusIndustrialListDTO { get; set; }
        public List<Customer_Attribute_Basic> CusAttributeListDTO { get; set; }
    }
    public class Customer_BankDTO
    {
        public string bankName { get; set; }
        public string bankBranch { get; set; }
        public string bankAccname { get; set; }
        public string bankCode { get; set; }
        public string bankAcc { get; set; }
        public long Lid { get; set; }
    }
    public class Customer_MainDTO
    {
        public string mainName { get; set; }
        public string mainBirth { get; set; }
        public string mainIDNum { get; set; }
        public string mainPhone { get; set; }
        public string mainJobtitle { get; set; }
        public string mainResiAddress { get; set; }
        public string mainCurrAddress { get; set; }
        public long Lid { get; set; }
    }
    public class Customer_ContactDTO
    {
        public string conName { get; set; }
        public string conEnName { get; set; }
        public string conJobtitle { get; set; }
        public string conDept { get; set; }
        public string conPhone { get; set; }
        public string conTelephone { get; set; }
        public string conArea { get; set; }
        public string conAddress { get; set; }
        public string conEmail { get; set; }
        public string conConType { get; set; }
        public long Lid { get; set; }
        public string gid { get; set; }
        public Guid Gid { get; set; }
        public string lid { get; set; }
        public string AreaName { get; set; }
        public string ConTypeName { get; set; }
    }
    public class Customer_ProductDTO
    {
        public string productType { get; set; }
        public string productMarket { get; set; }
        public string productMainProduct { get; set; }
        public long Lid { get; set; }
    }
}
