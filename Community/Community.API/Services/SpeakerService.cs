using Community.API.Data;
using Community.API.Models;
using System.Xml.Linq;

namespace Community.API.Services
{
    public class SpeakerService : ISpeakerService
    {
        private readonly SpeakerDbContext speakerDbContext;

        public SpeakerService(SpeakerDbContext speakerDbContext)
        {
            this.speakerDbContext = speakerDbContext;
        }

        public List<Speaker> GetSpeakers()
        {
            var speakers = new List<Speaker>()
            {
                new Speaker() { Name = "Abdullah" },
                new Speaker() { Name = "Abdurrahman" },


            };
            return speakers;
        }

        public List<Speaker> GetSpeakersByName(string speakerName)
        {
            var speakers = speakerDbContext.Speakers.ToList();

            var output = speakers.Where(sp => sp.Name.Contains(speakerName, StringComparison.OrdinalIgnoreCase)).ToList();

            return output;
        }

        public List<SpeakerSummary> GetSpeakersSummary()
        {
            var speakers = speakerDbContext.Speakers.ToList();
            return speakers.Select(sp => new SpeakerSummary { Name = sp.Name }).ToList();
        }
    }
}
