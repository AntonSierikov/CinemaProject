using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using MovieDomain.Abstract;

namespace MovieDomain.Entities
{
    public partial class Job : DbObject<int>
    {
        public Job()
        {}

        //----------------------------------------------------------------//

        public Job(string job, Department department = null)
             : this()
        {
            this.job = job;
            Department = department;
            DepartmentId = department.Id;
        }

        public string job { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        //----------------------------------------------------------------//

    }
}
