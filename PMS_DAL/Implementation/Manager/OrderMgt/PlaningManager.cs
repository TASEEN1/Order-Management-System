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
    public class PlaningManager:IPlaningManager
    {

        private readonly Dg_SqlCommon _SqlCommon;
        private readonly SqlConnection _specfo_conn;
        private readonly SqlConnection _dg_Asst_Mgt;
        private readonly SqlConnection _SpecFoInventory;
        private readonly SqlConnection _dg_Oder_Mgt;

        public PlaningManager(Dg_SqlCommon sqlCommon)
        {
            _SqlCommon = sqlCommon;
            _specfo_conn = new SqlConnection(Dg_Getway.SpecFoCon);
            _dg_Asst_Mgt = new SqlConnection(Dg_Getway.dg_Asst_Mgt);
            _SpecFoInventory = new SqlConnection(Dg_Getway.SpecFoInventory);
            _dg_Oder_Mgt = new SqlConnection(Dg_Getway.dg_Oder_Mgt);

        }
        //DROP DOWN
        public async Task<DataTable> GetPlanning_Padding_PI_Number()
        {
        var data = await _SqlCommon.get_InformationDataTableAsync("select distinct pi_issued_ref_no, pi_number from dg_pi_issued inner join dg_order_receiving on pi_or_ref_no = or_ref_no where pi_approvedBy_bit = 1 and or_proc_type_forItem in (1,3) order by pi_issued_ref_no desc", _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetPlanning_Quilting_PI_Number()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select distinct pi_issued_ref_no, pi_number from dg_pi_issued inner join dg_order_receiving on pi_or_ref_no = or_ref_no where pi_approvedBy_bit = 1 and or_proc_type_forItem in (2,3) order by pi_issued_ref_no desc", _dg_Oder_Mgt);
            return data;
        }
      
        //VIEW
        public async Task<DataTable> GetPlaning_Details_BeforeAdd(string Pi_Number, int Proc_ID, int ItemProc_ID)
        {
            var query = $"dg_planning_getDetails_FromPINumNProc  '{Pi_Number}', {Proc_ID},{ItemProc_ID}";
            var data = await _SqlCommon.get_InformationDataTableAsync(query, _dg_Oder_Mgt);
            return data;

        }

        public async Task<DataTable> GetPlaning_Details_AfterAdd( int Proc_ID, string sessionUser)
        {
            var query = $"dg_planning_afterAdd  {Proc_ID}, '{sessionUser}'";
            var data = await _SqlCommon.get_InformationDataTableAsync(query, _dg_Oder_Mgt);
            return data;

        }


        // DashBorad Get
        public async Task<DataTable> GetPlanning_DashBorad()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("dg_planning_dashboard_get", _dg_Oder_Mgt);
            return data;
        }


        //ADD/SAVE


        public async Task<string> PlaningSave(List<PlaningModel> PL)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();
           


            try
            {
                foreach (PlaningModel ord in PL)
                {

                    SqlCommand cmd = new SqlCommand("dg_planning_add", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pln_createdBy_compId", ord.Com_ID);
                    cmd.Parameters.AddWithValue("@pln_or_id", ord.or_ID);
                    cmd.Parameters.AddWithValue("@pln_or_ref_no", ord.or_ref_no);
                    cmd.Parameters.AddWithValue("@pln_pi_number", ord.Pi_Number);
                    cmd.Parameters.AddWithValue("@pln_proc_id", ord.Proc_ID);
                    cmd.Parameters.AddWithValue("@pln_plan_date", ord.PlanDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@pln_deli_date ",ord.proc_Delivery_date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@pln_mc_id ", ord.MC_ID);
                    cmd.Parameters.AddWithValue("@pln_tday_pln", ord.Today_Plan);
                    cmd.Parameters.AddWithValue("@pln_created_by", ord.Created_By);
                    cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                    cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                    await cmd.ExecuteNonQueryAsync();
                    message = (string)cmd.Parameters["@ERROR"].Value;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                _dg_Oder_Mgt.Close();
            }
           return message;
        }

        public async Task<string> PlaningComplete(List<PlaningModel> PL)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();


            try
            {
                foreach (PlaningModel ord in PL)
                {

                    SqlCommand cmd = new SqlCommand("dg_planning_complete", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@piNumber", ord.Pi_Number);
                    cmd.Parameters.AddWithValue("@pln_process_id", ord.Process_ID);
                    cmd.Parameters.AddWithValue("@sessionUser", ord.SessionUser);
                    cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                    cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                    await cmd.ExecuteNonQueryAsync();
                    message = (string)cmd.Parameters["@ERROR"].Value;

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                _dg_Oder_Mgt.Close();
            }
            return message;
        }
        public async Task<string> PL_Delete(List<PlaningModel> PL)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();


            try
            {
                foreach (PlaningModel ord in PL)
                {

                    SqlCommand cmd = new SqlCommand("dg_planning_delete_single", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pln_id", ord.PL_ID);
                    cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                    cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                    await cmd.ExecuteNonQueryAsync();
                    message = (string)cmd.Parameters["@ERROR"].Value;

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                _dg_Oder_Mgt.Close();
            }
            return message;
        }
    }
}
