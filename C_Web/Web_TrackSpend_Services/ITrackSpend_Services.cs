
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


        bool CreateClassifyInfo(ClassIconDTO DTO);
        bool CreateTrackSpendInfo(TrackSpendDTO DTO);
    }
}
