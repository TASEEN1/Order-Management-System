using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BOL.Models.Order_Mgt
{
    public class ProductionModel
    {
        public int ComID { get; set; }
        public int prod_or_ID { get; set; }
        public int prod_Hour { get; set; }
        public int prod_or_ref_no { get; set; }

        public int prod_process_id { get; set; }
        public int prod_shift_id { get; set; }
        public DateTime ProductionDate { get; set; }
        public int MachineID { get; set; }
        public string Superviser_Name { get; set; }
        public string Superviser_ID { get; set; }
        public decimal? prod_today_production { get; set; }
        public string createdby { get; set; }
        public int prod_ID { get; set; }
        public string SessionUser { get; set; }
        public string PI_Number { get; set; }

 



       


    }

    public class MachineDetails
    { 
        public int ComID { get; set; }
        public int machine_Type { get; set; }
        public string machine_decs { get; set; }
        public string machine_No { get; set; }
        public int machine_capacity { get; set; }
        public string Created_by { get; set;}


    }

    public class  ShiftDetails
    {
        public int ComID { get; set; }
        public string shiftName { get; set; }
        public DateTime shiftstartTime { get; set; }
        public DateTime shiftendTime { get; set;}
        public string Created_by { get; set; }

    }
}
