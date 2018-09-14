using System;
using MovieDomain.Entities;
using MovieDomain.Identifiers;
using MovieDomain.DAL.ICommands;
using MovieDomain.DAL.Abstract;

namespace MovieDomain.DAL.Commands
{
    internal class MovieCompanyCommand : BaseCommand<MovieCompany, MovieCompanyId>, IMovieCompanyCommand
    {
        public MovieCompanyCommand(ISession session) : base(session)
        {}

        protected override string GenerateInsertQuery(MovieCompany item)
        {
            string insert = $@"INSERT INTO {TableName}(MovieId, CompanyId)
                               OUTPUT INSERTED.MovieId, INSERTED.CompanyId
                               VALUES(@{nameof(item.Id.MovieId)}, @{nameof(item.Id.CompanyId)})";
            return insert;
        }

        protected override string GenerateUpdateQuery(MovieCompany item)
        {
            throw new NotImplementedException();
        }
    }
}
