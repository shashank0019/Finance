using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Finance.BusinessLogic;
using Finance.Models;

namespace Finance.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinanceControllers : ControllerBase
    {
        private readonly FinanceBusinessLogic _business;

        public FinanceControllers(FinanceBusinessLogic business)
        {
            _business = business;
        }

        [HttpGet("GetEmployeeDetails/{masterId}")]
        public IActionResult GetEmployeeDetails(long masterId)
        {
            var data = _business.GetEmployeeDetails(masterId);
            return Ok(data);
        }

        [HttpPost("UpdateEmployeeDetails")]
        public IActionResult UpdateEmployeeDetails([FromBody] UpdateEmployeeDetailsModel model)
        {
            var result = _business.UpdateEmployeeDetails(model);
            return Ok(result ? "Updated Successfully" : "Update Failed");
        }

        [HttpPost("InsertAttachment")]
        public IActionResult InsertAttachment([FromBody] InsertAttachmentModel model)
        {
            var result = _business.InsertAttachment(model);
            return Ok(result ? "Attachment Inserted" : "Failed");
        }

        [HttpGet("GetAllAttachments/{masterId}")]
        public IActionResult GetAllAttachments(long masterId)
        {
            var data = _business.GetAllAttachments(masterId);
            return Ok(data);
        }

        [HttpDelete("DeleteAttachment/{fileIndexId}")]
        public IActionResult DeleteAttachment(Guid fileIndexId)
        {
            var result = _business.DeleteAttachment(fileIndexId);
            return Ok(result ? "Deleted Successfully" : "Delete Failed");
        }
    }
}
