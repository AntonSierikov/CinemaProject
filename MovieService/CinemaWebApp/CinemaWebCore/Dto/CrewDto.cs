using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaWebCore.Dto
{
    public class CrewDto : ShortPeopleDto
    {
        public string Job { get; private set; }

        public string Department { get; private set; }

        //----------------------------------------------------------------//

        public CrewDto(string _job, string _department, int _peopleId, string _peopleName, string _imgPath)
            : base(_peopleId, _peopleName, _imgPath)
        {
            Job = _job;
            Department = _department;
        }

        //----------------------------------------------------------------//

    }
}
