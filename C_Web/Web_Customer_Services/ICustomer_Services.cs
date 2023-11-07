using C_WebDTO.CommonDTO;
using C_WebDTO.Customer;

namespace Web_Customer_Services
{
    public interface ICustomer_Services
    {
        List<DataTableDTO_content> GetCustomerInfoTable(FetchDTO DTO);



        #region CusBasic
        List<DataTableDTO_content> GetCusIndustrialBasicTable();
        List<DataTableDTO_content> GetCusAttributeBasicTable();

        bool CreateIndustrial(Customer_BasicDTO basicDTO);
        bool CreateAttribute(Customer_BasicDTO basicDTO);
        bool EditIndustrial(Customer_BasicDTO basicDTO);
        bool EditAttribute(Customer_BasicDTO basicDTO);
        bool DeleteIndustrial(Customer_BasicDTO basicDTO);
        bool DeleteAttribute(Customer_BasicDTO basicDTO);
        #endregion

        #region CusConBasic
        List<DataTableDTO_content> GetConTypeBasicTable();
        List<DataTableDTO_content> GetConAreaBasicTable();
        bool CreateContactType(Customer_BasicDTO basicDTO);
        bool CreateContactArea(Customer_BasicDTO basicDTO);
        bool EditContactType(Customer_BasicDTO basicDTO);
        bool EditContactArea(Customer_BasicDTO basicDTO);
        bool DeleteContactType(Customer_BasicDTO basicDTO);
        bool DeleteContactArea(Customer_BasicDTO basicDTO);
        #endregion
    }
}