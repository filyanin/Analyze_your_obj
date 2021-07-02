using System.Collections.Generic;


namespace Analyse_your_obj
{
    class MyFaceAnaLizer
    {
        public static bool[] SearchVerticalFaces(List<MyFace> faces, double accuracy)
        {
            bool[] map = new bool[faces.Count];

            for (int i = 0; i < map.Length; i++)
            {
                map[i] = faces[i].Normal.NearToVertical(accuracy);
            }
            return map;

        }

        public static bool[] SearchHorizontalFaces(List<MyFace> faces, double accuracy)
        {
            bool[] map = new bool[faces.Count];

            for (int i = 0; i < map.Length; i++)
            {
                map[i] = faces[i].Normal.NearToHorizontal(accuracy);
            }

            return map;
        }


        //Функция возвращает коллекцию листов, где индекс листа - это номер точки, а содержимое - то, в каких треугольниках используется данная точка
        public static List<List<int>> GetListOfTrianglesUsingPoint(List<MyVertex> vertices, List<MyFace> faces)
        {
            List<List<int>> buffer = new List<List<int>>();

            foreach (var tmp in vertices)
            {
                buffer.Add(new List<int>());
            }

            for (int j = 0; j < faces.Count; j++)
            {

                if (!buffer[faces[j].IndexOfVertex1 - 1].Contains(j))
                {
                    buffer[faces[j].IndexOfVertex1 - 1].Add(j);
                }
                if (!buffer[faces[j].IndexOfVertex2 - 1].Contains(j))
                {
                    buffer[faces[j].IndexOfVertex2 - 1].Add(j);
                }
                if (!buffer[faces[j].IndexOfVertex3 - 1].Contains(j))
                {
                    buffer[faces[j].IndexOfVertex3 - 1].Add(j);
                }
            }

            return buffer;
        }

        //Функция возвращает массив, где индекс - это номер точки в массиве точек поданом на вход, а значение - количество использований данной точки в конкретной плоскости
        public static int[] CountUsingOfPoints(List<MyVertex> vertices, List<MyFace> faces, bool[] map)
        {
            int[] listOfVertices = new int[vertices.Count];
            for (int i = 0; i < listOfVertices.Length; i++)
            {
                listOfVertices[i] = 0;
            }
            for (int i = 0; i < map.Length; i++)
            {
                if (map[i])
                {
                    listOfVertices[faces[i].IndexOfVertex1 - 1]++;
                    listOfVertices[faces[i].IndexOfVertex2 - 1]++;
                    listOfVertices[faces[i].IndexOfVertex3 - 1]++;
                }
            }

            return listOfVertices;
        }

        public static int LiteDeleteLonelyTriangle(List<MyVertex> vertices, List<MyFace> faces, bool[] map)
        {
            int countOfDeletingFaces = 0;

            int[] buffer = CountUsingOfPoints(vertices, faces, map);
            for (int j = 0; j < faces.Count; j++)
            {
                if (map[j])
                {
                    bool IsLonely = ((buffer[faces[j].IndexOfVertex1 - 1] < 2) && (buffer[faces[j].IndexOfVertex2 - 1] < 2) && (buffer[faces[j].IndexOfVertex3 - 1] < 2));

                    if (IsLonely)
                    {
                        map[j] = false;
                        buffer[faces[j].IndexOfVertex1 - 1]--;
                        buffer[faces[j].IndexOfVertex2 - 1]--;
                        buffer[faces[j].IndexOfVertex3 - 1]--;
                        countOfDeletingFaces++;
                    }
                }    
            }
            return countOfDeletingFaces;
        }

        public static int DeepDeleteLonelyTriangle(List<MyVertex> vertices, List<MyFace> faces, bool[] map, int depth)
        {
            int countOfDeletingFaces = 0;

            int[] buffer = CountUsingOfPoints(vertices, faces, map);

            for (int i = 0; i < depth; i++)
            {
                for (int j = 0; j < faces.Count; j++)
                {
                    if (map[j])
                    {
                        bool IsLonely = ((buffer[faces[j].IndexOfVertex1 - 1] < 2) && (buffer[faces[j].IndexOfVertex2 - 1] < 2) && (buffer[faces[j].IndexOfVertex3 - 1] < 2));

                        IsLonely = IsLonely || ((buffer[faces[j].IndexOfVertex1 - 1] < 2) && (buffer[faces[j].IndexOfVertex2 - 1] < 2));
                        IsLonely = IsLonely || ((buffer[faces[j].IndexOfVertex2 - 1] < 2) && (buffer[faces[j].IndexOfVertex3 - 1] < 2));
                        IsLonely = IsLonely || ((buffer[faces[j].IndexOfVertex1 - 1] < 2) && (buffer[faces[j].IndexOfVertex3 - 1] < 2));

                        if (IsLonely)
                        {
                            map[j] = false;
                            buffer[faces[j].IndexOfVertex1 - 1]--;
                            buffer[faces[j].IndexOfVertex2 - 1]--;
                            buffer[faces[j].IndexOfVertex3 - 1]--;
                            countOfDeletingFaces++;
                        }
                    }
                }
            }
            countOfDeletingFaces += LiteDeleteLonelyTriangle(vertices, faces, map);
            return countOfDeletingFaces;
        }

