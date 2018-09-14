using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDomain.Common.Constans
{
    public static class StringConstants
    {
        public const char COMA = ',';

        public const char POINT = '.';

        public const string CHARP_SEPARATOR = "###################################";

        public const char SLASH = '/';

        public const char QUESTION = '?';

        public const char AMPERSAND = '&';

        public const char VERTICAL_LINE = '|';

        public const char EQUAL = '=';

        public const char SPACE = ' '; 

        public const string COMA_SPACE = ", ";

        //----------------------------------------------------------------//
            
        public static string CharpSeparatorWithValue(string value)
        {
            return $"{CHARP_SEPARATOR} {value} {CHARP_SEPARATOR}";
        }

        //----------------------------------------------------------------//

        public static string SeparatorWithSpaces(string value)
        {
            return $" {value} ";
        }

        //----------------------------------------------------------------//

    }
}
