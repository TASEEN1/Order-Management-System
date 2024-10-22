using PMS_BLL.Interfaces.Manager.AssetMaster;
using PMS_BLL.Utility;
using PMS_BOL.Models.Asset_Mgt;
using System.Data;
using System.Data.SqlClient;

namespace PMS_DAL.Implementation.Manager.Asset_Master
{
    public class RentAssetManager: IRentAsset
    {
        private readonly Dg_SqlCommon _SqlCommon;
        private readonly SqlConnection _specfo_conn;
        private readonly SqlConnection _dg_Asst_Mgt;
        private readonly SqlConnection _SpecFoInventory;


        public RentAssetManager(Dg_SqlCommon sqlCommon)
        {
            _SqlCommon = sqlCommon;
            _specfo_conn = new SqlConnection(Dg_Getway.SpecFoCon);
            _dg_Asst_Mgt = new SqlConnection(Dg_Getway.dg_Asst_Mgt);
            _SpecFoInventory = new SqlConnection(Dg_Getway.SpecFoInventory);
        }

        public async Task<DataTable> GetCURRENT_HOLDER()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT DISTINCT dbo.Smt_Company.nCompanyID, dbo.Smt_Company.cCmpName FROM dbo.Smt_StyleMaster INNER JOIN dbo.Smt_Company ON dbo.Smt_StyleMaster.cCmp = dbo.Smt_Company.nCompanyID where ConfirmStatus='CONF' order by cCmpName", _specfo_conn);
            return data;
        }


        public async Task<DataTable> GetBind_Floor(int comID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT nFloor,cFloor_Descriptin from Smt_Floor where CompanyID='" + comID + "' Order by cFloor_Descriptin", _specfo_conn);
            return data;
        }

        public async Task<DataTable> GetBind_Line(int ComID, int floorID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT Line_Code,Line_No from Smt_Line where CompanyID='" + ComID + "' and FloorID='" + floorID + "' Order by Line_No ", _specfo_conn);
            return data;
        }
        public async Task<DataTable> GetMachine_Name()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT McCode,McDesc  FROM Mr_Machine_Master order by McDesc",_dg_Asst_Mgt);
            return data;
        }

        public async Task<DataTable> Get_Asset_Category()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT acat_id,acat_name  FROM Mr_Asset_Category order by acat_name", _dg_Asst_Mgt);
            return data;
        }
        public async Task<DataTable> Get_Brand()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT nBrand_ID,cBrand_Name  FROM Smt_Brand order by cBrand_Name", _specfo_conn);
            return data;
        }
        public async Task<DataTable> GetSupplierName()

        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT cSupCode,cSupName  FROM Smt_Suppliers order by cSupName", _SpecFoInventory);

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

        public async Task<DataTable> GetCurrency()

        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT cCurID,cCurdes  FROM Smt_CurencyType order by cCurdes", _SpecFoInventory);

            return data;
        }

        public async Task<DataTable> GetAssetRentSelectView( )

        {
            var data = await _SqlCommon.get_InformationDataTableAsync("Mr_Asset_Rent_View", _dg_Asst_Mgt);

            return data;
        }
        public async Task<DataTable> GetAssetRentSelect(string AssetNO)

        {
            var data = await _SqlCommon.get_InformationDataTableAsync("Mr_Asset_Rent_Select '"+ AssetNO + "'" , _dg_Asst_Mgt);

            return data;
        }









        public async Task<string> Rent_Asset_Save(List<Rent_Asset_Model> Asst_Rent)
        {
            string message = string.Empty;
            await _dg_Asst_Mgt.OpenAsync();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "SELECT MAX(ReturnRefNo)+1 FROM Mr_Asset_Rent";
            cmd1.Connection = _dg_Asst_Mgt;
            SqlDataReader dr = cmd1.ExecuteReader();
            dr.Read();
            int d = dr.GetInt32(0);
            dr.Close();


            try
            {
                foreach (Rent_Asset_Model asset in Asst_Rent)
                {
                    SqlCommand cmd = new SqlCommand("Mr_Asset_Rent_Save", _dg_Asst_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CurrentHolder ", asset.CurrentHolder);
                    cmd.Parameters.AddWithValue("@FloorId", asset.FloorID);
                    cmd.Parameters.AddWithValue("@LineId", asset.LineId);
                    cmd.Parameters.AddWithValue("@ChallanNo", asset.ChallanNo);
                    cmd.Parameters.AddWithValue("@RentedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ReturnDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@AssetCate", asset.AssetCate);
                    cmd.Parameters.AddWithValue("@AssetSpFeature", asset.AssetSpFeature);
                    cmd.Parameters.AddWithValue("@AssetStatus", asset.AssetStatus);
                    cmd.Parameters.AddWithValue("@AssetName", asset.AssetName);
                    cmd.Parameters.AddWithValue("@AssetNo", asset.AssetNo);
                    cmd.Parameters.AddWithValue("@SerialNo", asset.SerialNo);
                    cmd.Parameters.AddWithValue("@Model", asset.Model);
                    cmd.Parameters.AddWithValue("@Supplier", asset.Supplier);
                    cmd.Parameters.AddWithValue("@AssetValue", asset.AssetValue);
                    cmd.Parameters.AddWithValue("@Currency", asset.Currency);
                    cmd.Parameters.AddWithValue("@TotalDays", asset.TotalDays);
                    cmd.Parameters.AddWithValue("@InputUser", asset.InputUser);
                    cmd.Parameters.AddWithValue("@ReturnRefNo", d);
                    cmd.Parameters.AddWithValue("@Brand  ", asset.Brand);

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



        public async Task<string> Update_Asset_Rent(List<Rent_Asset_Model> Asst_Rent_put)
        {
            string message = string.Empty;
            await _dg_Asst_Mgt.OpenAsync();


            try
            {
                foreach (Rent_Asset_Model asset in Asst_Rent_put)
                {
                    SqlCommand cmd = new SqlCommand("Mr_Asset_Rent_Update", _dg_Asst_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CurrentHolder ", asset.CurrentHolder);
                    cmd.Parameters.AddWithValue("@FloorId", asset.FloorID);
                    cmd.Parameters.AddWithValue("@LineId", asset.LineId);
                    cmd.Parameters.AddWithValue("@ChallanNo", asset.ChallanNo);
                    cmd.Parameters.AddWithValue("@RentedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ReturnDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@AssetCate", asset.AssetCate);
                    cmd.Parameters.AddWithValue("@AssetSpFeature", asset.AssetSpFeature);
                    cmd.Parameters.AddWithValue("@AssetStatus", asset.AssetStatus);
                    cmd.Parameters.AddWithValue("@AssetName", asset.AssetName);
                    cmd.Parameters.AddWithValue("@AssetNo", asset.AssetNo);
                    cmd.Parameters.AddWithValue("@SerialNo", asset.SerialNo);
                    cmd.Parameters.AddWithValue("@Model", asset.Model);
                    cmd.Parameters.AddWithValue("@Supplier", asset.Supplier);
                    cmd.Parameters.AddWithValue("@AssetValue", asset.AssetValue);
                    cmd.Parameters.AddWithValue("@Currency", asset.Currency);
                    cmd.Parameters.AddWithValue("@TotalDays", asset.TotalDays);
                    cmd.Parameters.AddWithValue("@InputUser", asset.InputUser);
                    cmd.Parameters.AddWithValue("@Brand  ", asset.Brand);

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


       




    }

}
