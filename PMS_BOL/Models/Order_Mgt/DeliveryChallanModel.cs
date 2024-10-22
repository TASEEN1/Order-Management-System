using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BOL.Models.Order_Mgt
{
    public class DeliveryChallanModel
    {
        public int Com_ID { get; set; }
        public int DC_ID { get; set; }
        public int DC_delivery_customer { get; set; }
        public int DC_or_ID { get; set; }
        public int DC_or_ref_NO { get; set; }
        public int DC_Proc { get; set; }
        public int DC_item_Proc { get; set; }
        public string DC_Pi_Number { get; set; }
        public int DC_challan_ref_NO { get; set; }
        public decimal DC_item_Qty { get; set; }
        public int DC_item_roll { get; set; }
        public DateTime DC_dalivery_Date { get; set; }
        public string DC_Attention_Person { get; set; }
        public string DC_Attention_Person_MobNO { get; set; }
        public string DC_delivery_address { get; set; }
        public string DC_carrier_name { get; set; }
        public string DC_carrier_MobNO { get; set; }
        public string DC_vehiNO { get; set; }
        public string DC_driver_name { get; set; }
        public string DC_driver_MobNo { get; set; }
        public string DC_driver_lisc { get; set; }
        public string DC_created_by { get; set; }
        public DateTime DC_Created_Date { get; set; }
        public string sessionUser { get; set; }
        public int  custParam { get; set; }
        public int Challan_ID { get; set; }




    }

    public class Challan_Approval
    {
        public int DC_challan_ref_NO { get; set; }
        public string DC_Approved_user { get; set; }
        public int DC_Approvedby_com_ID { get; set; }
        public string DC_checkdby_user { get; set; }
        public int DC_checkedby_com_ID { get; set; }

    }

    public class Challan_cancel
    {
        public int DC_challan_ref_NO { get; set; }
        public string DC_Cancelby_user { get; set; }
        public int DC_cancelby_com_ID { get; set; }




    }
}
