using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Sample_project_for_ClosedXML.DTO.Requests;
using Sample_project_for_ClosedXML.Service.DownloadService;
using Sample_project_for_ClosedXML.Service.RegistrationService;
using System.IO;

namespace Sample_project_for_ClosedXML.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DownloadController : BaseController
    {
        private readonly IExcelDownloader _excelDownloader;

        public DownloadController(IExcelDownloader excelDownloader)
        {
            _excelDownloader = excelDownloader;
        }

        [HttpPost("Excel/ParticipantCount")]
        public IActionResult ExcelParticipantCount(RequestGetParticipantCount request)
        {


            var result = _excelDownloader.DownloadParticipantCount(request);

            var content = result.ToArray();

            // Set the content type and file name
            HttpContext.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string value = "attachment; filename=" + request.EventName.ToString() + ".xlsx";
            HttpContext.Response.Headers.Add("Content-Disposition", value);

            // Return the Excel file as a stream
            return new FileContentResult(content, HttpContext.Response.ContentType);
        }

        [HttpPost("Excel/ParticipantCountbyCategory")]
        public IActionResult ExcelParticipantCountbyCategory(RequestGetParticipantCountByCategory request)
        {


            var result = _excelDownloader.DownloadParticipantCountByCategory(request);

            var content = result.ToArray();

            // Set the content type and file name
            HttpContext.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string value = "attachment; filename=" + request.EventName.ToString() + ".xlsx";
            HttpContext.Response.Headers.Add("Content-Disposition", value);

            // Return the Excel file as a stream
            return new FileContentResult(content, HttpContext.Response.ContentType);
        }
    }
}
