using Community.API.Models;
using Community.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Community.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakerController : ControllerBase
    {
        private ISpeakerService depentendService;

        public SpeakerController(ISpeakerService speakerService)
        {
            depentendService = speakerService;
        }

        public IActionResult GetAll()
        {
            var speakerSummaries = depentendService.GetSpeakersSummary();
            return Ok(speakerSummaries);
        }

        public IActionResult Search(string name)
        {
            //var depentendService = new SpeakerService();
            //var speakers = depentendService.GetSpeakers();
            var output = depentendService.GetSpeakersByName(name);
            return Ok(output);
        }
    }
}
