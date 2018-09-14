using System;
using System.Collections.Generic;
using System.Text;


namespace MovieDomain.Attributes.Database
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKey : Attribute
    {
        public String ColumnName { get; set; }
    }
}
