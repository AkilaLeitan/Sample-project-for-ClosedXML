using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample_project_for_ClosedXML.DTO.Requests;
using Sample_project_for_ClosedXML.DTO.Responses;

namespace Sample_project_for_ClosedXML.Service.RegistrationService
{
    public interface IRegistrationService
    {
        List<ResponseGetParticipantCount> GetParticipantCount(RequestGetParticipantCount request);
        List<ResponseGetParticipantCountByCategory> GetParticipantCountByCategory(RequestGetParticipantCountByCategory request);
    }
}