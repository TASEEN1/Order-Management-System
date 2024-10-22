using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;
using PMS_BOL.Functions;
using PMS_BOL.Models;

namespace PMS_API.Controllers.Asset_mgt
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class Schedule_MaintenanceController : ControllerBase
    {
        private readonly IGlobalMaster _globalMaster;

        public Schedule_MaintenanceController(IGlobalMaster globalMaster)
        {
            _globalMaster = globalMaster;
        }


        [HttpGet]
        public async Task<IActionResult> GetAssetNo()
        {
            var data = await _globalMaster.asset_Running_Repair.GetAssetNo();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsset_Master_List(string AsstNo)
        {
            var data = await _globalMaster.asset_Running_Repair.GetAsset_Master_List(AsstNo);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetServiceDescription()
        {
            var data = await _globalMaster.schedule_Maintenance.GetServiceDescription();
            return Ok(data);
        }



        [HttpPost]
        public async Task<IActionResult> ScheduleMaintenanceSave(MaintenanceSaveRequest maintenanceSaveRequest)
        {
            var data = await _globalMaster.schedule_Maintenance.ScheduleMaintenanceSave(maintenanceSaveRequest);
            return Ok(new { message = data });
        }


        //[HttpPost]
        //public async Task<IActionResult> SM_service_Typesave(List<SMServiceTypeSave_Model> app)
        //{
        //    var data = await _globalMaster.schedule_Maintenance.SM_service_Typesave(app);
        //    return Ok("Data save successfully ");
        //}


    }
}
