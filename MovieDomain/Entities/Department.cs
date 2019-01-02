using System.Collections.Generic;
using MovieDomain.Abstract;
using MovieDomain.EqualityComparers;

namespace MovieDomain.Entities
{
    public class Department : DbObject<int>
    {

        //----------------------------------------------------------------//
        
        public Department()
        {
            Jobs = new HashSet<Job>(new BaseDbEqualityComparer<int>());
        }

        //----------------------------------------------------------------//

        public Department(string departmentName)
            : this()
        {
            DepartmentName = departmentName;
        }

        //----------------------------------------------------------------//

        public string DepartmentName { get; set; }

        public HashSet<Job> Jobs { get; set; }

        //----------------------------------------------------------------//


    }

}
