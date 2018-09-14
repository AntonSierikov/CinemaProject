

namespace MoviesDomain.AuthEntities
{

    //----------------------------------------------------------------//

    public class Role 
    {
        public string Name { get; set; }

        public Role() {}

        public Role(string name) { Name = name; }

        //----------------------------------------------------------------//

        public bool Equals(Role role)
        {
            if (role == null)
            {
                return false;
            }
            return role.Name == Name;
        }

        //----------------------------------------------------------------//

    }

    //----------------------------------------------------------------//
}
