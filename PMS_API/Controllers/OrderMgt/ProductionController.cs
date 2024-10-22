using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;
using PMS_BOL.Models.Order_Mgt;
using PMS_BOL.Models.OrderMgt;

namespace PMS_API.Controllers.OrderMgt
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProductionController : ControllerBase
    {
        private readonly IGlobalMaster _globalMaster;

        public ProductionController(IGlobalMaster globalMaster)
        {
            _globalMaster = globalMaster;
        }
        //DropDown 
        [HttpGet]
        public async Task<IActionResult> GetmachineNo(int Production_ProcID)
        {
            var data = await _globalMaster.productionManager.GetmachineNo(Production_ProcID);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetShift()
        {
            var data = await _globalMaster.productionManager.GetShift();
            return Ok(data);
        }
        //[HttpGet]
        //public async Task<IActionResult> GetProductionPadding_RefNo()
        //{
        //    var data = await _globalMaster.productionManager.GetProductionPadding_RefNo();
        //    return Ok(data);
        //}
        //[HttpGet]
        //public async Task<IActionResult> GetProductionQuilting_RefNo()
        //{
        //    var data = await _globalMaster.productionManager.GetProductionQuilting_RefNo();
        //    return Ok(data);
        //}
        [HttpGet]
        public async Task<IActionResult> GetProductionQuilting_ProcessType(int Ordr_refNO, int Process_ID)
        {
            var data = await _globalMaster.productionManager.GetProductionQuilting_ProcessType(Ordr_refNO,Process_ID);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetProduction_ProcessType()
        {
            var data = await _globalMaster.productionManager.GetProduction_ProcessType();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetProduction_Padding_PI_Number()
        {
            var data = await _globalMaster.productionManager.GetProduction_Padding_PI_Number();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetProduction_Quilting_PI_Number()
        {
            var data = await _globalMaster.productionManager.GetProduction_Quilting_PI_Number();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetProduction_Hour()
        {
            var data = await _globalMaster.productionManager.GetProduction_Hour();
            return Ok(data);
        }
        //GET Report DROP DOWN
        [HttpGet]
        public async Task<IActionResult> Get_ReportProduction_ProcessType()
        {
            var data = await _globalMaster.productionManager.Get_ReportProduction_ProcessType();
            return Ok(data);
        }


        //GET
        [HttpGet]
        public async Task<IActionResult> GetPadding_ProductionItemBeforeAdd (string Pi_Number)
        {
            var data = await _globalMaster.productionManager.GetPadding_ProductionItemBeforeAdd(Pi_Number);
            return Ok(data);
        }
       
        [HttpGet]
        public async Task<IActionResult> GetProductionAfterAdd(int ProcessID, string SessionUser)
        {
            var data = await _globalMaster.productionManager.GetProductionAfterAdd(ProcessID , SessionUser);
            return Ok(data);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetQuilting_ProductionItemBeforeAdd(string PINumber,int ProType)
        {
            var data = await _globalMaster.productionManager.GetQuilting_ProductionItemBeforeAdd( PINumber,ProType);
            return Ok(data);
        }


        //Modal
        [HttpGet]
        public async Task<IActionResult> GetmachineView()
        {
            var data = await _globalMaster.productionManager.GetmachineView();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetShiftview()
        {
            var data = await _globalMaster.productionManager.GetShiftview();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> MachineDetailsSave(List<MachineDetails>MC)
        {
            var data = await _globalMaster.productionManager.MachineDetailsSave(MC);
            return Ok(new { message = data });
        }
        [HttpPost]
        public async Task<IActionResult> shiftSave(List<ShiftDetails> SF)
        {
            var data = await _globalMaster.productionManager.shiftSave(SF);
            return Ok(new { message = data });
        }
        [HttpGet]
        public async Task<IActionResult> GetMechinType()
        {
            var data = await _globalMaster.productionManager.GetMechinType();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> ProductionSave(List<ProductionModel> PD)
        {
            var data = await _globalMaster.productionManager.ProductionSave(PD);
            return Ok(new { message = data });
        }

        [HttpDelete]
        public async Task<IActionResult> ProductionDelete(List<ProductionModel> PD)
        {
            var data = await _globalMaster.productionManager.ProductionDelete(PD);
            return Ok(new { message = data });
        }
        [HttpPut]
        public async Task<IActionResult> productionComplete(List<ProductionModel> PD)
        {
            var data = await _globalMaster.productionManager.productionComplete(PD);
            return Ok(new { message = data });
        }
        //public async Task<IActionResult> productionComplete(List<ProductionModel> PD)
        ////{
        ////    try
        ////    {
        ////        var data = await _globalMaster.productionManager.productionComplete(PD);

        ////        if (string.IsNullOrEmpty(data))
        ////        {
        ////            // Assuming an empty message means success
        ////            return Ok(new { message = "Production completed successfully" });
        ////        }
        ////        else
        ////        {
        ////            // If there's an error message from the procedure, return a Bad Request with the message
        ////            return BadRequest(new { error = data });
        ////        }
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        // Log the exception (you can log it here if needed)
        ////        return StatusCode(500, new { error = "An unexpected error occurred.", details = ex.Message });
        ////    }
        ////}

    }
}
