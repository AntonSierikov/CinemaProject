using System;
using System.Collections.Generic;
using System.Text;
using MovieDomain.Entities;
using MovieDomain.DAL.Constans;

namespace MovieDomain.DAL.Factories
{
    internal static class TableFactory
    {

        //----------------------------------------------------------------//

        private static Dictionary<Type, string> tableDictionary;

        //----------------------------------------------------------------//

        static TableFactory()
        {
            tableDictionary = new Dictionary<Type, string>();
            InitTables();
        }

        //----------------------------------------------------------------//

        private static void InitTables()
        {
            tableDictionary.Add(typeof(Cast), TableConstans.CAST);
            tableDictionary.Add(typeof(Crew), TableConstans.CREW);
            tableDictionary.Add(typeof(People), TableConstans.PEOPLE);
            tableDictionary.Add(typeof(Movie), TableConstans.MOVIE);
            tableDictionary.Add(typeof(ProductionCompany), TableConstans.PRODUCTION_COMPANY);
            tableDictionary.Add(typeof(ProductionCountry), TableConstans.PRODUCTION_COUNTRY);
            tableDictionary.Add(typeof(Genre), TableConstans.GENRE);
            tableDictionary.Add(typeof(TaskInfo), TableConstans.TASK_INFO);
            tableDictionary.Add(typeof(Job), TableConstans.JOB);
            tableDictionary.Add(typeof(Department), TableConstans.DEPARTMENT);
            tableDictionary.Add(typeof(JobPeople), TableConstans.JOB_PEOPLE);
            tableDictionary.Add(typeof(MovieCompany), TableConstans.MOVIE_COMPANY);
            tableDictionary.Add(typeof(MovieCountry), TableConstans.MOVIE_COUNTRY);
            tableDictionary.Add(typeof(MovieGenre), TableConstans.MOVIE_GENRE);
        }

        //----------------------------------------------------------------//

        public static string GetNameTable<T>()
        {
            return tableDictionary.GetValueOrDefault(typeof(T));
        }

        //----------------------------------------------------------------//

    }
}
