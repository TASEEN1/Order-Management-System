using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BLL.Interfaces.Manager.OrderMgt
{
    public interface IDashboardManager
    { 
    public Task<object> GetDashboard_Daily_View_Grapdata(string sessionUser, int sessionUser_compId);

    public Task<DataTable> GetDashboard_Daily_View(string sessionUser, int sessionUser_compId);
    public Task<DataTable> GetDashboard_All_summary_View(string sessionUser, int sessionUser_compId);

    public Task<DataTable> GetDashboard_HrwiseProd_View(int prodProc, string sessionUser, int sessionUser_compId);

    }
}
