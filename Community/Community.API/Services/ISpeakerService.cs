﻿using Community.API.Models;

namespace Community.API.Services
{
    public interface ISpeakerService
    {
        List<Speaker> GetSpeakers();
    }
}