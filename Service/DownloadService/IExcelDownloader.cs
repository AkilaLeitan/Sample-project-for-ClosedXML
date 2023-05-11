using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Sample_project_for_ClosedXML.DTO.Requests;

namespace Sample_project_for_ClosedXML.Service.DownloadService
{
    public interface IExcelDownloader
    {
        public MemoryStream DownloadParticipantCount(RequestGetParticipantCount request);
        public MemoryStream DownloadParticipantCountByCategory(RequestGetParticipantCountByCategory request);
    }
}
