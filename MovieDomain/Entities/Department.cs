using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using MovieDomain.Abstract;

namespace MovieDomain.Entities
{
    public partial class Department : DbObject<int>
    {

        //----------------------------------------------------------------//
        
        public Department()
        {
            Jobs = new HashSet<Job>();
        }

        //----------------------------------------------------------------//

        public Department(string departmentName)
            : this()
        {
            DepartmentName = departmentName;
        }

        //----------------------------------------------------------------//

        public string DepartmentName { get; set; }

        public ICollection<Job> Jobs { get; set; }

        //----------------------------------------------------------------//


    }

}
