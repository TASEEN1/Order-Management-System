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
    public class DeliveryChallanManager:IDeliveryChallanManager
    {
        private readonly Dg_SqlCommon _SqlCommon;
        private readonly SqlConnection _specfo_conn;
        private readonly SqlConnection _dg_Asst_Mgt;
        private readonly SqlConnection _SpecFoInventory;
        private readonly SqlConnection _dg_Oder_Mgt;

        public DeliveryChallanManager(Dg_SqlCommon sqlCommon)
        {
            _SqlCommon = sqlCommon;
            _specfo_conn = new SqlConnection(Dg_Getway.SpecFoCon);
            _dg_Asst_Mgt = new SqlConnection(Dg_Getway.dg_Asst_Mgt);
            _SpecFoInventory = new SqlConnection(Dg_Getway.SpecFoInventory);
            _dg_Oder_Mgt = new SqlConnection(Dg_Getway.dg_Oder_Mgt);

        }
      
  
        public async Task<DataTable> GetDelivery_Challan_PINumber(string? PI_Number, int custParamForPI, int pageProcId, int itemProcId)
        {
            var piNumberValue = PI_Number == null ? $"'{PI_Number}'" : "NULL";
            var query = $"dg_delivery_challan_GetPICustwise {piNumberValue},{custParamForPI},{pageProcId},{itemProcId}";
            var data = await _SqlCommon.get_InformationDataTableAsync(query, _dg_Oder_Mgt);
            return data;
        }

       

        //Drop Down
        public async Task<DataTable> GetPadding_Challan_ProcessType()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select pt_id, pt_process_name from dg_ms_process_type where pt_id not in (2) ", _dg_Oder_Mgt);
            return data;
        }
        //view 
        public async Task<DataTable> GetDelivery_Challan_Before_View(string PI_Number, int custParamForPI, int pageProcId, int itemProcId)
        {
      
            var query = $"dg_delivery_challan_BeforeAdd_view '{PI_Number}',{custParamForPI},{pageProcId},{itemProcId}";
            var data = await _SqlCommon.get_InformationDataTableAsync(query, _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetDelivery_Challan_After_View(int challanProcId, string sessionUser)
        {
        
            var query = $"dg_delivery_challan_AfterAdd_view {challanProcId},'{sessionUser}'";
            var data = await _SqlCommon.get_InformationDataTableAsync(query, _dg_Oder_Mgt);
            return data;
        }
      


        //save
        public async Task<Response> PaddingAndQuilting_Delivery_Challan_Save(List<DeliveryChallanModel> DV)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();

            var res = new Response();
            int message1= 0;

            if (DV == null || !DV.Any())
            {
                res.Status_code = 400; // Bad request
                res.Message = "No data provided.";
                return res;
            }

            try
            {
                foreach (DeliveryChallanModel ord in DV)
                {

                    SqlCommand cmd = new SqlCommand("dg_delivery_challan_add", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@dc_createdBy_compId", ord.Com_ID);
                    cmd.Parameters.AddWithValue("@dc_or_id", ord.DC_or_ID);
                    cmd.Parameters.AddWithValue("@dc_or_ref_no", ord.DC_or_ref_NO);
                    cmd.Parameters.AddWithValue("@dc_challan_proc", ord.DC_Proc);
                    cmd.Parameters.AddWithValue("@dc_pi_num", ord.DC_Pi_Number);
                    cmd.Parameters.AddWithValue("@dc_item_qty", ord.DC_item_Qty);
                    cmd.Parameters.AddWithValue("@dc_item_roll", ord.DC_item_roll);
                    cmd.Parameters.AddWithValue("@dc_deli_cust", ord.DC_delivery_customer);
                    cmd.Parameters.AddWithValue("@dc_deli_date ", ord.DC_dalivery_Date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@dc_att_person", ord.DC_Attention_Person);
                    cmd.Parameters.AddWithValue("@dc_att_mobNo", ord.DC_Attention_Person_MobNO);
                    cmd.Parameters.AddWithValue("@dc_deli_adrs", ord.DC_delivery_address);
                    cmd.Parameters.AddWithValue("@dc_carrier_nm", ord.DC_carrier_name);
                    cmd.Parameters.AddWithValue("@dc_carrier_mobNo", ord.DC_carrier_MobNO);
                    cmd.Parameters.AddWithValue("@dc_vehiNo", ord.DC_vehiNO);
                    cmd.Parameters.AddWithValue("@dc_driver_nm ", ord.DC_driver_name);
                    cmd.Parameters.AddWithValue("@dc_driver_mobNo", ord.DC_driver_MobNo);
                    cmd.Parameters.AddWithValue("@dc_driver_lisc", ord.DC_driver_lisc);
                    cmd.Parameters.AddWithValue("@dc_created_by", ord.DC_created_by);
                    cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                    cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 500);
                    cmd.Parameters["@status"].Direction = ParameterDirection.Output;
                    await cmd.ExecuteNonQueryAsync();
                    message = (string)cmd.Parameters["@ERROR"].Value;
                    message1 = Convert.ToInt32(cmd.Parameters["@status"].Value);
                    res.Status_code = 200;

                }
               


            }
            catch (Exception ex)
            {
                ex.ToString();
                res.Status_code = 500;
            }
            finally
            {
                _dg_Oder_Mgt.Close();
            }
            if (message1 == 1)
            {
                res.Status_code = 200;
                
            
            }
            else if (message1 == 0)
            {
                res.Status_code=409;
            }
            else
            {
                res.Status_code = 500;
            }
            res.Message = message;
            return res;
        }
        public async Task<string> PaddingAndQuilting_Delivery_Challan_Complete(List<DeliveryChallanModel> DV)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();


            try
            {
                foreach (DeliveryChallanModel ord in DV)
                {

                    SqlCommand cmd = new SqlCommand("dg_delivery_challan_complete", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@challanProcId", ord.Challan_ID);
                    cmd.Parameters.AddWithValue("@sessionUser", ord.sessionUser);
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
        public async Task<string> PaddingQuilting_Delivery_Challan_Delete(List<DeliveryChallanModel> DV)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();


            try
            {
                foreach (DeliveryChallanModel ord in DV)
                {

                    SqlCommand cmd = new SqlCommand("dg_delivery_challan_delete_single", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@dc_id", ord.DC_ID);
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


        //Report
        public async Task<DataTable> Get_Challan()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select distinct dc_challan_refNo from dg_delivery_challan where dc_challan_refNo <> 0 order by dc_challan_refNo desc", _dg_Oder_Mgt);
            return data;
        }

        //Challan Approval
        public async Task<string> PaddingQuilting_Delivery_challan_Approved_By_Approved(List<Challan_Approval>AP)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();


            try
            {
                foreach (Challan_Approval ord in AP)
                {

                    SqlCommand cmd = new SqlCommand("dg_delivery_challan_approval_approvedBy_approve", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@dc_approvedByUser_compId", ord.DC_Approvedby_com_ID);
                    cmd.Parameters.AddWithValue("@dc_challan_refNo", ord.DC_challan_ref_NO);
                    cmd.Parameters.AddWithValue("@dc_approvedBy_user", ord.DC_Approved_user);
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

        public async Task<string> PaddingQuilting_Delivery_challan_Checked_By_Approved(List<Challan_Approval> AP)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();


            try
            {
                foreach (Challan_Approval ord in AP)
                {

                    SqlCommand cmd = new SqlCommand("dg_delivery_challan_approval_checkedBy_approve", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@dc_checkedByUser_compId", ord.DC_checkedby_com_ID);
                    cmd.Parameters.AddWithValue("@dc_challan_refNo", ord.DC_challan_ref_NO);
                    cmd.Parameters.AddWithValue("@dc_checkedBy_user", ord.DC_checkdby_user);
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
        public async Task<string> PaddingQuilting_Delivery_challan_Cancel(List<Challan_cancel> AP)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();


            try
            {
                foreach (Challan_cancel ord in AP)
                {

                    SqlCommand cmd = new SqlCommand("dg_delivery_challan_approval_cancel", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@dc_cancelledByUser_compId ", ord.DC_cancelby_com_ID);
                    cmd.Parameters.AddWithValue("@dc_challan_refNo", ord.DC_challan_ref_NO);
                    cmd.Parameters.AddWithValue("@dc_cancelldBy_user", ord.DC_Cancelby_user);
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

        public async Task<DataTable> GetPaddingQuilting_Delivery_challan_Approval_By_Approved_View( string sessionUser)
        {

            var query = $"dg_delivery_challan_approval_approvedBy_view '{sessionUser}'";
            var data = await _SqlCommon.get_InformationDataTableAsync(query, _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetPaddingQuilting_Delivery_challan_for_Approval_By_Approved_View(string sessionUser)
        {

            var query = $"dg_delivery_challan_approval_forApproval_view '{sessionUser}'";
            var data = await _SqlCommon.get_InformationDataTableAsync(query, _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetPaddingQuilting_Delivery_challan_Checked_By_Approved_View(string sessionUser)
        {

            var query = $"dg_delivery_challan_approval_checkedBy_view '{sessionUser}'";
            var data = await _SqlCommon.get_InformationDataTableAsync(query, _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetPaddingQuilting_Delivery_challan_cancel_View(string sessionUser)
        {

            var query = $"dg_delivery_challan_approval_cancel_view '{sessionUser}'";
            var data = await _SqlCommon.get_InformationDataTableAsync(query, _dg_Oder_Mgt);
            return data;
        }



    }
}
