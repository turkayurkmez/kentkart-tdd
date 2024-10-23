using Community.API.Models;

namespace Community.API.Services
{
    public interface ISpeakerService
    {
        List<SpeakerSummary> GetSpeakersSummary();
        List<Speaker> GetSpeakers();
        List<Speaker> GetSpeakersByName(string speakerName);
    }
}