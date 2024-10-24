using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;
using PMS_BOL.Models.OrderMgt;
using static PMS_BOL.Models.OrderMgt.PI_Model;

namespace PMS_API.Controllers.OrderMgt
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PIController : ControllerBase
    {

        private readonly IGlobalMaster _globalMaster;

        public PIController(IGlobalMaster globalMaster)
        {
            _globalMaster = globalMaster;
        }

        [HttpGet]
        public async Task<IActionResult> GetGeneratePIAddView( string created_By)
        {
            var data = await _globalMaster.piManager.GetGeneratePIAddView(created_By);
            return Ok(data);
        }


        [HttpGet]
        public async Task<IActionResult> GetPIAddView( int Ref_no)
        {
            var data = await _globalMaster.piManager.GetPIAddView( Ref_no);
            return Ok(data);
        }


        [HttpGet]
        public async Task<IActionResult> GetPiApproval_checkedBy_View( string   Created_by)
        {
            var data = await _globalMaster.piManager.GetPiApproval_checkedBy_View(Created_by);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetPiApproval_approvedBy_view(string Created_by)
        {
            var data = await _globalMaster.piManager.GetPiApproval_approvedBy_view(Created_by);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetPiApproval_ForApprovalView(string Created_by)
        {
            var data = await _globalMaster.piManager.GetPiApproval_ForApprovalView(Created_by);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetPiApproval_revise_view(string Created_by)
        {
            var data = await _globalMaster.piManager.GetPiApproval_revise_view(Created_by);
            return Ok(data);
        }

       

        [HttpGet]
        public async Task<IActionResult> GetPI_ProcessType()
        {
            var data = await _globalMaster.piManager.GetPI_ProcessType();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetPI_Number()
        {
            var data = await _globalMaster.piManager.GetPI_Number();
            return Ok(data);
        }

      
        [HttpGet]
        public async Task<IActionResult> GetBookingRefForPiGenerate(int CustomerID)
        {
            var data = await _globalMaster.piManager.GetBookingRefForPiGenerate(CustomerID);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetPI_CustomerTermsAndCondition(int Ref_No)
        {
            var data = await _globalMaster.piManager.GetPI_CustomerTermsAndCondition(Ref_No);
            return Ok(data);
        }


        [HttpDelete]
        public async Task<IActionResult> PIDelete(List<PI_Model> app)
        {
            var data = await _globalMaster.piManager.PIDelete(app);
            return Ok(new { message = data });

        }

        [HttpPut]
        public async Task<IActionResult> PIRevise(List<PI_Model> app)
        {
            var data = await _globalMaster.piManager.PIRevise(app);
            return Ok(new { message = data });

        }

        [HttpPost]
        public async Task<IActionResult> GeneratePIAdd(List<PI_Model> app)
        {
            var data = await _globalMaster.piManager.GeneratePIAdd(app);
            return Ok(new { message = data });
        }

        [HttpPut]
        public async Task<IActionResult> GeneratePI(List<PI_Model> app)
        {
            var data = await _globalMaster.piManager.GeneratePI(app);
            return Ok(new { message = data });
        }

        [HttpPut]
        public async Task<IActionResult> ApprovedByApprove(List<PI_Model> app)
        {
            var data = await _globalMaster.piManager.ApprovedByApprove(app);
            return Ok(new { message = data });
        }

        [HttpPut]
        public async Task<IActionResult> CheckedByApprove(List<PI_Model> app)
        {
            var data = await _globalMaster.piManager.CheckedByApprove(app);
            return Ok(new { message = data });
        }



        // REVISED PI
        [HttpGet]
        public async Task<IActionResult> GetRevised_PI_Number()
        {
            var data = await _globalMaster.piManager.GetRevised_PI_Number();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetRevised_Version(string PINumber)
        {
            var data = await _globalMaster.piManager.GetRevised_Version(PINumber);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetRevised_Before_View(string PINumber)
        {
            var data = await _globalMaster.piManager.GetRevised_Before_View(PINumber);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetRevised_CustomerPaymentAndProcessData(string PINumber)
        {
            var data = await _globalMaster.piManager.GetRevised_CustomerPaymentAndProcessData(PINumber);
            return Ok(data);
        }


        [HttpPost]
        public async Task<IActionResult> Generate_RevisedPI(List<PIRevisedModel> app)
        {
            var data = await _globalMaster.piManager.Generate_RevisedPI(app);
            return Ok(new { message = data });
        }
        




    }
}
