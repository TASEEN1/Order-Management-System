using PMS_BLL.Interfaces.Manager.OrderMgt;
using PMS_BLL.Utility;
using PMS_BOL.Models.OrderMgt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PMS_BOL.Models.OrderMgt.PI_Model;

namespace PMS_DAL.Implementation.Manager.OrderMgt
{
    public class PIManager: IPIManager
    {


            private readonly Dg_SqlCommon _SqlCommon;
            private readonly SqlConnection _specfo_conn;
            private readonly SqlConnection _dg_Asst_Mgt;
            private readonly SqlConnection _SpecFoInventory;
            private readonly SqlConnection _dg_Oder_Mgt;

        public PIManager(Dg_SqlCommon sqlCommon)
        {
            _SqlCommon = sqlCommon;
            _specfo_conn = new SqlConnection(Dg_Getway.SpecFoCon);
            _dg_Asst_Mgt = new SqlConnection(Dg_Getway.dg_Asst_Mgt);
            _SpecFoInventory = new SqlConnection(Dg_Getway.SpecFoInventory);
            _dg_Oder_Mgt = new SqlConnection(Dg_Getway.dg_Oder_Mgt);

        }

        //pi add er poree
        public async Task<DataTable> GetGeneratePIAddView( string created_By)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("dg_generate_pi_add_view '" + created_By + "'", _dg_Oder_Mgt);
            return data;
        }
        //pi add er agee
        public async Task<DataTable> GetPIAddView( int Ref_no)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("dg_generate_pi_before_add_view  " + Ref_no, _dg_Oder_Mgt);
            return data;
        }

        public async Task<DataTable> GetPiApproval_checkedBy_View(string Created_by)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("dg_generate_pi_approval_checkedBy_view '" + Created_by + "'", _dg_Oder_Mgt);
            return data;
        }

        public async Task<DataTable> GetPiApproval_approvedBy_view(string Created_by)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("dg_generate_pi_approval_approvedBy_view '" + Created_by + "'", _dg_Oder_Mgt);
            return data;
        }

        public async Task<DataTable> GetPiApproval_ForApprovalView(string Created_by)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("dg_generate_pi_approval_forApproval_view '" + Created_by + "'", _dg_Oder_Mgt);
            return data;
        }

        public async Task<DataTable> GetPiApproval_revise_view(string Created_by)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("dg_generate_pi_approval_revise_view '" + Created_by + "'", _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetPI_ProcessType()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select pt_id, pt_process_name from dg_ms_process_type", _dg_Oder_Mgt);
            return data;
        }



        // report//
        public async Task<DataTable> GetPI_Number()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select distinct pi_number, pi_issued_ref_no from dg_pi_issued where pi_isRevised = 0 order by pi_issued_ref_no desc", _dg_Oder_Mgt);
            return data;
        }
       

        // report//

        public async Task<string> GeneratePIAdd(List<PI_Model> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();

            try
            {
                foreach (PI_Model ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_generate_pi_add", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pi_createdBy_compId", ord.ComID);
                    cmd.Parameters.AddWithValue("@or_ref_no", ord.pi_or_ref_no);
                    cmd.Parameters.AddWithValue("@pi_created_by", ord.Created_by);
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

        public async Task<string> GeneratePI(List<PI_Model> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();

            try
            {
                foreach (PI_Model ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_generate_pi_generate", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pi_payment_type", ord.pi_payment_type);
                    cmd.Parameters.AddWithValue("@pi_cust_terms_cond", ord.or_cust_terms_cond);
                    cmd.Parameters.AddWithValue("@pi_proc_type", ord.pi_proc_type);
                    cmd.Parameters.AddWithValue("@pi_created_by", ord.Created_by);
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

       

        public async Task<string> PIDelete(List<PI_Model> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();

            try
            {
                foreach (PI_Model ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_generate_pi_add_delete_single", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pi_or_ref_no", ord.pi_or_ref_no);
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

        public async Task<string> PIRevise(List<PI_Model> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();

            try
            {
                foreach (PI_Model ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_generate_pi_approval_revise", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pi_updatedBy_compId",ord.ComID);
                    cmd.Parameters.AddWithValue("@pi_ref_no", ord.Ref_no);
                    cmd.Parameters.AddWithValue("@pi_updated_by", ord.pi_Updated_by);
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

        public async Task<string> ApprovedByApprove(List<PI_Model> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();

            try
            {
                foreach (PI_Model ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_generate_pi_approval_approvedBy_approve", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pi_approvedByUser_compId",ord.ComID);
                    cmd.Parameters.AddWithValue("@pi_issued_ref_no", ord.Ref_no);
                    cmd.Parameters.AddWithValue("@pi_approvedBy_user", ord.pi_approvedBy_user);
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

        public async Task<string> CheckedByApprove(List<PI_Model> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();

            try
            {
                foreach (PI_Model ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_generate_pi_approval_checkedBy_approve", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pi_checkedByUser_compId", ord.ComID);
                    cmd.Parameters.AddWithValue("@pi_issued_ref_no", ord.Ref_no);
                    cmd.Parameters.AddWithValue("@pi_checkedBy_user", ord.pi_checkedBy_user);
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

        public async Task<DataTable> GetBookingRefForPiGenerate(int CustomerID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("dg_generate_pi_GetForPiBookingRef " + CustomerID, _dg_Oder_Mgt);
            return data;
        }
       


        public async Task<DataTable> GetPI_CustomerTermsAndCondition(int Ref_No)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select distinct c_id as customer_id, c_customer_name,c_tnc_concatedFromFE,c_att_person,c_att_mobile,c_att_email from dg_order_receiving inner join dg_ms_customer on or_cust = c_id where or_ref_no = " + Ref_No, _dg_Oder_Mgt);
            return data;
        }



        // REVISED PI

        public async Task<DataTable> GetRevised_PI_Number()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select distinct pi_number, pi_issued_ref_no from dg_pi_issued where pi_issued_ref_no not in ( select pi_issued_ref_no from dg_pi_issued where pi_isRevised =0) and pi_isRevised = 1 order by pi_issued_ref_no desc", _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetRevised_Version(string PINumber)
        {
            var query = $"select max(pi_revise_version)+1 as versionNo from dg_pi_issued where pi_number= '{PINumber}'";
            var data = await _SqlCommon.get_InformationDataTableAsync(query, _dg_Oder_Mgt);
            return data;
            
        }
        public async Task<DataTable> GetRevised_Before_View(string PINumber)
        {
            var query = $"dg_generate_revisedPi_before_view '{PINumber}'";
            var data = await _SqlCommon.get_InformationDataTableAsync(query, _dg_Oder_Mgt);
            return data;

        }
        public async Task<DataTable> GetRevised_CustomerPaymentAndProcessData(string PINumber)
        {
            var query = $"select * from (select distinct or_cust, c_customer_name, pi_proc_type, pt_process_name, pi_payment_type, Payment_Mode ,pi_cust_terms_cond,ROW_NUMBER() over(partition by pi_revise_version order by pi_revise_version desc) as rowNum from dg_pi_issued inner join dg_ms_process_type on pt_id = pi_proc_type inner join SpecFo.dbo.Smt_PaymentMode on pi_payment_type = pm_id inner join dg_order_receiving on or_ref_no = pi_or_ref_no inner join dg_ms_customer on or_cust = c_id where pi_number = '{PINumber}' and pi_isRevised = 1 )as alpha where alpha.rowNum = 1";
            var data = await _SqlCommon.get_InformationDataTableAsync(query, _dg_Oder_Mgt);
            return data;

        }

        public async Task<string> Generate_RevisedPI(List<PIRevisedModel> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();

            try
            {
                foreach (PIRevisedModel ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_generate_revisedPi_regenerate", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pi_createdBy_compId", ord.comID);
                    cmd.Parameters.AddWithValue("@piNumber", ord.PI_Number);
                    cmd.Parameters.AddWithValue("@pi_cust_terms_cond ", ord.Terms_cond);
                    cmd.Parameters.AddWithValue("@pi_created_by", ord.Created_by);
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
