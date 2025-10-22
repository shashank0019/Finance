using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Finance.Models;

namespace Finance.DataAccess
{
    public class FinanceDataAccess
    {
        private readonly string _connectionString;

        public FinanceDataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public DataTable GetEmployeeDetailsByMasterID(int FCTID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("FinanceComplianceTracker_GetEmployeeDetailsByMasterID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FCTID", FCTID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void UpdateEmpDetails(UpdateEmpDetailsRequest req)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("FinanceComplianceTracker_UpdateEmpDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FCTID", req.FCTID);
                cmd.Parameters.AddWithValue("@UpdatedDueDate", req.UpdatedDueDate);
                cmd.Parameters.AddWithValue("@CompletionDate", req.CompletionDate);
                cmd.Parameters.AddWithValue("@ApprovalDate", req.ApprovalDate);
                cmd.Parameters.AddWithValue("@AnyDelay", req.AnyDelay);
                cmd.Parameters.AddWithValue("@DelayReason", req.DelayReason);
                cmd.Parameters.AddWithValue("@LateFessPenaltyInterest", req.LateFessPenaltyInterest);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void InsertAttachment(InsertAttachmentRequest req)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("FinanceComplianceTracker_InsertAttachment", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FCTID", req.FCTID);
                cmd.Parameters.AddWithValue("@FileIndexID", req.FileIndexID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetAllAttachment(int FCTID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("FinanceComplianceTracker_GetAllAttachment", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FCTID", FCTID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void DeleteAttachmentByFileIndexID(int FileIndexID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("FinanceComplianceTracker_DeleteAttachmentByFileIndexID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FileIndexID", FileIndexID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
