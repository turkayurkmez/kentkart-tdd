using Community.API.Models;
using System.Xml.Linq;

namespace Community.API.Services
{
    public class SpeakerService : ISpeakerService
    {
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
            var speakers = GetSpeakers();

            var output = speakers.Where(sp => sp.Name.Contains(speakerName, StringComparison.OrdinalIgnoreCase)).ToList();

            return output;
        }
    }
}
