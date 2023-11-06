using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_WebDTO.CommonDTO;
using C_Web.Extension;
using C_Web.Extension.DBConn;
using System.Data.SqlClient;
using System.ComponentModel;
using WebC.Generic.Repository;
using C_Web.Entity.SYS;
using System.Data;

namespace Web_SYSList_Services
{
    public class SYSList_Services : ISYSList_Services
    {
        private readonly DataContext db;
        private IGenericRepository<SYS_List> SLDB;
        private IGenericRepository<dynamic> GEDB;
        
        public SYSList_Services(DataContext db, IGenericRepository<dynamic> GEDB)
        {
            this.SLDB = new GenericRepository<SYS_List>();
            this.GEDB = GEDB;
            this.db = db;
        }
        public List<DataTableDTO_content> GetSYSListTable(long? SYSListId)
        {
            try
            {
                string sql = $"SELECT * FROM SYS_List WHERE 1=1";
                sql += string.IsNullOrEmpty(SYSListId.ToString()) ? $" AND (FAID=0 OR FAID IS NULL)" : $" AND FAID = '{SYSListId}'";
                sql += $" ORDER BY Orders";
                List<DataTableDTO_content> list = new();
                list = GEDB.GetAlls<SYS_List>(sql).Select(x => new DataTableDTO_content()
                {
                    PKId = x.SYSListId,
                    intId = x.FAID == null ? 0 : Convert.ToInt32(x.FAID),
                    Text1 = x.Name,
                    Text2 = x.Url,
                    Text3 = x.Icon,
                    Text4 = db.SYS_UserManager.Where(z => z.UserId == x.MUser).Select(z => z.AccountName).FirstOrDefault(),
                    Text5 = x.MTime,
                    orderint = x.Orders,
                    booldata = x.OnOff,
                }).ToList();
                return list;
            }
            catch(Exception e)
            {
                return new List<DataTableDTO_content>() {  };
            }
        }
        
        public bool CreateSYSList(FetchDTO ListModel)
        {
            try
            {
                ListModel.Icon = ListModel.Icon == null ? "" : ListModel.Icon;
                db.SYS_List.Add(new SYS_List
                {
                    Name = ListModel.Name,
                    FAID = ListModel.FAID == "" ? null : int.Parse(ListModel.FAID),
                    Url = ListModel.Url,
                    Icon = ListModel.Icon,
                    OnOff   = true,
                    Orders = ListModel.Orders,
                    MUser = ListModel.MUser,
                    MTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                });
                db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public bool EditSYSList(SYS_List ListModel)
        {
            try
            {
                ListModel.MTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                SLDB.Get($"UPDATE SYS_List SET Name = @name, Url = @url, Icon = @icon, MTime=@mtime WHERE SYSListId = @id",
                                new { name=ListModel.Name, url = ListModel.Url, icon=ListModel.Icon, mtime = ListModel.MTime, id=ListModel.SYSListId});
                db.SaveChanges();
                return true;
            }
            catch (Exception e) 
            {
                return false;
            }
        }
        public bool OnOff(FetchDTO DTO)
        {
            try
            {
                SLDB.Get($"UPDATE SYS_List SET OnOff=@onoff, MTime=@mtime WHERE SYSListId=@id",
                                new { onoff = DTO.OnOff, mtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), id = DTO.PKId });
                db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public bool SYSListOrder(object[] data, object[] order)
        {
            try
            {
                for (var i = 0; i < data.Length; i++)
                {
                    var id = data[i].ToString().Split(":");
                    var orders = order[i].ToString().Split(":");
                    GEDB.Edits($"UPDATE SYS_List SET Orders = @Order WHERE SYSListId = @Id OR FAID = @Id;", new { Id = id, Order = orders });
                }
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public string GetFatherName(long? SYSListId)
        {
            string temp = "";
        Re:
            SYS_List syslist = db.SYS_List.Where(x => x.SYSListId == SYSListId).FirstOrDefault();
            if (syslist == null)
                return temp;
            if(syslist.FAID == 0 || syslist.FAID == null)
            {
                temp = syslist.Name + temp;
                return temp;
            }
            else
            {
                temp = "→" + syslist.Name + temp;
                SYSListId = syslist.FAID;
                goto Re;
            }
        }
        public SYS_List GetEditModel(long Id)
        {
            return SLDB.Get($"SELECT * FROM SYS_List WHERE SYSListId = @id", new { id = Id });
        }

        public List<SYS_List> GetAllSYSList()
        {
            return SLDB.GetAlls<SYS_List>($"SELECT * FROM SYS_List").ToList();
        }
    }
}
