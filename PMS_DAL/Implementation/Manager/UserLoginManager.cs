    using Microsoft.AspNetCore.Http;
using PMS_BLL.Interfaces.Manager;
using PMS_BLL.Utility;
using PMS_BOL.Models;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace PMS_DAL.Implementation.Manager
{
    public class UserLoginManager : IUserLoginManager
    {
        private readonly Dg_SqlCommon _sqlCommon;
        private readonly SqlConnection _connection;
        public UserLoginManager(Dg_SqlCommon sqlCommon)
        {
            _sqlCommon = sqlCommon;
            _connection = new SqlConnection(Dg_Getway.SpecFoCon);
        }

        public async Task<string> UserLogin(LoginUser obj)
        {
            string result = string.Empty;
            try
            {
                var logUserInfo = await _sqlCommon.get_InformationDataTableAsync("Sp_Smt_UserLogin '" + obj.userName + "','" + obj.password + "'", _connection);
                if (logUserInfo.Rows.Count > 0)
                {
                    var activeStatus = logUserInfo.Rows[0]["Activity_status"].ToString();
                    if (activeStatus == "A")
                    {
                        result = "Login Successfully";
                    }
                    else
                    {
                        result = "This user is Inactive";
                    }
                }
                else
                {
                    result = "User Name or Password Incorrect";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
        public async Task<DataTable> loginUserDetails(LoginUser obj)
        {
            var data = await _sqlCommon.get_InformationDataTableAsync("Sp_Smt_UserLogin '" + obj.userName + "','" + obj.password + "'", _connection);
            return data;
        }

        public async Task<List<object>> GetPermitedMenuList(List<MenuList> obj)
        {
            List<object> lstMenu = new List<object>();
            DataTable dt = await _sqlCommon.get_InformationDataTableAsync("select Permission_Status from Smt_Users where cUserName='" + obj[0].UserName + "'", _connection);
            DataTable userGroup = await _sqlCommon.get_InformationDataTableAsync("select nUgroup from Smt_Users where cUserName='"+ obj[0].UserName + "'", _connection);
            if (userGroup.Rows[0]["nUgroup"].ToString() != "1")
            {
                if (dt.Rows.Count > 0)
                {
                    string x = dt.Rows[0]["Permission_status"].ToString();
                    if (x == "U")
                    {
                        for (int iac = 0; iac < obj.Count; iac++)
                        {
                            string frmName = obj[iac].MenuText;
                            DataTable dtgtfrmU = await _sqlCommon.get_InformationDataTableAsync("select Form_Name from Smt_UserPermittedform where User_ID='" + obj[0].UserName + "' and Form_Name='" + frmName + "'", _connection);
                            if (dtgtfrmU.Rows.Count < 1)
                            {
                                var LiID = new
                                {
                                    MenuText = obj[iac].MenuText
                                };
                                lstMenu.Add(LiID);
                            }
                        }
                    }
                    else
                    {
                        for (int iac = 0; iac < obj.Count; iac++)
                        {
                            string frmName = obj[iac].MenuText;
                            DataTable dtgtfrmU = await _sqlCommon.get_InformationDataTableAsync("select Form_Name from Smt_UserPermittedform where nUgroup=" + userGroup.Rows[0]["nUgroup"].ToString() + " and Form_Name='" + frmName + "'", _connection);
                            if (dtgtfrmU.Rows.Count < 1)
                            {
                                var LiID = new
                                {
                                    MenuText = obj[iac].MenuText
                                };
                                lstMenu.Add(LiID);
                            }
                        }
                    }
                }
            }
            return lstMenu;
        }
        public async Task<List<object>> SetBtnPermission(List<ButtonList> obj)
        {
            List<object> lst = new List<object>();
            SqlCommand cmd = new SqlCommand("select UserName from tst_permitterbtn where UserName='" + obj[0].UserName + "'", _connection);
            if (_connection.State == ConnectionState.Closed)
            {
                await _connection.OpenAsync();
            }
            SqlDataReader dr = await cmd.ExecuteReaderAsync();
            await dr.ReadAsync();
            if (dr.HasRows)
            {
                await dr.CloseAsync();
                if (obj.Count > 0)
                {
                    for (int i = 0; i < obj.Count; i++)
                    {
                        string btnName = obj[i].ButtonName;
                        string controller = obj[i].Controller;
                        SqlCommand cd = new SqlCommand("select ButtonName from tst_permitterbtn where UserName='" + obj[0].UserName + "' and FormName='" + controller + "' and ButtonName='" + btnName + "'", _connection);
                        SqlDataReader drr = cd.ExecuteReader();
                        drr.Read();
                        if (drr.HasRows)
                        {
                            drr.Close();
                            var btnList = new ButtonList
                            {
                                IsShow = true,
                                ButtonName = obj[i].ButtonName
                            };
                            lst.Add(btnList);
                        }
                        else
                        {
                            drr.Close();
                            var btnList = new ButtonList
                            {
                                IsShow = false,
                                ButtonName = obj[i].ButtonName
                            };
                            lst.Add(btnList);
                        }
                    }
                }
            }
            else
            {
                await dr.CloseAsync();
            }
            if (_connection.State == ConnectionState.Open)
            {
                await _connection.CloseAsync();
            }
            return lst;
        }
    }
}
