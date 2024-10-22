using PMS_BLL.Interfaces.Manager;
using PMS_BLL.Interfaces.Manager.Asset_Master;
using PMS_BLL.Interfaces.Manager.AssetMaster;
using PMS_BLL.Interfaces.Manager.OrderMgt;

namespace PMS_BLL.Interfaces
{
    public interface IGlobalMaster
    {
        //Asset Managment System
        IUserLoginManager userLogin { get; }

        IAssetMasterManager assetmastermanager { get; }
        IRentAsset rent_Asset { get; }
        IRentedAssetReturnManager rentedAssetReturnManager { get; }
        IAssetTransferManager asset_TransferManager { get; }
        IAssetRunningRepair asset_Running_Repair { get; }
        Ischedule_Maintenance schedule_Maintenance { get; }
        IAssetReportManager asset_ReportManager { get; }


        //-------OMS
        IOrderManager orderManager { get; }
        IOrderReportManager orderReportManager { get; }
        IPIManager piManager { get; }
        IworkOrderManager workOrderManager { get; }
        IProductionManager  productionManager { get; }
        IPlaningManager planingManager { get; }
        IPaddingRawmaterialManager paddingRawmaterialManager { get; }
        IDeliveryChallanManager challanManager { get; }
        IDashboardManager dashboardManager { get; }



    }
}