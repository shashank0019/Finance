using Microsoft.AspNetCore.Mvc;
using Finance.BusinessLogic;
using Finance.Models;
using Microsoft.Extensions.Configuration;

namespace Finance.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinanceController : ControllerBase
    {
        private readonly FinanceBusinessLogic _logic;

        public FinanceController(IConfiguration configuration)
        {
            _logic = new FinanceBusinessLogic(configuration);
        }

        [HttpGet("GetEmployeeDetails/{FCTID}")]
        public IActionResult GetEmployeeDetails(int FCTID)
        {
            var result = _logic.GetEmployeeDetails(FCTID);
            return Ok(result);
        }

        [HttpPost("UpdateEmployeeDetails")]
        public IActionResult UpdateEmployeeDetails([FromBody] UpdateEmpDetailsRequest request)
        {
            _logic.UpdateEmployeeDetails(request);
            return Ok("Employee details updated successfully.");
        }

        [HttpPost("InsertAttachment")]
        public IActionResult InsertAttachment([FromBody] InsertAttachmentRequest request)
        {
            _logic.AddAttachment(request);
            return Ok("Attachment inserted successfully.");
        }

        [HttpGet("GetAllAttachment/{FCTID}")]
        public IActionResult GetAllAttachment(int FCTID)
        {
            var result = _logic.GetAllAttachments(FCTID);
            return Ok(result);
        }

        [HttpDelete("DeleteAttachment/{FileIndexID}")]
        public IActionResult DeleteAttachment(int FileIndexID)
        {
            _logic.DeleteAttachment(FileIndexID);
            return Ok("Attachment deleted successfully.");
        }
    }
}
