using PMS_BOL.Models.Order_Mgt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BLL.Interfaces.Manager.OrderMgt
{
    public interface IDeliveryChallanManager
    {

        //Common 
        //GetDelivery_Challan_PINumber(customer wise)
        public Task<DataTable> GetDelivery_Challan_PINumber( string? PI_Number , int custParamForPI, int pageProcId,int itemProcId);



        //-------Padding------//

        //Drop Down

        public Task<DataTable> GetPadding_Challan_ProcessType();


        //View
        public Task<DataTable> GetDelivery_Challan_Before_View(string PI_Number, int custParamForPI, int pageProcId, int itemProcId);
        public Task<DataTable> GetDelivery_Challan_After_View( int challanProcId, string sessionUser);




        //Save 
        public Task<Response> PaddingAndQuilting_Delivery_Challan_Save(List<DeliveryChallanModel>DV); 
        public Task<string> PaddingAndQuilting_Delivery_Challan_Complete(List<DeliveryChallanModel>DV);
        public Task<string> PaddingQuilting_Delivery_Challan_Delete(List<DeliveryChallanModel>DV);



        //report
        public Task<DataTable> Get_Challan();



        //Challan Approval
        public Task<string> PaddingQuilting_Delivery_challan_Approved_By_Approved(List<Challan_Approval>AP);
        public Task<string> PaddingQuilting_Delivery_challan_Checked_By_Approved(List<Challan_Approval> AP);
        public Task<DataTable>GetPaddingQuilting_Delivery_challan_Approval_By_Approved_View( string sessionUser);
        public Task<DataTable> GetPaddingQuilting_Delivery_challan_for_Approval_By_Approved_View(string sessionUser);
        public Task<DataTable> GetPaddingQuilting_Delivery_challan_cancel_View(string sessionUser);


        public Task<DataTable>GetPaddingQuilting_Delivery_challan_Checked_By_Approved_View(string sessionUser);
        public Task<string>PaddingQuilting_Delivery_challan_Cancel(List<Challan_cancel> AP);














    }
}
