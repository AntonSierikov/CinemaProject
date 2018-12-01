using System;
using System.Collections.Generic;
using System.Text;
using MovieDomain.Abstract;
using MovieDomain.Identifiers;

namespace MovieDomain.Entities
{
    public class JobPeople : DbObject<JobPeopleId>
    {

        //----------------------------------------------------------------//

        public Job Job { get; set; }

        public People People { get; set; }

        //----------------------------------------------------------------//

        public JobPeople(int jobId, int peopleId)
        {
            Id = new JobPeopleId(jobId, peopleId);
        }

        //----------------------------------------------------------------//

        public JobPeople(Job job, People people)
            : this(job.Id, people.Id)
        {
            People = people;
            Job = job;
        }

        //----------------------------------------------------------------//

    }
}
