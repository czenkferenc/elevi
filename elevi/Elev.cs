using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elevi
{
    class Elev : IComparable<Elev>, IEquatable<Elev>
    {
        protected string name;
        private double[] grades;
        protected double average;
        int nrGrades;

        public Elev(): base()
        {

        }

        public Elev(string n)
        {
            this.name = n;
        }

        public Elev(string n, double[] g)
        {
            this.name = n;
            this.grades = g;

        }

        public Elev(string n, int nr, double[] g)
        {
            this.name = n;
            this.grades = g;
            this.nrGrades = nr;
        }

        public void CalcAvg()
        {
            double avg = new double();

            int i = 0;
            foreach (double g in grades)
            {
                avg += g;
                i++;
            }
            avg /= i;

            average = avg;
        }

        public void FormatName()
        {
            char[] c = name.ToCharArray();
            name = "";
            c[0] = char.ToUpper(c[0]);
            name += c[0].ToString();
            char prevChar = c[0];
            for (int i = 1; i < c.Length; i++)
            {
                if (char.IsWhiteSpace(prevChar)) c[i] = char.ToUpper(c[i]);
                else c[i] = char.ToLower(c[i]);
                name += c[i].ToString();
                prevChar = c[i];
            }
        }

        public void AddName(string n)
        {
            name = n;
            FormatName();
        }
        public void AddGrades(double[] v)
        {
            grades = v;
        }
        public void AddNrgGrades(int nr)
        {
            nrGrades = nr;
        }

        public override string ToString()
        {
            return name + "\t" + average;
        }

        public int CompareTo(Elev e)
        {
            if (average != e.average) return -average.CompareTo(e.average);
            else return name.CompareTo(e.name);
        }

        public bool Equals(Elev e)
        {
            bool nameEqual = name.Equals(e.name);
            bool avgEqual = average.Equals(e.average);
            return avgEqual && nameEqual;
        }
    }
}
