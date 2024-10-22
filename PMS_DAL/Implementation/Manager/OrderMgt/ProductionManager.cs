using Microsoft.AspNetCore.Http;
using PMS_BLL.Interfaces.Manager.OrderMgt;
using PMS_BLL.Utility;
using PMS_BOL.Models.Order_Mgt;
using PMS_BOL.Models.OrderMgt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_DAL.Implementation.Manager.OrderMgt
{
    public class ProductionManager : IProductionManager
    {
        private readonly Dg_SqlCommon _SqlCommon;
        private readonly SqlConnection _specfo_conn;
        private readonly SqlConnection _dg_Asst_Mgt;
        private readonly SqlConnection _SpecFoInventory;
        private readonly SqlConnection _dg_Oder_Mgt;

        public ProductionManager(Dg_SqlCommon sqlCommon)
        {
            _SqlCommon = sqlCommon;
            _specfo_conn = new SqlConnection(Dg_Getway.SpecFoCon);
            _dg_Asst_Mgt = new SqlConnection(Dg_Getway.dg_Asst_Mgt);
            _SpecFoInventory = new SqlConnection(Dg_Getway.SpecFoInventory);
            _dg_Oder_Mgt = new SqlConnection(Dg_Getway.dg_Oder_Mgt);

        }

        //DropDown
        public async Task<DataTable> GetmachineNo(int Production_ProcID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select md_id,md_machine_no from dg_ms_machine_details where md_machine_type =  "+ Production_ProcID + "order by md_machine_no", _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetShift()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select ps_id, ps_shift_name from dg_ms_production_shift order by ps_shift_name", _dg_Oder_Mgt);
            return data;
        }
        

        public async Task<DataTable> GetProductionQuilting_ProcessType(int Ordr_refNO, int Process_ID)
        {
            var query = $"dg_quilting_production_save {Ordr_refNO}, {Process_ID}";
            var data = await _SqlCommon.get_InformationDataTableAsync(query, _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetProduction_ProcessType()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select pt_id, pt_process_name from dg_ms_process_type where pt_id not in (1)", _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetProduction_Padding_PI_Number()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select distinct pi_issued_ref_no, pln_pi_number, or_cust, c_customer_name  from dg_order_receiving inner join dg_ms_customer on or_cust = c_id inner join dg_planning on pln_or_id = or_id inner join dg_pi_issued on pln_or_ref_no = pi_or_ref_no  where or_production_status in ('approved', 'revised') and or_proc_type_forItem in (1,3)  order by pi_issued_ref_no desc ", _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetProduction_Quilting_PI_Number()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select distinct pi_issued_ref_no, pln_pi_number, or_cust, c_customer_name from dg_order_receiving inner join dg_ms_customer on or_cust = c_id inner join dg_planning on pln_or_id = or_id  inner join dg_pi_issued on pln_or_ref_no = pi_or_ref_no where or_production_status in ('approved', 'revised') and or_proc_type_forItem in (2,3) order by pi_issued_ref_no desc", _dg_Oder_Mgt);
            return data;
        }

        public async Task<DataTable> GetProduction_Hour()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select ph_id, ph_name from dg_ms_production_hour", _dg_Oder_Mgt);
            return data;
        }
        //GET Report DROP DOWN
        public async Task<DataTable> Get_ReportProduction_ProcessType()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select pt_id, pt_process_name from dg_ms_process_type where pt_id not in (3)", _dg_Oder_Mgt);
            return data;
        }





        //GET view
        public async Task<DataTable> GetPadding_ProductionItemBeforeAdd(string Pi_Number)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("dg_production_padding_GetItems_BeforeAdd "+ Pi_Number, _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetProductionAfterAdd(int ProcessID ,string SessionUser)
        {
            var query = $"dg_production_afterAdd {ProcessID},'{SessionUser}'";
            var data = await _SqlCommon.get_InformationDataTableAsync(query, _dg_Oder_Mgt);
            return data;
        }
        
        public async Task<DataTable> GetQuilting_ProductionItemBeforeAdd(string PINumber, int ProType)
        {
            var query = $"dg_production_quilting_BeforeAdd_sir  {PINumber}, '{ProType}'";
            var data = await _SqlCommon.get_InformationDataTableAsync(query, _dg_Oder_Mgt);
            return data;
        }




        //Modal
        public async Task<DataTable> GetmachineView()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select pt_process_name as machine_type, md_machine_no, md_machine_desc, md_machine_capacity, md_created_by, md_created_date from dg_ms_machine_details inner join dg_ms_process_type on md_machine_type = pt_id order by md_machine_no", _dg_Oder_Mgt);
            return data;
        }

        public async Task<DataTable> GetShiftview()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select * from dg_ms_production_shift", _dg_Oder_Mgt);
            return data;
        }

        public async Task<string> MachineDetailsSave(List<MachineDetails> MC)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();

            try
            {
                foreach (MachineDetails ord in MC)
                {
                    SqlCommand cmd = new SqlCommand("dg_ms_machine_details_save", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@md_createdBy_compId", ord.ComID);
                    cmd.Parameters.AddWithValue("@md_machine_type", ord.machine_Type);
                    cmd.Parameters.AddWithValue("@md_machine_desc", ord.machine_decs);
                    cmd.Parameters.AddWithValue("@md_machine_no", ord.machine_No);
                    cmd.Parameters.AddWithValue("@md_machine_capacity", ord.machine_capacity);
                    cmd.Parameters.AddWithValue("@md_created_by", ord.Created_by);
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
        public async Task<DataTable> GetMechinType()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select pt_id as mcTypeId , pt_process_name as mcType from dg_ms_process_type where pt_id in (1,2)", _dg_Oder_Mgt);
            return data;
        }







        public async Task<string> shiftSave(List<ShiftDetails> SF)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();

            try
            {
                foreach (ShiftDetails ord in SF)
                {
                    SqlCommand cmd = new SqlCommand("dg_ms_production_shift_save", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ps_createdBy_compId", ord.ComID);
                    cmd.Parameters.AddWithValue("@ps_shift_name", ord.shiftName);
                    TimeSpan shiftstartTime = new TimeSpan(ord.shiftstartTime.Hour, ord.shiftstartTime.Minute, 0);
                    TimeSpan shiftendTime = new TimeSpan(ord.shiftendTime.Hour, ord.shiftendTime.Minute, 0);
                    cmd.Parameters.AddWithValue("@ps_shift_startTime",ord.shiftstartTime.ToString("HH:mm"));
                    cmd.Parameters.AddWithValue("@ps_shift_endTime", ord.shiftendTime.ToString("HH:mm"));
                    cmd.Parameters.AddWithValue("@ps_created_by", ord.Created_by);
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
        //Main
        public async Task<string> ProductionSave(List<ProductionModel> PD)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();
           

            try
            {
                foreach (ProductionModel ord in PD)
                {
                  
                    SqlCommand cmd = new SqlCommand("dg_production_add_forBothProc", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@createdBy_compId", ord.ComID);
                    cmd.Parameters.AddWithValue("@prod_or_ref_no", ord.prod_or_ref_no);
                    cmd.Parameters.AddWithValue("@prod_or_id", ord.prod_or_ID);
                    cmd.Parameters.AddWithValue("@prod_hour_id", ord.prod_Hour);
                    cmd.Parameters.AddWithValue("@piNumber", ord.PI_Number);
                    cmd.Parameters.AddWithValue("@prod_process_id", ord.prod_process_id);
                    cmd.Parameters.AddWithValue("@prod_shift_id", ord.prod_shift_id);
                    cmd.Parameters.AddWithValue("@prod_production_date", ord.ProductionDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@prod_machine_id", ord.MachineID);
                    cmd.Parameters.AddWithValue("@prod_spvNm ", ord.Superviser_Name);
                    cmd.Parameters.AddWithValue("@prod_spvId", ord.Superviser_ID);
                    cmd.Parameters.AddWithValue("@prod_today_production", ord.prod_today_production);
                    cmd.Parameters.AddWithValue("@createdby", ord.createdby);
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





        public async Task<string> ProductionDelete(List<ProductionModel> PD)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();

            try
            {
                foreach (ProductionModel ord in PD)
                {
                    SqlCommand cmd = new SqlCommand("dg_production_delete_single", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prod_id", ord.prod_ID);
                    cmd.Parameters.AddWithValue("@prod_or_ref_no", ord.prod_or_ref_no);
                    cmd.Parameters.AddWithValue("@prod_or_id", ord.prod_or_ID);
                    cmd.Parameters.AddWithValue("@prod_hour_id", ord.prod_Hour);
                    cmd.Parameters.AddWithValue("@prod_pi_number", ord.PI_Number);
                    cmd.Parameters.AddWithValue("@prod_process_id", ord.prod_process_id);
                    cmd.Parameters.AddWithValue("@prod_shift_id", ord.prod_shift_id);
                    cmd.Parameters.AddWithValue("@prod_production_date", ord.ProductionDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@prod_machine_id", ord.MachineID);
                    cmd.Parameters.AddWithValue("@prod_today_production", ord.prod_today_production);
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

        public async Task<string> productionComplete(List<ProductionModel> PD)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();

            try
            {
                foreach (ProductionModel ord in PD)
                {
                    SqlCommand cmd = new SqlCommand("dg_production_complete", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prod_process_id", ord.prod_process_id);
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


    }
}
