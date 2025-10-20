using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Finance.Models;
using Microsoft.Extensions.Configuration;

namespace Finance.DataAccess
{
    public class FinanceDataAccess
    {
        private readonly string _connectionString;

        public FinanceDataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // 1️⃣ Get Employee Details
        public GetEmployeeDetailsModel GetEmployeeDetailsByMasterID(long masterId)
        {
            GetEmployeeDetailsModel details = new();
            using (SqlConnection con = new(_connectionString))
            using (SqlCommand cmd = new("FinanceComplianceTracker_GetEmployeeDetailsByMasterID", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MasterID", masterId);

                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        details.MasterID = masterId;
                        details.ModifyDueDate = reader["ModifyDueDate"] as DateTime?;
                        details.CompletionDate = reader["CompletionDate"] as DateTime?;
                        details.ApprovalDate = reader["ApprovalDate"] as DateTime?;
                        details.IsDelay = reader["IsDelay"] as bool?;
                        details.ReasonForDelay = reader["ReasonForDelay"].ToString();
                        details.Penalty = reader["Penalty"].ToString();
                        details.Remarks = reader["Remarks"].ToString();
                        details.Status = reader["Status"].ToString();
                    }
                }
            }
            return details;
        }

        // 2️⃣ Update Employee Details
        public bool UpdateEmployeeDetails(UpdateEmployeeDetailsModel model)
        {
            using (SqlConnection con = new(_connectionString))
            using (SqlCommand cmd = new("FinanceComplianceTracker_UpdateEmpDetails", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MasterID", model.MasterID);
                cmd.Parameters.AddWithValue("@ModifyDueDate", (object?)model.ModifyDueDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CompletionDate", (object?)model.CompletionDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ApprovalDate", (object?)model.ApprovalDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IsDelay", (object?)model.IsDelay ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ReasonForDelay", model.ReasonForDelay ?? "");
                cmd.Parameters.AddWithValue("@Penalty", model.Penalty ?? "");
                cmd.Parameters.AddWithValue("@Remarks", model.Remarks ?? "");
                cmd.Parameters.AddWithValue("@EmpCode", model.EmpCode ?? "");

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 3️⃣ Insert Attachment
        public bool InsertAttachment(InsertAttachmentModel model)
        {
            using (SqlConnection con = new(_connectionString))
            using (SqlCommand cmd = new("FinanceComplianceTracker_InsertAttachment", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MasterID", model.MasterID);
                cmd.Parameters.AddWithValue("@DocumentName", model.DocumentName);
                cmd.Parameters.AddWithValue("@DocumentPath", model.DocumentPath);
                cmd.Parameters.AddWithValue("@FileIndexID", model.FileIndexID);
                cmd.Parameters.AddWithValue("@UploadedBy", model.UploadedBy);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 4️⃣ Get All Attachments
        public List<GetAllAttachmentsModel> GetAllAttachments(long masterId)
        {
            List<GetAllAttachmentsModel> list = new();
            using (SqlConnection con = new(_connectionString))
            using (SqlCommand cmd = new("FinanceComplianceTracker_GetAllAttachment", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MasterID", masterId);

                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new GetAllAttachmentsModel
                        {
                            FileIndexID = (Guid)reader["FileIndexID"],
                            MasterID = (long)reader["MasterID"],
                            DocumentName = reader["DocumentName"].ToString(),
                            DocumentPath = reader["DocumentPath"].ToString(),
                            UploadedBy = reader["UploadedBy"].ToString(),
                            UploadedOn = Convert.ToDateTime(reader["UploadedOn"])
                        });
                    }
                }
            }
            return list;
        }

        // 5️⃣ Delete Attachment
        public bool DeleteAttachmentByFileIndexID(Guid fileIndexId)
        {
            using (SqlConnection con = new(_connectionString))
            using (SqlCommand cmd = new("FinanceComplianceTracker_DeleteAttachmentByFileIndexID", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FileIndexID", fileIndexId);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
