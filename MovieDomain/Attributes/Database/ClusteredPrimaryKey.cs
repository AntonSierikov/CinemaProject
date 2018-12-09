using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDomain.Attributes.Database
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ClusteredPrimaryKey : Attribute
    {
    }
}
