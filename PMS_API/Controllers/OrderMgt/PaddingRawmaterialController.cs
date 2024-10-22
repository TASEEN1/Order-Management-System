using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;
using PMS_BOL.Functions;
using PMS_BOL.Models.Order_Mgt;
using PMS_BOL.Models.OrderMgt;

namespace PMS_API.Controllers.OrderMgt
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PaddingRawmaterialController : ControllerBase
    {
        private readonly IGlobalMaster _globalMaster;

        public PaddingRawmaterialController(IGlobalMaster globalMaster)
        {
            _globalMaster = globalMaster;
        }

        //Drop Down

        [HttpGet]
        public async Task<IActionResult> Get_mianCetegory()
        {
            var data = await _globalMaster.paddingRawmaterialManager.Get_mianCetegory();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> Get_subCategory(int mainCateID)
        {
            var data = await _globalMaster.paddingRawmaterialManager.Get_subCategory(mainCateID);
            return Ok(data);
        }

        // view

        [HttpGet]
        public async Task<IActionResult> GetPadding_raw_material_After_View(DateTime date, int paddingMachineId)
        {
            var data = await _globalMaster.paddingRawmaterialManager.GetPadding_raw_material_After_View(date, paddingMachineId);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetPadding_raw_material_After_View_Remarks(DateTime date, int paddingMachineId)
        {
            var data = await _globalMaster.paddingRawmaterialManager.GetPadding_raw_material_After_View_Remarks(date, paddingMachineId);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetPadding_raw_meterial_Before_view(DateTime date,int paddingMachineId)
        {
            var data = await _globalMaster.paddingRawmaterialManager.GetPadding_raw_meterial_Before_view(date, paddingMachineId);
            return Ok(data);
        }


        // save
        //[HttpPost]
        //public async Task<IActionResult> padding_raw_material_Save(RawmaterailSaveRequest rawmaterailSaveRequests)
        //{
        //    var data = await _globalMaster.paddingRawmaterialManager.padding_raw_material_Save(rawmaterailSaveRequests);
        //    return Ok(data);

        //}
        [HttpPost]
        public async Task<IActionResult> padding_raw_material_Save(RawmaterailSaveRequest rawmaterailSaveRequests)
        {
            var data = await _globalMaster.paddingRawmaterialManager.padding_raw_material_Save(rawmaterailSaveRequests);
            return Ok(new { message = data });

        }





        [HttpDelete]
        public async Task<IActionResult> padding_raw_material_Delete(List<RawmaterialModel> RM)
        {
            var data = await _globalMaster.paddingRawmaterialManager.padding_raw_material_Delete(RM);
            return Ok(new { message = data });

        }

    }
}
