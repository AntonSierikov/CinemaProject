using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaWebCore.Dto
{
    public class CastDto :  ShortPeopleDto
    {
        public string Character { get; private set; }

        public int Order { get; private set; }

        //----------------------------------------------------------------//
                
        public CastDto(string character, string peopleName, int order,
                       int _peopleId, string imgPath)
            : base(_peopleId, peopleName, imgPath)
        {
            Character = character;
            Order = order;
        }

        //----------------------------------------------------------------//
       
    }
}
