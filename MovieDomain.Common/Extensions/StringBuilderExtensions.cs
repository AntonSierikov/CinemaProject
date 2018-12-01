using System;
using System.Collections.Generic;
using System.Text;
using MovieDomain.Common.Constans;

namespace MovieDomain.Common.Extensions
{
    public static class StringBuilderExtensions
    {

        //----------------------------------------------------------------//

        public static void AppendCollection<T>(this StringBuilder builder, IEnumerable<T> enumerable, 
                                                 Func<T, string> func, string delimeter)
        {
            IEnumerator<T> enumerator = enumerable.GetEnumerator();
            bool hasNext = enumerator.MoveNext();

            while (hasNext)
            {
                builder.Append(func(enumerator.Current));
                hasNext = enumerator.MoveNext();
                if(!string.IsNullOrEmpty(delimeter) && hasNext)
                {
                    builder.Append(StringConstants.SeparatorWithSpaces(delimeter));
                }
            }
        }

        //----------------------------------------------------------------//

        public static void AppendCollection<T, T2>(this StringBuilder builder, IEnumerable<T> enumerable,
                                               Func<T, T2, string> func, T2 arg2, string delimeter)
        {
            IEnumerator<T> enumerator = enumerable.GetEnumerator();
            bool hasNext = enumerator.MoveNext();

            while (hasNext)
            {
                builder.Append(func(enumerator.Current, arg2));
                hasNext = enumerator.MoveNext();
                if (!string.IsNullOrEmpty(delimeter) && hasNext)
                {
                    builder.Append(StringConstants.SeparatorWithSpaces(delimeter));
                }
            }
        }

        //----------------------------------------------------------------//

        public static void AppendExceptionLog(this StringBuilder builder, Exception ex)
        {
            builder.AppendLine($"Message: {ex.Message}");
            builder.AppendLine($"Stack trace: {ex.StackTrace}");
        }

        //----------------------------------------------------------------//

    }
}
