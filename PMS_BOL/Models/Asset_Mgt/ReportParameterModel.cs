using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BOL.Models.Asset_Mgt
{
    public class ReportParameterModel
    {
        public int ComFrom { get; set; }
        public int ComTo { get; set; }
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }
        public int Floor { get; set; }
        public int Line { get; set; }
        public int Status { get; set; }

        public string Supplire { get; set; }

        public int AssetCategory { get; set; }




    }
}
