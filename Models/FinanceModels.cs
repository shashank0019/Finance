using System;

namespace Finance.Models
{
    // =====================================================
    // Model for FinanceComplianceTracker_GetEmployeeDetailsByMasterID
    // =====================================================
    public class GetEmployeeDetailsModel
    {
        public long MasterID { get; set; }
        public DateTime? ModifyDueDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public bool? IsDelay { get; set; }
        public string? ReasonForDelay { get; set; }
        public string? Penalty { get; set; }
        public string? Remarks { get; set; }
        public string? Status { get; set; }
    }

    // =====================================================
    // Model for FinanceComplianceTracker_UpdateEmpDetails
    // =====================================================
    public class UpdateEmployeeDetailsModel
    {
        public long MasterID { get; set; }
        public DateTime? ModifyDueDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public bool? IsDelay { get; set; }
        public string? ReasonForDelay { get; set; }
        public string? Penalty { get; set; }
        public string? Remarks { get; set; }
        public string? EmpCode { get; set; }
    }

    // =====================================================
    // Model for FinanceComplianceTracker_InsertAttachment
    // =====================================================
    public class InsertAttachmentModel
    {
        public long MasterID { get; set; }
        public string DocumentName { get; set; } = string.Empty;
        public string DocumentPath { get; set; } = string.Empty;
        public Guid FileIndexID { get; set; }
        public string UploadedBy { get; set; } = string.Empty;
    }

    // =====================================================
    // Model for FinanceComplianceTracker_GetAllAttachment
    // =====================================================
    public class GetAllAttachmentsModel
    {
        public Guid FileIndexID { get; set; }
        public long MasterID { get; set; }
        public string DocumentName { get; set; } = string.Empty;
        public string DocumentPath { get; set; } = string.Empty;
        public string UploadedBy { get; set; } = string.Empty;
        public DateTime UploadedOn { get; set; }
    }

    // =====================================================
    // Model for FinanceComplianceTracker_DeleteAttachmentByFileIndexID
    // =====================================================
    public class DeleteAttachmentModel
    {
        public Guid FileIndexID { get; set; }
    }
}
