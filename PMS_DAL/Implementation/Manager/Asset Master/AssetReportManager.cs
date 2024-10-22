using Microsoft.AspNetCore.Hosting;
using PMS_BLL.Interfaces.Manager.AssetMaster;
using PMS_BLL.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Reporting.NETCore;
using System.Data;
using System.Drawing;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Security.Cryptography;
using PMS_BOL.Models.Asset_Mgt;

namespace PMS_DAL.Implementation.Manager.Asset_Master
{
    public class AssetReportManager:IAssetReportManager
    {
        private readonly Dg_SqlCommon _SqlCommon;
        private readonly SqlConnection _specfo_conn;
        private readonly SqlConnection _dg_Asst_Mgt;
        private readonly SqlConnection _SpecFoInventory;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AssetReportManager(Dg_SqlCommon sqlCommon, IWebHostEnvironment webHostEnvironment)
        {
            _SqlCommon = sqlCommon;
            _webHostEnvironment = webHostEnvironment;
            _specfo_conn = new SqlConnection(Dg_Getway.SpecFoCon);
            _dg_Asst_Mgt = new SqlConnection(Dg_Getway.dg_Asst_Mgt);
            _SpecFoInventory = new SqlConnection(Dg_Getway.SpecFoInventory);
        }

       

        public byte[] AssetDetailsSummary(string reportType, int comID,  string UserName, int? floor, int? Line, int? status, int? AssetCetagory, DateTime FromDate, DateTime ToDate)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Mr_Asset_Details_Summary_Rpt ");
            stringBuilder.Append(comID);
            stringBuilder.Append(", " + (floor != null ? floor : "NULL"));
            stringBuilder.Append(", " + (Line != null ? Line : "NULL"));
            stringBuilder.Append(", " + (status != null ? status : "NULL"));
            stringBuilder.Append(", " + (AssetCetagory != null ? AssetCetagory : "NULL"));
            stringBuilder.Append(", '");
            stringBuilder.Append(FromDate.ToString("yyyy-MM-dd") + "', '");
            stringBuilder.Append(ToDate.ToString("yyyy-MM-dd"));
            stringBuilder.Append("' ");

            string stateQu = stringBuilder.ToString();
            var tbldata = new DataTable[]
            {
                 //_SqlCommon.get_InformationDataTable("Mr_Asset_Details_Summary_Rpt '"+ AsstCat + "','"+status+"','"+floor+"','"+line+"'",_dg_Asst_Mgt),
                 _SqlCommon.get_InformationDataTable(stateQu,_dg_Asst_Mgt)
               

            };
            var strSetName = new string[]
            {
                "AsstDetailSumm"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Asset_report\\AssetDetailsSummary.rdlc";
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Asset Details Summary Rport- Fectory:"  +ComName+""),
            new ReportParameter("PrintUser",  "" + UserName + "")
            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;


        }

        public byte[] AssetDetailsReport(string reportType, int comID,  string UserName, int? floor, int? Line, int? status, int? AssetCetagory, DateTime FromDate, DateTime ToDate)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Mr_Asset_Master_List_Info_Rpt ");
            stringBuilder.Append(comID);
            stringBuilder.Append(", " + (floor != null ? floor : "NULL"));
            stringBuilder.Append(", " + (Line != null ? Line : "NULL"));
            stringBuilder.Append(", " + (status != null ? status : "NULL"));
            stringBuilder.Append(", " + (AssetCetagory != null ? AssetCetagory : "NULL"));
            stringBuilder.Append(", '");
            stringBuilder.Append(FromDate.ToString("yyyy-MM-dd") + "', '");
            stringBuilder.Append(ToDate.ToString("yyyy-MM-dd"));
            stringBuilder.Append("' ");

            string stateQu = stringBuilder.ToString();

