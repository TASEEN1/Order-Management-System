using PMS_BOL.Models.Asset_Mgt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BLL.Interfaces.Manager.AssetMaster
{
    public interface IAssetTransferManager
    {
        public Task<DataTable> Get_Company_CH();
        public Task<DataTable> BindFloor( int ComID);

        public Task<DataTable> GetLine( int ComID , int FloorID);
        public Task<DataTable> IGet_Asst_No(int ComID, int floorID, int LineID);

        public Task<DataTable> EGet_Asst_No(int ComID);

        public Task<string> Internal_Transfer_Save(List<Asset_Transfer_Model> App);
        public Task<string> External_Transfer_Save(List<Asset_Transfer_Model> App);
        public Task<DataTable> GetInternalTransferAddView( int ComID , string InputUser);
        public Task<DataTable> GetExternalTransferAddView(int ComID, string InputUser);
        public Task<DataTable> GetExternalTransferView(int ComID);
        public Task<DataTable>GetInternalTransferView(int ComID);

        Task<bool> Asset_InternalTransfer_Approval(List<Asset_Internal_Transfer_Approval> App);
        Task<bool> Asset_ExternalTransfer_Approval(List<Asset_External_Transfer_Approval> App);
        Task<DataTable>GetTransferView(int ComID);








    }
}
