using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;
using PMS_BOL.Models.Order_Mgt;

namespace PMS_API.Controllers.OrderMgt
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class DashboardController : Controller
    {
        private readonly IGlobalMaster _globalMaster;
        public DashboardController(IGlobalMaster globalMaster)
        {
            _globalMaster = globalMaster;
        }
        //view
        [HttpGet]
        public async Task<IActionResult> GetDashboard_Daily_View(string sessionUser, int sessionUser_compId)
        {
            var data = await _globalMaster.dashboardManager.GetDashboard_Daily_View(sessionUser, sessionUser_compId);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetDashboard_All_summary_View(string sessionUser, int sessionUser_compId)
        {
            var data = await _globalMaster.dashboardManager.GetDashboard_All_summary_View(sessionUser, sessionUser_compId);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetDashboard_Daily_View_Grapdata(string sessionUser, int sessionUser_compId)
        {
            var data = await _globalMaster.dashboardManager.GetDashboard_Daily_View_Grapdata(sessionUser, sessionUser_compId);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetDashboard_HrwiseProd_View(int prodProc, string sessionUser, int sessionUser_compId)
        {
            var data = await _globalMaster.dashboardManager.GetDashboard_HrwiseProd_View(prodProc, sessionUser, sessionUser_compId);
            return Ok(data);
        }
    }
}
