using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyse_your_obj
{
    class MyVertex
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public MyVertex(double _x, double _y, double _z)
        {
            X = _x;
            Y = _y;
            Z = _z;
        }

        public override string ToString()
        {
            string tmp = Convert.ToString(X) + " " + Convert.ToString(Y) + " " + Convert.ToString(Z);
            return tmp.Replace(",", ".");
        }
    }
}
