using Azure;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Sample_project_for_ClosedXML.DTO.Requests;
using Sample_project_for_ClosedXML.Service.RegistrationService;
using System.IO;

namespace Sample_project_for_ClosedXML.Service.DownloadService
{
    public class ExcelDownloader : IExcelDownloader
    {
        public readonly IRegistrationService _registrationService;

        public ExcelDownloader(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        public MemoryStream DownloadParticipantCount(RequestGetParticipantCount request)
        {
            using (XLWorkbook workbook = new XLWorkbook())
            {
                var workSheet = workbook.Worksheets.Add(request.EventName.ToString());
                var currentRow = 1;

                #region Header
                workSheet.Cell(currentRow, 1).Value = "Registered Date";
                workSheet.Cell(currentRow, 2).Value = "No. of Participants";

                foreach (var cell in workSheet.Row(currentRow).Cells())
                {
                    cell.Style.Font.SetBold();
                }
                #endregion

                #region Body

                //get Data
                var dataList = _registrationService.GetParticipantCount(request);

                foreach (var recode in dataList)
                {
                    currentRow++;
                    workSheet.Cell(currentRow, 1).Value = recode.Date.ToString();
                    workSheet.Cell(currentRow, 2).Value = recode.ParticipantCount;
                }
                #endregion

                #region Add sum function
                workSheet.Cell(currentRow + 1, 1).Value = "Total Participants";
                workSheet.Cell(currentRow + 1, 2).FormulaA1 = $"SUM(B2:B{currentRow})";
                foreach (var cell in workSheet.Row(currentRow + 1).Cells())
                {
                    cell.Style.Font.SetBold();
                    cell.Style.Font.FontColor = XLColor.Red;
                }
                #endregion

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);

                    return stream;
                }
            }
        }

        public MemoryStream DownloadParticipantCountByCategory(RequestGetParticipantCountByCategory request)
        {
            using (XLWorkbook workbook = new XLWorkbook())
            {
                var workSheet = workbook.Worksheets.Add(request.EventName.ToString());
                var currentRow = 1;

                #region Header
                workSheet.Cell(currentRow, 1).Value = "Event Name";
                workSheet.Cell(currentRow, 2).Value = request.EventName.ToString();
                foreach (var cell in workSheet.Row(currentRow).Cells())
                {
                    cell.Style.Font.SetBold();
                }
                currentRow++;
                workSheet.Cell(currentRow, 1).Value = "Category Name";
                workSheet.Cell(currentRow, 2).Value = "No. of Participants";
                foreach (var cell in workSheet.Row(currentRow).Cells())
                {
                    cell.Style.Font.SetBold();
                }
                #endregion

                #region Body

                //get Data
                var dataList = _registrationService.GetParticipantCountByCategory(request);

                foreach (var recode in dataList)
                {
                    currentRow++;
                    workSheet.Cell(currentRow, 1).Value = recode.CategoryName.ToString();
                    workSheet.Cell(currentRow, 2).Value = recode.ParticipantCount;
                }
                #endregion

                #region Add sum function
                workSheet.Cell(currentRow + 1, 1).Value = "Total Participants";
                workSheet.Cell(currentRow + 1, 2).FormulaA1 = $"SUM(B3:B{currentRow})";
                foreach (var cell in workSheet.Row(currentRow + 1).Cells())
                {
                    cell.Style.Font.SetBold();
                    cell.Style.Font.FontColor = XLColor.Red;
                }
                #endregion

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);

                    return stream;
                }
            }
        }
    }
}
