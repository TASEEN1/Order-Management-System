using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BOL.Models
{
    public class CutMaster
    {
        public int StyleID { get; set; }
        public string PO { get; set; }
        public string POID { get; set; }
        public int CompanyID { get; set; }
        public int Year { get; set; }
        public string UserName { get; set; }
        //public DateTime CreateDate { get; set; }
        public int CutCompanyID { get; set; }

    }

    public class CuttingSave
    {
        public int cutNo { get; set; }
        public int cyear { get; set; }
        public decimal lay { get; set; }
        //public int crow { get; set; }
        public int fabriccolor { get; set; }
        public string? fabricshade { get; set; }
        public string? lot { get; set; }
        public int plies { get; set; }
        public int? qty { get; set; }
        public decimal? reallay { get; set; }
        public string UserName { get; set; }
        public int styleID { get; set; }
        public string pono { get; set; }
        public int companyID { get; set; }
        public int countryID { get; set; }
        public DateTime productiondate { get; set; }
        public string? remarks { get; set; }


    }

    public class CuttingLaySize
    {
        public int cutNo { get; set; }
        public int cyear { get; set; }
        public decimal lay { get; set; }
        public int crow { get; set; }
        public decimal reallay { get; set; }
        public DateTime productiondate { get; set; }
        public string UserName { get; set; }
        public int styleID { get; set; }
        public string lot { get; set; }
        public int countryID { get; set; }
        public string size { get; set; }
        public int sizeID { get; set; }
        public decimal ratio { get; set; }
        public string pono { get; set; }

    }
    public class CutForApprove
    {
        public int Style { get; set; }
        public int cutno { get; set; }
        public int layno { get; set; }
    }

    
}