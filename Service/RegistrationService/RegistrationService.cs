using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample_project_for_ClosedXML.DTO.Requests;
using Sample_project_for_ClosedXML.DTO.Responses;
using Sample_project_for_ClosedXML.Model;

namespace Sample_project_for_ClosedXML.Service.RegistrationService
{
    public class RegistrationService : IRegistrationService
    {
        List<string> eventNames = new List<string> { "Event 1", "Event 2", "Event 3" };
        List<string> CategoryNamesForE1 = new List<string> { "Category 1", "Category 2", "Category 3", "Category 4" };
        List<string> CategoryNamesForE2 = new List<string> { "Category A", "Category B", "Category C" };
        List<string> CategoryNamesForE3 = new List<string> { "Visitors", "Person Interview Day 1", "Person Interview Day 2" };
        private List<Registrations> _registrationsList;

        public RegistrationService() => SeedData();

        public List<ResponseGetParticipantCount> GetParticipantCount(RequestGetParticipantCount request)
        {
            var result = _registrationsList.Where(r => r.RegistredDate >= request.StartDate && r.RegistredDate <= request.EndDate && r.EventName == request.EventName)
                .GroupBy(r => new { r.EventName, r.RegistredDate })
                .Select(g => new ResponseGetParticipantCount { Date = g.Key.RegistredDate, ParticipantCount = g.Count() });
            Console.WriteLine(result);

            return result.ToList();
        }

        public List<ResponseGetParticipantCountByCategory> GetParticipantCountByCategory(RequestGetParticipantCountByCategory request)
        {
            var result = _registrationsList.Where(r => r.EventName == request.EventName)
                 .GroupBy(r => new { r.EventName, r.EventCategory })
                 .Select(g => new ResponseGetParticipantCountByCategory { CategoryName = g.Key.EventCategory, ParticipantCount = g.Count() });
            Console.WriteLine(result);

            return result.ToList();
        }



        ///- - - - - - - - - - - - - - - - - - - - - - - -
        public void SeedData()
        {
            _registrationsList = new List<Registrations>();
            for (int i = 1; i <= 200; i++)
            {
                Random rand = new Random();
                int randomIndex = rand.Next(eventNames.Count);

                string eName = eventNames[randomIndex];
                string cName = generateCategory(randomIndex);
                int eDate = 1;
                if (i < 50)
                {
                    eDate = 1;
                }
                else if (i <= 80)
                {
                    eDate = 2;
                }
                else if (i < 100)
                {
                    eDate = 3;
                }
                else if (eDate <= 170)
                {
                    eDate = 4;
                }
                else
                {
                    eDate = 5;
                }
                _registrationsList.Add(
                   new Registrations
                   {
                       RegistrationsID = i,
                       EventName = eName,
                       ParticipantName = "user " + i + "",
                       EventCategory = cName,
                       RegistredDate = new DateTime(2023, 1, eDate)
                   });
            }

        }

        public string generateCategory(int eventId)
        {
            if (eventId == 0)
            {
                Random rand = new Random();
                int randomIndex = rand.Next(CategoryNamesForE1.Count);

                return CategoryNamesForE1[randomIndex];
            }
            else if (eventId == 1)
            {
                Random rand = new Random();
                int randomIndex = rand.Next(CategoryNamesForE2.Count);

                return CategoryNamesForE2[randomIndex];
            }
            else
            {
                Random rand = new Random();
                int randomIndex = rand.Next(CategoryNamesForE3.Count);

                return CategoryNamesForE3[randomIndex];
            }
        }
    }
}