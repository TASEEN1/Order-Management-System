using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;
using PMS_BLL.Utility;
using PMS_BOL.Functions;
using PMS_BOL.Models.Asset_Mgt;
using System.Net.Mime;

namespace PMS_API.Controllers.Asset_mgt
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AssetReportController : ControllerBase
    {
        private readonly IGlobalMaster _globalMaster;

        public AssetReportController(IGlobalMaster globalMaster)
        {
            _globalMaster = globalMaster;
        }



        [HttpGet]
        public async Task<IActionResult> AssetDetailsSummary(string reportType, int comID, string UserName, int? floor, int? Line, int? status, int? AssetCetagory, DateTime FromDate, DateTime ToDate)


        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.asset_ReportManager.AssetDetailsSummary(reportType, comID, UserName, floor, Line, status, AssetCetagory, FromDate, ToDate);
            return File(data, MediaTypeNames.Application.Octet, reportFileExt.GetContentType(reportType));
        }

        [HttpGet]
        public async Task<IActionResult> AssetDetailsReport(string reportType, int ComID, string UserName, int? floor, int? Line, int? status, int? AssetCetagory, DateTime FromDate, DateTime ToDate)
        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.asset_ReportManager.AssetDetailsReport(reportType, ComID, UserName, floor, Line, status, AssetCetagory, FromDate, ToDate);
            return File(data, MediaTypeNames.Application.Octet, reportFileExt.GetContentType(reportType));
        }

        [HttpGet]
        public async Task<IActionResult> AssetDetails_RepairReport(string reportType, int ComID, string UserName, int? floor, int? Line, int? status, DateTime FromDate, DateTime ToDate)
        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.asset_ReportManager.AssetDetails_RepairReport(reportType, ComID, UserName, floor, Line, status, FromDate, ToDate);
            return File(data, MediaTypeNames.Application.Octet, reportFileExt.GetContentType(reportType));

        }


        [HttpGet]
        public async Task<IActionResult> AssetDetailsMaster_Report(string reportType, int ComID, string UserName, int? floor, int? Line, int? status, int? AssetCetagory, DateTime FromDate, DateTime ToDate)
        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.asset_ReportManager.AssetDetailsMaster_Report(reportType, ComID, UserName, floor, Line, status, AssetCetagory, FromDate, ToDate);
            return File(data, MediaTypeNames.Application.Octet, reportFileExt.GetContentType(reportType));

        }


        //1 no report
        [HttpGet]
        public async Task<IActionResult> AssetManagementReport(string reportType, int? ComID, string UserName, int? floor, int? line, int? status, int? AssetCategory, DateTime FromDate, DateTime ToDate)
        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.asset_ReportManager.AssetManagementReport(reportType, ComID, UserName, floor, line, status, AssetCategory, FromDate, ToDate);
            return File(data, MediaTypeNames.Application.Octet, reportFileExt.GetContentType(reportType));
        }

        [HttpGet]
        public async Task<IActionResult> AssetSummaryReport(string reportType, int comID, string UserName)
        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.asset_ReportManager.AssetSummaryReport(reportType, comID, UserName);
            return File(data, MediaTypeNames.Application.Octet, reportFileExt.GetContentType(reportType));

        }
        [HttpGet]
        public async Task<IActionResult> RentedAssetDetailsReport(string reportType, int comID, string UserName)
        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.asset_ReportManager.RentedAssetDetailsReport(reportType, comID, UserName);
            return File(data, MediaTypeNames.Application.Octet, reportFileExt.GetContentType(reportType));

        }
        [HttpGet]
        public async Task<IActionResult> InternalFixedAssetTransferReport(string reportType, string UserName, int? comID, int? Floor, int? Line, int? AssetCetagory, DateTime FromDate, DateTime ToDate)
        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.asset_ReportManager.InternalFixedAssetTransferReport(reportType, UserName, comID, Floor, Line, AssetCetagory, FromDate, ToDate);
            return File(data, MediaTypeNames.Application.Octet, reportFileExt.GetContentType(reportType));
        }


        [HttpGet]
        public async Task<IActionResult> ExternalFixedAssetTransferReport(string reportType, int fromComId, int toComId, string UserName)
        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.asset_ReportManager.ExternalFixedAssetTransferReport(reportType, fromComId, toComId, UserName);
            return File(data, MediaTypeNames.Application.Octet, reportFileExt.GetContentType(reportType));

        }

        [HttpGet]
        public async Task<IActionResult> ScheduledMaintenanceReport(string reportType, int comID, string UserName, int? floor, int? Line, DateTime FromDate, DateTime ToDate)
        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.asset_ReportManager.ScheduledMaintenanceReport(reportType, comID, UserName, floor, Line, FromDate, ToDate);
            return File(data, MediaTypeNames.Application.Octet, reportFileExt.GetContentType(reportType));

        }


        [HttpPost]
        public async Task<IActionResult> ReportParameterSave(List<ReportParameterModel> app)
        {
            var data = await _globalMaster.asset_ReportManager.ReportParameterSave(app);
            return Ok(data);

        }


    }

}
