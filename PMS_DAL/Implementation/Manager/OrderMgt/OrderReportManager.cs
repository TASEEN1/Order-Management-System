using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Reporting.NETCore;
using PMS_BLL.Interfaces.Manager.OrderMgt;
using PMS_BLL.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace PMS_DAL.Implementation.Manager.OrderMgt
{
    public class OrderReportManager : IOrderReportManager
    {
        private readonly Dg_SqlCommon _SqlCommon;
        private readonly SqlConnection _specfo_conn;
        private readonly SqlConnection _dg_Asst_Mgt;
        private readonly SqlConnection _SpecFoInventory;
        private readonly SqlConnection _dg_Oder_Mgt;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public OrderReportManager(Dg_SqlCommon sqlCommon, IWebHostEnvironment webHostEnvironment)
        {
            _SqlCommon = sqlCommon;
            _webHostEnvironment = webHostEnvironment;
            _specfo_conn = new SqlConnection(Dg_Getway.SpecFoCon);
            _dg_Asst_Mgt = new SqlConnection(Dg_Getway.dg_Asst_Mgt);
            _SpecFoInventory = new SqlConnection(Dg_Getway.SpecFoInventory);
            _dg_Oder_Mgt = new SqlConnection(Dg_Getway.dg_Oder_Mgt);

        }


        public byte[] OrderReceivedReport (int comID , string UserName , string reportType, int? customer, string? style)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("dg_report_order_receiving_Rpt ");
            stringBuilder.Append(customer != null ? customer : "NULL");
            stringBuilder.Append(", '" + (style != null ? style : "NULL"));
            stringBuilder.Append(" '");
            //stringBuilder.Append(FromDate.ToString("yyyy-MM-dd") + "', '");
            //stringBuilder.Append(ToDate.ToString("yyyy-MM-dd"));
            //stringBuilder.Append(" '");

            string stateQu = stringBuilder.ToString();
            var tbldata = new DataTable[]
            {
                 
                 _SqlCommon.get_InformationDataTable(stateQu,_dg_Oder_Mgt)
            };
            var strSetName = new string[]
            {
                "OrdDataSet"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Order_Mgt_Report\\OrderWiseRpt.rdlc";
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Style Wise Order Receive Report"),
            new ReportParameter("PrintUser",  "" + UserName + "")
            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;


        }


        public byte[] ProformaInvoiceReport(int comID, string UserName, string reportType, string? pi_number)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("dg_report_proforma_invoice_Rpt ");
            //stringBuilder.Append(pi_issued_ref_no != null ? pi_issued_ref_no : "NULL");
            //stringBuilder.Append(pi_number != null ? pi_number : "NULL");
            stringBuilder.Append(" '" + (pi_number != null ? pi_number : "NULL"));
            stringBuilder.Append("' ");

            string stateQu = stringBuilder.ToString();
            var tbldata = new DataTable[]
            {

                 _SqlCommon.get_InformationDataTable(stateQu,_dg_Oder_Mgt)
            };
            var strSetName = new string[]
            {
                "OrdDataSet"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Order_Mgt_Report\\Proforma_Invoice.rdlc";
            string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;

            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("UserSignPath",imgERP),
            new ReportParameter("Title", "Proforma Invoice"),
            new ReportParameter("PrintUser",  "" + UserName + "")
            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;


        }

       

        public byte[] WorkOrderReportFormate(int comID, string UserName, string reportType, int Rrf_No, int customerId)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            var tbldata = new DataTable[]
            {
                _SqlCommon.get_InformationDataTable("dg_report_work_order_Rpt_2 '"+customerId+"','"+ Rrf_No + "'", _dg_Oder_Mgt),

            };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Order_Mgt_Report\\WorkOrderFormate.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Attributes From"),
            new ReportParameter("PrintUser", "" + UserName + "")

            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }


        public byte[] ProductionSummaryReport(int comID, string UserName, string reportType, DateTime FromDate, DateTime ToDate)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            var tbldata = new DataTable[]
            {
                _SqlCommon.get_InformationDataTable("dg_report_production__Rpt '"+FromDate+"','"+ ToDate + "'", _dg_Oder_Mgt),
                //_SqlCommon.get_InformationDataTable("dg_report_production_Rpt2 '"+FromDate+"','"+ ToDate + "'", _dg_Oder_Mgt),

            };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Order_Mgt_Report\\Production_Summary.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Production Summary"),
            new ReportParameter("PrintUser", "" + UserName + "")

            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }

        public byte[] DailyProductionSummaryReport(int comID, string UserName, string reportType,int processType, DateTime FromDate, DateTime ToDate)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("dg_report_daily_production_Summary_Rpt ");
            stringBuilder.Append(processType != null ? processType : "NULL");
            stringBuilder.Append(" ,'");
            stringBuilder.Append(FromDate.ToString("yyyy-MM-dd") + " '");
            //stringBuilder.Append(ToDate.ToString("yyyy-MM-dd"));
            //stringBuilder.Append(" '");
            string stateQu = stringBuilder.ToString();
            var tbldata = new DataTable[]
            {

                 _SqlCommon.get_InformationDataTable(stateQu,_dg_Oder_Mgt)
            };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Order_Mgt_Report\\DailyProductionSummary.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            string reportTitle = processType == 1 ? "Padding Production Report" : "Quilting Production Report";

            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title",reportTitle),
            new ReportParameter("PrintUser", "" + UserName + "")

            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }
        public byte[] DailyPlaningReport(int comID, string UserName, string reportType, int processType, DateTime FromDate)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("dg_report_Daily_Planing_Rpt ");
            stringBuilder.Append(processType != null ? processType : "NULL");
            stringBuilder.Append(" ,'");
            stringBuilder.Append(FromDate.ToString("yyyy-MM-dd") + " '");
            //stringBuilder.Append(ToDate.ToString("yyyy-MM-dd"));
            //stringBuilder.Append(" '");
            string stateQu = stringBuilder.ToString();
            var tbldata = new DataTable[]
            {

                 _SqlCommon.get_InformationDataTable(stateQu,_dg_Oder_Mgt)
            };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Order_Mgt_Report\\DailyPlaningReport.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            string reportTitle = processType == 1 ? "Padding Daily Planning Report" : "Quilting Daily Planning Report";

            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title",reportTitle),
            new ReportParameter("PrintUser", "" + UserName + "")

            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }
        public byte[] Daily_p_and_Q_Machine_PlannigReport(int comID, string UserName, string reportType, int processType, DateTime FromDate)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("dg_report_Daily_P_and_Q_Machine_Planing_Rpt ");
            stringBuilder.Append(processType != null ? processType : "NULL");
            stringBuilder.Append(" ,'");
            stringBuilder.Append(FromDate.ToString("yyyy-MM-dd") + " '");
            //stringBuilder.Append(ToDate.ToString("yyyy-MM-dd"));
            //stringBuilder.Append(" '");
            string stateQu = stringBuilder.ToString();
            var tbldata = new DataTable[]
            {

                 _SqlCommon.get_InformationDataTable(stateQu,_dg_Oder_Mgt)
            };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Order_Mgt_Report\\Daily_P&Q_Machine_Planning.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            string reportTitle = processType == 1 ? " Daily Padding Mechine Planning Report" : " Daily Quilting Mechine Planning Report";

            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title",reportTitle),
            new ReportParameter("PrintUser", "" + UserName + "")

            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }
        public byte[] StyleWisePeoductionReport(int comID, string UserName, string reportType, int customer, int refNO ,string Style, int processType, DateTime FromDate)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("dg_report_production_StyleWise_Rpt ");
            stringBuilder.Append(customer != null ? customer : "NULL" );
            stringBuilder.Append(" ,");
            stringBuilder.Append(refNO != null ? refNO : "NULL");
            stringBuilder.Append("  ,'");
            stringBuilder.Append(Style != null ? Style : "NULL");
            stringBuilder.Append(" ',");
            stringBuilder.Append(processType != null ? processType : "NULL");
            stringBuilder.Append(" ,'");
            stringBuilder.Append(FromDate.ToString("yyyy-MM-dd") +" '");
            //stringBuilder.Append(ToDate.ToString("yyyy-MM-dd"));
            //stringBuilder.Append(" '");
            string stateQu = stringBuilder.ToString();
            var tbldata = new DataTable[]
            {

                 _SqlCommon.get_InformationDataTable(stateQu,_dg_Oder_Mgt)
            };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Order_Mgt_Report\\StyleWiseProductionReport.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            string reportTitle = processType == 1 ? "Padding Style Wise Production Report" : "Quilting Style Wise Production Reportt";

            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title",reportTitle),
            new ReportParameter("PrintUser", "" + UserName + "")

            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }
        public byte[] HourlyPeoductionReport(int comID, string UserName, string reportType, DateTime productionDate,int? pprodprocID)
        {
            

            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("dg_report_production_hourly ");
            stringBuilder.Append(" '");
            stringBuilder.Append(productionDate.ToString("yyyy-MM-dd") + " ',");
            stringBuilder.Append(pprodprocID != null ? pprodprocID : "NULL");
            string stateQu = stringBuilder.ToString();
            var tbldata = new DataTable[]
            {

                 _SqlCommon.get_InformationDataTable(stateQu,_dg_Oder_Mgt)
            };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Order_Mgt_Report\\ProductionReport.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            string reportTitle = pprodprocID == 1 ? "Padding Hourly Production Report" : "Quilting Hourly Production Report";

            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title",reportTitle),
            new ReportParameter("PrintUser", "" + UserName + "")

            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }

        public byte[] OrderReceivedReportD2D(int comID, string UserName, string reportType, DateTime FromDate, DateTime ToDate)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("dg_report_order_receiving_RptD2D ");
            stringBuilder.Append(" '");
            stringBuilder.Append(FromDate.ToString("yyyy-MM-dd") + " ','");
            stringBuilder.Append(ToDate.ToString("yyyy-MM-dd") + " '");
            string stateQu = stringBuilder.ToString();
            var tbldata = new DataTable[]
            {

                 _SqlCommon.get_InformationDataTable(stateQu,_dg_Oder_Mgt)
            };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Order_Mgt_Report\\OrderReceivedReportD2D.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            //string reportTitle = processType == 1 ? "Padding Style Wise Production Report" : "Quilting Style Wise Production Reportt";

            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title","Order Received Report D2D"),
            new ReportParameter("PrintUser", "" + UserName + "")

            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }

        public byte[] OrderSummaryReport(int comID, string UserName, string reportType, DateTime FromDate)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            var tbldata = new DataTable[]
            {
                _SqlCommon.get_InformationDataTable("dg_report_Order_Summary_Rpt'"+FromDate+"'", _dg_Oder_Mgt),
                _SqlCommon.get_InformationDataTable("dg_report_order_summary_custBuyerItem'"+FromDate+"'", _dg_Oder_Mgt),
               



            };
            var strSetName = new string[]
            {
                "DataSet1", "DataSet2"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Order_Mgt_Report\\Order_Summary_report.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            //string reportTitle = processType == 1 ? "Padding Style Wise Production Report" : "Quilting Style Wise Production Reportt";

            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title","Order Summary Report"),
            new ReportParameter("PrintUser", "" + UserName + "")

            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }
        public byte[] BuyerAndShiftWise_ProductionReport(int comID, string UserName, string reportType, DateTime productionDate)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("dg_report_production_buyerwiseShift");
            stringBuilder.Append(" '");
            stringBuilder.Append(productionDate.ToString("yyyy-MM-dd") + " '");
            string stateQu = stringBuilder.ToString();
            var tbldata = new DataTable[]
            {

                 _SqlCommon.get_InformationDataTable(stateQu,_dg_Oder_Mgt)
            };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Order_Mgt_Report\\Buyer&ShiftWise_ProductionReport.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            //string reportTitle = processType == 1 ? "Padding Style Wise Production Report" : "Quilting Style Wise Production Reportt";

            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title","Buyer Wise Production Report"),
            new ReportParameter("PrintUser", "" + UserName + "")

            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }
        public byte[] PaddingRaw_MaterialReport(int comID, string UserName, string reportType, DateTime productionDate, int MachineId)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            var tbldata = new DataTable[]
            {
                _SqlCommon.get_InformationDataTable("dg_report_Raw_material_Rpt'"+productionDate+"','"+ MachineId + "'", _dg_Oder_Mgt),
                _SqlCommon.get_InformationDataTable("dg_report_Raw_materia_PSF_Rpt'"+productionDate+"','"+ MachineId + "'", _dg_Oder_Mgt),
                _SqlCommon.get_InformationDataTable("dg_report_Raw_materia_Resin_Rpt'"+productionDate+"','"+ MachineId + "'", _dg_Oder_Mgt),
                _SqlCommon.get_InformationDataTable("dg_report_raw_material_remarks'"+productionDate+"','"+ MachineId + "'", _dg_Oder_Mgt),



            };
            var strSetName = new string[]
            {
                "DataSet1",  "DataSet2",  "DataSet3","DataSet4"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Order_Mgt_Report\\Padding_Raw_Material_Report.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            //string reportTitle = processType == 1 ? "Padding Style Wise Production Report" : "Quilting Style Wise Production Reportt";

            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title","Daily Padding Production Report"),
            new ReportParameter("PrintUser", "" + UserName + "")

            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }
        public byte[] AttributeFromReport(int comID, string UserName, string reportType, string? pi_number)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            var tbldata = new DataTable[]
             {
                _SqlCommon.get_InformationDataTable("dg_report_work_order_Rpt '"+pi_number+"'", _dg_Oder_Mgt),

             };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Order_Mgt_Report\\AttributeFrom.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
           
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title","Attribute From"),
            new ReportParameter("PrintUser", "" + UserName + "")

            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }
        public byte[] Delivery_ChallanReport(int comID, string UserName, string reportType,int Refno)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            var tbldata = new DataTable[]
             {
                _SqlCommon.get_InformationDataTable("dg_report_Delivery_Challan '"+Refno+"'", _dg_Oder_Mgt),

             };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Order_Mgt_Report\\DeliveryChallanReport.rdlc";
            string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;

            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("UserSignPath",imgERP),
            new ReportParameter("Title","Attribute From"),
            new ReportParameter("PrintUser", "" + UserName + "")

            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }

        public byte[] Production_And_Delivery_StatusReport(int comID, string UserName, string reportType, DateTime FromDate, DateTime ToDate)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("dg_report_productionNDelivery_balance ");
            stringBuilder.Append(" '");
            stringBuilder.Append(FromDate.ToString("yyyy-MM-dd") + " ','");
            stringBuilder.Append(ToDate.ToString("yyyy-MM-dd") + " '");
            string stateQu = stringBuilder.ToString();
            var tbldata = new DataTable[]
            {

                 _SqlCommon.get_InformationDataTable(stateQu,_dg_Oder_Mgt)
            };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Order_Mgt_Report\\ProductionAndDeliveryStatus.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            //string reportTitle = processType == 1 ? "Padding Style Wise Production Report" : "Quilting Style Wise Production Reportt";

            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title","Production And Delivery Status"),
            new ReportParameter("PrintUser", "" + UserName + "")

            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }




        //Common Report Code
        private byte[] GenerateReport(DataTable dataTable, string datasetName, string rdlcFilePath, string reportType, ReportParameterCollection reportParameters = null)
        {
            LocalReport localReport = new LocalReport();
            ReportDataSource reportDataSource = new ReportDataSource(datasetName, dataTable);
            localReport.ReportPath = rdlcFilePath;
            localReport.EnableExternalImages = true;
            localReport.DataSources.Clear();
            localReport.DataSources.Add(reportDataSource);
            if (reportParameters != null)
            {
                localReport.SetParameters(reportParameters);
            }
            localReport.Refresh();
            byte[] reportBytes;
            switch (reportType.ToUpper())
            {
                case "PDF":
                    reportBytes = localReport.Render("PDF");
                    break;
                case "EXCEL":
                    reportBytes = localReport.Render("EXCELOPENXML");
                    break;
                case "WORD":
                    reportBytes = localReport.Render("WORDOPENXML");
                    break;
                default:
                    throw new ArgumentException("Unsupported report type");
            }
            return reportBytes;
        }
        private byte[] GenerateReport(DataTable[] dataTable, string[] datasetName, string rdlcFilePath, string reportType, ReportParameterCollection reportParameters = null)
        {
            LocalReport localReport = new LocalReport();
            localReport.DataSources.Clear();
            for (int i = 0; i < dataTable.Length; i++)
            {
                string dataset = datasetName[i];
                var dt = dataTable[i];
                ReportDataSource reportDataSource = new ReportDataSource(dataset, dt);
                localReport.DataSources.Add(reportDataSource);
            }
            localReport.ReportPath = rdlcFilePath;
            localReport.EnableExternalImages = true;
            if (reportParameters != null)
            {
                localReport.SetParameters(reportParameters);
            }
            localReport.Refresh();
            byte[] reportBytes;
            switch (reportType.ToUpper())
            {
                case "PDF":
                    reportBytes = localReport.Render("PDF");
                    break;
                case "EXCEL":
                    reportBytes = localReport.Render("EXCELOPENXML");
                    break;
                case "WORD":
                    reportBytes = localReport.Render("WORDOPENXML");
                    break;
                default:
                    throw new ArgumentException("Unsupported report type");
            }
            return reportBytes;
        }



    }
}
