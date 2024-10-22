using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BOL.Models.OrderMgt
{
    public class OrderReciveComplete
    {
       
        public int Customer { get; set; }
        public string or_created_by { get; set; }
        public int Ref_No { get; set; }
        public int Buyer { get; set; }
        public string Style_no { get; set; }
        public string Remarks { get; set; }

    }
}