        public static int ExtremeDeleteLonelyTriangle(List<MyVertex> vertices, List<MyFace> faces, bool[] map, int depth)
        {
            int countOfDeletingFaces = 0;

            int[] buffer = CountUsingOfPoints(vertices, faces, map);

            for (int i = 0; i < depth; i++)
            {
                for (int j = 0; j < faces.Count; j++)
                {
                    if (map[j])
                    {
                        bool IsLonely = ((buffer[faces[j].IndexOfVertex1 - 1] < 2) && (buffer[faces[j].IndexOfVertex2 - 1] < 2) && (buffer[faces[j].IndexOfVertex3 - 1] < 2));

                        IsLonely = IsLonely || ((buffer[faces[j].IndexOfVertex1 - 1] < 2) && (buffer[faces[j].IndexOfVertex2 - 1] < 2));
                        IsLonely = IsLonely || ((buffer[faces[j].IndexOfVertex2 - 1] < 2) && (buffer[faces[j].IndexOfVertex3 - 1] < 2));
                        IsLonely = IsLonely || ((buffer[faces[j].IndexOfVertex1 - 1] < 2) && (buffer[faces[j].IndexOfVertex3 - 1] < 2));

                        IsLonely = IsLonely || (buffer[faces[j].IndexOfVertex1 - 1] < 2);
                        IsLonely = IsLonely || (buffer[faces[j].IndexOfVertex2 - 1] < 2);
                        IsLonely = IsLonely || (buffer[faces[j].IndexOfVertex3 - 1] < 2);

                        if (IsLonely)
                        {
                            map[j] = false;
                            buffer[faces[j].IndexOfVertex1 - 1]--;
                            buffer[faces[j].IndexOfVertex2 - 1]--;
                            buffer[faces[j].IndexOfVertex3 - 1]--;
                            countOfDeletingFaces++;
                        }
                    }
                }
            }
            countOfDeletingFaces += LiteDeleteLonelyTriangle(vertices, faces, map);
            return countOfDeletingFaces;
        }

        public delegate bool Operation(double accuracy, MyNormal Normal);
        public static void SearchLostPoint(List<List<int>> listOfIndexFacesUsingPoints, List<MyVertex> vertieces, List<MyFace> faces, bool[] map, Operation operation, int depth, double accuracy)
        {
            
            for (int i = 0; i < depth; i++)
            {
                List<int> buffer = new List<int>();
                int[] usingOfPoints = CountUsingOfPoints(vertieces, faces, map);

                for (int j = 0; j < listOfIndexFacesUsingPoints.Count; j++)
                {
                    if (usingOfPoints[j] > 0)
                    {
                        foreach (var part in listOfIndexFacesUsingPoints[j])
                        {
                            if ((!buffer.Contains(part))&& !map[part])
                            {
                                buffer.Add(part);
                            }
                        }
                    }
                }
                foreach (var tmp in buffer)
                {
                    if (operation(accuracy, faces[tmp].Normal))
                        map[tmp] = true;
                }
            }
        }           
        public static List<List<MyFace>> GetAllSurface(List<List<int>> listOfIndexFacesUsingPoints, List<MyFace> faces, bool[] map, int accuracy)
        {
            
            List<List<MyFace>> result = new List<List<MyFace>>();
            bool[] bufferMap = new bool[map.Length];
            for (int i = 0; i < map.Length; i++)
            {
                bufferMap[i] = map[i];
            }

            for (int i = 0; i < bufferMap.Length; i++)
            {
                if (bufferMap[i])
                {
                    bufferMap[i] = false;

                    List<MyFace> tmp = new List<MyFace>();
                    Queue<int> quenue = new Queue<int>();
                    quenue.Enqueue(i);
                    int workInt;
 
                    while (quenue.Count > 0)
                    {
                        workInt = quenue.Peek();
                        quenue.Dequeue();
                        tmp.Add(faces[workInt]);
                        foreach (var buf in listOfIndexFacesUsingPoints[faces[workInt].IndexOfVertex1 - 1])
                        {
                            if (bufferMap[buf])
                            {
                                bufferMap[buf] = false;
                                quenue.Enqueue(buf);
                            }
                        }
                        foreach (var buf in listOfIndexFacesUsingPoints[faces[workInt].IndexOfVertex2 - 1])
                        {
                            if (bufferMap[buf])
                            {
                                bufferMap[buf] = false;
                                quenue.Enqueue(buf);
                            }
                        }
                        foreach (var buf in listOfIndexFacesUsingPoints[faces[workInt].IndexOfVertex3 - 1])
                        {
                            if (bufferMap[buf])
                            {
                                bufferMap[buf] = false;
                                quenue.Enqueue(buf);
                            }
                        }
                    }
                    if (tmp.Count > accuracy)
                        result.Add(tmp);
                }


            }
            return result;
        }
    }
}
