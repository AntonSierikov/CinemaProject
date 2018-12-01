using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieDomain.Abstract;
using MovieDomain.Common.Extensions;
using MovieDomain.Common.Enums;
using MovieDomain.DAL.ICommands;
using MovieDomain.DAL.IQueries;

namespace MovieDomain.DAL.Helpers
{
    public static class QueryHelper
    {

        //----------------------------------------------------------------//

        public static IEnumerable<TEntity>
         SaveOrUpdateCollection<TEntity, TKey>(
                this ICommand<TEntity,
                TKey> command,
                IEnumerable<TEntity> entities
        ) where TEntity: DbObject<TKey>
        {
            entities.ForEach(e => command.SaveOrUpdate(e));
            return entities;
        }

        //----------------------------------------------------------------//

        public static async Task<IEnumerable<TEntity>> SaveOrUpdateCollectionAsync<TEntity, TKey>(this ICommand<TEntity, TKey> command, 
                                                                                           IEnumerable<TEntity> entities) where TEntity : DbObject<TKey>
        {
            await entities.ForEachAsync(e => command.SaveOrUpdateAsync(e));
            return entities;
        }

        //----------------------------------------------------------------//

        public static DbCommandResult? SaveOrUpdate<TEn, TKey>(this ICommand<TEn, TKey> command, TEn entity) where TEn: DbObject<TKey>
        {
            DbCommandResult? result = null;
            if (entity.Id.Equals(default(TEn)))
            {
                entity.Id = command.Insert(entity);
                if (!entity.Id.Equals(default(TEn)))
                {
                    result = DbCommandResult.Inserted;
                }
            }
            else if(command.Update(entity))
            {
                result = DbCommandResult.Updated;
            }

            return result;
        }

        public static async Task<DbCommandResult?> SaveOrUpdateAsync<TEn, TKey>(this ICommand<TEn, TKey> command, TEn entity) where TEn : DbObject<TKey>
        {
            DbCommandResult? result = null;
            if (entity.Id.Equals(default(TKey)))
            {
                entity.Id = await command.InsertAsync(entity);
                if (!entity.Id.Equals(default(TKey)))
                {
                    result = DbCommandResult.Inserted;
                }
            }
            else if(await command.UpdateAsync(entity))
            {
                result = DbCommandResult.Updated;
            }

            return result;
        }

        //----------------------------------------------------------------//

        public static async Task<DbCommandResult?> SaveOrUpdateAsync<TEn, TKey>(this ICommand<TEn, TKey> command, 
                                                                                     IQuery<TEn, TKey> query, 
                                                                                     TEn entity) where TEn: DbObject<TKey>
        {
            entity.Id = entity.Id.Equals(default(TKey)) ? await query.GetIdByItem(entity) : entity.Id;
            return await command.SaveOrUpdateAsync(entity);
        }

        //----------------------------------------------------------------//

        public static async Task<Dictionary<DbCommandResult, List<TEn>>> 
            SaveOrUpdateCollectionAsync<TEn, TKey>(this ICommand<TEn, TKey> command,
                                                        IQuery<TEn, TKey> query,
                                                        IEnumerable<TEn> entities, 
                                                        Func<TEn,string> selectLog = null) where TEn : DbObject<TKey>
        {
            Dictionary<DbCommandResult, List<TEn>> resultDictionary = new Dictionary<DbCommandResult, List<TEn>>();
            resultDictionary[DbCommandResult.Inserted] = new List<TEn>();
            resultDictionary[DbCommandResult.Updated] = new List<TEn>();

            foreach(TEn entity in entities)
            {
                switch(await command.SaveOrUpdateAsync(query, entity))
                {
                    case DbCommandResult.Inserted:
                        resultDictionary[DbCommandResult.Inserted].Add(entity);                      
                        break;
                    case DbCommandResult.Updated:
                        resultDictionary[DbCommandResult.Updated].Add(entity);
                        break;
                }
            }

            return resultDictionary;
        }

        //----------------------------------------------------------------//

        public static async Task<bool> SaveIfNotExist<TEn, TKey>(this ICommand<TEn, TKey> command, 
                                                                      IQuery<TEn, TKey> query,   
                                                                      TEn entity) where TEn : DbObject<TKey>
        {
            if (!await query.IsExist(entity))
            {
                entity.Id = await command.InsertAsync(entity);
                return true;
            }

            return false;
        }

        //----------------------------------------------------------------//
        
        public static async Task<List<TEn>> SaveIfNotExistCollection<TEn, TKey>
                            (this ICommand<TEn, TKey> command, 
                             IQuery<TEn, TKey> query, 
                             IEnumerable<TEn> entities) where TEn: DbObject<TKey>
        {
            List<TEn> collection = new List<TEn>();
            foreach(TEn entity in entities)
            {
                if(await SaveIfNotExist(command, query, entity))
                {
                    collection.Add(entity);
                }
            }
            return collection;
        }

        //----------------------------------------------------------------//
 
    }
}
