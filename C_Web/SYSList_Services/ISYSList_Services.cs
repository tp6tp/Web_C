using C_Web.Entity.SYS;
using C_WebDTO.CommonDTO;

namespace Web_SYSList_Services
{
    public interface ISYSList_Services
    {
        SYS_List GetEditModel(long Id);
        string GetFatherName(long? SYSListId);
        List<SYS_List> GetAllSYSList();

        List<DataTableDTO_content> GetSYSListTable(long? SYSListId);

        bool CreateSYSList(FetchDTO ListModel);
        bool EditSYSList(SYS_List ListModel);
        bool OnOff(FetchDTO DTO);
        bool SYSListOrder(object[] data, object[] order);
    }
}