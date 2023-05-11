using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample_project_for_ClosedXML.DTO.Requests;
using Sample_project_for_ClosedXML.DTO.Responses;
using Sample_project_for_ClosedXML.Service.RegistrationService;

namespace Sample_project_for_ClosedXML.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : BaseController
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost("GetParticipantCount")]
        public ActionResult<List<ResponseGetParticipantCount>> GetParticipantCount(RequestGetParticipantCount request)
        {
            return Ok(_registrationService.GetParticipantCount(request));
        }

        [HttpPost("GetParticipantCountByCategory")]
        public ActionResult<List<ResponseGetParticipantCountByCategory>> GetParticipantCountByCategory(RequestGetParticipantCountByCategory request)
        {
            return Ok(_registrationService.GetParticipantCountByCategory(request));
        }
    }
}