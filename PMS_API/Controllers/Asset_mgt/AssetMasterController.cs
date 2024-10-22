using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMS_BLL.Interfaces;
using PMS_BOL.Models.Asset_Mgt;

namespace PMS_API.Controllers.Asset_mgt
{
    [Route("api/[controller]/[Action]")]
    [ApiController]

    public class AssetMasterController : ControllerBase
    {
        private readonly IGlobalMaster _globalMaster;

        public AssetMasterController(IGlobalMaster globalMaster)
        {
            _globalMaster = globalMaster;
        }

        [HttpGet]
        public async Task<IActionResult> GetGetCompany()
        {
            var data = await _globalMaster.assetmastermanager.GetCompany();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartment(int comID)
        {
            var data = await _globalMaster.assetmastermanager.GetDepartment(comID);
            return Ok(data);

        }

        [HttpGet]
        public async Task<IActionResult> GetSection(int comID, int DeptID)
        {
            var data = await _globalMaster.assetmastermanager.GetSection(comID, DeptID);

            return Ok(data);

        }

        [HttpGet]
        public async Task<IActionResult> GetFloor(int comID)
        {
            var data = await _globalMaster.assetmastermanager.GetFloor(comID);

            return Ok(data);

        }

        [HttpGet]
        public async Task<IActionResult> GetLine(int comID, int floorID)
        {
            var data = await _globalMaster.assetmastermanager.GetLine(comID, floorID);

            return Ok(data);

        }

        [HttpGet]
        public async Task<IActionResult> GetAssetCategory()
        {
            var data = await _globalMaster.assetmastermanager.GetAssetCategory();

            return Ok(data);

        }

        [HttpGet]
        public async Task<IActionResult> GetAsstSpecialFeature()
        {
            var data = await _globalMaster.assetmastermanager.GetAsstSpecialFeature();

            return Ok(data);

        }

        [HttpGet]
        public async Task<IActionResult> GetAssetStatus()
        {
            var data = await _globalMaster.assetmastermanager.GetAssetStatus();

            return Ok(data);

        }

        [HttpGet]
        public async Task<IActionResult> GetMachineName()
        {
            var data = await _globalMaster.assetmastermanager.GetMachineName();

            return Ok(data);

        }

        [HttpGet]
        public async Task<IActionResult> GetSupplierName()
        {
            var data = await _globalMaster.assetmastermanager.GetSupplierName();

            return Ok(data);


        }
        [HttpGet]
        public async Task<IActionResult> GetBrand()
        {
            var data = await _globalMaster.assetmastermanager.GetBrand();

            return Ok(data);

        }

        [HttpGet]
        public async Task<IActionResult> GetCurrency()
        {
            var data = await _globalMaster.assetmastermanager.GetCurrency();

            return Ok(data);

        }

        [HttpGet]
        public async Task<IActionResult> BindCURRENTHOLDER()
        {
            var data = await _globalMaster.assetmastermanager.BindCURRENTHOLDER();
            return Ok(data);

        }

        [HttpGet]
        public async Task<IActionResult> GetAll_AssetMaster_List()
        {
            var data = await _globalMaster.assetmastermanager.GetAll_AssetMaster_List();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAsset(List<Asset_Master_Save> Asst)
        {
            var data = await _globalMaster.assetmastermanager.SaveAsset(Asst);
            return Ok(new { message = data });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAssetInfo(List<Asset_Master_Save> asset_update_put)
        {
            var data = await _globalMaster.assetmastermanager.UpdateAssetInfo(asset_update_put);
            return Ok(new { message = data });
        }

        [HttpGet]
        public async Task<IActionResult> Mr_Asset_Master_(string AsstNo)
        {
            var data = await _globalMaster.assetmastermanager.Mr_Asset_Master_(AsstNo);
            return Ok(data);
        }









    }
}
