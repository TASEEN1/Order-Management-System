using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BOL.Models.Asset_Mgt
{
    public class AssetRunningRepairModel
    {
        public string assetno { get; set; }

        public DateTime nextservicedate { get; set; }

        public DateTime lastservicedate { get; set; }

        public DateTime repairdate { get; set; }

        public string repairdetails { get; set; }

        public string itemreplace { get; set; }

        public decimal faultreporttime { get; set; }

        public decimal downtime { get; set; }

        public decimal attendendtime { get; set; }

        public DateTime readydate { get; set; }

        public string doneby { get; set; }

        public string inputby { get; set; }














    }
}
