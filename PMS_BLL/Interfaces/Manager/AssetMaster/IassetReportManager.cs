using PMS_BOL.Models.Asset_Mgt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BLL.Interfaces.Manager.AssetMaster
{
    public interface IAssetReportManager
    {
        public byte[] AssetDetailsSummary(string reportType, int comID,  string UserName, int? floor, int? Line, int? status, int? AssetCetagory, DateTime FromDate, DateTime ToDate);

        public byte[] AssetDetailsReport(string reportType, int comID, string UserName, int? floor, int? Line, int? status, int? AssetCetagory, DateTime FromDate, DateTime ToDate);
        public byte[] AssetDetails_RepairReport(string reportType, int comID, string UserName, int? floor, int? Line, int? status, DateTime FromDate, DateTime ToDate);
        public byte[] AssetDetailsMaster_Report(string reportType, int comID, string UserName, int? floor, int? Line, int? status, int? AssetCetagory, DateTime FromDate, DateTime ToDate);
        //1 no report
        public byte[] AssetManagementReport(string reportType, int? ComID, string UserName, int? floor, int? line, int? status, int? AssetCategory, DateTime FromDate, DateTime ToDate);
        public byte[] AssetSummaryReport(string reportType, int comID, string UserName);
        public byte[] RentedAssetDetailsReport(string reportType, int comID, string UserName);
        public byte[] InternalFixedAssetTransferReport(string reportType, string UserName, int? comID, int? Floor, int? Line, int? AssetCetagory, DateTime FromDate, DateTime ToDate);
        public byte[] ExternalFixedAssetTransferReport(string reportType, int fromComId, int toComId, string UserName);
        public byte[] ScheduledMaintenanceReport(string reportType, int comID, string UserName, int? floor, int? Line, DateTime FromDate, DateTime ToDate);
        public Task<string> ReportParameterSave(List<ReportParameterModel> app);







    }

    
}