            var tbldata = new DataTable[]
            {
                 _SqlCommon.get_InformationDataTable(stateQu,_dg_Asst_Mgt)

            };
            var strSetName = new string[]
            {
                "Asset_DtailsDataset"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Asset_report\\Asset Details.rdlc";
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Asset Details Report- Fectory: "+ComName+""),
            new ReportParameter("PrintUser",  "" + UserName + "")
            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;


        }
        public byte[] AssetDetails_RepairReport(string reportType, int comID, string UserName, int? floor , int? Line,int?  status, DateTime FromDate, DateTime ToDate)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DG_Asset_Running_Repair_Details_Rpt ");
            stringBuilder.Append(comID);
            stringBuilder.Append(", " + (floor != null ? floor : "NULL"));
            stringBuilder.Append(", " + (Line != null ? Line : "NULL"));
            stringBuilder.Append(", " + (status != null ? status : "NULL"));
            //stringBuilder.Append(", " + (AssetCetagory != null ? AssetCetagory : "NULL"));
            stringBuilder.Append(", '");
            stringBuilder.Append(FromDate.ToString("yyyy-MM-dd") + "', '");
            stringBuilder.Append(ToDate.ToString("yyyy-MM-dd"));
            stringBuilder.Append("' ");
            string stateQu = stringBuilder.ToString();
            var tbldata = new DataTable[]
            {
                 
                 _SqlCommon.get_InformationDataTable(stateQu,_dg_Asst_Mgt)

            };
            var strSetName = new string[]
            {
                "AsstDataSet"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Asset_report\\Asset_Repair_ReportDatails.rdlc";
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Asset Details Repair Report- Fectory: "+ComName+""),
            new ReportParameter("PrintUser",  "" + UserName + "")
            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;


        }
        public byte[] AssetDetailsMaster_Report(string reportType, int comID, string UserName, int? floor, int? Line, int? status, int? AssetCetagory, DateTime FromDate, DateTime ToDate)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            //int floorMan = floor == null ? null : floor;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DG_AssetDetailsMaster_Rpt ");
            stringBuilder.Append(comID);
            stringBuilder.Append(", " + (floor != null ? floor : "NULL"));
            stringBuilder.Append(", " + (Line !=  null  ? Line:"NULL"));
            stringBuilder.Append(", " + (status != null ? status: "NULL"));
            stringBuilder.Append(", " + (AssetCetagory!= null ? AssetCetagory : "NULL"));
            stringBuilder.Append(", '");
            stringBuilder.Append(FromDate.ToString("yyyy-MM-dd") + "', '");
            stringBuilder.Append(ToDate.ToString("yyyy-MM-dd"));
            stringBuilder.Append("' ");

            string stateQu = stringBuilder.ToString();
            var tbldata = new DataTable[]
            {
             //_SqlCommon.get_InformationDataTable("DG_AssetDetailsMaster_Rpt 40,NULL,98,1,5,'2015-08-15','2025-08-15'",_dg_Asst_Mgt)
                 _SqlCommon.get_InformationDataTable(stateQu,_dg_Asst_Mgt)
            //_SqlCommon.get_InformationDataTable("DG_AssetDetailsMaster_Rpt '"+ comID + "','"+floor+"','"+Line+"','"+status+"','"+AssetCetagory+"','"+ DateTime.ParseExact(FromDate.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture)+ DateTime.ParseExact(ToDate.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture)+ "'",_dg_Asst_Mgt)
            //_SqlCommon.get_InformationDataTable("DG_AssetDetailsMaster_Rpt '"+ comID + "','"+floor+"','"+Line+"','"+status+"','"+AssetCetagory+"','"+ DateTime.ParseExact(FromDate.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture)+ DateTime.ParseExact(ToDate.ToString("MM/dd/yyyy HH:mm:ss"), "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture)+ "'",_dg_Asst_Mgt)
            //string stateQu = "DG_AssetDetailsMaster_Rpt '"+ comID + "', '"+floor != null ? floor.ToString() : "NULL"+"' ,'" + Line + "','" + status + "','" + AssetCetagory + "','" + FromDate.ToString("yyyy-MM-dd") + "','" + ToDate.ToString("yyyy-MM-dd") + "'";


            };
            var strSetName = new string[]
            {
                "AsstDataSet"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Asset_report\\AssetDetailsMaster_Rpt.rdlc";
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Asset Details Report- Fectory: "+ComName+""),
            new ReportParameter("PrintUser",  "" + UserName + "")
            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;


        }

        //1 no report - Asset Management Report - M A Master List Rpt 
        public byte[] AssetManagementReport(string reportType, int? ComID, string UserName, int? floor, int? line, int? status, int? AssetCategory, DateTime FromDate, DateTime ToDate)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + ComID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Mr_Asset_Master_List_Rpt ");
            stringBuilder.Append(ComID);
            stringBuilder.Append(", " + (floor != null ? floor : "NULL"));
            stringBuilder.Append(", " + (line != null ? line : "NULL"));
            stringBuilder.Append(", " + (status != null ? status : "NULL"));
            stringBuilder.Append(", " + (AssetCategory != null ? AssetCategory : "NULL"));
            stringBuilder.Append(", '" + FromDate.ToString("yyyy-MM-dd") + "'");
            stringBuilder.Append(", '" + ToDate.ToString("yyyy-MM-dd") + "' ");


            string stateQu = stringBuilder.ToString();

