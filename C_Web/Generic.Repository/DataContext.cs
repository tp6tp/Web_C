using System.ComponentModel;
using System.Data.Entity;
using C_Web.Entity.CustomerInfo;
using C_Web.Entity.LicenseInfo;
using C_Web.Entity.SYS;
using C_Web.Extension.DBConn;


namespace WebC.Generic.Repository
{
    public class DataContext: DbContext
    {
        public DataContext() : base(DBConnClass.GetDBConnString())
        {
            Database.SetInitializer<DataContext>(null);
            (this as System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.CommandTimeout =120;
        }
        
        public DbSet<SYS_UserManager> SYS_UserManager { get; set; }
        public DbSet<SYS_List> SYS_List { get; set; }
        public DbSet<Customer_Info> Customer_Info { get; set; }
        public DbSet<Customer_Attribute_Basic> Customer_Attribute_Basic {get; set; }
        public DbSet<Customer_Industrial_Basic> Customer_Industrial_Basic { get; set; }
        public DbSet<Customer_ContactArea_Basic> Customer_ContactArea_Basic { get; set; }
        public DbSet<Customer_ContactType_Basic> Customer_ContactType_Basic { get; set; }


        public DbSet<License_Info> License_Info { get; set; }
    }
}