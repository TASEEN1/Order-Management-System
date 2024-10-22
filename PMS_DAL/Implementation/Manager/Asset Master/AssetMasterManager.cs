using PMS_BLL.Interfaces.Manager.AssetMaster;
using PMS_BLL.Utility;
using PMS_BOL.Models.Asset_Mgt;
using System.Data;
using System.Data.SqlClient;

namespace PMS_DAL.Implementation.Manager.Asset_Master
{
    public class AssetMasterManager : IAssetMasterManager
    {

        private readonly Dg_SqlCommon _SqlCommon;
        private readonly SqlConnection _specfo_conn;
        private readonly SqlConnection _dg_Asst_Mgt;
        private readonly SqlConnection _SpecFoInventory;


        public AssetMasterManager(Dg_SqlCommon sqlCommon)
        {
            _SqlCommon = sqlCommon;
           _specfo_conn = new SqlConnection(Dg_Getway.SpecFoCon);
           _dg_Asst_Mgt = new SqlConnection(Dg_Getway.dg_Asst_Mgt);
           _SpecFoInventory = new SqlConnection(Dg_Getway.SpecFoInventory);
        }

        public async Task<DataTable> GetCompany()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT DISTINCT dbo.Smt_Company.nCompanyID, dbo.Smt_Company.cCmpName FROM dbo.Smt_StyleMaster INNER JOIN dbo.Smt_Company ON dbo.Smt_StyleMaster.cCmp = dbo.Smt_Company.nCompanyID where ConfirmStatus='CONF' order by cCmpName",_specfo_conn);
            return data;
        }


        public async Task<DataTable> GetDepartment(int comID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT DISTINCT nUserDept, cDeptname FROM Smt_Department where nCompanyID='"+ comID+"' order by cDeptname" , _specfo_conn);
            return data;
        }


        public async Task<DataTable> GetSection(int comID , int DeptID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT DISTINCT nSectionID, cSection_Description FROM Smt_Section where nCompanyID='"+ comID+"'  and nUserDept='"+ DeptID +"' order by cSection_Description", _specfo_conn);
            return data;
        }


        public async Task<DataTable> GetFloor(int comID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT nFloor,cFloor_Descriptin from Smt_Floor where CompanyID='"+ comID+"' Order by cFloor_Descriptin", _specfo_conn);
            return data;
        }


        public async Task<DataTable> GetLine(int comID, int floorID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT Line_Code,Line_No from Smt_Line where CompanyID='"+ comID +"' and FloorID='"+ floorID + "' Order by Line_No ", _specfo_conn);

            return data;
        }

        public async Task<DataTable> GetAssetCategory()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT acat_id,acat_name  FROM Mr_Asset_Category order by acat_name", _dg_Asst_Mgt);

