
using C_Web.Entity.TrackSpend;
using C_Web.Entity.TrackSpend.Enum;
using C_WebDTO.TrackSpendDTO;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Net;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Nodes;
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
        public TrackSpendDTO GetEditTrack(string TrackSpendId)
        {
            try
            {
                return GEDB.GetAlls<TrackSpendDTO>($"SELECT * FROM TrackSpend_Info TS" +
                    $" LEFT JOIN Classify_Info class ON class.ClassifyId = TS.ClassifyId" +
                    $" LEFT JOIN Icon_Info icon on icon.IconId = class.ClassifyIconId" +
                    $" WHERE TrackSpendId=@id", new { id=TrackSpendId}).FirstOrDefault();
            }
            catch(Exception e)
            {
                return new TrackSpendDTO();
            }
        }

        public List<TrackSpendDTO> GetTracks(long UserId, string nowdate) 
        {
            try
            {
                string Sql = $"SELECT * FROM TrackSpend_Info TS " +
                    $"LEFT JOIN Classify_Info class on TS.ClassifyId = class.ClassifyId " +
                    $"LEFT JOIN Icon_Info icon on icon.IconId = class.ClassifyIconId " +
                    $"LEFT JOIN IconType_Info itype on itype.Icon_TypeId = class.ClassifyTypeId " +
                    $"WHERE TS.UserId=@id";
                Sql += string.IsNullOrEmpty(nowdate) ? "" : $" AND DATEPART(MONTH, NowDate) = @month";
                Sql += $" ORDER BY TS.NowDate ASC";

                return GEDB.GetAlls<TrackSpendDTO>(Sql, new { id = UserId, month = nowdate }).ToList();
            }
            catch(Exception e )
            {
                return new List<TrackSpendDTO>();
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

        public bool EditTrackSpendInfo(TrackSpendDTO DTO)
        {
            try
            {
                DTO.NowDate = Convert.ToDateTime(DTO.NowDate).ToString("yyyy/MM/dd");
                DTO.Week = ParseWeekCh(Convert.ToDateTime(DTO.NowDate).DayOfWeek.ToString());
                DTO.Years = DTO.NowDate.Split("/")[0];
                DTO.Month = DTO.NowDate.Split("/")[1];
                GEDB.GetAlls<TrackSpend_Info>($"UPDATE TrackSpend_Info SET Note=@note, NowDate=@date," +
                    $" Week=@week, TotalAmount=@amount, Years=@years, Month=@month, ClassifyId=@classid," +
                    $" IncomeOrExpenses=@inorex WHERE TrackSpendId=@id",
                    new { note=DTO.Note, date=DTO.NowDate, week=DTO.Week, amount=DTO.TotalAmount,
                                years=DTO.Years, month=DTO.Month, classid=DTO.ClassifyId, 
                                inorex = (IncomeOrExpensesEnum)Enum.Parse(typeof(IncomeOrExpensesEnum), DTO.InOrEx),
                                id=DTO.TrackSpendId});
                db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public bool DeleteClassifyInfo(int ClassifyId)
        {
            try
            {
                GEDB.Get($"DELETE FROM Classify_Info WHERE ClassifyId=@id;", new { id = ClassifyId });
                db.SaveChanges();
                return true;
            }
            catch(Exception e)
            { 
                return false; 
            }
        }
        public List<List<List<string>>> Make3Array(List<TrackSpendDTO> Tracks)
        {
            List<List<List<string>>> data = new();
            List<string> head = Tracks.Select(x => x.NowDate + " " + x.Week).Distinct().ToList();
            
            for (var i = 0; i <= head.Count() - 1; i++)
            {
                List<List<string>> item = new();
                item.Add(new List<string>());
                item[0].Add(head[i]);
                List<TrackSpendDTO> content = Tracks.Where(x => Convert.ToDateTime(x.NowDate).Equals(Convert.ToDateTime(head[i].Split(" ")[0]))).ToList();
                for (var y = 0; y <= content.Count() - 1; y++)
                {
                    item.Add(new List<string>());
                    item[item.Count() - 1].Add(content[y].IconCode);
                    item[item.Count() - 1].Add(content[y].TypeColorCode);
                    item[item.Count() - 1].Add(content[y].Note);
                    item[item.Count() - 1].Add(content[y].TotalAmount.ToString());
                    item[item.Count() - 1].Add(content[y].IncomeOrExpenses.ToString());
                    item[item.Count() - 1].Add(content[y].TrackSpendId.ToString());
                    item[item.Count() - 1].Add(content[y].ClassifyId.ToString());
                }
                data.Add(item);
            }
            return data;
        }

        public object[] GetChart1(string SDate, string EDate, long UserId)
        {
            object[] result = new object[2];
            try
            {
                string Sql = $"SELECT" +
                                        " SUM( CASE WHEN IncomeOrExpenses = 0 THEN TotalAmount ELSE 0 END) as expenses," +
                                        " SUM( CASE WHEN IncomeOrExpenses = 1 THEN TotalAmount ELSE 0 END) as income" +
                                    " FROM TrackSpend_Info WHERE UserId=@id";
                Sql += string.IsNullOrEmpty(SDate) ? "" : string.IsNullOrEmpty(EDate) ?
                    $" AND CONVERT(DATE, NowDate, 111) >= CONVERT(DATE, @sdate, 111)" :
                    $" AND CONVERT(DATE, NowDate, 111) BETWEEN CONVERT(DATE, @sdate, 111) AND CONVERT(DATE, @edate, 111)";
                Sql += string.IsNullOrEmpty(EDate) ? "" : string.IsNullOrEmpty(SDate) ?
                    $" AND CONVERT(DATE, NowDate, 111) <= CONVERT(DATE, @edate, 111)" : "";
                IQueryable<TrackSpendDTO> chart1 = GEDB.GetAlls<TrackSpendDTO>(Sql, new { sdate = SDate, edate = EDate, id = UserId });

                result[0] = chart1.Select(x => x.income);
                result[1] = chart1.Select(x => x.expenses);
                return result;
            }
            catch (Exception e)
            {
                result[0] = 0;
                result[1] = 0;
                return result;
            }
        }
        public object[] GetChat2(string SDate, string EDate, long UserId)
        {
            object[] result = new object[3];
            try
            {
                string Sql = $"SELECT SUM(TotalAmount) AS TotalAmount, TS.ClassifyId, TS.Note, ICON.IconCode, ITYPE.TypeColorCode" +
                            $" FROM TrackSpend_Info TS" +
                            $" LEFT JOIN Classify_Info CLASS ON TS.ClassifyId = CLASS.ClassifyId" +
                            $" LEFT JOIN Icon_Info ICON on CLASS.ClassifyIconId = ICON.IconId" +
                            $" LEFT JOIN IconType_Info ITYPE on CLASS.ClassifyTypeId = ITYPE.Icon_TypeId" +
                            $" WHERE TS.UserId=@id";
                Sql += string.IsNullOrEmpty(SDate) ? "" : string.IsNullOrEmpty(EDate) ?
                   $" AND CONVERT(DATE, TS.NowDate, 111) >= CONVERT(DATE, @sdate, 111)" :
                   $" AND CONVERT(DATE, TS.NowDate, 111) BETWEEN CONVERT(DATE, @sdate, 111) AND CONVERT(DATE, @edate, 111)";
                Sql += string.IsNullOrEmpty(EDate) ? "" : string.IsNullOrEmpty(SDate) ?
                    $" AND CONVERT(DATE, TS.NowDate, 111) <= CONVERT(DATE, @edate, 111)" : "";
                Sql += $" GROUP BY TS.ClassifyId, ICON.IconCode, ITYPE.TypeColorCode, TS.Note";
                IQueryable<TrackSpendDTO> chart2 = GEDB.GetAlls<TrackSpendDTO>(Sql, new { id = UserId, sdate = SDate, edate = EDate });
                result[0] = chart2.Select(x => x.TotalAmount);
                result[1] = chart2.Select(x => x.Note.Trim());
                result[2] = chart2.Select(x => x.TypeColorCode);
                return result;
            }
            catch (Exception e)
            {
                result[0] = 0;
                result[1] = "";
                result[2] = "";
                return result;
            }
        }
        public object[] GetChart3(string SDate, string EDate, long UserId)
        {
            object[] result = new object[4];
            try
            {
                string Sql = $"SELECT Month, Years, " +
                                    $"SUM( CASE WHEN IncomeOrExpenses = 0 THEN TotalAmount ELSE 0 END) as expenses, " +
                                    $"SUM( CASE WHEN IncomeOrExpenses = 1 THEN TotalAmount ELSE 0 END) as income " +
                                    $"FROM TrackSpend_Info WHERE UserId=@id";
                Sql += string.IsNullOrEmpty(SDate) ? "" : string.IsNullOrEmpty(EDate) ?
                   $" AND CONVERT(DATE, NowDate, 111) >= CONVERT(DATE, @sdate, 111)" :
                   $" AND CONVERT(DATE, NowDate, 111) BETWEEN CONVERT(DATE, @sdate, 111) AND CONVERT(DATE, @edate, 111)";
                Sql += string.IsNullOrEmpty(EDate) ? "" : string.IsNullOrEmpty(SDate) ?
                    $" AND CONVERT(DATE, NowDate, 111) <= CONVERT(DATE, @edate, 111)" : "";
                Sql += $" GROUP BY Month, Years";
                IQueryable<TrackSpendDTO> chart3 = GEDB.GetAlls<TrackSpendDTO>(Sql, new { id = UserId, sdate = SDate, edate = EDate });
                result[0] = chart3.Select(x => x.Years + "年" + x.Month + "月");
                result[1] = chart3.Select(x => x.expenses);
                result[2] = chart3.Select(x => x.income);
                result[3] = chart3.Select(x => x.income - x.expenses);
                return result;
            }
            catch(Exception e)
            {
                result[0] = "";
                result[1] = 0;
                result[2] = 0;
                result[3] = 0;
                return result;
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