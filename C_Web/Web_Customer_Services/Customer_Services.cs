using C_Web.Entity.CustomerInfo;
using C_Web.Entity.CustomerInfo.Enums;
using C_WebDTO.CommonDTO;
using C_WebDTO.Customer;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using WebC.Generic.Repository;

namespace Web_Customer_Services
{
    public class Customer_Services: ICustomer_Services
    {
        private readonly DataContext db;
        private IGenericRepository<dynamic> GEDB;
        public Customer_Services(DataContext db, IGenericRepository<dynamic> GEDB)
        {
            this.db = db;
            this.GEDB = GEDB;
        }

        public List<DataTableDTO_content> GetCustomerInfoTable(FetchDTO DTO)
        {
            try
            {
                List<DataTableDTO_content> list = new();
                string Sql = $@"SELECT * FROM Customer_Info(NOLOCK) WHERE 1=1";
                Sql += string.IsNullOrEmpty(DTO.STime) ? "" : $"AND CTime >= '{DTO.STime}' ";
                Sql += string.IsNullOrEmpty(DTO.ETime) ? "" : $"AND CTime <= '{DTO.ETime}' ";
                Sql += string.IsNullOrEmpty(DTO.Company) ? "" : $"AND Name LIKE '%{DTO.Company}%' ";
                Sql += string.IsNullOrEmpty(DTO.Unicode) ? "" : $"AND UnifNum = '{DTO.Unicode}' ";
                Sql += string.IsNullOrEmpty(DTO.Type) ? "" : $"AND Type = '{DTO.Type}' ";
                list = GEDB.GetAlls<Customer_Info>(Sql).Select(x => new DataTableDTO_content()
                {
                    Text1 = x.Name,
                    Text2 = x.SName,
                    Text3 = x.CEO,
                    Text4 = x.UnifNum,
                    Text5 = x.PhoneNum,
                    Text6 = x.Email,
                    Text7 = x.BusinessAddress,
                    Text8 = ((Customer_InfoEnum)Enum.ToObject(typeof(Customer_InfoEnum), x.Type)).ToString(),
                    Text9 = db.SYS_UserManager.Where(S => S.UserId == x.MUser).Select(S => S.AccountName).FirstOrDefault(),
                    Text10 = db.SYS_UserManager.Where(S => S.UserId == x.CUser).Select(S => S.AccountName).FirstOrDefault(),
                    Text11 = x.MTime,
                    Text12 = x.CTime,
                    Text13 = x.CustomerId.ToString(),
                }).ToList();
                return list;
            }
            catch(Exception e) 
            {
                return new List<DataTableDTO_content>() { };
            }
        }


