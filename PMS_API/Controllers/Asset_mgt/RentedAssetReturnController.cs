using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;
using PMS_BOL.Models.Asset_Mgt;

namespace PMS_API.Controllers.Asset_mgt
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class RentedAssetReturnController : ControllerBase
    {
        private readonly IGlobalMaster _globalMaster;
        public RentedAssetReturnController(IGlobalMaster globalMaster)
        {
            _globalMaster = globalMaster;
        }
        [HttpGet]
        public async Task<IActionResult> GetCurrentHolder()
        {
            var data = await _globalMaster.rentedAssetReturnManager.GetCurrentHolder();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetSupplier(int currentHolder) //Company
        {
            var data = await _globalMaster.rentedAssetReturnManager.GetSupplier(currentHolder);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetAssetName(string supplierId)
        {
            var data = await _globalMaster.rentedAssetReturnManager.GetAssetName(supplierId);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetRentAssetList(int currentHolderId, string supplierId)
        {
            var data = await _globalMaster.rentedAssetReturnManager.GetRentAssetList(currentHolderId, supplierId);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetReturnAddView(int currentHolderId, string supplierId)
        {
            var data = await _globalMaster.rentedAssetReturnManager.GetReturnAddView(currentHolderId, supplierId);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetEId()
        {
            var data = await _globalMaster.rentedAssetReturnManager.GetEId();
            return Ok(data);
        }

        //post
        [HttpPut]
        public async Task<IActionResult> PutAssetRent(List<AssetRentComplete> put_asset_rent)
        {
            var data = await _globalMaster.rentedAssetReturnManager.PutAssetRent(put_asset_rent);
            return Ok(new { message = data });
        }

        //[HttpGet]
        //public async Task<IActionResult> ForApproval_AssetReturnView(int comID)
        //{
        //    var data = await _globalMaster.rentedAssetReturnManager.ForApproval_AssetReturnView(comID);
        //    return Ok(data);

        //}


        [HttpGet]
        public async Task<IActionResult> ForApproval_Asset_ReturnView(int comID)
        {
            var data = await _globalMaster.rentedAssetReturnManager.ForApproval_Asset_ReturnView(comID);
            return Ok(data);

        }
        [HttpPut]
        public async Task<IActionResult> ForApproval_Asset_Return(List<AssetForApprove> App)
        {
            var data = await _globalMaster.rentedAssetReturnManager.ForApproval_Asset_Return(App);
            return Ok(new { message = data });
        }

        [HttpDelete]
        public async Task<IActionResult> Asset_ReturnCancel(List<AssetReturnCancel> App)
        {
            var data = await _globalMaster.rentedAssetReturnManager.Asset_ReturnCancel(App);
            return Ok(new { message = data });
        }

        [HttpPut]
        public async Task<IActionResult> PutReturnAdd(List<RentAssetAdd> put_return_add)
        {
            var data = await _globalMaster.rentedAssetReturnManager.PutReturnAdd(put_return_add);
            return Ok(new { message = data });
        }

        [HttpGet]
        public async Task<IActionResult> GetApproval(int comID)
        {
            var data = await _globalMaster.rentedAssetReturnManager.GetApproval(comID);
            return Ok(data);
        }



    }
}
