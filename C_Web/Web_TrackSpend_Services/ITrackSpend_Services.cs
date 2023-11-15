
using C_Web.Entity.TrackSpend;
using C_WebDTO.TrackSpendDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_TrackSpend_Services
{
    public interface ITrackSpend_Services
    {
        List<Icon_Info> GetIconList();
        List<IconType_Info> GetIconTypeList();
        List<ClassifyDTO> GetClassifyInfoList(long UserId);
        List<TrackSpendDTO> GetTracks(long UserId, string nowdate);
        TrackSpendDTO GetEditTrack(string TrackSpendId);
        object[] GetChart1(string nowdate, long UserId);
        object[] GetChat2(string nowdate, long UserId);
        object[] GetChart3(string nowdate, long UserId);

        bool CreateClassifyInfo(ClassIconDTO DTO);
        bool CreateTrackSpendInfo(TrackSpendDTO DTO);
        bool EditTrackSpendInfo(TrackSpendDTO DTO);
        bool DeleteClassifyInfo(int ClassifyId);
        List<List<List<string>>> Make3Array(List<TrackSpendDTO> Tracks);
    }
}
