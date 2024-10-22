using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BOL.Models.OrderMgt
{
    public class PI_Model
    {
        public int ComID { get; set; }
        public int Pi_id { get; set; }
    
        public int or_id { get; set; }
        public int pi_or_id { get; set; }
        public string Po_No { get; set; }
        public string Style_No { get; set;}

        public int Ref_no { get; set; }
        public string Created_by { get; set; }
        public string pi_checkedBy_user { get; set; }
        public string pi_approvedBy_user { get; set; }
        public string or_cust_terms_cond { get; set; }
        public int pi_payment_type { get; set; }

        public int pi_proc_type { get; set; }
        public int pi_or_ref_no { get; set; }
        public string rpi_revised_by { get; set; }
        public string pi_Updated_by { get; set; }

        //public DateTime pi_checkedBy_date { get; set; }
        //public DateTime pi_approvedBy_date { get; set; }


        public class PIRevisedModel
        {
            public int comID { get; set; }
            public string PI_Number { get; set; }
            public int ProcessType { get; set; }
            public int paymentType { get; set; }
            public string Terms_cond { get; set; }
            public string Created_by { get; set; }


        }



    }
}
