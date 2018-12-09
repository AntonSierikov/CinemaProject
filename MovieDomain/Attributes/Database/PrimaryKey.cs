using System;


namespace MovieDomain.Attributes.Database
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public class PrimaryKey : Attribute
    {
        public String ColumnName { get; set; }
    }
}
