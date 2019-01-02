using System;
using System.Collections.Generic;
using System.Text;
using MovieDomain.EqualityComparers;

namespace MovieDomain.ComparerFactories
{
    public static class EqualityComparerFactory
    {
        private static BaseDbEqualityComparer<int> _baseDbIntPKComparer;

        private static BaseDbEqualityComparer<string> _baseDbStringPKComparer;

        public static BaseDbEqualityComparer<int> BaseDbIntPKComparer
        {
            get
            {
                if(_baseDbIntPKComparer == null)
                {
                    _baseDbIntPKComparer = new BaseDbEqualityComparer<int>();
                }

                return _baseDbIntPKComparer;
            }
        }

        public static BaseDbEqualityComparer<string> BaseDbStringPKComparer
        {
            get
            {
                if(_baseDbStringPKComparer == null)
                {
                    _baseDbStringPKComparer = new BaseDbEqualityComparer<string>();
                }

                return _baseDbStringPKComparer;
            }
        }

    }
}