            var tbldata = new DataTable[]
            {
                //_SqlCommon.get_InformationDataTable("Mr_Asset_Master_List_Rpt '" + ComID + "'", _dg_Asst_Mgt),
                 _SqlCommon.get_InformationDataTable(stateQu,_dg_Asst_Mgt)
                //_SqlCommon.get_InformationDataTable("Mr_Cutting_Closing_Style_Wise_Report '"+styleID+"'", _dg_pms_conn),
                //_SqlCommon.get_InformationDataTable("Mr_Cutting_Closing_Style_Line_Wise_Report '"+styleID+"'", _dg_pms_conn),
                //     _SqlCommon.get_InformationDataTable("Mr_Cut_Fabrics_Closing_Rpt '"+styleID+"'", _dg_pms_conn),
            }; 
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Asset_Report\\AssetManagementReport.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Asset Details Report- Factory: " + ComName + ""),
            new ReportParameter("PrintUser", "" + UserName + "")
            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }

        //4 no report - Asset Summary Report - M A Summary Rpt 
        public byte[] AssetSummaryReport(string reportType, int comID, string UserName)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            var tbldata = new DataTable[]
            {
                _SqlCommon.get_InformationDataTable("Mr_Asset_Summary_Rpt '" + comID + "'", _dg_Asst_Mgt),
                //_SqlCommon.get_InformationDataTable("Mr_Cutting_Closing_Style_Wise_Report '"+styleID+"'", _dg_pms_conn),
                //_SqlCommon.get_InformationDataTable("Mr_Cutting_Closing_Style_Line_Wise_Report '"+styleID+"'", _dg_pms_conn),
                //     _SqlCommon.get_InformationDataTable("Mr_Cut_Fabrics_Closing_Rpt '"+styleID+"'", _dg_pms_conn),
            };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Asset_Report\\AssetSummaryReport.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Asset Summary Report- Factory: " + ComName + ""),
            new ReportParameter("PrintUser", "" + UserName + "")
            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }
        //9 no report - Rented asset details Report - DG_Rented_Asset_Details_Rpt
        public byte[] RentedAssetDetailsReport(string reportType, int comID, string UserName)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            var tbldata = new DataTable[]
            {
                _SqlCommon.get_InformationDataTable("DG_Rented_Asset_Details_Rpt '" + comID + "'", _dg_Asst_Mgt),
                //_SqlCommon.get_InformationDataTable("Mr_Cutting_Closing_Style_Wise_Report '"+styleID+"'", _dg_pms_conn),
                //_SqlCommon.get_InformationDataTable("Mr_Cutting_Closing_Style_Line_Wise_Report '"+styleID+"'", _dg_pms_conn),
                //     _SqlCommon.get_InformationDataTable("Mr_Cut_Fabrics_Closing_Rpt '"+styleID+"'", _dg_pms_conn),
            };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Asset_Report\\RentedAssetDetailsReport.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Rented Asset Details Report- Factory: " + ComName + ""),
            new ReportParameter("PrintUser", "" + UserName + "")
            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }

        //6 no report - internal fixed asset transfer Report - DG_Internal_Fixed_Asset_Transfer_Rpt
        public byte[] InternalFixedAssetTransferReport(string reportType,  string UserName, int? comID, int? Floor, int? Line, int? AssetCetagory, DateTime FromDate, DateTime ToDate)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DG_Internal_Fixed_Asset_Transfer_Rpt ");
            stringBuilder.Append(comID);
            stringBuilder.Append(", " + (Floor != null ? Floor : "NULL"));
            stringBuilder.Append(", " + (Line != null ? Line : "NULL"));
            //stringBuilder.Append(", " + (status != null ? status : "NULL"));
            stringBuilder.Append(", " + (AssetCetagory != null ? AssetCetagory : "NULL"));
            stringBuilder.Append(", '" + FromDate.ToString("yyyy-MM-dd") + "'");
            stringBuilder.Append(", '" + ToDate.ToString("yyyy-MM-dd") + "' ");


            string stateQu = stringBuilder.ToString();

            var tbldata = new DataTable[]



            {
                _SqlCommon.get_InformationDataTable(stateQu, _dg_Asst_Mgt),
                //_SqlCommon.get_InformationDataTable("Mr_Cutting_Closing_Style_Wise_Report '"+styleID+"'", _dg_pms_conn),
                //_SqlCommon.get_InformationDataTable("Mr_Cutting_Closing_Style_Line_Wise_Report '"+styleID+"'", _dg_pms_conn),
                //     _SqlCommon.get_InformationDataTable("Mr_Cut_Fabrics_Closing_Rpt '"+styleID+"'", _dg_pms_conn),
            };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Asset_Report\\InternalFixedAssetTransferReport.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Internal Fixed Asset Transfer Report- Factory: " + ComName + ""),
            new ReportParameter("PrintUser", "" + UserName + "")
            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }
        //7 no report - external fixed asset transfer Report - DG_External_Fixed_Asset_Transfer_Rpt
        public byte[] ExternalFixedAssetTransferReport(string reportType, int fromComId, int toComId, string UserName)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + fromComId + "'", _specfo_conn);
            DataTable dt2 = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + toComId + "'", _specfo_conn);

            string FromComName = dt.Rows[0]["cCmpName"].ToString();
            string ToComName = dt2.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();
            var tbldata = new DataTable[]
            {
                _SqlCommon.get_InformationDataTable("DG_External_Fixed_Asset_Transfer_Rpt " + fromComId +  ","  + toComId  , _dg_Asst_Mgt),
                //_SqlCommon.get_InformationDataTable("Mr_Cutting_Closing_Style_Wise_Report '"+styleID+"'", _dg_pms_conn),
                //_SqlCommon.get_InformationDataTable("Mr_Cutting_Closing_Style_Line_Wise_Report '"+styleID+"'", _dg_pms_conn),
                //     _SqlCommon.get_InformationDataTable("Mr_Cut_Fabrics_Closing_Rpt '"+styleID+"'", _dg_pms_conn),
            };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Asset_Report\\ExternalFixedAssetTransferReport.rdlc";
            //string imgERP = new Uri($"http://192.168.1.42/ERP/imgsign/").AbsoluteUri;
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",FromComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "External Fixed Asset Transfer Report - From Factory: " + FromComName + "; To Factory: " + ToComName + ""),
            new ReportParameter("PrintUser", "" + UserName + "")
            };
            byte[] reportBytes = this.GenerateReport(tbldata, strSetName, path, reportType, reportParameters);
            return reportBytes;
        }

        public byte[] ScheduledMaintenanceReport(string reportType, int comID, string UserName, int? floor, int? Line,  DateTime FromDate, DateTime ToDate)
        {
            DataTable dt = _SqlCommon.get_InformationDataTable("select cCmpName,cAdd1,cAdd2 from Smt_Company where nCompanyID='" + comID + "'", _specfo_conn);
            string ComName = dt.Rows[0]["cCmpName"].ToString();
            string cAdd1 = dt.Rows[0]["cAdd1"].ToString();
            string cAdd2 = dt.Rows[0]["cAdd2"].ToString();


            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DG_Scheduled_Maintenance_Rpt ");
            stringBuilder.Append(comID);
            stringBuilder.Append(", " + (floor != null ? floor : "NULL"));
            stringBuilder.Append(", " + (Line != null ? Line : "NULL"));
            //stringBuilder.Append(", " + (status != null ? status : "NULL"));
            //stringBuilder.Append(", " + (AssetCategory != null ? AssetCategory : "NULL"));
            stringBuilder.Append(", '" + FromDate.ToString("yyyy-MM-dd") + "'");
            stringBuilder.Append(", '" + ToDate.ToString("yyyy-MM-dd") + "' ");


            string stateQu = stringBuilder.ToString();
            var tbldata = new DataTable[]
            {

                 _SqlCommon.get_InformationDataTable(stateQu,_dg_Asst_Mgt)

            };
            var strSetName = new string[]
            {
                "DataSet1"
            };
            string path = $"{_webHostEnvironment.WebRootPath}\\Report\\Asset_report\\ScheduledMaintenance Report.rdlc";
            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
            new ReportParameter("Company",ComName),
            new ReportParameter("Add1", cAdd1),
            new ReportParameter("Title", "Scheduled Maintenance Report- Fectory: "+ComName+""),
            new ReportParameter("PrintUser",  "" + UserName + "")
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


        // report parameter save 

        public async Task<string> ReportParameterSave(List<ReportParameterModel> app)
        {
            string message = string.Empty;
            await _dg_Asst_Mgt.OpenAsync();
            try
            {
                foreach (ReportParameterModel Apps in app)
                {
                    SqlCommand cmd = new SqlCommand("DG_ReportparameterSave", _dg_Asst_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ComFrom ", Apps.ComFrom);
                    cmd.Parameters.AddWithValue("@ComTo", Apps.ComTo);
                    cmd.Parameters.AddWithValue("@FromDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ToDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Floor", Apps.Floor);
                    cmd.Parameters.AddWithValue("@Line", Apps.Line);
                    cmd.Parameters.AddWithValue("@Status", Apps.Status);
                    cmd.Parameters.AddWithValue("@Supplier", Apps.Supplire);
                    cmd.Parameters.AddWithValue("@AssetCategory", Apps.AssetCategory);

                    //cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                    //cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                    await cmd.ExecuteNonQueryAsync();
                    //message = (string)cmd.Parameters["@ERROR"].Value;
                }



            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                _dg_Asst_Mgt.Close();
            }
            return message;
        }

    }



}

