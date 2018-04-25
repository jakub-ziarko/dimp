using System.Collections;
using System.Collections.Generic;

namespace dimp
{
    public class DimpEnumerator : IEnumerable<DimKvp>
    {
        private DimKvp[] _items;

        public IEnumerator<DimKvp> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
