using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BOL.Models.Asset_Mgt
{
    public class Rent_Asset_Model
    {

        public int CurrentHolder { get; set; }
        public int FloorID { get; set; }

        public int LineId { get; set; }
        public int ChallanNo { get; set; }

        public DateTime RentedDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public int AssetCate { get; set; }
        public int AssetSpFeature { get; set; }

        public int AssetStatus { get; set; }
        public string AssetName { get; set; }
        public string AssetNo { get; set; }

        public string SerialNo { get; set; }
        public int Brand { get; set; }

        public string Model { get; set; }

        public string Supplier { get; set; }

        public decimal AssetValue { get; set; }

        public int Currency { get; set; }

        public int TotalDays { get; set; }

        public string InputUser { get; set; }

















    }
}