            return data;
        }


        public async Task<DataTable> GetAsstSpecialFeature()

        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT asf_id,asf_descrip  FROM Mr_Asset_Special_Feature order by asf_descrip", _dg_Asst_Mgt);

            return data;
        }

        public async Task<DataTable> GetAssetStatus()

        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT StatusId,StatusName  FROM Mr_Asset_Status order by StatusName", _dg_Asst_Mgt);

            return data;
        }

        public async Task<DataTable> GetMachineName()

        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT McCode,McDesc  FROM Mr_Machine_Master order by McDesc", _dg_Asst_Mgt);

            return data;
        }

        public async Task<DataTable> GetSupplierName()

        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT cSupCode,cSupName  FROM Smt_Suppliers order by cSupName", _SpecFoInventory);

            return data;
        }

        public async Task<DataTable> GetBrand()

        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT nBrand_ID,cBrand_Name  FROM Smt_Brand order by cBrand_Name", _specfo_conn);

            return data;
        }

        public async Task<DataTable> GetCurrency()

        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT cCurID,cCurdes  FROM Smt_CurencyType order by cCurdes", _SpecFoInventory);

            return data;
        }

        public async Task<DataTable> BindCURRENTHOLDER()

        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT DISTINCT dbo.Smt_Company.nCompanyID, dbo.Smt_Company.cCmpName FROM dbo.Smt_StyleMaster INNER JOIN dbo.Smt_Company ON dbo.Smt_StyleMaster.cCmp = dbo.Smt_Company.nCompanyID where ConfirmStatus='CONF' order by cCmpName", _specfo_conn);

            return data;
        }


        public async Task<DataTable> GetAll_AssetMaster_List()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("Mr_Asset_Master_List_View", _dg_Asst_Mgt);
            return data;
        }
  

        public async Task<string> SaveAsset(List<Asset_Master_Save> Asst)
        {
            string message = string.Empty;
            await _dg_Asst_Mgt.OpenAsync();


            try
            { 
                foreach (Asset_Master_Save asset in Asst)
                {
                    SqlCommand cmd = new SqlCommand("Mr_Asset_Master_List_Save", _dg_Asst_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ComId", asset.ComId);
                    cmd.Parameters.AddWithValue("@Dept", asset.Dept);
                    cmd.Parameters.AddWithValue("@SectionId", asset.SectionId);
                    cmd.Parameters.AddWithValue("@FloorId", asset.FloorId);
                    cmd.Parameters.AddWithValue("@LineId", asset.LineId);
                    cmd.Parameters.AddWithValue("@PurchaseDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@AsstCateId", asset.AsstCateId);
                    cmd.Parameters.AddWithValue("@AsstSpId", asset.AsstSpId);
                    cmd.Parameters.AddWithValue("@AsstStatusId", asset.AsstStatusId);
                    cmd.Parameters.AddWithValue("@AsstNameId", asset.AsstNameId);
                    cmd.Parameters.AddWithValue("@AsstNo",asset.AsstNo);
                    cmd.Parameters.AddWithValue("@SerialNo", asset.SerialNo);
                    cmd.Parameters.AddWithValue("@BrandId", asset.BrandID);
                    cmd.Parameters.AddWithValue("@Model",asset.Model);
                    cmd.Parameters.AddWithValue("@SupplierId",asset.SupplierId);
                    cmd.Parameters.AddWithValue("@AsstValue", asset.AsstValue);
                    cmd.Parameters.AddWithValue("@Curency", asset.Curency);
                    cmd.Parameters.AddWithValue("@DepValue", asset.DepValue);
                    cmd.Parameters.AddWithValue("@DepPeriod", asset.DepPeriod);
                    cmd.Parameters.AddWithValue("@BillNo",asset.BillNo );
                    cmd.Parameters.AddWithValue("@BillInputDate",DateTime.Now);
                    cmd.Parameters.AddWithValue("@LCNo", asset.LCNo);
                    cmd.Parameters.AddWithValue("@LCDate",DateTime.Now);
                    cmd.Parameters.AddWithValue("@ComInvoiceNo",asset.ComInvoiceNo);
                    cmd.Parameters.AddWithValue("@ComInvoiceDate",DateTime.Now);
                    cmd.Parameters.AddWithValue("@WarrantyExpDate",DateTime.Now);
                    cmd.Parameters.AddWithValue("@CurrenHolder",asset.CurrenHolder );
                    cmd.Parameters.AddWithValue("@CommencingDate",DateTime.Now );
                    cmd.Parameters.AddWithValue("@InhouseDate",DateTime.Now );
                    cmd.Parameters.AddWithValue("@Remarks",asset.Remarks );
                    cmd.Parameters.AddWithValue("@UserName", asset.UserName);
                    cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                    cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                    await cmd.ExecuteNonQueryAsync();
                    message = (string)cmd.Parameters["@ERROR"].Value;
                 }



            } catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                _dg_Asst_Mgt.Close();
            }
            return message;
        }


        public async Task<string> UpdateAssetInfo( List<Asset_Master_Save> asset_update_put)
        {
            string message = string.Empty;
            await _dg_Asst_Mgt.OpenAsync();


            try
            {
                foreach (Asset_Master_Save asset_update in asset_update_put) {

                    SqlCommand cmd = new SqlCommand("Mr_Asset_Master_List_Update", _dg_Asst_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ComId", asset_update.ComId);
                    cmd.Parameters.AddWithValue("@Dept", asset_update.Dept);
                    cmd.Parameters.AddWithValue("@SectionId", asset_update.SectionId);
                    cmd.Parameters.AddWithValue("@FloorId", asset_update.FloorId);
                    cmd.Parameters.AddWithValue("@LineId", asset_update.LineId);
                    cmd.Parameters.AddWithValue("@PurchaseDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@AsstCateId", asset_update.AsstCateId);
                    cmd.Parameters.AddWithValue("@AsstSpId", asset_update.AsstSpId);
                    cmd.Parameters.AddWithValue("@AsstStatusId", asset_update.AsstStatusId);
                    cmd.Parameters.AddWithValue("@AsstNameId", asset_update.AsstNameId);
                    cmd.Parameters.AddWithValue("@AsstNo", asset_update.AsstNo);
                    cmd.Parameters.AddWithValue("@SerialNo", asset_update.SerialNo);
                    cmd.Parameters.AddWithValue("@BrandId", asset_update.BrandID);
                    cmd.Parameters.AddWithValue("@Model", asset_update.Model);
                    cmd.Parameters.AddWithValue("@SupplierId", asset_update.SupplierId);
                    cmd.Parameters.AddWithValue("@AsstValue", asset_update.AsstValue);
                    cmd.Parameters.AddWithValue("@Curency", asset_update.Curency);
                    cmd.Parameters.AddWithValue("@DepValue", asset_update.DepValue);
                    cmd.Parameters.AddWithValue("@DepPeriod", asset_update.DepPeriod);
                    cmd.Parameters.AddWithValue("@BillNo", asset_update.BillNo);
                    cmd.Parameters.AddWithValue("@BillInputDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@LCNo", asset_update.LCNo);
                    cmd.Parameters.AddWithValue("@LCDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ComInvoiceNo", asset_update.ComInvoiceNo);
                    cmd.Parameters.AddWithValue("@ComInvoiceDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@WarrantyExpDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@CurrenHolder", asset_update.CurrenHolder);
                    cmd.Parameters.AddWithValue("@CommencingDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@InhouseDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Remarks", asset_update.Remarks);
                    cmd.Parameters.AddWithValue("@UserName", asset_update.UserName);
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
                _dg_Asst_Mgt.Close();
            }
            return message;


            
        }

        public async Task<DataTable> Mr_Asset_Master_( string AsstNo)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("Mr_Asset_Master_List_Select '"+ AsstNo + "'", _dg_Asst_Mgt);
            return data;
        }



    }
}