        #region cusBasic
        public List<DataTableDTO_content> GetCusIndustrialBasicTable()
        {
            List<DataTableDTO_content> list = new();
            list = GEDB.GetAlls<Customer_Industrial_Basic>($"SELECT * FROM Customer_Industrial_Basic").Select(x => new DataTableDTO_content()
            {
                Text1 = "<button " + "style=" + '"' + "text-align:center;" + '"' + " class=" + '"' + "btn btn-dark" + '"' + " id=" + '"' + "indus_" + x.CusIndustrialId + '"' + "> " + x.IndustrialName + " </button>",
                Text2 = x.CusIndustrialId.ToString(),
                Text3 = db.SYS_UserManager.Where(z => z.UserId == x.CUser).Select(z => z.AccountName).FirstOrDefault(),
                Text4 = x.CTime,
                Text5 = db.SYS_UserManager.Where(z => z.UserId == x.MUser).Select(z => z.AccountName).FirstOrDefault(),
                Text6 = x.MTime,
            }).ToList();
            return list;
        }
        public List<DataTableDTO_content> GetCusAttributeBasicTable()
        {
            List<DataTableDTO_content> list = new();
            list = GEDB.GetAlls<Customer_Attribute_Basic>($"SELECT * FROM Customer_Attribute_Basic").Select(x => new DataTableDTO_content()
            {
                Text1 = "<button " + "style=" + '"' + "text-align:center;" + '"' + " class=" + '"' + "btn btn-dark" + '"' + " id=" + '"' + "attri_" + x.CusAttributeId + '"' + "> " + x.AttributeName + " </button>",
                Text2 = x.CusAttributeId.ToString(),
                Text3 = db.SYS_UserManager.Where(z => z.UserId == x.CUser).Select(z => z.AccountName).FirstOrDefault(),
                Text4 = x.CTime,
                Text5 = db.SYS_UserManager.Where(z => z.UserId == x.MUser).Select(z => z.AccountName).FirstOrDefault(),
                Text6 = x.MTime,
            }).ToList();
            return list;
        }
        public bool CreateIndustrial(Customer_BasicDTO basicDTO)
        {
            try
            {
                string nowT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                db.Customer_Industrial_Basic.Add(new Customer_Industrial_Basic
                {
                    IndustrialName = basicDTO.industrialName,
                    CUser = Convert.ToInt32(basicDTO.UserId),
                    MUser = Convert.ToInt32(basicDTO.UserId),
                    CTime = nowT,
                    MTime = nowT,
                });
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool CreateAttribute(Customer_BasicDTO basicDTO)
        {
            try
            {
                string nowT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                db.Customer_Attribute_Basic.Add(new Customer_Attribute_Basic
                {
                    AttributeName = basicDTO.attributeName,
                    CUser = Convert.ToInt32(basicDTO.UserId),
                    MUser = Convert.ToInt32(basicDTO.UserId),
                    CTime = nowT,
                    MTime = nowT,
                });
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool EditIndustrial(Customer_BasicDTO basicDTO)
        {
            try
            {
                string nowT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                GEDB.Edits("UPDATE Customer_Industrial_Basic SET IndustrialName=@IndustrialName, MUser=@MUser, MTime=@MTime " +
                    "WHERE CusIndustrialId=@id;", new { IndustrialName = basicDTO.industrialName, MUser = basicDTO.UserId, MTime = nowT, id = basicDTO.ID });
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool EditAttribute(Customer_BasicDTO basicDTO)
        {
            try
            {
                string nowT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                GEDB.Edits("UPDATE Customer_Attribute_Basic SET AttributeName=@AttributeName, MUser=@MUser, MTime=@MTime " +
                    "WHERE CusAttributeId=@id;", new { AttributeName = basicDTO.attributeName, MUser = basicDTO.UserId, MTime = nowT, id = basicDTO.ID });
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteIndustrial(Customer_BasicDTO basicDTO)
        {
            try
            { 
                var data = db.Customer_Industrial_Basic.Where(x => x.CusIndustrialId == basicDTO.ID).FirstOrDefault();
                if (data == null)
                    return false;
                else
                {
                    db.Customer_Industrial_Basic.Remove(data);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteAttribute(Customer_BasicDTO basicDTO)
        {
            try
            {
                var data = db.Customer_Attribute_Basic.Where(x => x.CusAttributeId == basicDTO.ID).FirstOrDefault();
                if(data == null)
                    return false;
                else
                {
                    db.Customer_Attribute_Basic.Remove(data);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion
        #region contactBasic
        public List<DataTableDTO_content> GetConTypeBasicTable()
        {
            List<DataTableDTO_content> list = new();
            list = GEDB.GetAlls<Customer_ContactType_Basic>($"SELECT * FROM Customer_ContactType_Basic WHERE 1=1").Select(x => new DataTableDTO_content()
            {
                Text1 = "<button " + "style=" + '"' + "text-align:center;" + '"' + " class=" + '"' + "btn btn-dark" + '"' + " id=" + '"' + "contype_" + x.CusContactTypeId + '"' + "> " + x.ContactType + " </button>",
                Text2 = x.CusContactTypeId.ToString(),
                Text3 = db.SYS_UserManager.Where(z => z.UserId == x.CUser).Select(z => z.AccountName).FirstOrDefault(),
                Text4 = x.CTime,
                Text5 = db.SYS_UserManager.Where(z => z.UserId == x.MUser).Select(z => z.AccountName).FirstOrDefault(),
                Text6 = x.MTime,
            }).ToList();
            return list;
        }
        public List<DataTableDTO_content> GetConAreaBasicTable()
        {
            List<DataTableDTO_content> list = new();
            list = GEDB.GetAlls<Customer_ContactArea_Basic>($"SELECT * FROM Customer_ContactArea_Basic WHERE 1=1").Select(x => new DataTableDTO_content()
            {
                Text1 = "<button " + "style=" + '"' + "text-align:center;" + '"' + " class=" + '"' + "btn btn-dark" + '"' + " id=" + '"' + "conarea_" + x.CusContactAreaId + '"' + "> " + x.ContactArea + " </button>",
                Text2 = x.CusContactAreaId.ToString(),
                Text3 = db.SYS_UserManager.Where(z => z.UserId == x.CUser).Select(z => z.AccountName).FirstOrDefault(),
                Text4 = x.CTime,
                Text5 = db.SYS_UserManager.Where(z => z.UserId == x.MUser).Select(z => z.AccountName).FirstOrDefault(),
                Text6 = x.MTime,
            }).ToList();
            return list;
        }
        public bool CreateContactType(Customer_BasicDTO basicDTO)
        {
            try
            {
                string nowT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                db.Customer_ContactType_Basic.Add(new Customer_ContactType_Basic
                {
                    ContactType = basicDTO.ContactType,
                    CUser = Convert.ToInt32(basicDTO.UserId),
                    MUser = Convert.ToInt32(basicDTO.UserId),
                    CTime = nowT,
                    MTime = nowT,
                });
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool CreateContactArea(Customer_BasicDTO basicDTO)
        {
            try
            {
                string nowT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                db.Customer_ContactArea_Basic.Add(new Customer_ContactArea_Basic
                {
                    ContactArea = basicDTO.ContactArea,
                    CUser = Convert.ToInt32(basicDTO.UserId),
                    MUser = Convert.ToInt32(basicDTO.UserId),
                    CTime = nowT,
                    MTime = nowT,
                });
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool EditContactType(Customer_BasicDTO basicDTO)
        {
            try
            {
                string nowT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                GEDB.Edits("UPDATE Customer_ContactType_Basic SET ContactType=@contactType, MUser=@MUser, MTime=@MTime " +
                    "WHERE CusContactTypeId=@id;", 
                    new { contactType = basicDTO.ContactType, MUser = basicDTO.UserId, MTime = nowT, id = basicDTO.ID });
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool EditContactArea(Customer_BasicDTO basicDTO)
        {
            try
            {
                string nowT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                GEDB.Edits("UPDATE Customer_ContactArea_Basic SET ContactArea=@contactArea, MUser=@MUser, MTime=@MTime " +
                    "WHERE CusContactAreaId=@id;",
                    new { contactArea = basicDTO.ContactArea, MUser = basicDTO.UserId, MTime = nowT, id = basicDTO.ID });
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteContactType(Customer_BasicDTO basicDTO)
        {
            try
            {
                var data = db.Customer_ContactType_Basic.Where(x => x.CusContactTypeId == basicDTO.ID).FirstOrDefault();
                if (data == null)
                    return false;
                else
                {
                    db.Customer_ContactType_Basic.Remove(data);
                    db.SaveChanges();
                    return true;
                }                
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteContactArea(Customer_BasicDTO basicDTO)
        {
            try
            {
                var data = db.Customer_ContactArea_Basic.Where(x => x.CusContactAreaId == basicDTO.ID).FirstOrDefault();
                if (data == null)
                    return false;
                else
                {
                    db.Customer_ContactArea_Basic.Remove(data);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion
    }
}
