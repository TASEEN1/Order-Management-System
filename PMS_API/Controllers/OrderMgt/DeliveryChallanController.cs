using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;
using PMS_BOL.Models.Order_Mgt;

namespace PMS_API.Controllers.OrderMgt
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class DeliveryChallanController : ControllerBase
    {
        private readonly IGlobalMaster _globalMaster;

        public DeliveryChallanController(IGlobalMaster globalMaster)
        {
            _globalMaster = globalMaster;
        }
        //Common 
        //GetDelivery_Challan_PINumber(customer wise)
        [HttpGet]
        public async Task<IActionResult> GetDelivery_Challan_PINumber(string? PI_Number, int custParamForPI, int pageProcId, int itemProcId)
        {
            var data = await _globalMaster.challanManager.GetDelivery_Challan_PINumber(PI_Number, custParamForPI, pageProcId, itemProcId);
            return Ok(data);
        }




        //-------Padding------//

        //Drop Down

        [HttpGet]
        public async Task<IActionResult> GetPadding_Challan_ProcessType()
        {
            var data = await _globalMaster.challanManager.GetPadding_Challan_ProcessType();
            return Ok(data);
        }
        //view
        [HttpGet]
        public async Task<IActionResult> GetDelivery_Challan_Before_View(string PI_Number, int custParamForPI, int pageProcId, int itemProcId)
        {
            var data = await _globalMaster.challanManager.GetDelivery_Challan_Before_View(PI_Number, custParamForPI, pageProcId, itemProcId);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetDelivery_Challan_After_View(int challanProcId, string sessionUser)
        {
            var data = await _globalMaster.challanManager.GetDelivery_Challan_After_View( challanProcId, sessionUser);
            return Ok(data);
        }
       


        //save

        [HttpPost]
        public async Task<IActionResult> PaddingAndQuilting_Delivery_Challan_Save(List<DeliveryChallanModel> DV)
        {
        
            var data = await _globalMaster.challanManager.PaddingAndQuilting_Delivery_Challan_Save(DV);
            return Ok(data);

        }
        [HttpPut]
        public async Task<IActionResult> PaddingAndQuilting_Delivery_Challan_Complete(List<DeliveryChallanModel> DV)
        {
            var data = await _globalMaster.challanManager.PaddingAndQuilting_Delivery_Challan_Complete(DV);
            return Ok(new { message = data });

        }
        [HttpDelete]
        public async Task<IActionResult> PaddingQuilting_Delivery_Challan_Delete(List<DeliveryChallanModel> DV)
        {
            var data = await _globalMaster.challanManager.PaddingQuilting_Delivery_Challan_Delete(DV);
            return Ok(new { message = data });

        }
        //report
        [HttpGet]
        public async Task<IActionResult> Get_Challan()
        {
            var data = await _globalMaster.challanManager.Get_Challan();
            return Ok(data);
        }


        // Challan_Approval
        [HttpPut]
        public async Task<IActionResult> PaddingQuilting_Delivery_challan_Approved_By_Approved(List<Challan_Approval> AP)
        {
            var data = await _globalMaster.challanManager.PaddingQuilting_Delivery_challan_Approved_By_Approved(AP);
            return Ok(new { message = data });

        }
        [HttpPut]
        public async Task<IActionResult> PaddingQuilting_Delivery_challan_Checked_By_Approved(List<Challan_Approval> AP)
        {
            var data = await _globalMaster.challanManager.PaddingQuilting_Delivery_challan_Checked_By_Approved(AP);
            return Ok(new { message = data });

        }
        [HttpGet]
        public async Task<IActionResult> GetPaddingQuilting_Delivery_challan_Approval_By_Approved_View( string sessionUser)
        {
            var data = await _globalMaster.challanManager.GetPaddingQuilting_Delivery_challan_Approval_By_Approved_View( sessionUser);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetPaddingQuilting_Delivery_challan_for_Approval_By_Approved_View(string sessionUser)
        {
            var data = await _globalMaster.challanManager.GetPaddingQuilting_Delivery_challan_for_Approval_By_Approved_View(sessionUser);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetPaddingQuilting_Delivery_challan_Checked_By_Approved_View(string sessionUser)
        {
            var data = await _globalMaster.challanManager.GetPaddingQuilting_Delivery_challan_Checked_By_Approved_View(sessionUser);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetPaddingQuilting_Delivery_challan_cancel_View(string sessionUser)
        {
            var data = await _globalMaster.challanManager.GetPaddingQuilting_Delivery_challan_cancel_View(sessionUser);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> PaddingQuilting_Delivery_challan_Cancel(List<Challan_cancel> AP)
        {
            var data = await _globalMaster.challanManager.PaddingQuilting_Delivery_challan_Cancel(AP);
            return Ok(new { message = data });

        }



    }
}
