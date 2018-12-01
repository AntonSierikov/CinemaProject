using System;
using MovieDomain.Entities;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.ICommands;

namespace MovieDomain.DAL.Commands
{
    internal class DepartmentCommand : BaseCommand<Department, int>, IDepartmentCommand
    {
        public DepartmentCommand(ISession session) : base(session)
        {
        }

        protected override string GenerateInsertQuery(Department item)
        {
            return $@"INSERT INTO {TableName} OUTPUT Inserted.Id  VALUES (@{nameof(item.DepartmentName)})";
        }

        protected override string GenerateUpdateQuery(Department item)
        {
            return $@"UPDATE {TableName} SET DepartmentName = @{nameof(item.DepartmentName)}
                      WHERE Id = @{nameof(item.Id)}";
        }
    }
}
