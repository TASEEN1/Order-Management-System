using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BOL.Models.Order_Mgt
{
    public class PlaningModel
    {
        public int PL_ID { get; set; }
        public int Com_ID { get; set; }
        public int or_ID { get; set; }
        public int or_ref_no { get; set; }
        public string Pi_Number { get; set; }
        public int Proc_ID { get; set; }
        public string Proc_Name { get; set; }
        public DateTime PlanDate { get; set; }
        public  int MC_ID { get;set; }
        public decimal Today_Plan { get; set; }
        public string Created_By { get; set; }
        public int Process_ID { get; set; }
        public string SessionUser { get; set; }
        public DateTime proc_Delivery_date { get; set; }



    }
}
