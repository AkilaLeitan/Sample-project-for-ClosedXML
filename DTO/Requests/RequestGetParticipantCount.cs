using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_project_for_ClosedXML.DTO.Requests
{
    public class RequestGetParticipantCount
    {
        public string EventName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } = new DateTime(2023, 1, 1);
        public DateTime EndDate { get; set; } = new DateTime(2023, 1, 5);
    }
}