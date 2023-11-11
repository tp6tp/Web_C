
using C_Web.Entity.TrackSpend;
using C_Web.Entity.TrackSpend.Enum;
using C_WebDTO.TrackSpendDTO;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using WebC.Generic.Repository;

namespace Web_TrackSpend_Services
{
    public class TrackSpend_Services : ITrackSpend_Services
    {
        private readonly DataContext db;
        private readonly IGenericRepository<dynamic> GEDB;
        public TrackSpend_Services(DataContext db, IGenericRepository<dynamic> GEDB)
        {
            this.db = db;
            this.GEDB = GEDB;
        }

        public List<Icon_Info> GetIconList()
        {
            try
            {
                return GEDB.GetAlls<Icon_Info>($"SELECT * FROM Icon_Info").ToList();
            }
            catch (Exception e)
            {
                return new List<Icon_Info>();
            }
        }
        public List<IconType_Info> GetIconTypeList()
        {
            try
            {
                return GEDB.GetAlls<IconType_Info>($"SELECT * FROM IconType_Info").ToList();
            }
            catch(Exception e)
            {
                return new List<IconType_Info>();
            }
        }
        public List<ClassifyDTO> GetClassifyInfoList(long UserId)
        {
            try
            {
                return GEDB.GetAlls<ClassifyDTO>($"SELECT * FROM Classify_Info class" +
                    $" LEFT JOIN Icon_Info icon on class.ClassifyIconId=icon.IconId" +
                    $" LEFT JOIN IconType_Info itype on class.ClassifyTypeId=itype.Icon_TypeId WHERE UserId=@id",new { id=UserId}).ToList();
            }
            catch( Exception e )
            {
                return new List<ClassifyDTO>();
            }
        }
        public bool CreateClassifyInfo(ClassIconDTO DTO)
        {
            try
            {
                db.Classify_Info.Add(new Classify_Info()
                {
                    UserId = DTO.UserId,
                    ClassifyName = DTO.ClassName,
                    ClassifyIconId = DTO.ClassIcon,
                    ClassifyTypeId = DTO.ClassColor,
                    IncomeOrExpenses = (IncomeOrExpensesEnum)Enum.Parse(typeof(IncomeOrExpensesEnum), DTO.InOrEx),
                });
                db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public bool CreateTrackSpendInfo(TrackSpendDTO DTO)
        {
            try
            {
                DTO.NowDate = Convert.ToDateTime(DTO.NowDate).ToString("yyyy/MM/dd");
                DTO.Week = ParseWeekCh(Convert.ToDateTime(DTO.NowDate).DayOfWeek.ToString());
                DTO.Years = DTO.NowDate.Split("/")[0];
                DTO.Month = DTO.NowDate.Split("/")[1];
                db.TrackSpend_Info.Add(new TrackSpend_Info()
                {
                    UserId = DTO.UserId,
                    Note = DTO.Note,
                    NowDate = DTO.NowDate,
                    Week = DTO.Week,
                    TotalAmount = DTO.TotalAmount,
                    Years = DTO.Years,
                    Month = DTO.Month,
                    ClassifyId = DTO.ClassifyId,
                    IncomeOrExpenses = (IncomeOrExpensesEnum)Enum.Parse(typeof(IncomeOrExpensesEnum), DTO.InOrEx),
                });
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string ParseWeekCh(string week)
        {
            switch (week)
            {
                case "Sunday":
                    return "星期日";
                case "Monday":
                    return "星期一";
                case "Tuesday":
                    return "星期二";
                case "Wednesday":
                    return "星期三";
                case "Thursday":
                    return "星期四";
                case "Friday":
                    return "星期五";
                case "Saturday":
                    return "星期六";
                default:
                    return "";
            }
        }
    }
}