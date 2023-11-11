using System.ComponentModel;
using System.Data.Entity;
using C_Web.Entity.SYS;
using C_Web.Entity.TrackSpend;
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
        public DbSet<Icon_Info> Icon_Info { get; set; }
        public DbSet<Classify_Info> Classify_Info { get; set;}
        public DbSet<IconType_Info> IconType_Info {  get; set; }
        public DbSet<TrackSpend_Info> TrackSpend_Info { get; set;}

    }
}