using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyse_your_obj
{
    class MyCollector
    {
        
        public static void WriteVertexToObj(List<MyVertex> vertices, StreamWriter swr)
        {

            foreach (var tmp in vertices)
            {
                swr.WriteLine("v " + tmp.ToString());
            }

            swr.WriteLine("# " + (vertices.Count) + " vertices");
        }

        public static void WriteVertexNormalToObj(List<MyVertex> vertexNormal, StreamWriter swr)
        {

            foreach (var tmp in vertexNormal)
            {
                swr.WriteLine("vn " + tmp.ToString());
            }

            swr.WriteLine("# " + (vertexNormal) + " vertices");
        }


        public static void WriteFaceToObj(List<MyFace> faces, bool[] map, StreamWriter swr)
        {

            for(int i = 0; i < map.Length; i++)
            {
                if (map[i])
                    swr.WriteLine(faces[i].ToString());
            }

            swr.WriteLine("# 0 polygons - " + faces.Count + " triangles");
        }

        public static void WriteFaceToObj(List<MyFace> faces, StreamWriter swr)
        {

            foreach(var tmp in faces)
            {
                    swr.WriteLine(tmp.ToString());
            }

            swr.WriteLine("# 0 polygons - " + faces.Count + " triangles");
        }
        public static void WriteToObjFile(List<MyFace> faces, List<MyVertex> vertices, List<MyVertex> vertexNormal, bool[] map, string nameOfFile)
        {
            using (StreamWriter swr = new StreamWriter(nameOfFile))
            {
                WriteVertexToObj(vertices, swr);
                WriteVertexNormalToObj(vertexNormal, swr);
                WriteFaceToObj(faces, map, swr);
            }
        }
        public static void WriteToObjFile(List<MyFace> faces, List<MyVertex> vertices, List<MyVertex> vertexNormal, string nameOfFile)
        {
            using (StreamWriter swr = new StreamWriter(nameOfFile))
            {
                WriteVertexToObj(vertices, swr);
                WriteVertexNormalToObj(vertexNormal, swr);
                WriteFaceToObj(faces, swr);
            }
        }


        public static void WriteAllPartOfSurface(List<MyFace> faces, bool[] map, List<MyVertex> vertices, List<MyVertex> vertexNormal, List<List<int>> listOfIndexFacesUsingPoints, int accuracy, string name)
        {
            int i = 0;
            foreach (var tmp in MyFaceAnaLizer.GetAllSurface(listOfIndexFacesUsingPoints,faces,map,accuracy))
            {
                WriteToObjFile(tmp, vertices, vertexNormal, name + "_#_" + i + ".obj");
                Console.WriteLine(name + "_#_" + i + " записан");
                i++;
            }
        }
    }
}
