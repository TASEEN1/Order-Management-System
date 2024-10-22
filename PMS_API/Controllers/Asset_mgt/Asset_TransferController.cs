using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;
using PMS_BOL.Models.Asset_Mgt;

namespace PMS_API.Controllers.Asset_mgt
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class Asset_TransferController : ControllerBase
    {
        private readonly IGlobalMaster _globalMaster;

        public Asset_TransferController(IGlobalMaster globalMaster)
        {
            _globalMaster = globalMaster;
        }

        [HttpGet]
        public async Task<IActionResult> Get_Company_CH()
        {
            var data = _globalMaster.asset_TransferManager.Get_Company_CH();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> BindFloor(int ComID)
        {
            var data = _globalMaster.asset_TransferManager.BindFloor(ComID);
            return Ok(data);


        }

        [HttpGet]
        public async Task<IActionResult> GetLine(int ComID, int floorID)
        {
            var data = _globalMaster.asset_TransferManager.GetLine(ComID, floorID);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> IGet_Asst_No(int ComID, int floorID, int LineID)
        {
            var data = _globalMaster.asset_TransferManager.IGet_Asst_No(ComID, floorID, LineID);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> EGet_Asst_No(int ComID)
        {
            var data = _globalMaster.asset_TransferManager.EGet_Asst_No(ComID);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Internal_Transfer_Save(List<Asset_Transfer_Model> App)
        {
            var data = await _globalMaster.asset_TransferManager.Internal_Transfer_Save(App);
            return Ok(new { message = data });

        }
        [HttpGet]
        public async Task<IActionResult> GetInternalTransferAddView(int comID, string InputUser)
        {
            var data = await _globalMaster.asset_TransferManager.GetInternalTransferAddView(comID, InputUser);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> External_Transfer_Save(List<Asset_Transfer_Model> App)
        {
            var data = await _globalMaster.asset_TransferManager.External_Transfer_Save(App);
            return Ok(new { message = data });

        }

        [HttpGet]
        public async Task<IActionResult> GetExternalTransferAddView(int ComID, string InputUser)
        {
            var data = await _globalMaster.asset_TransferManager.GetExternalTransferAddView(ComID, InputUser);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetExternalTransferView(int ComID)
        {
            var data = await _globalMaster.asset_TransferManager.GetExternalTransferView(ComID);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetInternalTransferView(int ComID)
        {
            var data = await _globalMaster.asset_TransferManager.GetInternalTransferView(ComID);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Asset_InternalTransfer_Approval(List<Asset_Internal_Transfer_Approval> App)
        {
            var data = await _globalMaster.asset_TransferManager.Asset_InternalTransfer_Approval(App);
            return Ok(new { message = data });
        }
        [HttpPut]
        public async Task<IActionResult> Asset_ExternalTransfer_Approval(List<Asset_External_Transfer_Approval> App)
        {
            var data = await _globalMaster.asset_TransferManager.Asset_ExternalTransfer_Approval(App);
            return Ok(new { message = data });
        }

        [HttpGet]
        public async Task<IActionResult> GetTransferView(int ComID)
        {
            var data = await _globalMaster.asset_TransferManager.GetTransferView(ComID);
            return Ok(data);
        }
    }
}