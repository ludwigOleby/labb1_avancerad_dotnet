using System;
using System.Linq;

namespace labb1_avancerad_dotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            LådaCollection lådlista = new LådaCollection();
            lådlista.Add(new Låda(3, 2, 4));
            lådlista.Add(new Låda(10, 20, 40));
            lådlista.Add(new Låda(6, 16, 21));
            lådlista.Add(new Låda(33, 22, 44));
            lådlista.Add(new Låda(7, 18, 19));

            // LÅDA MED SAMMA DIMENSIONER
            lådlista.Add(new Låda(7, 18, 19));

            // REMOVE

            Display(lådlista);
            Console.WriteLine("Tar bort låda med dimensionerna: 3x2x4");
            lådlista.Remove(new Låda(3, 2, 4));
            Display(lådlista);

            Console.WriteLine("*************");

            // CONTAINS

            Låda kolla = new Låda(6, 16, 21);
            Console.WriteLine("Finns lådan med diemnsionerna: {0}x{1}x{2} i lådan?\t ", kolla.längd.ToString(),kolla.bredd.ToString(),kolla.höjd.ToString());
            Console.WriteLine(lådlista.Contains(kolla));
            
             

            Console.WriteLine("******");

            Console.WriteLine("DISPLAY:");
            Display(lådlista);

        }
        public static void Display(LådaCollection lådlista)
        {
            Console.WriteLine("\nHeight\tLength\tWidth\tHash Code");
            foreach (Låda bx in lådlista)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}",
                    bx.höjd.ToString(), bx.längd.ToString(),
                    bx.bredd.ToString(), bx.GetHashCode().ToString());
            }
        }
    }
}

