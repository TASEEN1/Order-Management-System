using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;
using PMS_BOL.Models.Order_Mgt;
using PMS_DAL.Implementation;
using System.Runtime.ExceptionServices;

namespace PMS_API.Controllers.OrderMgt
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PlaningController : ControllerBase
    {
        private readonly IGlobalMaster _globalMaster;

        public PlaningController(IGlobalMaster globalMaster)
        {
            _globalMaster = globalMaster;
        }

        //DROP DOWN

        [HttpGet]
        public async Task<IActionResult> GetPlanning_Padding_PI_Number()
        {
            var data = await _globalMaster.planingManager.GetPlanning_Padding_PI_Number();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetPlanning_Quilting_PI_Number()
        {
            var data = await _globalMaster.planingManager.GetPlanning_Quilting_PI_Number();
            return Ok(data);
        }
       
        //VIEW
        [HttpGet]
        public async Task<IActionResult> GetPlaning_Details_BeforeAdd(string Pi_Number, int Proc_ID, int ItemProc_ID)
        {
            var data = await _globalMaster.planingManager.GetPlaning_Details_BeforeAdd(Pi_Number,Proc_ID,ItemProc_ID);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetPlaning_Details_AfterAdd( int Proc_ID, string sessionUser)
        {
            var data = await _globalMaster.planingManager.GetPlaning_Details_AfterAdd( Proc_ID,sessionUser);
            return Ok(data);
        }

        // DashBorad Get
        [HttpGet]
        public async Task<IActionResult> GetPlanning_DashBorad()
        {
            var data= await _globalMaster.planingManager.GetPlanning_DashBorad();
            return Ok(data);
        }
        //ADD/SAVE


        [HttpPost]
        public async Task<IActionResult> PlaningSave(List<PlaningModel> PL)
        {
            var data = await _globalMaster.planingManager.PlaningSave(PL);

            return Ok(new { message = data });
        }

        [HttpPut]
        public async Task<IActionResult> PlaningComplete(List<PlaningModel> PL)
        {
            var data = await _globalMaster.planingManager.PlaningComplete(PL);

            return Ok(new { message = data });
        }

        [HttpDelete]
        public async Task<IActionResult> PL_Delete(List<PlaningModel> PL)
        {
            var data = await _globalMaster.planingManager.PL_Delete(PL);

            return Ok(new { message = data });
        }
    }
   
}
