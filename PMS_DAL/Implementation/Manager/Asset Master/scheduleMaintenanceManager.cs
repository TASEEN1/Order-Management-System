using PMS_BLL.Interfaces.Manager.AssetMaster;
using PMS_BLL.Utility;
using PMS_BOL.Functions;
using PMS_BOL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_DAL.Implementation.Manager.Asset_Master
{
    public class scheduleMaintenanceManager: Ischedule_Maintenance
    {
        private readonly Dg_SqlCommon _SqlCommon;
        private readonly SqlConnection _specfo_conn;
        private readonly SqlConnection _dg_Asst_Mgt;
        private readonly SqlConnection _specFo_inventory;

        public scheduleMaintenanceManager(Dg_SqlCommon sqlCommon)
        {
            _SqlCommon = sqlCommon;
            _specfo_conn = new SqlConnection(Dg_Getway.SpecFoCon);
            _specFo_inventory = new SqlConnection(Dg_Getway.SpecFoInventory);
            _dg_Asst_Mgt = new SqlConnection(Dg_Getway.dg_Asst_Mgt);
        }

        public async Task<DataTable> GetAssetNo()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT DISTINCT McAsstNo FROM Mr_Asset_Master_List ORDER BY McAsstNo", _dg_Asst_Mgt);
            return data;
        }

        public async Task<DataTable> GetAsset_Master_List(string AsstNo)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("Mr_Asset_Master_List_Select '" + AsstNo + "'", _dg_Asst_Mgt);
            return data;
        }

        public async Task<DataTable> GetServiceDescription()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("Select  ser_service_type from Mr_Service_type ", _dg_Asst_Mgt);
            return data;
        }

        //public async Task<string> ScheduleMaintenanceSave(List<ScheduleMaintenanceModel> App)
        //{
        //    string message = string.Empty;
        //    await _dg_Asst_Mgt.OpenAsync();


        //    try
        //    {
        //        foreach (ScheduleMaintenanceModel asset in App)
        //        {
        //            SqlCommand cmd = new SqlCommand("Mr_Schedule_Maintenance_Save", _dg_Asst_Mgt);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@assetno", asset.assetno);
        //            cmd.Parameters.AddWithValue("@nextservicedate", DateTime.Now);
        //            cmd.Parameters.AddWithValue("@ItemReplaced", asset.itemreplace);
        //            cmd.Parameters.AddWithValue("@readydate", DateTime.Now);
        //            cmd.Parameters.AddWithValue("@doneby", asset.doneby);
        //            cmd.Parameters.AddWithValue("@InputUser", asset.InputUser);
        //            cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        //            cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        //            await cmd.ExecuteNonQueryAsync();
        //            message = (string)cmd.Parameters["@ERROR"].Value;
        //        }



        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //    }
        //    finally
        //    {
        //        _dg_Asst_Mgt.Close();
        //    }
        //    return message;
        //}


        //public async Task<string> SM_service_Typesave(List<SMServiceTypeSave_Model> app)
        //{
        //    string message = string.Empty;
        //    await _dg_Asst_Mgt.OpenAsync();


        //    try
        //    {
        //        foreach (SMServiceTypeSave_Model asset in app)
        //        {
        //            SqlCommand cmd = new SqlCommand("Mr_SM_Service_Type_Save", _dg_Asst_Mgt);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@AssetNo", asset.assetno);
        //            cmd.Parameters.AddWithValue("@ServiceID", asset.ServiceID);
        //            cmd.Parameters.AddWithValue("@ReadyDate", DateTime.Now);
        //            cmd.Parameters.AddWithValue("@InputUser", asset.InputUser);
        //            //cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        //            //cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        //            await cmd.ExecuteNonQueryAsync();
        //            //message = (string)cmd.Parameters["@ERROR"].Value;
        //        }



        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //    }
        //    finally
        //    {
        //        _dg_Asst_Mgt.Close();
        //    }
        //    return message;
        //}


        public async Task<string> ScheduleMaintenanceSave(MaintenanceSaveRequest maintenanceSaveRequest)
        {
            string message = string.Empty;
            await _dg_Asst_Mgt.OpenAsync();
            int insert1 = 0;
            int insert2 =0;

            SqlTransaction transaction = _dg_Asst_Mgt.BeginTransaction();

            try
            {
                foreach (var asset in maintenanceSaveRequest.ScheduleMaintenanceModels)
                {
                    using (SqlCommand cmd = new SqlCommand("Mr_Schedule_Maintenance_Save", _dg_Asst_Mgt, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@assetno", asset.assetno);
                        cmd.Parameters.AddWithValue("@nextservicedate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@ItemReplaced", asset.itemreplace);
                        cmd.Parameters.AddWithValue("@readydate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@doneby", asset.doneby);
                        cmd.Parameters.AddWithValue("@InputUser", asset.InputUser);
                        cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500).Direction = ParameterDirection.Output;

                         insert1 = await cmd.ExecuteNonQueryAsync();
                        string error = (string)cmd.Parameters["@ERROR"].Value;
                        if (!string.IsNullOrEmpty(error))
                        {
                            message += "Schedule Maintenance : " + error + Environment.NewLine;
                        }
                        //if (insert < 1)
                        //{
                        //    transaction.Rollback();
                        //}
                    }
                }

                foreach (var asset in maintenanceSaveRequest.SMServiceTypeSaveModels)
                {
                    using (SqlCommand cmd = new SqlCommand("Mr_SM_Service_Type_Save", _dg_Asst_Mgt, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AssetNo", asset.assetno);
                        cmd.Parameters.AddWithValue("@ServiceID", asset.ServiceID);
                        cmd.Parameters.AddWithValue("@ReadyDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@InputUser", asset.InputUser);

                        insert2 = await cmd.ExecuteNonQueryAsync();

                       

                    }
                }
                if(insert1 < 1 && insert2 <1)
                {
                    transaction.Rollback();
                }
                else
                {
                    transaction.Commit();
                }
                
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                message = "Transaction failed and rolled back: " + ex.Message;
               
            }
            finally
            {
                await _dg_Asst_Mgt.CloseAsync();
            }

            return message;
        }






    }
}
