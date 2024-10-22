using PMS_BOL.Models.OrderMgt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PMS_BOL.Models.OrderMgt.PI_Model;

namespace PMS_BLL.Interfaces.Manager.OrderMgt
{
    public interface IPIManager
    {
        public Task<string> GeneratePIAdd(List<PI_Model>app);
        public Task<string> GeneratePI(List<PI_Model> app);
        public Task<DataTable> GetPI_ProcessType();
        public Task<DataTable> GetGeneratePIAddView( string created_By);
        public Task<string> PIDelete(List<PI_Model>app);
        public Task<DataTable> GetPIAddView( int Ref_no);
        public Task<DataTable> GetPiApproval_checkedBy_View(string Created_by);
        public Task<DataTable> GetPiApproval_approvedBy_view(string Created_by);
        public Task<DataTable> GetPiApproval_revise_view(string Created_by);
        public Task<string> PIRevise(List<PI_Model> app);
        public Task<DataTable> GetPiApproval_ForApprovalView(string Created_by);
        public Task<string> ApprovedByApprove(List<PI_Model>app);
        public Task<string> CheckedByApprove(List<PI_Model>app);
        public Task<DataTable> GetPI_Number();
        public Task<DataTable> GetBookingRefForPiGenerate( int CustomerID);
        public Task<DataTable> GetPI_CustomerTermsAndCondition(int Ref_No);



        // REVISED PI 

        public Task<DataTable> GetRevised_PI_Number();
        public Task<DataTable> GetRevised_Version(string PINumber);
        public Task<DataTable> GetRevised_Before_View(string PINumber);
        public Task<DataTable> GetRevised_CustomerPaymentAndProcessData(string PINumber);

        public Task<string> Generate_RevisedPI(List<PIRevisedModel> app);
        














    }




}
