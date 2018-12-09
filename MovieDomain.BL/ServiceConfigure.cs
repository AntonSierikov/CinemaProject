using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using MovieDomain.Constans;
using MovieDomain.Common.Infrastructure;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.Factories;
using MovieDomain.BL.ServicesInterface;
using MovieDomain.BL.ServicesImpl;

namespace MovieDomain.BL
{
    public static class ServiceConfigure
    {

        //----------------------------------------------------------------//

        public static void Configure(IServiceCollection collection, string pathFolder, string fileName)
        {
            collection.AddSingleton(c => new ConfigurationFactory(pathFolder, fileName));
            collection.AddSingleton<ISessionFactory, SessionFactory>(p => new SessionFactory(p.GetRequiredService<ConfigurationFactory>().GetConnectionString(ConfigurationConstans.MainDb)));
            collection.AddSingleton<IQueryFactory, QueryFactory>();
            collection.AddSingleton<ICommandFactory, CommandFactory>();
            collection.AddTransient<IDbConnection, SqlConnection>(p => new SqlConnection(p.GetRequiredService<ConfigurationFactory>().GetConnectionString(ConfigurationConstans.MainDb)));

            collection.AddSingleton<IMovieService, MovieService>(p => new MovieService(p));
            collection.AddSingleton<ICreditService, CreditService>(p => new CreditService(p));
        }

        //----------------------------------------------------------------//

    }
}
