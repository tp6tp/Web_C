using System.ComponentModel;
using System.Data.Entity;
using C_Web.Entity.SYS;
using C_Web.Extension.DBConn;
using CW.MIS.Entity.LicenseInfo;

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

        public DbSet<License_Info> License_Info { get; set; }
    }
}