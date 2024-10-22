using Community.API.Models;
using Community.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community.Tests.API
{

    //Sadece test amaçlı ve -mış gibi çalışan SpeakerService instance'ı
    public class FakeSpeakerService : ISpeakerService
    {
        public List<Speaker> GetSpeakers()
        {
           return new List<Speaker>() { new() { Name="Abdullah" }, new() { Name = "Abdurrahman" } };
        }

        public List<Speaker> GetSpeakersByName(string speakerName)
        {
            throw new NotImplementedException();
        }
    }
}
