using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BOL.Models
{
    public class StyleMasterModel
    {

        public string StyleNo { get; set; }

        public string DispStyleNo { get; set; }
		public int GmtType { get; set; }

		public int TotOrdQty { get; set; }

		public int OrdType { get; set; }

		public int TNA { get; set; }

		public int BuyerID { get; set; }

		public string UserName { get; set; }

		public string Season { get; set; }
		public int BrandID { get; set; }
		public int StoreID{ get; set; }
		public int DeptID { get; set; }
		public string StyleType { get; set; }
		public DateTime OrgRcvd { get; set; }
		public DateTime ConRcvd { get; set; }
		public string Fectory { get; set; }

		public decimal Fob { get; set; }
		public DateTime Bpcd { get; set; }
		public string  ConfromStatus {get; set;}
		public string FOBMode { get; set;}
		public int CurrencyID { get; set;}

		public int SeasonID { get; set;}




















    }






 
}
