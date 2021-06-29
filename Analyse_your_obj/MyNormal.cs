using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyse_your_obj
{
    class MyNormal
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public MyNormal(MyVertex vertex1, MyVertex vertex2, MyVertex vertex3)
        {
            try
            {
                if (vertex1 is null)
                {
                    throw new ArgumentNullException(nameof(vertex1));
                }

                if (vertex2 is null)
                {
                    throw new ArgumentNullException(nameof(vertex2));
                }

                if (vertex3 is null)
                {
                    throw new ArgumentNullException(nameof(vertex3));
                }
                MyVertex v1 = new MyVertex(vertex1.X - vertex2.X, vertex1.Y - vertex2.Y, vertex1.Z - vertex2.Z);
                MyVertex v2 = new MyVertex(vertex3.X - vertex2.X, vertex3.Y - vertex2.Y, vertex3.Z - vertex2.Z);

                MyVertex v3 = new MyVertex(v1.Y * v2.Z - v1.Z * v2.Y, v1.Z * v2.X - v1.X * v2.Z, v1.X * v2.Y - v1.Y * v2.X);

                double length = Math.Sqrt(v3.X * v3.X + v3.Z * v3.Z + v3.Y * v3.Y);

                this.X = v3.X / length;
                this.Y = v3.Y / length;
                this.Z = v3.Z / length;
            }
            catch
            {

            }
        }
        public bool NearToHorizontal(double accuracy)
        {
            double xBase = 0;
            double yBase = 1;
            double zBase = 0;

            double scalar = Math.Abs(xBase * X + yBase * Y + zBase * Z);

            if (scalar >= 1 - accuracy)
                return true;
            return false;
        }

        public static bool IsVertical(double accuracy, MyNormal normal)
        {
            return normal.NearToVertical(accuracy);
        }

        public static bool IsHorizontal(double accuracy, MyNormal normal)
        {
            return normal.NearToHorizontal(accuracy);
        }
        public bool NearToVertical(double accuracy)
        {
            double xBase = 0;
            double yBase = 1;
            double zBase = 0;


            double scalar = Math.Abs(xBase * X + yBase * Y + zBase * Z);

            if (scalar <= accuracy)
                return true;
            return false;
        }
    }
}
