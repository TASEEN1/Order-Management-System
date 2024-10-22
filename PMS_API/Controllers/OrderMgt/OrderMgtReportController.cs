using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;
using PMS_BOL.Functions;
using System.Net.Mime;

namespace PMS_API.Controllers.OrderMgt
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class OrderMgtReportController : ControllerBase
    {
        private readonly IGlobalMaster _globalMaster;

        public OrderMgtReportController(IGlobalMaster globalMaster)
        {
            _globalMaster = globalMaster;
        }

        [HttpGet]
        public async Task<IActionResult> OrderReceivedReport(int comID, string UserName, string reportType, int? customer, string? style)


        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.orderReportManager.OrderReceivedReport(comID, UserName, reportType, customer, style);
            return File(data, MediaTypeNames.Application.Octet, (reportFileExt.GetContentType(reportType)));
        }

        [HttpGet]
        public async Task<IActionResult> ProformaInvoiceReport(int comID, string UserName, string reportType,  string? pi_number)


        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.orderReportManager.ProformaInvoiceReport(comID, UserName, reportType, pi_number);
            return File(data, MediaTypeNames.Application.Octet, (reportFileExt.GetContentType(reportType)));
        }

        [HttpGet]
        public async Task<IActionResult>WorkOrderReportFormate(int comID, string UserName, string reportType, int Rrf_No, int customerId)


        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.orderReportManager.WorkOrderReportFormate(comID, UserName, reportType, Rrf_No,customerId);
            return File(data, MediaTypeNames.Application.Octet, (reportFileExt.GetContentType(reportType)));
        }
        [HttpGet]
        public async Task<IActionResult> ProductionSummaryReport(int comID, string UserName, string reportType, DateTime FromDate, DateTime ToDate)


        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.orderReportManager.ProductionSummaryReport(comID, UserName, reportType, FromDate, ToDate);
            return File(data, MediaTypeNames.Application.Octet, (reportFileExt.GetContentType(reportType)));
        }
        [HttpGet]
        public async Task<IActionResult> DailyProductionSummaryReport(int comID, string UserName, string reportType, int processType, DateTime FromDate, DateTime ToDate)


        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.orderReportManager.DailyProductionSummaryReport(comID, UserName, reportType,processType, FromDate, ToDate);
            return File(data, MediaTypeNames.Application.Octet, (reportFileExt.GetContentType(reportType)));
        }

        [HttpGet]
        public async Task<IActionResult> DailyPlaningReport(int comID, string UserName, string reportType, int processType, DateTime FromDate)


        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.orderReportManager.DailyPlaningReport(comID, UserName, reportType, processType, FromDate);
            return File(data, MediaTypeNames.Application.Octet, (reportFileExt.GetContentType(reportType)));
        }
        [HttpGet]
        public async Task<IActionResult> Daily_p_and_Q_Machine_PlannigReport(int comID, string UserName, string reportType, int processType, DateTime FromDate)


        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.orderReportManager.Daily_p_and_Q_Machine_PlannigReport(comID, UserName, reportType, processType, FromDate);
            return File(data, MediaTypeNames.Application.Octet, (reportFileExt.GetContentType(reportType)));
        }

        [HttpGet]
        public async Task<IActionResult> StyleWisePeoductionReport(int comID, string UserName, string reportType, int customer, int refNO, string Style, int processType, DateTime FromDate)


        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.orderReportManager.StyleWisePeoductionReport(comID, UserName, reportType, customer, refNO, Style, processType, FromDate);
            return File(data, MediaTypeNames.Application.Octet, (reportFileExt.GetContentType(reportType)));
        }

        [HttpGet]
        public async Task<IActionResult> HourlyPeoductionReport(int comID, string UserName, string reportType, DateTime productionDate,  int? prodprocID)


        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.orderReportManager.HourlyPeoductionReport(comID, UserName, reportType, productionDate,  prodprocID);
            return File(data, MediaTypeNames.Application.Octet, (reportFileExt.GetContentType(reportType)));
        }

        [HttpGet]
        public async Task<IActionResult> OrderReceivedReportD2D(int comID, string UserName, string reportType, DateTime FromDate, DateTime ToDate)


        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.orderReportManager.OrderReceivedReportD2D(comID, UserName, reportType, FromDate, ToDate);
            return File(data, MediaTypeNames.Application.Octet, (reportFileExt.GetContentType(reportType)));
        }

        [HttpGet]
        public async Task<IActionResult> OrderSummaryReport(int comID, string UserName, string reportType, DateTime FromDate)


        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.orderReportManager.OrderSummaryReport(comID, UserName, reportType, FromDate);
            return File(data, MediaTypeNames.Application.Octet, (reportFileExt.GetContentType(reportType)));
        }
        [HttpGet]
        public async Task<IActionResult> AttributeFromReport(int comID, string UserName, string reportType, string pi_number)


        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.orderReportManager.AttributeFromReport(comID, UserName, reportType, pi_number);
            return File(data, MediaTypeNames.Application.Octet, (reportFileExt.GetContentType(reportType)));
        }
          [HttpGet]
        public async Task<IActionResult> BuyerAndShiftWise_ProductionReport(int comID, string UserName, string reportType, DateTime productionDate)


        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.orderReportManager.BuyerAndShiftWise_ProductionReport(comID, UserName, reportType, productionDate);
            return File(data, MediaTypeNames.Application.Octet, (reportFileExt.GetContentType(reportType)));
        }
        [HttpGet]
        public async Task<IActionResult> PaddingRaw_MaterialReport(int comID, string UserName, string reportType, DateTime productionDate, int MachineId)


        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.orderReportManager.PaddingRaw_MaterialReport(comID, UserName, reportType, productionDate, MachineId);
            return File(data, MediaTypeNames.Application.Octet, (reportFileExt.GetContentType(reportType)));
        }
        [HttpGet]
        public async Task<IActionResult> Delivery_ChallanReport(int comID, string UserName, string reportType, int Refno)


        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.orderReportManager.Delivery_ChallanReport(comID, UserName, reportType, Refno);
            return File(data, MediaTypeNames.Application.Octet, (reportFileExt.GetContentType(reportType)));
        }

        [HttpGet]
        public async Task<IActionResult> Production_And_Delivery_StatusReport(int comID, string UserName, string reportType, DateTime FromDate, DateTime ToDate)


        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.orderReportManager.Production_And_Delivery_StatusReport(comID, UserName, reportType, FromDate, ToDate);
            return File(data, MediaTypeNames.Application.Octet, (reportFileExt.GetContentType(reportType)));
        }


    }
}
