using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphMinimumWay
{
    /// <summary>
    /// вершина
    /// </summary>
    class Vertex
    {
        private string name; //название вершины
        private int x; //координата x для графического интерфейса
        private int y; //координата y для графического интерфейса

        public Vertex Before { get; set; }

        public int Mark { get; set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="name">название вершины</param>
        /// <param name="x">координата x</param>
        /// <param name="y">координата y</param>
        public Vertex(string name, int x, int y)
        {
            this.name = name;
            this.x = x;
            this.y = y;

            if (name == "s0")
            {
                this.Mark = 0;
            }
            else
            {
                this.Mark = 9999;
            }
        }

        /// <summary>
        /// возвращает имя  текущей вершины
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// возвращает координату х текущей вершины
        /// </summary>
        public int X
        {
            get
            {
                return this.x;
            }
        }

        /// <summary>
        /// возвращает координату у текущей вершины
        /// </summary>
        public int Y
        {
            get
            {
                return this.y;
            }
        }
    }

    /// <summary>
    /// ребро
    /// </summary>
    class Edge
    {
        private string name; // название
        private Vertex v1; // начальная вершина
        private Vertex v2; // конечная вершина
        private int weight; //вес

        /// <summary>
        /// конструкор класса
        /// </summary>
        /// <param name="name">имя</param>
        /// <param name="v1">стартовая вершина</param>
        /// <param name="v2">конечная вершина</param>
        public Edge(string name, Vertex v1, Vertex v2)
        {
            this.name = name;
            this.v1 = v1;
            this.v2 = v2;
            this.weight = 0;
            this.IsBezier = false;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value >= 0) weight = value;
            }
        }

        public Vertex StartVertex
        {
            get
            {
                return v1;
            }
        }
        public Vertex FinalVertex
        {
            get
            {
                return v2;
            }
        }

        public bool IsBezier { get; set; }

        public bool SamePoints (Edge e2)
        {
            bool result = false;

            if (this.StartVertex.X == e2.FinalVertex.X && e2.StartVertex.Y == this.FinalVertex.Y)
            {
                result = true;
            }
            else if (this.FinalVertex.X == e2.StartVertex.X && e2.FinalVertex.Y == this.StartVertex.Y)
            {
                result = true;
            }

            return result;
        }
    }


    /// <summary>
    /// граф
    /// </summary>
    class Graph
    {
        /// <summary>
        /// список вершин
        /// </summary>
        private Dictionary<int, Vertex> vertexes;
        /// <summary>
        /// список рёбер
        /// </summary>
        private List<Edge> edges;

        /// <summary>
        /// конструктор
        /// </summary>
        public Graph()
        {
            vertexes = new Dictionary<int, Vertex>();
            edges = new List<Edge>();
        }

        /// <summary>
        /// добавление вершины
        /// </summary>
        /// <param name="x">координата х</param>
        /// <param name="y">коорлината у</param>
        public void AddVertex(int x, int y) //добавление вершины
        {
            
            string name = "s" + Convert.ToString(vertexes.Count);
            Vertex v = new Vertex(name, x, y);
            vertexes.Add(vertexes.Count, v);
        }

        /// <summary>
        /// ребро
        /// </summary>
        /// <param name="v1">начальная вершина</param>
        /// <param name="v2">конечная вершина</param>
        public void AddEdge(Vertex v1, Vertex v2) //добавление ребра
        {
            string name = Convert.ToString((char)(97 + edges.Count));
            Edge edg = new Edge(name, v1, v2);

            foreach (Edge e in edges)
            {
                if (edg.SamePoints(e))
                {
                    edg.IsBezier = true;
                    break;
                }
            }
            edges.Add(edg);
        }

        public Dictionary<int, Vertex> Vertexes //возвращает список вершин
        {
            get
            {
                return vertexes;
            }
        }

        public List<Edge> Edges // возвращает список ребер
        {
            get
            {
                return edges;
            }
        }

        public void SetWeight(Edge e, int weight) //устанавливает вес ребра
        {
            e.Weight = weight;
        }

        public Vertex SearchVertex(string name) //осуществляет поиск вершины по имени
        {
            Vertex v = null;
            foreach(var vertex in vertexes)
            {
                if (name == vertex.Value.Name)
                {
                    v = vertex.Value;
                    break;
                }
            }
            return v;
        }

        public Vertex SearchVertex(int x, int y) //осуществляет поиск вершины по координатам
        {
            Vertex v = null;
            foreach (var vertex in vertexes)
            {
                if (x == vertex.Value.X && y == vertex.Value.Y)
                {
                    v = vertex.Value;
                    break;
                }
            }
            return v;
        }

        private int SearchIndex(Vertex v)//осуществляет поиск ключа вершины в Dictionary <int, Vertex> vertexes
        {
            int i = -1;
            foreach (var vertex in vertexes)
            {
                if (v == vertex.Value)
                {
                    i = vertex.Key;
                    break;
                }
            }
            return i;
        }

        /// <summary>
        /// поиск ребра, соединяющего две заданные вершины
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public Edge SearchEdgeByVertexes(Vertex v1, Vertex v2)
        {
            Edge e = null;
            foreach (var edg in edges)
            {
                if (edg.StartVertex == v1 && edg.FinalVertex == v2)
                {
                    e = edg;
                    break;
                }
            }
            return e;
        }

        public int[,] Ways() //возвращает матрицу смежностей графа
        {
            int[,] ways = new int[vertexes.Count, vertexes.Count];

            for (int i = 0; i < vertexes.Count; i++)
            {
                for (int j = 0; j < vertexes.Count; j++) ways[i, j] = 0;
            }

            foreach (var edg in edges)
            {
                int i = Convert.ToInt32(edg.StartVertex.Name.Substring(1));
                int j = Convert.ToInt32(edg.FinalVertex.Name.Substring(1));
                ways[i, j] = edg.Weight;
            }

            return ways;
        }

        /// <summary>
        /// уничтожает все вершины и рёбра
        /// </summary>
        public void Clear()
        {
            vertexes.Clear();
            edges.Clear();
        }
    }

   
}
