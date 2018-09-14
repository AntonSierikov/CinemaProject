using System;
using System.Text;
using System.Linq;
using System.Reflection;
using MovieDomain.Attributes.Database;
using MovieDomain.Common.Extensions;
using MovieDomain.DAL.Constans;

namespace MovieDomain.DAL.Helpers
{
    public class SqlGenerateHelper
    {

        //----------------------------------------------------------------//

        public static string GenerateUniqueCondition<T, TKey>(string paramName)
        {
            Type type = typeof(T);
            string condition = String.Empty;
            HasSimplePrimaryKey simplePrimaryKey = type.GetCustomAttribute<HasSimplePrimaryKey>();

            if (simplePrimaryKey != null)
            {
                condition = $"{simplePrimaryKey.ColumnName} = @{paramName}";
            }
            else
            {
                Type keyType = typeof(TKey);
                PropertyInfo[] properties = keyType.GetProperties(BindingFlags.Public);
                if (properties.Length > 0)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.AppendCollection(properties, p => GenerateCondition(p, paramName) , SqlKeywords.AND);
                    condition = builder.ToString();
                }
            }

            condition = !String.IsNullOrEmpty(condition) ? condition : GeneralDatabaseConstants.DEFAULT_PK_NAME;
            return condition;
        }

        //----------------------------------------------------------------//

        private static String GenerateCondition(PropertyInfo info, string paramName)
        {
            PrimaryKey primaryKey = info.GetCustomAttribute<PrimaryKey>();
            return $"{primaryKey.ColumnName} = @{String.Concat(paramName, primaryKey.ColumnName)}";
        }

        //----------------------------------------------------------------//

    }
}
