using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDomain.BL.Model
{
    public class BLJob
    {
        public readonly string Job;
        public readonly string Department;


        //----------------------------------------------------------------//

        public BLJob(string _job, string _department)
        {
            Job = _job;
            Department = _department;
        }

        //----------------------------------------------------------------//

    }
}
