using System;
using System.Text;
using System.Linq;
using System.Reflection;
using MovieDomain.Attributes.Database;
using MovieDomain.Abstract;
using MovieDomain.Common.Extensions;
using MovieDomain.DAL.Constans;

namespace MovieDomain.DAL.Helpers
{
    public class SqlGenerateHelper
    {

        //----------------------------------------------------------------//

        public static string GenerateUniqueCondition<T, TKey>(string paramName, bool isClustered) where  T: DbObject<TKey>
        {
            Type keyType = typeof(TKey);
            T entity = null;
            string condition = String.Empty;

            if (!isClustered)
            {
                condition = $"{nameof(entity.Id)} = @{paramName}";
            }
            else
            {
                PropertyInfo[] properties = keyType.GetProperties(BindingFlags.Public);
                if (properties.Length > 0)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.AppendCollection(properties, p => $"{p.Name} = @{p.Name}", SqlKeywords.AND);
                    condition = builder.ToString();
                }
            }

            return condition;
        }

        //----------------------------------------------------------------//

        public static bool IsClustered<T>() => Attribute.IsDefined(typeof(T), typeof(ClusteredPrimaryKey));

        //----------------------------------------------------------------//

        public static object CreatePrimaryKeyParameter<TKey>(TKey key, bool isClustered)
        {
            object param = null;
            if (isClustered)
            {
                param = key;
            }
            else
            {
                param = new { key };
            }

            return param;
        }
    }
}
