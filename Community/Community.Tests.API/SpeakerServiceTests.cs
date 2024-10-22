using Community.API.Models;
using Community.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community.Tests.API
{
    public class SpeakerServiceTests
    {

        private SpeakerService speakerService = new SpeakerService(); 
        [Fact]
        public void Given_Exact_match_then_one_speaker_in_collection()
        {
            //setupMockForSearch("Abdullah");
            //var controller = new SpeakerController();
            string name = "Abdullah";
            var result = speakerService.GetSpeakersByName(name);         
            Assert.Single(result);


        }
    }
}
