using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDomain.Attributes.Database
{
    public class HasSimplePrimaryKey : Attribute
    {
        private string _columnName;

        public string ColumnName { get { return _columnName; } }

        //----------------------------------------------------------------//

        public HasSimplePrimaryKey(string columnName)
        {
            _columnName = columnName;
        }

        //----------------------------------------------------------------//

    }
}
