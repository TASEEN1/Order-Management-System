using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces.Manager.Asset_Master;
using PMS_BLL.Utility;
using PMS_BOL.Models.Asset_Mgt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_DAL.Implementation.Manager.Asset_Master
{
    public class RentedAssetReturnManager: IRentedAssetReturnManager
    {
        private readonly Dg_SqlCommon _SqlCommon;
        private readonly SqlConnection _specfo_conn;
        private readonly SqlConnection _dg_Asst_Mgt;
        private readonly SqlConnection _specFo_inventory;

        public RentedAssetReturnManager(Dg_SqlCommon sqlCommon)
        {
            _SqlCommon = sqlCommon;
            _specfo_conn = new SqlConnection(Dg_Getway.SpecFoCon);
            _specFo_inventory = new SqlConnection(Dg_Getway.SpecFoInventory);
            _dg_Asst_Mgt = new SqlConnection(Dg_Getway.dg_Asst_Mgt);
        }
        //1 query
        public async Task<DataTable> GetCurrentHolder()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT DISTINCT dbo.Smt_Company.nCompanyID, dbo.Smt_Company.cCmpName FROM dbo.Smt_StyleMaster INNER JOIN dbo.Smt_Company ON dbo.Smt_StyleMaster.cCmp = dbo.Smt_Company.nCompanyID where ConfirmStatus='CONF' and Active_Com=1 order by cCmpName", _specfo_conn);
            return data;
        }

        public async Task<DataTable> GetSupplier(int currentHolder) //Company
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT DISTINCT TOP (100) PERCENT SpecFo_Inventory.dbo.Smt_Suppliers.cSupCode, SpecFo_Inventory.dbo.Smt_Suppliers.cSupName, dbo.Mr_Asset_Rent.Company FROM dbo.Mr_Asset_Rent INNER JOIN SpecFo_Inventory.dbo.Smt_Suppliers ON dbo.Mr_Asset_Rent.SuppCode = SpecFo_Inventory.dbo.Smt_Suppliers.cSupCode WHERE  (dbo.Mr_Asset_Rent.Company = " + currentHolder + ") ORDER BY SpecFo_Inventory.dbo.Smt_Suppliers.cSupName", _dg_Asst_Mgt);
            return data;
        }
        public async Task<DataTable> GetAssetName(string supplierId)//SuppCode
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT RentAssetNo  FROM Mr_Asset_Rent WHERE  (SuppCode = '" + supplierId + "') ORDER BY  RentAssetNo", _dg_Asst_Mgt);
            return data;
        }
        public async Task<DataTable>GetRentAssetList(int currentHolderId, string supplierId)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("Mr_Asset_Return_Filter '" + currentHolderId + "','" + supplierId + "'",_dg_Asst_Mgt);
            return data;
        }
        public async Task<DataTable> GetReturnAddView(int currentHolderId, string supplierId)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("Mr_Asset_Return_Add_View '" + currentHolderId + "','" + supplierId + "'", _dg_Asst_Mgt);
            return data;
        }

        public async Task<DataTable> GetEId()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select MAX(ReturnRefNo) as ID from Mr_Asset_Rent", _dg_Asst_Mgt);
            return data;
        }

        public async Task<string> PutAssetRent(List<AssetRentComplete> put_asset_rent)
        {
            /*string message = string.Empty*//*;*/
            string message = "save succecfully";
            await _dg_Asst_Mgt.OpenAsync();
            try
            {
                foreach(AssetRentComplete modelVar in put_asset_rent){
                    SqlCommand cmd = new SqlCommand("Mr_Asset_rent_Complete", _dg_Asst_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ReturnRefNo ", modelVar.ReturnRefNo);
                    cmd.Parameters.AddWithValue("@ReturnDate ", modelVar.ReturnDate);
                    cmd.Parameters.AddWithValue("@ReturnUser ", modelVar.ReturnUser);
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

        //public async Task<DataTable> ForApproval_AssetReturnView(int comID)
        //{
        //    var data = await _SqlCommon.get_InformationDataTableAsync("Mr_Asset_Return_Approval_View '" + comID + "'", _dg_Asst_Mgt);
        //    return data;


        //}

      
        public async Task<DataTable> ForApproval_Asset_ReturnView(int comID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("Mr_Asset_Return_For_Approval_View '" + comID + "'", _dg_Asst_Mgt);
            return data;


        }

        public async Task<bool> ForApproval_Asset_Return(List<AssetForApprove> App)
        {
            bool flag = false;
            try
            {
                foreach (AssetForApprove Apps in App)
                {
                    await _dg_Asst_Mgt.OpenAsync();
                    SqlCommand cmd = new SqlCommand("Mr_Asset_Return_For_Approval", _dg_Asst_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AssetNo", Apps.AssetNo);
                    cmd.Parameters.AddWithValue("@Appby", Apps.Appby);

                    await cmd.ExecuteNonQueryAsync();
                    await _dg_Asst_Mgt.CloseAsync();
                }
                flag = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                flag = false;
            }
            finally
            {
                await _dg_Asst_Mgt.CloseAsync();
            }
            return flag;
        }

        public async Task<bool> Asset_ReturnCancel(List<AssetReturnCancel> App)
        {
            bool flag = false;
            try
            {
                foreach (AssetReturnCancel Apps in App)
                {
                    await _dg_Asst_Mgt.OpenAsync();
                    SqlCommand cmd = new SqlCommand("Mr_Asset_Return_Cancel", _dg_Asst_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AssetNo", Apps.AssetNo);
                    cmd.Parameters.AddWithValue("@CancelBy", Apps.CancelBy);

                    await cmd.ExecuteNonQueryAsync();
                    await _dg_Asst_Mgt.CloseAsync();
                }
                flag = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                flag = false;
            }
            finally
            {
                await _dg_Asst_Mgt.CloseAsync();
            }
            return flag;
        }
        public async Task<string> PutReturnAdd(List<RentAssetAdd> put_return_add)
        {
            //string message = string.Empty;
            string message = "Saved Successfully";
            await _dg_Asst_Mgt.OpenAsync();
            try
            {
                foreach (RentAssetAdd modelVar in put_return_add)
                {
                    SqlCommand cmd = new SqlCommand("Mr_Asset_Return_Add", _dg_Asst_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AssetNo", modelVar.RentAssetNo);
                    await cmd.ExecuteNonQueryAsync();
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

        public async Task<DataTable> GetApproval(int comID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("Mr_Asset_Return_Approval_View '" + comID + "'", _dg_Asst_Mgt);
            return data;

        }
    }



    }
 
