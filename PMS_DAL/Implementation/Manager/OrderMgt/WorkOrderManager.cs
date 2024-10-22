using PMS_BLL.Interfaces.Manager.OrderMgt;
using PMS_BLL.Utility;
using PMS_BOL.Functions;
using PMS_BOL.Models.OrderMgt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PMS_DAL.Implementation.Manager.OrderMgt
{
    public class WorkOrderManager: IworkOrderManager
    {
       
            private readonly Dg_SqlCommon _SqlCommon;
            private readonly SqlConnection _specfo_conn;
            private readonly SqlConnection _dg_Asst_Mgt;
            private readonly SqlConnection _SpecFoInventory;
            private readonly SqlConnection _dg_Oder_Mgt;

            public WorkOrderManager(Dg_SqlCommon sqlCommon)
            {
                _SqlCommon = sqlCommon;
                _specfo_conn = new SqlConnection(Dg_Getway.SpecFoCon);
                _dg_Asst_Mgt = new SqlConnection(Dg_Getway.dg_Asst_Mgt);
                _SpecFoInventory = new SqlConnection(Dg_Getway.SpecFoInventory);
                _dg_Oder_Mgt = new SqlConnection(Dg_Getway.dg_Oder_Mgt);

            }


        // Padding Section


        public async Task<DataTable> GetPadding_Type()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select pt_id as padding_type_id, pt_padding_type from dg_ms_padding_type order by pt_padding_type", _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetPadding_Thickness()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select pt_id as padding_thickness_id, pt_padding_thickness from dg_ms_padding_thickness order by pt_padding_thickness", _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetPadding_Washstatus()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select ws_id, ws_wash_status from dg_ms_wash_status order by ws_wash_status", _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetPadding_GarmentsType()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select gt_id, gt_garments_type from dg_ms_garments_type order by gt_garments_type", _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetPadding_HeatSide()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select hs_id, hs_heat_side from dg_ms_heat_side order by hs_heat_side", _dg_Oder_Mgt);
            return data;
        }

        public async Task<DataTable> GetPadding_Chemical_Restriction()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select cr_id, cr_chemical_restriction from dg_ms_chemical_restriction order by cr_chemical_restriction", _dg_Oder_Mgt);
            return data;
        }


        //Quilting Section

        public async Task<DataTable> GetQuilting_Type()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select qt_id, qt_quilting_type from dg_ms_quilting_type order by qt_quilting_type", _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetQuilting_MachineType()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select mt_id, mt_machine_type from dg_ms_machine_type order by mt_machine_type", _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetQuilting_DesignName()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select qdn_id, qdn_quilting_design_name from dg_ms_quilting_design_name order by qdn_quilting_design_name", _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetQuilting_Design_Dimension()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select qdd_id, qdd_quilting_design_dimension from dg_ms_quilting_design_dimension order by qdd_quilting_design_dimension", _dg_Oder_Mgt);
            return data;
        }

        public async Task<DataTable> GetQuilting_Stitch_PerInch()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select spi_id, spi_stitch_per_inch from dg_ms_stitch_per_inch order by spi_stitch_per_inch", _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetQuilting_FabricSide()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select qfs_id, qfs_quilting_fabric_side from dg_ms_quilting_fabric_side order by qfs_quilting_fabric_side", _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetQuilting_Lining_Usage()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select lu_id, lu_lining_usage from dg_ms_lining_usage order by lu_lining_usage", _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetQuilting_Yarn_Count()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select yc_id, yc_yarn_count from dg_ms_yarn_count order by yc_yarn_count", _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetQuilting_FabricName()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select qfn_id, qfn_quilting_fabric_name from dg_ms_quilting_fabric_name order by qfn_quilting_fabric_name", _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetQuilting_FabricType()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select qft_id, qft_quilting_fabric_type from dg_ms_quilting_fabric_type order by qft_quilting_fabric_type", _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetQuilting_Fabric_Composition()
        
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select qfc_id, qfc_quilting_fabric_composition from dg_ms_quilting_fabric_composition order by qfc_quilting_fabric_composition", _dg_Oder_Mgt);
            return data;
        }


        //Work_Order

        public async Task<string> Work_Order_Save(WorkorderSaveRequest workorderSaveRequest)
        {
            string message = string.Empty;

            try
            {

                DataTable workOrderSL = _SqlCommon.get_InformationDataTable("select COALESCE(MAX(wo_workOrderSL),0)+1 as SL from dg_work_order", _dg_Oder_Mgt);
                int wo_workOrderSL = int.Parse(workOrderSL.Rows[0]["SL"].ToString());

                await _dg_Oder_Mgt.OpenAsync();
                foreach (var ord in workorderSaveRequest.workOrder_Models)
                {
                    using (SqlCommand cmd = new SqlCommand("dg_work_order_other_attributes_save", _dg_Oder_Mgt))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@wo_insertedBy_compId", ord.ComID);
                        cmd.Parameters.AddWithValue("@wo_or_ref_no", ord.wo_or_ref_no);
                        cmd.Parameters.AddWithValue("@wo_or_id", ord.wo_or_id);
                        cmd.Parameters.AddWithValue("@wo_workOrderSL", wo_workOrderSL);
                        cmd.Parameters.AddWithValue("@wo_remarks", ord.wo_remarks);
                        cmd.Parameters.AddWithValue("@wo_thickness", ord.wo_thickness);
                        cmd.Parameters.AddWithValue("@wo_wash_status", ord.wo_wash_status);
                        cmd.Parameters.AddWithValue("@wo_garments_type", ord.wo_garments_type);
                        cmd.Parameters.AddWithValue("@wo_heat_side", ord.wo_heat_side);
                        cmd.Parameters.AddWithValue("@wo_chemical_restriction", ord.wo_chemical_restriction);
                        cmd.Parameters.AddWithValue("@wo_quilting_type", ord.wo_quilting_type);
                        cmd.Parameters.AddWithValue("@wo_machine_type", ord.wo_machine_type);
                        cmd.Parameters.AddWithValue("@wo_quilting_design_name", ord.wo_quilting_design_name);
                        cmd.Parameters.AddWithValue("@wo_quilting_design_dimension", ord.wo_quilting_design_dimension);
                        cmd.Parameters.AddWithValue("@wo_spi", ord.wo_spi);
                        cmd.Parameters.AddWithValue("@wo_quilting_fabric_side", ord.wo_quilting_fabric_side);
                        cmd.Parameters.AddWithValue("@wo_quilting_fabric_type", ord.wo_quilting_fabric_type);
                        cmd.Parameters.AddWithValue("@wo_lining_usage", ord.wo_lining_usage);
                        cmd.Parameters.AddWithValue("@wo_yarn_count", ord.wo_yarn_count);
                        cmd.Parameters.AddWithValue("@wo_quilting_fabric_name", ord.wo_quilting_fabric_name);
                        cmd.Parameters.AddWithValue("@wo_quilting_fabric_composition", ord.wo_quilting_fabric_composition);
                        cmd.Parameters.AddWithValue("@wo_test_name", ord.wo_test_name);
                        cmd.Parameters.AddWithValue("@wo_inserted_by", ord.wo_created_by);
                        cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                        cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                        await cmd.ExecuteNonQueryAsync();
                        message = (string)cmd.Parameters["@ERROR"].Value;



                    }

                }
                foreach (var ord in workorderSaveRequest.paddingTypes)
                {
                    using (SqlCommand cmd2 = new SqlCommand("dg_work_order_padding_type_save", _dg_Oder_Mgt))
                    {
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddWithValue("@wopt_or_ref_no",ord.wopt_or_ref_no);
                        cmd2.Parameters.AddWithValue("@wopt_wo_workOrderSL", wo_workOrderSL);
                        cmd2.Parameters.AddWithValue("@wopt_or_id",ord.wopt_or_id);
                        cmd2.Parameters.AddWithValue("@wopt_padding_type",ord.wopt_padding_type);
                        await cmd2.ExecuteNonQueryAsync();



                    }
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







        public async Task<string> Work_Order_Update(WorkorderUpdateRequest workorderUpdateRequest)
        {
            string message = string.Empty;
           
            try
            {

                DataTable workOrderSL = _SqlCommon.get_InformationDataTable("select COALESCE(MAX(wo_workOrderSL),0)+1 as SL from dg_work_order", _dg_Oder_Mgt);
                int wo_workOrderSL = int.Parse(workOrderSL.Rows[0]["SL"].ToString());

                await _dg_Oder_Mgt.OpenAsync();
                foreach (var ord in workorderUpdateRequest.work_Order_Update_Deletes)
                {
                    SqlCommand cmd = new SqlCommand("dg_work_order_forUpdate_delete", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@wo_or_ref_no", ord.wo_or_ref_no);
                    cmd.Parameters.AddWithValue("@wo_or_id", ord.wo_or_id);
                    cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                    cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                    await cmd.ExecuteNonQueryAsync();
                    message = (string)cmd.Parameters["@ERROR"].Value;
                }


                foreach(var ord in workorderUpdateRequest.workOrder_Models)
                {
                    SqlCommand cmd = new SqlCommand("dg_work_order_other_attributes_save", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@wo_insertedBy_compId", ord.ComID);
                    cmd.Parameters.AddWithValue("@wo_or_ref_no", ord.wo_or_ref_no);
                    cmd.Parameters.AddWithValue("@wo_or_id", ord.wo_or_id);
                    cmd.Parameters.AddWithValue("@wo_workOrderSL", wo_workOrderSL);
                    cmd.Parameters.AddWithValue("@wo_remarks", ord.wo_remarks);
                    cmd.Parameters.AddWithValue("@wo_thickness", ord.wo_thickness);
                    cmd.Parameters.AddWithValue("@wo_wash_status", ord.wo_wash_status);
                    cmd.Parameters.AddWithValue("@wo_garments_type", ord.wo_garments_type);
                    cmd.Parameters.AddWithValue("@wo_heat_side", ord.wo_heat_side);
                    cmd.Parameters.AddWithValue("@wo_chemical_restriction", ord.wo_chemical_restriction);
                    cmd.Parameters.AddWithValue("@wo_quilting_type", ord.wo_quilting_type);
                    cmd.Parameters.AddWithValue("@wo_machine_type", ord.wo_machine_type);
                    cmd.Parameters.AddWithValue("@wo_quilting_design_name", ord.wo_quilting_design_name);
                    cmd.Parameters.AddWithValue("@wo_quilting_design_dimension", ord.wo_quilting_design_dimension);
                    cmd.Parameters.AddWithValue("@wo_spi", ord.wo_spi);
                    cmd.Parameters.AddWithValue("@wo_quilting_fabric_side", ord.wo_quilting_fabric_side);
                    cmd.Parameters.AddWithValue("@wo_quilting_fabric_type", ord.wo_quilting_fabric_type);
                    cmd.Parameters.AddWithValue("@wo_lining_usage", ord.wo_lining_usage);
                    cmd.Parameters.AddWithValue("@wo_yarn_count", ord.wo_yarn_count);
                    cmd.Parameters.AddWithValue("@wo_quilting_fabric_name", ord.wo_quilting_fabric_name);
                    cmd.Parameters.AddWithValue("@wo_quilting_fabric_composition", ord.wo_quilting_fabric_composition);
                    cmd.Parameters.AddWithValue("@wo_test_name", ord.wo_test_name);
                    cmd.Parameters.AddWithValue("@wo_inserted_by", ord.wo_updated_by);
                    cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                    cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                    await cmd.ExecuteNonQueryAsync();
                    
                    message = (string)cmd.Parameters["@ERROR"].Value;

                }


                foreach (var ord in workorderUpdateRequest.paddingTypes)
                {
                    SqlCommand cmd = new SqlCommand("dg_work_order_padding_type_save", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@wopt_or_ref_no", ord.wopt_or_ref_no);
                    cmd.Parameters.AddWithValue("@wopt_or_id", ord.wopt_or_id);
                    cmd.Parameters.AddWithValue("@wopt_wo_workOrderSL", wo_workOrderSL);
                    cmd.Parameters.AddWithValue("@wopt_padding_type", ord.wopt_padding_type);
                    await cmd.ExecuteNonQueryAsync();

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


        public async Task<DataTable> work_order_completedOrderReceiving_view(int Ref_no)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("dg_work_order_completedOrderReceiving_view " + Ref_no , _dg_Oder_Mgt);
            return data;
        }

        public async Task<DataTable> work_order_afterBothSaveSP_save_view(int Ref_no)
        {

            var data = await _SqlCommon.get_InformationDataTableAsync("dg_work_order_afterBothSaveSP_save_view " + Ref_no, _dg_Oder_Mgt);
          
            return data;
        }
        public async Task<DataTable> GetpaddingtypeUpdateSelect(int Wo_or_ID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select wopt_padding_type, dg_ms_padding_type.pt_padding_type from dg_wo_padding_type inner join dg_ms_padding_type on wopt_padding_type = pt_id where wopt_or_id =" + Wo_or_ID, _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetWorkOrderUpdateSelect(int Id)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("dg_work_order_getworkOrderSL_FromBooking  " + Id, _dg_Oder_Mgt);
            return data;
        }






    }
}
