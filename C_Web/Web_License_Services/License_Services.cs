using WebC.Generic.Repository;

namespace Web_License_Services
{
    public class License_Services:ILicense_Services
    {
        private readonly DataContext db;
        private IGenericRepository<dynamic> GEDB;
        public License_Services(DataContext db, IGenericRepository<dynamic> GEDB)
        {
            this.db = db;
            this.GEDB = GEDB;
        }

    }
}