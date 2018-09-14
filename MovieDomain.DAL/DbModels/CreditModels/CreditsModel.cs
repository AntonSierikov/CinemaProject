using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDomain.DAL.DbModels.CreditModels
{
    public class CreditsModel
    {
        public IEnumerable<CastsModel> Casts;

        public IEnumerable<CrewModel> Crews;
    }
}
