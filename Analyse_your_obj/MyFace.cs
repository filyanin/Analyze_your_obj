using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyse_your_obj
{
    class MyFace
    {
        public int IndexOfVertex1 { get; set; }
        public int IndexOfVertex2 { get; set; }
        public int IndexOfVertex3 { get; set; }
        public int IndexOfVertexNormal1 { get; set; }
        public int IndexOfVertexNormal2 { get; set; }
        public int IndexOfVertexNormal3 { get; set; }
        public int BaseNumber { get; set; }

        internal MyNormal Normal { get; set; }

        public MyFace(int _indexOfVertex1, int _indexOfVertex2, int _indexOfVertex3, int _indexOfVertexNormal1, int _indexOfVertexNormal2, int _indexOfVertexNormal3, int _baseNumber)
        {
            IndexOfVertex1 = _indexOfVertex1;
            IndexOfVertex2 = _indexOfVertex2;
            IndexOfVertex3 = _indexOfVertex3;
            IndexOfVertexNormal1 = _indexOfVertexNormal1;
            IndexOfVertexNormal2 = _indexOfVertexNormal2;
            IndexOfVertexNormal3 = _indexOfVertexNormal3;
            Normal = null;
            BaseNumber = _baseNumber;

        }

        public void CountNormalVector(MyVertex vertex1, MyVertex vertex2, MyVertex vertex3)
        {
            Normal = new MyNormal(vertex1, vertex2, vertex3);
        }

        public override string ToString()
        {
            return "f " + Convert.ToString(IndexOfVertex1) + "//" + Convert.ToString(IndexOfVertexNormal1) + " " + Convert.ToString(IndexOfVertex2) + "//" + Convert.ToString(IndexOfVertexNormal2) + " " + Convert.ToString(IndexOfVertex3) + "//" + Convert.ToString(IndexOfVertexNormal3);
        }

        public bool IfUsingCurrentPoint(int point)
        {
            if ((point == IndexOfVertex1) || (point == IndexOfVertex2) || (point == IndexOfVertex3))
            {
                return true;
            }
            return false;
        }
    }
}
