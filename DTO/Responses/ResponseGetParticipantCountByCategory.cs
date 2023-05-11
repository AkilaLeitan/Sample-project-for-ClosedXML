using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_project_for_ClosedXML.DTO.Responses
{
    public class ResponseGetParticipantCountByCategory
    {
        public string CategoryName { get; set; } = string.Empty;
        public int ParticipantCount { get; set; } = 0;
    }
}