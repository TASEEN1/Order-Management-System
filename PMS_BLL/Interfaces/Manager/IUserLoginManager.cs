using PMS_BOL.Models;
using System.Data;

namespace PMS_BLL.Interfaces.Manager
{
    public interface IUserLoginManager
    {
        Task<string> UserLogin(LoginUser obj);
        Task<DataTable> loginUserDetails(LoginUser obj);
        Task<List<object>> GetPermitedMenuList(List<MenuList> obj);
        Task<List<object>> SetBtnPermission(List<ButtonList> obj);
    }
}
