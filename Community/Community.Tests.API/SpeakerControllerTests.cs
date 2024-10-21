using Community.API.Controllers;
using Community.API.Models;
using Community.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Community.Tests.API
{
    public class SpeakerControllerTests
    {
        //[Fact]
        //public void ItExists()
        //{
        //    var controller = new SpeakerController();
        //}


        //[Fact]
        //public void ItHasSearch()
        //{
        //    var controller = new SpeakerController();
        //    string name = string.Empty;
        //    controller.Search(name);
        //}
        SpeakerController controller;
        FakeSpeakerService speakerService;
        public SpeakerControllerTests()
        {
            speakerService = new FakeSpeakerService();
            controller = new SpeakerController(speakerService);
        }

        [Fact]
        public void ItReturnsOkObjectResult()
        {
          
            string name = string.Empty;
            var result = controller.Search(name);
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void It_Returns_Collection_Of_Speakers()
        {
            //var controller = new SpeakerController();
            string name = "Jos";
            var result = controller.Search(name) as OkObjectResult;
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.IsAssignableFrom<IEnumerable<Speaker>>(result.Value); 

        }



        [Fact]
        public void Given_Exact_match_then_one_speaker_in_collection()
        {
            //var controller = new SpeakerController();
            string name = "Abdullah";
            var result = controller.Search(name) as OkObjectResult;
            var speakers = (IEnumerable<Speaker>)result.Value;
            Assert.Single(speakers);


        }

        [Theory]
        [InlineData("abdullah")]
        [InlineData("Abdullah")]
        [InlineData("abduLlah")]

        public void Given_Case_Insensitive_Match_Then_Speaker_InCollection(string searchString)
        {
        
            var result = controller.Search(searchString) as OkObjectResult;
            var speakers = (IEnumerable<Speaker>)result.Value;
            Assert.Single(speakers);
            Assert.Equal("Abdullah", speakers.ToList()[0].Name);
        }

        [Fact]
        public void Given_No_Match_Then_Empty_Collection()
        {
            var searchString = "x";
            var result = controller.Search(searchString) as OkObjectResult;
            var speakers = (IEnumerable<Speaker>)result.Value;

            Assert.Empty(speakers);

        }


        [Fact]
        public void Given_Two_Match_Then_Collection_Two_Collection()
        {
            var searchString = "abd";
            var result = controller.Search(searchString) as OkObjectResult;
            var speakers = (IEnumerable<Speaker>)result.Value;

            Assert.Equal(2, speakers.Count());
            Assert.True(speakers.Any(s=>s.Name == "Abdullah"));
            Assert.True(speakers.Any(s => s.Name == "Abdurrahman"));


        }

    }
}