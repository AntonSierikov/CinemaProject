namespace MovieDomain.Identifiers
{
    public class JobPeopleId
    {

        //----------------------------------------------------------------//

        public int JobId { get; set; }

        public int PeopleId { get; set; }

        //----------------------------------------------------------------//

        public JobPeopleId(int jobId, int peopleId)
        {
            JobId = JobId;
            PeopleId = peopleId;
        }

        //----------------------------------------------------------------//

        public override bool Equals(object obj)
        {
            JobPeopleId jobPeople = obj as JobPeopleId;
            if(jobPeople != null)
            {
                return jobPeople.PeopleId.Equals(PeopleId) && jobPeople.JobId.Equals(JobId);
            }

            return false;
        }

        //----------------------------------------------------------------//

        public override int GetHashCode()
        {
            return JobId.GetHashCode() ^ PeopleId.GetHashCode();
        }

        //----------------------------------------------------------------//

    }
}
