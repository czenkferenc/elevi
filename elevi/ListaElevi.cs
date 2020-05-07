using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace elevi
{
    internal class ListaElevi
    {
        private List<Elev> lista = new List<Elev>();

        public ListaElevi(): base()
        {

        }

        public void ReadFromFile(string path)
        {
            StreamReader sr = new StreamReader(path);
            char[] sep = { ' ', '-', '_', ':', ';', '\t' };
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                Elev e = new Elev();
                string nume = "";
                string note = "";

                char prevChar = 'a';
                foreach(char c in line)
                {
                    if(char.IsLetter(c))
                    {
                        nume += c;
                    }
                    if(char.IsDigit(c))
                    {
                        note += c;
                    }
                    if(sep.Contains(c) && char.IsLetter(prevChar))
                    {
                        nume += c;
                    }
                    if(sep.Contains(c) && char.IsDigit(prevChar))
                    {
                        note += c;
                    }

                    prevChar = c;
                }

                e.AddName(nume);
                e.FormatName();

                double[] noteD = note.Split(sep).Select(double.Parse).ToArray();

                int nrNote = int.Parse(noteD[0].ToString());

                double[] noteFinal = new double[nrNote];

                for (int i = 0; i < nrNote; i++)
                {
                    noteFinal[i] = noteD[i + 1];
                }

                e.AddGrades(noteFinal);
                e.CalcAvg();
                
                lista.Add(e);
            }
            sr.Close();
        }

        public void WriteToFile(string path) 
        {
            StreamWriter sw = new StreamWriter(path);
            foreach(Elev e in lista)
            {
                sw.WriteLine(e.ToString());
            }
            sw.Close();
        }

        
        public void SortListaElevi()
        {
            lista.Sort();
        }
    }
}