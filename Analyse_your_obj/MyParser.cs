using System;
using System.Collections.Generic;

namespace Analyse_your_obj
{
    static class MyParser
    {
        static bool IsTarget(string target, string source)
        {
            if (target == source)
                return true;
            return false;
        }

        static public bool TryParseStringToVertex(string line, List<MyVertex> listOfVertex)
        {
            string[] parts = line.Split(' ');
            if (parts[0] == "v")
            {
                listOfVertex.Add(new MyVertex(Convert.ToDouble(parts[1]), Convert.ToDouble(parts[2]), Convert.ToDouble(parts[3])));
                return true;
            }
            return false;
        }

        static public bool TryParseStringToVertexNormal(string line, List<MyVertex> listOfVertex)
        {
            string[] parts = line.Split(' ');
            if (parts[0] == "vn")
            {
                listOfVertex.Add(new MyVertex(Convert.ToDouble(parts[1]), Convert.ToDouble(parts[2]), Convert.ToDouble(parts[3])));
                return true;
            }
            return false;
        }

        static public bool TryParseToFace(string line, List<MyFace> listOfFace, int number)
        {
            string[] parts = line.Split(' ');
            string[] numbers1;
            string[] numbers2;
            string[] numbers3;

            if (IsTarget("f", parts[0]))
            {
                numbers1 = parts[1].Split('/');
                numbers2 = parts[2].Split('/');
                numbers3 = parts[3].Split('/');

                listOfFace.Add(new MyFace(Convert.ToInt32(numbers1[0]), Convert.ToInt32(numbers2[0]), Convert.ToInt32(numbers3[0]), Convert.ToInt32(numbers1[2]), Convert.ToInt32(numbers2[2]), Convert.ToInt32(numbers3[2]), number));
                return true;
            }

            return false;
        }
    }
}
