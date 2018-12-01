﻿using System;
using System.Linq.Expressions;
using MovieDomain.Abstract;


namespace MovieDomain.Entities
{
    public partial class Crew : DbObject<int>
    {

        //----------------------------------------------------------------//

        public int? PeopleId { get; set; }
        public int MovieId { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
        public People People { get; set; }
        public Movie Movie { get; set; }

        //----------------------------------------------------------------//

        public Crew() {}

        //----------------------------------------------------------------//

        public Crew(Movie movie, People people, Job job)
        {
            Movie = movie;
            MovieId = movie.Id;
            People = people;
            PeopleId = people.Id;
            Job = job;
            JobId = job.Id;
        }

        //----------------------------------------------------------------//

        public Crew(Job job, int peopleId = 0)
        {
            PeopleId = peopleId;
            Job = job;
        }

        //----------------------------------------------------------------//


    }
}
