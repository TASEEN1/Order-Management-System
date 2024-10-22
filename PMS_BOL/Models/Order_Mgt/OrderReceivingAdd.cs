using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BOL.Models.OrderMgt
{
    public class OrderReceivingAdd
    {
        public int ComID { get; set; }
        public int Id { get; set; }
        public int Ref_no { get; set; }

        public int Customer { get; set; }
        public int Buyer { get; set; }
        public string style_no { get; set; }
        public string Po_no { get; set; }
        public string Att_name { get; set; }
        public string Att_mobile_no { get; set; }
        public string Att_email { get; set; }
        public string Item_desc { get; set; }
        public int Item_color { get; set; }
        public int Design { get; set; }
        public int Dia { get; set; }
        public int Gsm { get; set; }
      
        public int proc_type { get; set; }

        public decimal Oder_qty { get; set; }
        public decimal Unit_price { get; set; }
        public int unit { get; set; }
        public decimal Total_price { get; set; }
        public int Payment_type { get; set; }
        public string Terms_condition { get; set; }
        public DateTime Ord_receive_date { get; set; }
        public DateTime Ord_delivery_date { get; set; }
        public string Hs_code { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public decimal or_order_net_weight { get; set; }
        public decimal or_order_gross_weight { get; set; }
        public int or_payment_currency { get; set; }
        public int item_Name {get;set;}
        public int or_proc_type_forItem { get; set; }
        public int custOrderType { get; set; }






    }

    public class ColorSave
    {
        public int ComID { get; set; }
        public string ColorName { get; set; }
        public string createdby { get; set; }
    }



    public class ItemDescriptionSave
    {
        public int ComID { get; set; }
        public string ItemName { get; set; }
        public string HSCode { get; set; }
        public string createdby { get; set; }
    }

    public class ProcessTypeSave
    {
        public int ComID { get; set; }
        public string processName { get; set; }
        public string createdby { get; set; }
    }

    public class BuyerSave
    {
        public int ComID { get; set; }
        public int BuyerID { get; set; }
        public string BuyerName { get; set; }
        public string AttPerson { get; set; }
        public string AttEmail { get; set; }
        public string Attmobile_No { get; set; }
        public string BuyerAddress { get; set; }
        public string createdby { get; set; }
        public string updatedby { get; set;}

    }

    public class customerSave
    {
        public int ComID { get; set; }
        public int customer_Type { get; set; }
        public int customerId { get; set; }
        public string Cus_Name { get; set; }
        public string AttPerson { get; set; }
        public string AttEmail { get; set; }
        public string Attmobile_No { get; set; }

        public string Cus_Address { get; set; }
        public string Cus_Terms_Condition { get; set; }
        public string createdby { get; set; }
        public string UpdatedBy { get; set; }
        public string c_tnc_offerValidity { get; set; }
        public string c_tnc_letterOfCredit { get; set; }
        public string c_tnc_advisingBank { get; set; }
        public string c_tnc_negoBankNPeriod { get; set; }
        public string c_tnc_delivery { get ; set; }

        public string c_tnc_deliveryTerms { get; set; }
        public string c_tnc_paymentNInterest { get; set; }
        public string c_tnc_bankCharges { get; set; }
        public string c_tnc_inspection { get; set; }
        public string c_tnc_BTMACertificate { get; set; }
        public string c_tnc_maturity { get; set; }
        public string c_tnc_payment { get; set; }
        public string c_tnc_cashIncentive { get; set; }
        public string c_tnc_BINandVAT { get; set; }
        public string c_tnc_HSCode { get; set; }
        public string c_tnc_concatedFromFE { get; set; }







    }

    public class diaSave
    {
        public int ComID { get; set; }
        public string DiaName { get; set; }
        public string createdby { get; set; }
    }

    public class gsmSave
    {
        public int ComID { get; set; }
        public string GsmName { get; set; }
        public string createdby { get; set; }
    }

    public class designSave

    {
        public int ComID { get; set; }
        public string designName { get; set; }
        public string createdby { get; set; }
    }

    public class orderReceiveDelete
    {
        public int  id { get; set; }
       
    }


}
