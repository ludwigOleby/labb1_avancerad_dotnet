using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static labb1_avancerad_dotnet.LådaEnumerator;

namespace labb1_avancerad_dotnet
{
    public class LådaCollection : ICollection<Låda>
    {
        public int Count {get { return lådlista.Count; } }

        public bool IsReadOnly => throw new NotImplementedException();

        private List<Låda> lådlista;

        public LådaCollection()
        {
            lådlista = new List<Låda>();
        }

        public Låda this[int index]
        {
            get { return (Låda)lådlista[index]; }
            set { lådlista[index] = value; }
        }

        public void Add(Låda item)
        {
            if (!Contains(item))
            {
                lådlista.Add(item);
            }
            else
            {
                Console.WriteLine("Lådan existerar redan i listan!");
            }
        }

        public void Clear()
        {
            throw new NotImplementedException(); 
        }

        public bool Contains(Låda item)
        {
            bool found = false;
            foreach (Låda i in lådlista)
            {
                if (i.Equals(item))
                {
                    found = true;
                }
            }
            return found;
        }

        public bool Contains(Låda item, EqualityComparer<Låda> compare)
        {
            bool found = false;
            foreach (var i in lådlista)
            {
                if (compare.Equals(i, item))
                {
                    found = true;
                }
            }
            return found;
        }

        public void CopyTo(Låda[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Låda> GetEnumerator()
        {
            return new LådaEnumerator(this);
        }

        public bool Remove(Låda item)
        {
            bool resultat = false;
            for (int i = 0; i < lådlista.Count; i++)
            {
                Låda nuvarandeLåda = (Låda)lådlista[i];
                if (new LådaSameDimensions().Equals(nuvarandeLåda, item))
                {
                    lådlista.RemoveAt(i);
                    resultat = true;
                    break;
                }
            }
            return resultat;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new LådaEnumerator(this);
        }
    }
}
