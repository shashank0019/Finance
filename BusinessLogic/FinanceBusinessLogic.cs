using System;
using System.Collections.Generic;
using Finance.DataAccess;
using Finance.Models;

namespace Finance.BusinessLogic
{
    public class FinanceBusinessLogic
    {
        private readonly FinanceDataAccess _dataAccess;

        public FinanceBusinessLogic(FinanceDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public GetEmployeeDetailsModel GetEmployeeDetails(long masterId)
        {
            return _dataAccess.GetEmployeeDetailsByMasterID(masterId);
        }

        public bool UpdateEmployeeDetails(UpdateEmployeeDetailsModel model)
        {
            return _dataAccess.UpdateEmployeeDetails(model);
        }

        public bool InsertAttachment(InsertAttachmentModel model)
        {
            return _dataAccess.InsertAttachment(model);
        }

        public List<GetAllAttachmentsModel> GetAllAttachments(long masterId)
        {
            return _dataAccess.GetAllAttachments(masterId);
        }

        public bool DeleteAttachment(Guid fileIndexId)
        {
            return _dataAccess.DeleteAttachmentByFileIndexID(fileIndexId);
        }
    }
}
