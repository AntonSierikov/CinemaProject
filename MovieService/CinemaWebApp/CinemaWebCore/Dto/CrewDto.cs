using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaWebCore.Dto
{
    public class CrewDto
    {
        public string Job { get; private set; }

        public string Department { get; private set; }

        public string PeopleName { get; private set; }

        //----------------------------------------------------------------//

        public CrewDto(string _job, string _department, string _peopleName)
        {
            Job = _job;
            Department = _department;
            PeopleName = _peopleName;
        }

        //----------------------------------------------------------------//

    }
}
