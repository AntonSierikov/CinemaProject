using System;
using System.Collections.Generic;
using System.Text;
using MovieDomain.Entities;

namespace MovieDomain.BL.Model
{
    //temp solution
    public class BLCredits
    {

        //----------------------------------------------------------------//

        public IEnumerable<Cast> Casts { get; private set; }

        public IEnumerable<Crew> Crews { get; private set; }

        //----------------------------------------------------------------//

        public BLCredits(IEnumerable<Cast> casts, IEnumerable<Crew> crews)
        {
            this.Casts = casts;
            this.Crews = crews;
        }

        //----------------------------------------------------------------//

    }
}
