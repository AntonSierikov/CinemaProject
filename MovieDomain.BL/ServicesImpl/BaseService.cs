using System;
using System.Data;
using MovieDomain.DAL.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace MovieDomain.BL.ServicesImpl
{
    internal class BaseService
    {

        //----------------------------------------------------------------//

        protected IServiceProvider provider { get; private set; }

        protected IQueryFactory queryFactory { get; private set; }

        protected ICommandFactory commandFactory { get; private set; }

        //----------------------------------------------------------------//

        public BaseService(IServiceProvider provider)
        {
            this.provider = provider;
            queryFactory = provider.GetRequiredService<IQueryFactory>();
            commandFactory = provider.GetRequiredService<ICommandFactory>();
        }

        //----------------------------------------------------------------//

        protected IDbConnection OpenConnection()
        {
            IDbConnection connection = provider.GetRequiredService<IDbConnection>();
            connection.Open();
            return connection;
        }

        //----------------------------------------------------------------//

    }
}
