using Finance.DataAccess;
using Finance.Models;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace Finance.BusinessLogic
{
    public class FinanceBusinessLogic
    {
        private readonly FinanceDataAccess _dataAccess;

        public FinanceBusinessLogic(IConfiguration configuration)
        {
            _dataAccess = new FinanceDataAccess(configuration);
        }

        public DataTable GetEmployeeDetails(int FCTID)
        {
            return _dataAccess.GetEmployeeDetailsByMasterID(FCTID);
        }

        public void UpdateEmployeeDetails(UpdateEmpDetailsRequest request)
        {
            _dataAccess.UpdateEmpDetails(request);
        }

        public void AddAttachment(InsertAttachmentRequest request)
        {
            _dataAccess.InsertAttachment(request);
        }

        public DataTable GetAllAttachments(int FCTID)
        {
            return _dataAccess.GetAllAttachment(FCTID);
        }

        public void DeleteAttachment(int FileIndexID)
        {
            _dataAccess.DeleteAttachmentByFileIndexID(FileIndexID);
        }
    }
}
