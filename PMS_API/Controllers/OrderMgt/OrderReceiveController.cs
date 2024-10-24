using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;
using PMS_BOL.Models.OrderMgt;

namespace PMS_API.Controllers.OrderMgt
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class OrderReceiveController : ControllerBase
    {
        private readonly IGlobalMaster _globalMaster;

        public OrderReceiveController(IGlobalMaster globalMaster)
        {
            _globalMaster = globalMaster;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentType()
        {
            var data = await _globalMaster.orderManager.GetPaymentType();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetColor()
        {
            var data = await _globalMaster.orderManager.GetColor();
            return Ok(data);
        }


        [HttpGet]
        public async Task<IActionResult> GetUnit()
        {
            var data = await _globalMaster.orderManager.GetUnit();
            return Ok(data);
        }


        [HttpGet]
        public async Task<IActionResult> GetItemName()
        {
            var data = await _globalMaster.orderManager.GetItemName();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> ItemNameGet()
        {
            var data = await _globalMaster.orderManager.ItemNameGet();
            return Ok(data);
        }



        [HttpGet]
        public async Task<IActionResult> GetBuyer()
        {
            var data = await _globalMaster.orderManager.GetBuyer();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomer()
        {
            var data = await _globalMaster.orderManager.GetCustomer();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetDia()
        {
            var data = await _globalMaster.orderManager.GetDia();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> Getgsm()
        {
            var data = await _globalMaster.orderManager.Getgsm();
            return Ok(data);
        }
       
        [HttpGet]
        public async Task<IActionResult> GetBuyerView()
        {
            var data = await _globalMaster.orderManager.GetBuyerView();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetcustomerView()
        {
            var data = await _globalMaster.orderManager.GetcustomerView();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetcolorView()
        {
            var data = await _globalMaster.orderManager.GetcolorView();
            return Ok(data);
        }

       

        [HttpGet]
        public async Task<IActionResult> GetDiaView()
        {
            var data = await _globalMaster.orderManager.GetDiaView();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetgsmView()
        {
            var data = await _globalMaster.orderManager.GetgsmView();
            return Ok(data);

        }
       

       

        [HttpGet]
        public async Task<IActionResult> GetCustomerEdit()
        {
            var data = await _globalMaster.orderManager.GetCustomerEdit();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> Getpayment_currency()
        {
            var data = await _globalMaster.orderManager.Getpayment_currency();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomerType()
        {
            var data = await _globalMaster.orderManager.GetCustomerType();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetOrderType()
        {
            var data = await _globalMaster.orderManager.GetOrderType();
            return Ok(data);
        }


        [HttpGet]
        public async Task<IActionResult> OrderReceivedAddView(string sessionUser)
        {
            var data = await _globalMaster.orderManager.OrderReceivedAddView(sessionUser);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetRefNoFromOrderReceiving(string username)
        {
            var data = await _globalMaster.orderManager.GetRefNoFromOrderReceiving(username);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetRefNoFromAddEditOrderReceiving(string username)
        {
            var data = await _globalMaster.orderManager.GetRefNoFromAddEditOrderReceiving(username);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderReceivedAddEditView( int Ref_no)
        {
            var data = await _globalMaster.orderManager.GetOrderReceivedAddEditView(Ref_no);
            return Ok(data);
        }


        [HttpPost]
        public async Task<IActionResult> ColorSave(List<ColorSave> app)
        {
            var data = await _globalMaster.orderManager.ColorSave(app);
            return Ok(new { message = data });

        }

        [HttpPost]
        public async Task<IActionResult> OrderReceivedAdd(List<OrderReceivingAdd> app)
        {
            var data = await _globalMaster.orderManager.OrderReceivedAdd(app);
            return Ok(new { message = data });

        }

        [HttpPut]
        public async Task<IActionResult> OrderReceivedComplete(List<OrderReciveComplete> app)
        {
            var data = await _globalMaster.orderManager.OrderReceivedComplete(app);
            return Ok(new { message = data });

        }

        [HttpPost]
        public async Task<IActionResult> ItemNameSave(List<ItemDescriptionSave> app)
        {
            var data = await _globalMaster.orderManager.ItemNameSave(app);
            return Ok(new { message = data });

        }

       
        [HttpPost]
        public async Task<IActionResult> BuyerSave(List<BuyerSave> app)
        {
            var data = await _globalMaster.orderManager.BuyerSave(app);
            return Ok(new { message = data });

        }

        [HttpPost]
        public async Task<IActionResult> CustomerSave(List<customerSave> app)
        {
            var data = await _globalMaster.orderManager.CustomerSave(app);
            return Ok(new { message = data });

        }

        [HttpPost]
        public async Task<IActionResult> DiaSave(List<diaSave> app)
        {
            var data = await _globalMaster.orderManager.DiaSave(app);
            return Ok(new { message = data });

        }
        [HttpPost]
        public async Task<IActionResult> GsmSave(List<gsmSave> app)
        {
            var data = await _globalMaster.orderManager.GsmSave(app);
            return Ok(new { message = data });

        }
       
        [HttpDelete]
        public async Task<IActionResult> OrderReceiveDelete(List<orderReceiveDelete> app)
        {
            var data = await _globalMaster.orderManager.OrderReceiveDelete(app);
            return Ok(new { message = data });

        }

        [HttpPut]
        public async Task<IActionResult> OrderReceiveEditUpdate(List<OrderReceivingAdd> app)
        {
            var data = await _globalMaster.orderManager.OrderReceiveEditUpdate(app);
            return Ok(new { message = data });

        }
       

        [HttpPut]
        public async Task<IActionResult> CustomerUpdate(List<customerSave> app)
        {
            var data = await _globalMaster.orderManager.CustomerUpdate(app);
            return Ok(new { message = data });

        }

      

        [HttpPut]
        public async Task<IActionResult> BuyerUpdate(List<BuyerSave> app)
        {
            var data = await _globalMaster.orderManager.BuyerUpdate(app);
            return Ok(new { message = data });

        }
        [HttpPost]
        public async Task<IActionResult> OrderReceiveEditAdd(List<OrderReceivingAdd> app)
        {
            var data = await _globalMaster.orderManager.OrderReceiveEditAdd(app);
            return Ok(new { message = data });

        }

        [HttpPut]
        public async Task<IActionResult> OrderReceiveAddOrderUpdate(List<OrderReceivingAdd> app)
        {
            var data = await _globalMaster.orderManager.OrderReceiveAddOrderUpdate(app);
            return Ok(new { message = data });

        }

        [HttpPut]
        public async Task<IActionResult> OrderReceiveAddEditComplete(List<OrderReciveComplete> app)
        {
            var data = await _globalMaster.orderManager.OrderReceiveAddEditComplete(app);
            return Ok(new { message = data });

        }



        //-----------------Report_GETAPI------------

        [HttpGet]
        public async Task<IActionResult> GetReport_Customer( string username)
        {
            var data = await _globalMaster.orderManager.GetReport_Customer(username);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetReport_RefNo(string username, int customerID)
        {
            var data = await _globalMaster.orderManager.GetReport_RefNo(username,customerID);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetReport_Style(string usernmae, int custID)
        {
            var data = await _globalMaster.orderManager.GetReport_Style(usernmae,custID);
            return Ok(data);
        }





        //----------------------OMS Customer------------------------//


        //[HttpPost]
        //public async Task<IActionResult> OMS_CustomerSave(List<customerSave> app)
        //{
        //    var data = await _globalMaster.orderManager.OMS_CustomerSave(app);
        //    return Ok(new { message = data });

        //}
        //[HttpPut]
        //public async Task<IActionResult> OMS_CustomerUpdate(List<customerSave> app)
        //{
        //    var data = await _globalMaster.orderManager.OMS_CustomerUpdate(app);
        //    return Ok(new { message = data });

        //}
        //[HttpGet]
        //public async Task<IActionResult> OMS_GetCustomerType()
        //{
        //    var data = await _globalMaster.orderManager.OMS_GetCustomerType();
        //    return Ok(data);
        //}
        //[HttpGet]
        //public async Task<IActionResult> OMS_GetcustomerView()
        //{
        //    var data = await _globalMaster.orderManager.OMS_GetcustomerView();
        //    return Ok(data);
        //}


    }
}
