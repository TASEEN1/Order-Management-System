using PMS_BOL.Functions;
using PMS_BOL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BLL.Interfaces.Manager.AssetMaster
{
    public interface Ischedule_Maintenance
    {

        Task<DataTable> GetAssetNo();
        Task<DataTable> GetAsset_Master_List(string AsstNo);



        Task<string> ScheduleMaintenanceSave(MaintenanceSaveRequest maintenanceSaveRequest);

        //Task<string> SM_service_Typesave(List<SMServiceTypeSave_Model> smServiceTypeSaveModels);

        Task<DataTable> GetServiceDescription();

    }
}