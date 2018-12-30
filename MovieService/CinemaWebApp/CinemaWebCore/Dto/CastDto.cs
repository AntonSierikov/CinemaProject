using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaWebCore.Dto
{
    public class CastDto
    {
        public string Character { get; private set; }

        public string PeopleName { get; private set; }

        public int Order { get; private set; }

        //----------------------------------------------------------------//
                
        public CastDto(string character, string peopleName)
        {
            Character = character;
            PeopleName = peopleName;
        }

        //----------------------------------------------------------------//
       
    }
}
