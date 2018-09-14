using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using MovieDomain.DAL.ICommands;
using MovieDomain.DAL.Abstract;
using MovieDomain.Entities;


namespace MovieDomain.DAL.Commands
{
    internal class JobCommand : BaseCommand<Job, int>, IJobCommand
    {

        //----------------------------------------------------------------//

        public JobCommand(ISession session)
            : base(session)
        {}

        //----------------------------------------------------------------//

        protected override string GenerateInsertQuery(Job entity)
        {
           return $"INSERT INTO {TableName} VALUES (DEFAULT, @{nameof(entity.Department)}, @{nameof(entity.DepartmentId)})";
        }

        //----------------------------------------------------------------//

        protected override string GenerateUpdateQuery(Job entity)
        {
            return $@"UPDATE {TableName} SET
                      DepartmentId = @{nameof(entity.DepartmentId)},
                      job = @{nameof(entity.job)}
                      WHERE id = @{nameof(entity.Id)}";
        }

        //----------------------------------------------------------------//


    }
}
