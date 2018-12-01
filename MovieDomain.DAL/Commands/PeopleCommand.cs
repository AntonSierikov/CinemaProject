using System;
using MovieDomain.Entities;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.Constans;
using MovieDomain.DAL.ICommands;
using Dapper;

namespace MovieDomain.DAL.Commands
{
    internal class PeopleCommand : BaseCommand<People, int>, IPeopleCommand
    {

        //----------------------------------------------------------------//

        public PeopleCommand(ISession session)
            : base(session)
        {}

        //----------------------------------------------------------------//

        protected override string GenerateInsertQuery(People entity)
        {
            string insert = $@"INSERT INTO {TableName} VALUES OUTPUT Inserted.Id VALUES
                               (DEFAULT, {nameof(entity.Imdb_id)}, {nameof(entity.Name)}, {nameof(entity.Biography)},
                                {nameof(entity.Gender)}, {nameof(entity.Homepage)}, {nameof(entity.Birthday)}, {nameof(entity.Deathday)},
                                {nameof(entity.PlaceOfBirth)}, {nameof(entity.Popularity)}, {nameof(entity.ProfilePath)})";
            return insert;
        }

        //----------------------------------------------------------------//

        protected override string GenerateUpdateQuery(People entity)
        {
            string update = $@"UPDATE {TableName} SET
                               Imdb_id = {nameof(entity.Imdb_id)} 
                               Name = {nameof(entity.Name)},
                               Biography = {nameof(entity.Biography)},
                               Gender = {nameof(entity.Gender)},
                               HomePage  = {nameof(entity.Homepage)},
                               Birthday = {nameof(entity.Birthday)}, 
                               Deathday = {nameof(entity.Deathday)},
                               PlaceOfBirth = {nameof(entity.PlaceOfBirth)},
                               Popularity = {nameof(entity.Popularity)},
                               ProfilePath = {nameof(entity.ProfilePath)}
                               WHERE Id = @{nameof(entity.Id)}";
            return update;
        }

        //----------------------------------------------------------------//

    }
}
