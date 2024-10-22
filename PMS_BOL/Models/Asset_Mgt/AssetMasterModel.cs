using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BOL.Models.Asset_Mgt
{
    public class Asset_Master_Save
    {
        public int ComId { get; set; }
        public int Dept { get; set; }

        public int SectionId { get; set; }

        public int FloorId { get; set; }

        public int LineId { get; set; }

        public DateTime PurchaseDate { get; set; }
        public string AsstCateId { get; set; }

        public string AsstSpId { get; set; }

        public int AsstStatusId { get; set; }
        public string AsstNameId { get; set; }

        public string AsstNo { get; set; }

        public string SerialNo { get; set; }

        public string BrandID { get; set; }

        public string Model { get; set; }

        public string SupplierId { get; set; }

        public decimal AsstValue { get; set; }
        public string Curency { get; set; }

        public decimal DepValue { get; set; }

        public int DepPeriod { get; set; }

        public string BillNo { get; set; }
        public DateTime BillInputDate { get; set; }
        public string LCNo { get; set; }
        public DateTime LCDate { get; set; }

        public string ComInvoiceNo { get; set; }

        public DateTime ComInvoiceDate { get; set; }

        public DateTime WarrantyExpDate { get; set; }

        public int CurrenHolder { get; set; }

        public DateTime CommencingDate { get; set; }

        public DateTime InhouseDate { get; set; }

        public string Remarks { get; set; }
        public string UserName { get; set; }













    }
}
