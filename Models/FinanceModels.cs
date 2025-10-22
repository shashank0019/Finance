namespace Finance.Models
{
    // Model for FinanceComplianceTracker_GetEmployeeDetailsByMasterID
    public class FinanceEmployeeDetails
    {
        public int FCTID { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public DateTime ApprovalDate { get; set; }
        public bool AnyDelay { get; set; }
        public string DelayReason { get; set; }
        public string LateFessPenaltyInterest { get; set; }
    }

    // Model for FinanceComplianceTracker_UpdateEmpDetails
    public class UpdateEmpDetailsRequest
    {
        public int FCTID { get; set; }
        public DateTime UpdatedDueDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public DateTime ApprovalDate { get; set; }
        public bool AnyDelay { get; set; }
        public string DelayReason { get; set; }
        public string LateFessPenaltyInterest { get; set; }
    }

    // Model for FinanceComplianceTracker_InsertAttachment
    public class InsertAttachmentRequest
    {
        public int FCTID { get; set; }
        public int FileIndexID { get; set; }
    }

    // Model for FinanceComplianceTracker_GetAllAttachment
    public class AttachmentDetails
    {
        public int FileIndexID { get; set; }
        public int FCTID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadedDate { get; set; }
    }

    // Model for FinanceComplianceTracker_DeleteAttachmentByFileIndexID
    public class DeleteAttachmentRequest
    {
        public int FileIndexID { get; set; }
    }
}
