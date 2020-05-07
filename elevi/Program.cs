using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elevi
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaElevi clasa = new ListaElevi();
            clasa.ReadFromFile("../../input.txt");
            clasa.SortListaElevi();
            clasa.WriteToFile("../../output.txt");
        }
    }
}
