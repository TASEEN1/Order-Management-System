using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;
using PMS_BOL.Functions;
using PMS_BOL.Models.OrderMgt;

namespace PMS_API.Controllers.OrderMgt
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class workOrderController : ControllerBase
    {
        private readonly IGlobalMaster _globalMaster;

        public workOrderController(IGlobalMaster globalMaster)
        {
            _globalMaster = globalMaster;
        }

        // Padding Section

        [HttpGet]
        public async Task<IActionResult>GetPadding_Type()
        {
            var data = await _globalMaster.workOrderManager.GetPadding_Type();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetPadding_Thickness()
        {
            var data = await _globalMaster.workOrderManager.GetPadding_Thickness();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetPadding_Washstatus()
        {
            var data = await _globalMaster.workOrderManager.GetPadding_Washstatus();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetPadding_GarmentsType()
        {
            var data = await _globalMaster.workOrderManager.GetPadding_GarmentsType();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetPadding_HeatSide()
        {
            var data = await _globalMaster.workOrderManager.GetPadding_HeatSide();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetPadding_Chemical_Restriction()
        {
            var data = await _globalMaster.workOrderManager.GetPadding_Chemical_Restriction();
            return Ok(data);
        }

        //Quilting Section

        [HttpGet]
        public async Task<IActionResult> GetQuilting_Type()
        {
            var data = await _globalMaster.workOrderManager.GetQuilting_Type();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetQuilting_MachineType()
        {
            var data = await _globalMaster.workOrderManager.GetQuilting_MachineType();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetQuilting_DesignName()
        {
            var data = await _globalMaster.workOrderManager.GetQuilting_DesignName();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetQuilting_Design_Dimension()
        {
            var data = await _globalMaster.workOrderManager.GetQuilting_Design_Dimension();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetQuilting_Stitch_PerInch()
        {
            var data = await _globalMaster.workOrderManager.GetQuilting_Stitch_PerInch();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetQuilting_FabricSide()
        {
            var data = await _globalMaster.workOrderManager.GetQuilting_FabricSide();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetQuilting_Lining_Usage()
        {
            var data = await _globalMaster.workOrderManager.GetQuilting_Lining_Usage();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetQuilting_Yarn_Count()
        {
            var data = await _globalMaster.workOrderManager.GetQuilting_Yarn_Count();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetQuilting_FabricName()
        {
            var data = await _globalMaster.workOrderManager.GetQuilting_FabricName();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetQuilting_FabricType()
        {
            var data = await _globalMaster.workOrderManager.GetQuilting_FabricType();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetQuilting_Fabric_Composition()
        
        {
            var data = await _globalMaster.workOrderManager.GetQuilting_Fabric_Composition();
            return Ok(data);
        }


        //WORK Order

        [HttpPost]
        public async Task<IActionResult> Work_Order_Save(WorkorderSaveRequest workorderSaveRequest)
        {
            var data = await _globalMaster.workOrderManager.Work_Order_Save(workorderSaveRequest);
            return Ok(new { message = data });

        }

        [HttpPut]
        public async Task<IActionResult> Work_Order_Update(WorkorderUpdateRequest workorderUpdateRequest)
        {
            var data = await _globalMaster.workOrderManager.Work_Order_Update(workorderUpdateRequest);
            return Ok(new { message = data });

        }

        [HttpGet]
        public async Task<IActionResult> work_order_completedOrderReceiving_view(int Ref_no)

        {
            var data = await _globalMaster.workOrderManager.work_order_completedOrderReceiving_view(Ref_no);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> work_order_afterBothSaveSP_save_view(int Ref_no)

        {
            var data = await _globalMaster.workOrderManager.work_order_afterBothSaveSP_save_view(Ref_no);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetpaddingtypeUpdateSelect(int Wo_or_ID)

        {
            var data = await _globalMaster.workOrderManager.GetpaddingtypeUpdateSelect(Wo_or_ID);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetWorkOrderUpdateSelect(int Id)

        {
            var data = await _globalMaster.workOrderManager.GetWorkOrderUpdateSelect(Id);
            return Ok(data);
        }









    }
}
