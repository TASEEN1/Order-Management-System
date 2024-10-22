using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BOL.Functions
{
    public class ReportFileExt
    {
        public string GetContentType(string reportType)
        {
            switch (reportType.ToUpper())
            {
                case "PDF":
                    return "rpt.pdf";
                case "EXCEL":
                    return "rpt.xls";
                case "WORD":
                    return "rpt.doc";
                default:
                    throw new ArgumentException("Unsupported report type");
            }
        }
    }
}
