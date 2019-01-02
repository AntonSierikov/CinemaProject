using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaWebCore.Dto
{
    public class ShortPeopleDto
    {
        public int PeopleId { get; private set; }

        public string PeopleName { get; private set; }

        public string ImagePath { get; private set; }
        
        public ShortPeopleDto(int _peopleId, string _peopleName, string _imagePath)
        {
            PeopleId = _peopleId;
            PeopleName = _peopleName;
            ImagePath = _imagePath;
        }
    }
}
