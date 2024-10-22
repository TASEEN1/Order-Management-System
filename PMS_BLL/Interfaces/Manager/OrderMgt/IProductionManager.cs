using PMS_BOL.Models.Order_Mgt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BLL.Interfaces.Manager.OrderMgt
{
    public interface IProductionManager
    {
        //Dropdown
        public Task<DataTable> GetmachineNo( int Production_ProcID);

        public Task<DataTable> GetShift();
      
        public Task<DataTable> GetProduction_Padding_PI_Number();

        public Task<DataTable> GetProduction_Quilting_PI_Number();

        public Task<DataTable>GetProductionQuilting_ProcessType (int Ordr_refNO , int Process_ID);
        public Task<DataTable> GetProduction_ProcessType();
        public Task<DataTable> GetProduction_Hour();


        //GET Report DROP DOWN
        public Task<DataTable> Get_ReportProduction_ProcessType();





        //GET
        public Task<DataTable> GetPadding_ProductionItemBeforeAdd(string Pi_Number);
        public Task<DataTable> GetProductionAfterAdd( int ProcessID, string SessionUser);
       
        public Task<DataTable> GetQuilting_ProductionItemBeforeAdd(string PINumber, int ProType);





        //Modal
        public Task<DataTable> GetmachineView();
        public Task<DataTable> GetShiftview();
        public Task<string> MachineDetailsSave(List<MachineDetails>MC);
        public Task<string> shiftSave(List<ShiftDetails>SF);
        public Task<DataTable> GetMechinType();

        //Main Page
        public Task<string> ProductionSave (List<ProductionModel> PD);
        public Task<string> ProductionDelete(List<ProductionModel> PD);
        public Task<string> productionComplete(List<ProductionModel> PD);
       

    }
}
