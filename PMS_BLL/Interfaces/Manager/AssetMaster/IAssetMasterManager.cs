using PMS_BOL.Models.Asset_Mgt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BLL.Interfaces.Manager.AssetMaster
{
    public interface IAssetMasterManager
    {
        Task<DataTable> GetCompany();
        Task<DataTable> GetDepartment( int comID);

        Task<DataTable> GetSection(int comID , int DeptID);
        Task<DataTable> GetFloor(int comID);

        Task<DataTable> GetLine(int comID, int floorID);
        Task<DataTable> GetAssetCategory();

        Task<DataTable> GetAsstSpecialFeature();

        Task<DataTable> GetAssetStatus();
        Task<DataTable> GetMachineName();
        Task<DataTable> GetSupplierName();
        Task<DataTable> GetBrand();
        Task<DataTable> GetCurrency();
        Task<DataTable> BindCURRENTHOLDER();
        Task <DataTable> GetAll_AssetMaster_List();
        Task<string> SaveAsset(List<Asset_Master_Save> Asst);

        Task<string> UpdateAssetInfo(List<Asset_Master_Save > asset_update_put);

        Task<DataTable> Mr_Asset_Master_(string AsstNo);



















    }
}
