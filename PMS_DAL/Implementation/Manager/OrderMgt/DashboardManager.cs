using PMS_BLL.Interfaces.Manager.OrderMgt;
using PMS_BLL.Utility;
using PMS_BOL.Models.Order_Mgt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_DAL.Implementation.Manager.OrderMgt
{
    public class DashboardManager : IDashboardManager
    {
        private readonly Dg_SqlCommon _SqlCommon;
        private readonly SqlConnection _specfo_conn;
        private readonly SqlConnection _SpecFoInventory;
        private readonly SqlConnection _dg_Oder_Mgt;

        public DashboardManager(Dg_SqlCommon sqlCommon)
        {
            _SqlCommon = sqlCommon;
            _specfo_conn = new SqlConnection(Dg_Getway.SpecFoCon);
            _SpecFoInventory = new SqlConnection(Dg_Getway.SpecFoInventory);
            _dg_Oder_Mgt = new SqlConnection(Dg_Getway.dg_Oder_Mgt);

        }

        //view
        public async Task<DataTable> GetDashboard_Daily_View(string sessionUser, int sessionUser_compId)
        {

            var query = $"dg_dashboard_daily_view '{sessionUser}',{sessionUser_compId}";
            var data = await _SqlCommon.get_InformationDataTableAsync(query, _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetDashboard_All_summary_View(string sessionUser, int sessionUser_compId)
        {

            var query = $"dg_dashboard_all_summary '{sessionUser}',{sessionUser_compId}";
            var data = await _SqlCommon.get_InformationDataTableAsync(query, _dg_Oder_Mgt);
            return data;
        }




        public async Task<object> GetDashboard_Daily_View_Grapdata(string sessionUser, int sessionUser_compId)
        {
            // Query to get the data
            var query = $"dg_dashboard_daily_view '{sessionUser}',{sessionUser_compId}";
            var dataTable = await _SqlCommon.get_InformationDataTableAsync(query, _dg_Oder_Mgt);

            // Initialize dictionaries to hold the data
            List<int> padding_day = new List<int>();
            List<int> quilting_day = new List<int>();
            List<int> p_and_q_day = new List<int>();
            List<int> padding_monthly = new List<int>();
            List<int> quilting_monthly = new List<int>();
            List<int> p_and_q_monthly = new List<int>();

            // Process each row in the dataTable
            foreach (DataRow row in dataTable.Rows)
            {
                string processName = row["pt_process_name"].ToString();

                // Get day values
                int dayTotOrderProcwise = Convert.ToInt32(row["dayTotOrderProcwise"]);
                int dayTotPlanProcwise = Convert.ToInt32(row["dayTotPlanProcwise"]);
                int dayTotProdProcwise = Convert.ToInt32(row["dayTotProdProcwise"]);
                int dayTotChallanProcwise = Convert.ToInt32(row["dayTotChallanProcwise"]);

                // Get month values
                int monTotOrderProcwise = Convert.ToInt32(row["monTotOrderProcwise"]);
                int monTotPlanProcwise = Convert.ToInt32(row["monTotPlanProcwise"]);
                int monTotProdProcwise = Convert.ToInt32(row["monTotProdProcwise"]);
                int monTotChallanProcwise = Convert.ToInt32(row["monTotChallanProcwise"]);

                // Add the day and monthly values based on the process name
                if (processName == "Padding")
                {
                    padding_day.AddRange(new List<int> { dayTotOrderProcwise, dayTotPlanProcwise, dayTotProdProcwise, dayTotChallanProcwise });
                    padding_monthly.AddRange(new List<int> { monTotOrderProcwise, monTotPlanProcwise, monTotProdProcwise, monTotChallanProcwise });
                }
                else if (processName == "Quilting")
                {
                    quilting_day.AddRange(new List<int> { dayTotOrderProcwise, dayTotPlanProcwise, dayTotProdProcwise, dayTotChallanProcwise });
                    quilting_monthly.AddRange(new List<int> { monTotOrderProcwise, monTotPlanProcwise, monTotProdProcwise, monTotChallanProcwise });
                }
                else if (processName == "Padding and Quilting")
                {
                    p_and_q_day.AddRange(new List<int> { dayTotOrderProcwise, dayTotPlanProcwise, dayTotProdProcwise, dayTotChallanProcwise });
                    p_and_q_monthly.AddRange(new List<int> { monTotOrderProcwise, monTotPlanProcwise, monTotProdProcwise, monTotChallanProcwise });
                }
            }

            // Prepare the result object in the required format
            var result = new
            {
                padding_day = padding_day,
                quilting_day = quilting_day,
                p_and_q_day = p_and_q_day,
                padding_monthly = padding_monthly,
                quilting_monthly = quilting_monthly,
                p_and_q_monthly = p_and_q_monthly
            };

            return result;
        }





        public async Task<DataTable> GetDashboard_HrwiseProd_View(int prodProc, string sessionUser, int sessionUser_compId)
        {

            var query = $"dg_dashboard_hrwiseProd_view {prodProc}, '{sessionUser}',{sessionUser_compId}";
            var data = await _SqlCommon.get_InformationDataTableAsync(query, _dg_Oder_Mgt);
            return data;
        }

    }
}
