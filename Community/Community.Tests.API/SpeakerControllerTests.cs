using Community.API.Controllers;
using Community.API.Models;
using Community.API.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

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
        ISpeakerService speakerService;
        Mock<ISpeakerService> speakerServiceMock;
        private IEnumerable<Speaker> _speakers;
        public SpeakerControllerTests()
        {
            _speakers = new Speaker[]
            {
                new Speaker{ Name = "Burak Selim"},
                new Speaker{ Name = "Türkay"},
                new Speaker{ Name = "Abdullah"},
                new Speaker{ Name = "Abdurrahman"},
            };


            //speakerService = new FakeSpeakerService();
            string name = string.Empty;
            speakerServiceMock = new Mock<ISpeakerService>();
            speakerServiceMock.Setup(sp => sp.GetSpeakers()).Returns(_speakers.ToList());
            speakerServiceMock.Setup(sp => sp.GetSpeakersSummary()).Returns(_speakers.Select(x => new SpeakerSummary { Name = x.Name }).ToList());

            controller = new SpeakerController(speakerServiceMock.Object);
        }

        private void setupMockForSearch(string name)
        {
            speakerServiceMock.Setup(sp => sp.
                                             GetSpeakersByName(It.IsAny<string>()))
                                            .Returns(_speakers.Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList());

            controller = new SpeakerController(speakerServiceMock.Object);
        }

        [Fact]
        public void ItReturnsOkObjectResult()
        {
          
            string name = string.Empty;
            var result = controller.Search(name);

            result.Should().NotBeNull();
            //Assert.NotNull(result);



            //Assert.IsType<OkObjectResult>(result);
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void It_Returns_Collection_Of_Speakers()
        {
            //var controller = new SpeakerController();
            string name = "Jos";
            setupMockForSearch(name);
            var result = controller.Search(name) as OkObjectResult;
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.IsAssignableFrom<IEnumerable<Speaker>>(result.Value); 

        }



        [Fact]
        public void Given_Exact_match_then_one_speaker_in_collection()
        {
            setupMockForSearch("Abdullah");
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


            setupMockForSearch(searchString);
            var result = controller.Search(searchString) as OkObjectResult;
            var speakers = (IEnumerable<Speaker>)result.Value;
            Assert.Single(speakers);
            Assert.Equal("Abdullah", speakers.ToList()[0].Name);
        }

        [Fact]
        public void Given_No_Match_Then_Empty_Collection()
        {
            var searchString = "x";
            setupMockForSearch(searchString);
            var result = controller.Search(searchString) as OkObjectResult;
            var speakers = (IEnumerable<Speaker>)result.Value;

            Assert.Empty(speakers);

        }


        [Fact]
        public void Given_Two_Match_Then_Collection_Two_Collection()
        {
            var searchString = "abd";
            setupMockForSearch(searchString);
            var result = controller.Search(searchString) as OkObjectResult;
            var speakers = (IEnumerable<Speaker>)result.Value;

            Assert.Equal(2, speakers.Count());
            Assert.True(speakers.Any(s=>s.Name == "Abdullah"));
            Assert.True(speakers.Any(s => s.Name == "Abdurrahman"));


        }

        //[Fact]
        //public void It_Has_GetAll()
        //{
        //    controller.GetAll();
        //}

        [Fact]
        public void It_Return_OkObject_Result()
        {
            var result = controller.GetAll();
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public void It_Returns_Collection_of_SpeakersSummary()
        {
            var result = (OkObjectResult)controller.GetAll();
            Assert.NotNull(result.Value);
            Assert.IsAssignableFrom<List<SpeakerSummary>>(result.Value);

            result.Value.Should().BeOfType<List<SpeakerSummary>>();
        }



    }
}