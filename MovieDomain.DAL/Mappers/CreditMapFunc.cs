using System;
using System.Collections.Generic;
using System.Text;
using MovieDomain.Entities;

namespace MovieDomain.DAL.Mappers
{
    public static class CreditMapFunc
    {
        public static Cast CastQueryMap(Cast cast, People people)
        {
            InitPeople(cast, people);
            return cast;
        }

        //----------------------------------------------------------------//

        public static Crew CrewQueryMap(Crew crew, People people)
        {
            InitPeople(crew, people);
            return crew;
        }

        //----------------------------------------------------------------//

        public static Crew CrewQueryMap(Crew crew, Job job, Department department, People people)
        {
            InitPeople(crew, people);
            crew.Job = job;
            crew.Job.Department = department;
            return crew;
        }
        
        //----------------------------------------------------------------//

        private static void InitPeople(Credit credit, People people) => credit.People = people;

        //----------------------------------------------------------------//


    }
}
