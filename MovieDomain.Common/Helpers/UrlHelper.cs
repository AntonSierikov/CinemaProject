using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using MovieDomain.Common.Constans;

namespace MovieDomain.Common.Helpers
{
    public static class UrlHelper
    {
        private const string _haveParametersPattern = @"\w*?\w=\w";

        public static string AddTerm(string url, string term)
        {
            string newUrl = url;
            if(!url.EndsWith(StringConstants.SLASH.ToString()))
            {
                newUrl += StringConstants.SLASH;
            }
            newUrl += term;
            return newUrl;
        }

        //----------------------------------------------------------------//

        public static string AddParam(string url, KeyValuePair<string, string> param)
        {
            url = RemoveLastSlashIfExist(url);
            Regex regex = new Regex(_haveParametersPattern);
            char separator = regex.IsMatch(url) ? StringConstants.AMPERSAND : StringConstants.QUESTION;
            return $"{url}{separator}{param.Key}{StringConstants.EQUAL}{param.Value}"; 
        }


        //----------------------------------------------------------------//

        public static void AddParam(this StringBuilder builder, string url, KeyValuePair<string, string> param)
        {
            url = RemoveLastSlashIfExist(url);
            Regex regex = new Regex(_haveParametersPattern);
            char separator = regex.IsMatch(url) ? StringConstants.AMPERSAND : StringConstants.QUESTION;
            builder.Append($"{url}{separator}{param.Key}{StringConstants.EQUAL}{param.Value}");
        }

        //----------------------------------------------------------------//

        public static string AddParams(string url, IDictionary<string, string> parameters)
        {
            StringBuilder builder = new StringBuilder();
            foreach(KeyValuePair<string, string> parameter in parameters)
            {
                builder.AddParam(url, parameter);
            }
            return builder.ToString();
        }

        //----------------------------------------------------------------//

        public static string AddParams(string url, NameValueCollection parameters)
        {
            StringBuilder builder = new StringBuilder();
            List<string> l_params = new List<string>();
            string newUrl = string.Empty;

            url = RemoveLastSlashIfExist(url);
            builder.Append(url);
            builder.Append(StringConstants.QUESTION);      
            foreach(string key in parameters)
            {
                string value = parameters[key];
                l_params.Add($"{key}={value}");
            }
            builder.Append(string.Join(StringConstants.AMPERSAND.ToString(), l_params));
            return builder.ToString();
        } 

        //----------------------------------------------------------------//

        public static string RemoveLastSlashIfExist(string url)
        {
            if (url.EndsWith(StringConstants.SLASH.ToString()))
            {
                url = url.Remove(url.Length - 1);
            }
            return url;
        }

        //----------------------------------------------------------------//

    }
}
