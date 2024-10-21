using Community.API.Models;

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
    }
}
