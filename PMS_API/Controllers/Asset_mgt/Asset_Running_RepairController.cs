using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;
using PMS_BOL.Models.Asset_Mgt;

namespace PMS_API.Controllers.Asset_mgt
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class Asset_Running_RepairController : ControllerBase
    {
        private readonly IGlobalMaster _globalMaster;

        public Asset_Running_RepairController(IGlobalMaster globalMaster)
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
        [HttpPost]
        public async Task<IActionResult> Machine_Running_Repairsave(List<AssetRunningRepairModel> App)
        {
            var data = await _globalMaster.asset_Running_Repair.Machine_Running_Repairsave(App);
            return Ok(new { message = data });
        }
        [HttpGet]
        public async Task<IActionResult> GetMachineRunningRepair_View()
        {
            var data = await _globalMaster.asset_Running_Repair.GetMachineRunningRepair_View();
            return Ok(data);
        }



    }
}
