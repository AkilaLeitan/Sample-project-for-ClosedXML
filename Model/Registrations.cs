using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_project_for_ClosedXML.Model
{
    public class Registrations : DbBaseClass
    {
        public int RegistrationsID { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string ParticipantName { get; set; } = string.Empty;
        public string EventCategory { get; set; } = string.Empty;
        public DateTime RegistredDate { get; set; } = DateTime.Today;
    }
}