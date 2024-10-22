using PMS_BOL.Functions;
using PMS_BOL.Models.Order_Mgt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BLL.Interfaces.Manager.OrderMgt
{
    public  interface IPaddingRawmaterialManager
    {
        //Drop Down

        public Task<DataTable> Get_mianCetegory();

        public Task<DataTable> Get_subCategory(int mainCateID);

        //View
        public Task<DataTable> GetPadding_raw_material_After_View(DateTime date, int paddingMachineId);
        public Task<DataTable> GetPadding_raw_material_After_View_Remarks(DateTime date, int paddingMachineId);


        public Task<DataTable>GetPadding_raw_meterial_Before_view(DateTime date, int paddingMachineId);



        //save 
        //public Task<Response> padding_raw_material_Save(RawmaterailSaveRequest rawmaterailSaveRequests);
        public Task<string> padding_raw_material_Save(RawmaterailSaveRequest rawmaterailSaveRequests);

        public Task<string> padding_raw_material_Delete(List<RawmaterialModel> RM);
       
    }
}
