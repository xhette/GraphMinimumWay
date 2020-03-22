using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphMinimumWay
{
    class Dijkstra
    {
        /// <summary>
        /// граф
        /// </summary>
        protected Graph graph;

        /// <summary>
        /// метки вершин
        /// </summary>
        protected int[] vertexMarks;

        /// <summary>
        /// матрица смежностей 
        /// </summary>
        protected int[,] ways;

        public Dijkstra(Graph graph)
        {
            this.graph = graph;
        }

        private int[] VertexMarks() //массив меток вершин
        {
            int[] vertexMarks = new int[graph.Vertexes.Count];
            for (int i = 0; i < vertexMarks.Length; i++)
            {
                if (i == 0) vertexMarks[i] = 0; // если начальная вершина, то путь до нее нулевой
                else vertexMarks[i] = 9999; // до остальных бесконечность

            }

            return vertexMarks;
        }

        public int[] Search() //алгоритм Дейкстры
        {
            ways = graph.Ways();
            vertexMarks = VertexMarks();

            //заполнение массива меток 
            foreach (var vertex in graph.Vertexes)
            {
                int index = Convert.ToInt32(vertex.Value.Name.Substring(1));

                for (int i = 0; i < ways.GetLength(1); i++)
                {
                    int weight = ways[index, i];
                    string final = "s" + i;
                    Vertex finalVertex = graph.SearchVertex(final);

                    if (weight != 0)
                    {
                        if (weight + vertex.Value.Mark < finalVertex.Mark)
                        {
                            finalVertex.Mark = weight + vertex.Value.Mark;

                            finalVertex.Before = vertex.Value;

                            ChangeMarks(finalVertex);
                        }
                    }
                }
            }

            for (int i = 0; i < vertexMarks.Length; i++)
            {
                string name = "s" + i;
                Vertex vertex = graph.SearchVertex(name);
                vertexMarks[i] = vertex.Mark;

            }
            return vertexMarks;
        }

        public List<Edge> Way(Vertex v) //вывод кратчайшего пути от начальной вершины до требуемой
        {
            List<Edge> minWay = new List<Edge>();

            Vertex after = v;
            Vertex before = after.Before;

            while (before != null)
            {
                Edge e = graph.SearchEdgeByVertexes(before, after);
                minWay.Add(e);

                after = before;
                before = after.Before;
            }
            
            return minWay;
        }


        private void ChangeMarks(Vertex v)
        {
            if (v != null)
            {
                int index = Convert.ToInt32(v.Name.Substring(1));

                for (int j = 0; j < ways.GetLength(1); j++)
                {
                    string name = "s" + j;
                    Vertex secondVertex = graph.SearchVertex(name);

                    if (ways[index, j] > 0)
                    {
                        int finalWeight = v.Mark + ways[index, j];

                        if (finalWeight < secondVertex.Mark)
                        {
                            secondVertex.Mark = finalWeight;
                            secondVertex.Before = v;

                            ChangeMarks(secondVertex);
                        }
                    }
                }
            }
        }
    }

  
}
