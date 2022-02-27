using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace labb1_avancerad_dotnet
{
    public class LådaEnumerator : IEnumerator<Låda>
    {
        private LådaCollection _collection;
        private int curIndex;
        private Låda nuvarandeLåda;

        public LådaEnumerator(LådaCollection collection)
        {
            _collection = collection;
            curIndex = -1;
            nuvarandeLåda = default(Låda);
        }

        public bool MoveNext()
        {
            if (++curIndex >= _collection.Count)
            {
                return false;
            }
            else
            {
                nuvarandeLåda = _collection[curIndex];
            }
            return true;
        }
        public void Reset() { curIndex = -1; }

        void IDisposable.Dispose() { }

        public Låda Current
        {
            get { return nuvarandeLåda; }
        }

        object IEnumerator.Current
        {
            get { return Current;  }
        }

        // Kollar om två lådor har samma dimension
        public class LådaSameDimensions : EqualityComparer<Låda>
        {

            public override bool Equals(Låda b1, Låda b2)
            {
                if (b1.höjd == b2.höjd && b1.längd == b2.längd
                                    && b1.bredd == b2.bredd)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public override int GetHashCode(Låda bx)
            {
                int hCode = bx.höjd ^ bx.höjd ^ bx.bredd;
                return hCode.GetHashCode();
            }
        }
    }
}
