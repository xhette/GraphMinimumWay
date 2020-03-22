using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphMinimumWay
{
    class DrawingGraph
    {
        private Graph graph;
        //графические инструменты
        private Bitmap bitmap;
        private Pen gray;
        private Pen orange;
        private Pen arrow;
        private Graphics graphic;
        private Font font;
        private Brush brush;
        private Brush brush2;
        private Brush fill;
        private PointF point;
        private int R = 15;

        public DrawingGraph(Graph graph, int width, int height)
        {
            this.graph = graph;

            bitmap = new Bitmap(width, height);
            graphic = Graphics.FromImage(bitmap);
            gray = new Pen(Color.DarkGray);
            gray.Width = 2;
            orange = new Pen(Color.DarkOrange);
            orange.Width = 2;
            arrow = new Pen(Color.Black);
            arrow.EndCap = LineCap.ArrowAnchor;
            brush = Brushes.DarkGray;
            brush2 = Brushes.Black;
            fill = Brushes.WhiteSmoke;
            font = new Font("Times New Roman", 10);
        }

      

        public Bitmap GetBitmap
        {
            get
            {
                return this.bitmap;
            }
        }

        public void SetVertex(MouseEventArgs e)
        {
            graph.AddVertex(e.X, e.Y);
        }

        /// <summary>
        /// рисуем вершину
        /// </summary>
        /// <param name="v"></param>
        private void DrawVertex(Vertex v)
        {
            point = new PointF(v.X-6, v.Y-6);
            graphic.FillEllipse(fill, (v.X - R), (v.Y - R), 2 * R, 2 * R);
            graphic.DrawEllipse(gray, (v.X - R), (v.Y - R), 2 * R, 2 * R);
            graphic.DrawString(v.Name, font, brush, point);
        }

        /// <summary>
        /// рисуем выделенную вершину
        /// </summary>
        /// <param name="v"></param>
        public void DrawSelectedVertex(Vertex v)
        {
            if (v != null)
            {
                point = new PointF(v.X - 6, v.Y - 6);
                graphic.DrawEllipse(orange, (v.X - R), (v.Y - R), 2 * R, 2 * R);
                graphic.DrawString(v.Name, font, brush, point);
            }
        }

        /// <summary>
        /// обработка клика по вершине
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public Vertex VertexInRadius(MouseEventArgs e)
        {
            Vertex v1 = null;
            foreach (var v in graph.Vertexes)
            {
                if (Math.Pow((v.Value.X - e.X), 2) + Math.Pow((v.Value.Y - e.Y), 2) <= R * R)
                {
                    v1 = v.Value;
                }
            }
            return v1;
        }

        /// <summary>
        /// соединение двух вершин ребром
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        public void SetEdge(Vertex v1, Vertex v2)
        {
            if (v1 != null && v2 != null)
            {
                graph.AddEdge(v1, v2);
            }
        }

        /// <summary>
        /// присваивание веса ребру
        /// </summary>
        /// <param name="value"></param>
        public void SetWeight (int value)
        {
            if (value > 0)
            {
                graph.Edges[graph.Edges.Count - 1].Weight = value;
            }
        }

        /// <summary>
        /// рисуем ребро
        /// </summary>
        /// <param name="e"></param>
        private void DrawEdge(Edge e)
        {
            if (e != null)
            {
                PointF p1 = new PointF(e.StartVertex.X, e.StartVertex.Y);
                PointF p2 = new PointF(e.FinalVertex.X, e.FinalVertex.Y);
                PointF arrowPoint1 = new PointF();
                PointF arrowPoint2 = new PointF();

                PointF point = new PointF((e.StartVertex.X + e.FinalVertex.X) / 2, (e.StartVertex.Y + e.FinalVertex.Y) / 2);

                if (e.IsBezier)
                {
                    PointF p12 = new PointF(e.StartVertex.X + 35, e.StartVertex.Y + 35);
                    PointF p22 = new PointF(e.FinalVertex.X + 35, e.FinalVertex.Y + 35);
                    point = new PointF(e.FinalVertex.X + 15, e.FinalVertex.Y + 15);

                    graphic.DrawBezier(gray, p1, p12, p22, p2);
                }
                else
                {
                    graphic.DrawLine(gray, p1, p2);
                    graphic.DrawLine(arrow, arrowPoint1, arrowPoint2);
                }


                graphic.DrawString(Convert.ToString(e.Weight), font, brush2, point);
            }
        }

        /// <summary>
        /// отрисовка выбранного ребра
        /// </summary>
        /// <param name="e"></param>
        public void DrawSelectedEdge(Edge e)
        {
            if (e != null)
            {
                PointF p1 = new PointF(e.StartVertex.X, e.StartVertex.Y);
                PointF p2 = new PointF(e.FinalVertex.X, e.FinalVertex.Y);

                if (e.IsBezier)
                {
                    PointF p12 = new PointF(e.StartVertex.X + 35, e.StartVertex.Y + 35);
                    PointF p22 = new PointF(e.FinalVertex.X + 35, e.FinalVertex.Y + 35);
                    point = new PointF(e.FinalVertex.X + 15, e.FinalVertex.Y + 15);

                    graphic.DrawBezier(orange, p1, p12, p22, p2);
                }
                else
                {
                    point = new PointF((e.StartVertex.X + e.FinalVertex.X) / 2 + 3, (e.StartVertex.Y + e.FinalVertex.Y) / 2 + 3);
                    graphic.DrawLine(orange, p1, p2);
                }
            }
        }


        public void DrawGraph()
        {
            Clear();
            foreach (var e in graph.Edges) DrawEdge(e);
            foreach (var v in graph.Vertexes) DrawVertex(v.Value);
        }

        /// <summary>
        /// отрисовка пути5
        /// </summary>
        /// <param name="ways"></param>
        public void DrawSelectedWay(List<Edge> ways)
        {
            if (ways != null)
            {
                Clear();
                foreach (var e in graph.Edges) DrawEdge(e);
                foreach (var w in ways) if (w != null) DrawSelectedEdge(w);
                foreach (var v in graph.Vertexes) DrawVertex(v.Value);
                foreach (var w in ways) if (w != null) DrawSelectedVertex(w.StartVertex);
                if (ways.Count != 0) DrawSelectedVertex(ways[ways.Count - 1].FinalVertex);
            }
        }

        public void Clear()
        {
            graphic.Clear(Color.WhiteSmoke);
        }
    }
}
