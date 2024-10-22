using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;
using PMS_BOL.Models.Asset_Mgt;

namespace PMS_API.Controllers.Asset_mgt
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class Rent_AssetController : ControllerBase
    {
        private readonly IGlobalMaster _globalMaster;

        public Rent_AssetController(IGlobalMaster globalMaster)
        {
            _globalMaster = globalMaster;
        }

        [HttpGet]
        public async Task<IActionResult> GetCURRENT_HOLDER()
        {
            var data = await _globalMaster.rent_Asset.GetCURRENT_HOLDER();

            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetBind_Floor(int comID)
        {
            var data = await _globalMaster.rent_Asset.GetBind_Floor(comID);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetBind_Line(int comID, int floorID)
        {
            var data = await _globalMaster.rent_Asset.GetBind_Line(comID, floorID);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetMachine_Name()
        {
            var data = await _globalMaster.rent_Asset.GetMachine_Name();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> Get_Asset_Category()
        {
            var data = await _globalMaster.rent_Asset.Get_Asset_Category();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> Get_Brand()
        {
            var data = await _globalMaster.rent_Asset.Get_Brand();
            return Ok(data);
        }


        [HttpGet]
        public async Task<IActionResult> GetSupplierName()
        {
            var data = await _globalMaster.rent_Asset.GetSupplierName();

            return Ok(data);

        }

        [HttpGet]
        public async Task<IActionResult> GetAsstSpecialFeature()
        {
            var data = await _globalMaster.rent_Asset.GetAsstSpecialFeature();

            return Ok(data);

        }

        [HttpGet]
        public async Task<IActionResult> GetAssetStatus()
        {
            var data = await _globalMaster.rent_Asset.GetAssetStatus();

            return Ok(data);

        }

        [HttpGet]
        public async Task<IActionResult> GetCurrency()
        {
            var data = await _globalMaster.rent_Asset.GetCurrency();

            return Ok(data);

        }

        [HttpGet]
        public async Task<IActionResult> GetAssetRentSelectView()
        {
            var data = await _globalMaster.rent_Asset.GetAssetRentSelectView();

            return Ok(data);

        }

        [HttpGet]
        public async Task<IActionResult> GetAssetRentSelect(string AssetNO)
        {
            var data = await _globalMaster.rent_Asset.GetAssetRentSelect(AssetNO);

            return Ok(data);

        }


        [HttpPost]
        public async Task<IActionResult> Rent_Asset_Save(List<Rent_Asset_Model> Asst_Rent)
        {
            var data = await _globalMaster.rent_Asset.Rent_Asset_Save(Asst_Rent);
            return Ok(new { message = data });
        }


        [HttpPut]
        public async Task<IActionResult> Update_Asset_Rent(List<Rent_Asset_Model> Asst_Rent_put)
        {
            var data = await _globalMaster.rent_Asset.Update_Asset_Rent(Asst_Rent_put);
            return Ok(new { message = data });
        }





    }
}
