using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphMinimumWay
{
    public partial class Form1 : Form
    {
        private DrawingGraph drawing;
        private Graph graph;
        private Vertex vertex1;
        private Vertex vertex2;
        private Dijkstra dijkstra;
        public Form1()
        {
            InitializeComponent();
           

            graph = new Graph();
            drawing = new DrawingGraph(graph, pictureBox1.Width, pictureBox1.Height);
            dijkstra = new Dijkstra(graph);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        //рисование графа
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (drawVerdex.Enabled == false) //если нажата кнопка "рисовать вершину"
            {
                drawing.SetVertex(e);
                drawing.DrawGraph();
            }
            if (drawEdge.Enabled == false) //если нажата кнопка "рисовать ребро"
            {
                
                if (vertex1 == null) //если не выбрана стартовая вершина
                {
                    vertex1 = drawing.VertexInRadius(e);
                    drawing.DrawGraph();
                    drawing.DrawSelectedVertex(vertex1);
                } else if (vertex2 == null) //если выбрана стартовая вершина, но не выбрана конечная
                {
                    vertex2 = drawing.VertexInRadius(e);
                    drawing.DrawGraph();
                    drawing.DrawSelectedVertex(vertex1);
                    drawing.DrawSelectedVertex(vertex2);
                }

                if (vertex1 != null && vertex2 != null) //если обе вершины выбраны
                {
                   
                    drawing.DrawGraph();
                    drawing.DrawSelectedVertex(vertex1);
                    drawing.DrawSelectedVertex(vertex2);

                    drawing.SetEdge(vertex1, vertex2); //рисуется ребро

                    //поле для введения веса ребра становится видимым
                    Point p = new Point((vertex1.X + vertex2.X) / 2, (vertex1.Y + vertex2.Y) / 2);
                    textBox1.Location = p;
                    textBox1.Visible = true; //поле для введения веса, нажатие Enter для присваивания веса
                    vertex1 = null;
                    vertex2 = null;
                }

            }
            pictureBox1.Image = drawing.GetBitmap;
        }
        

        private void drawVerdex_Click(object sender, EventArgs e)
        {
            if (drawEdge.Enabled == false)
            {
                drawEdge.Enabled = true;
                drawEdge.Image = global::GraphMinimumWay.Properties.Resources.edge;
            }
            drawVerdex.Enabled = false;
            drawVerdex.Image = global::GraphMinimumWay.Properties.Resources.vertex_pressed;
        }

        private void drawVerdex_MouseDown(object sender, MouseEventArgs e)
        {
            drawVerdex.Image = global::GraphMinimumWay.Properties.Resources.vertex_pointed;
        }

        private void drawVerdex_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawVerdex.Enabled == false) drawVerdex.Image = global::GraphMinimumWay.Properties.Resources.vertex_pressed;
            else drawVerdex.Image = global::GraphMinimumWay.Properties.Resources.vertex;
        }

        private void drawEdge_Click(object sender, EventArgs e)
        {
            if (drawVerdex.Enabled == false)
            {
                drawVerdex.Enabled = true;
                drawVerdex.Image = global::GraphMinimumWay.Properties.Resources.vertex;
            }
            drawEdge.Image = global::GraphMinimumWay.Properties.Resources.edge_pressed;
            drawEdge.Enabled = false;
        }

        private void drawEdge_MouseDown(object sender, MouseEventArgs e)
        {
            drawEdge.Image = global::GraphMinimumWay.Properties.Resources.edge_pointed;
        }

        private void drawEdge_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawEdge.Enabled == false) drawEdge.Image = global::GraphMinimumWay.Properties.Resources.edge_pressed;
            else drawEdge.Image = global::GraphMinimumWay.Properties.Resources.vertex;
        }


        private void toClear_Click(object sender, EventArgs e) // кнопка "очистить". удаляются все вершины и ребра графа
        {
            if (drawVerdex.Enabled == false)
            {
                drawVerdex.Enabled = true;
                drawVerdex.Image = global::GraphMinimumWay.Properties.Resources.vertex;
            }
            if (drawEdge.Enabled == false)
            {
                drawEdge.Enabled = true;
                drawEdge.Image = global::GraphMinimumWay.Properties.Resources.edge;
            }

            if (textBox1.Visible == true)
            {
                textBox1.Visible = false;
                textBox1.Text = "введите вес";
            }

            graph.Clear();
            drawing.Clear();
            pictureBox1.Image = drawing.GetBitmap;

            toClear.Image = global::GraphMinimumWay.Properties.Resources.clear_pressed;
            graph.Clear();
            pictureBox1.Image = drawing.GetBitmap;
            toClear.Image = global::GraphMinimumWay.Properties.Resources.clear;
        }

        private void toClear_MouseDown(object sender, MouseEventArgs e)
        {
            toClear.Image = global::GraphMinimumWay.Properties.Resources.clear_pointed;
        }

        private void toClear_MouseUp(object sender, MouseEventArgs e)
        {
            toClear.Image = global::GraphMinimumWay.Properties.Resources.clear;
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            int weight = 0;
            if (e.KeyCode == Keys.Enter)
            {
                if (Int32.TryParse(textBox1.Text, out weight)) // если введенный текст является числом, то значение 
                                                              // присваивается весу ребра, а текстовое окно делается невидимым
                {
                    drawing.SetWeight(weight);
                    textBox1.Visible = false;
                    drawing.DrawGraph();
                    pictureBox1.Image = drawing.GetBitmap;
                    textBox1.Text = "введите вес";
                }
            }
        }

        private void getMinimum_Click(object sender, EventArgs e) // в ListBox выводится список вершин со значением
                                                                 // длины кратчайшего пути до каждой из низ из стартовой
        {
            verdexList.Items.Clear();
            if (graph != null && graph.Edges != null && graph.Vertexes != null)
            {
                getMinimum.Image = global::GraphMinimumWay.Properties.Resources.iknowdaway_pressed;
                int[] theWays = dijkstra.Search();
                for (int i = 0; i < theWays.Length; i++)
                    verdexList.Items.Add("В " + graph.Vertexes[i].Name + " - " + Convert.ToString(theWays[i]));
                getMinimum.Image = global::GraphMinimumWay.Properties.Resources.iknowdaway;
            }
        }

        private void verdexList_MouseClick(object sender, MouseEventArgs e) 
        {
            // при выборе каждой вершины на графе цветом выделяется кратчайший путь до нее
            drawing.DrawSelectedWay(dijkstra.Way(graph.Vertexes[verdexList.SelectedIndex]));
            pictureBox1.Image = drawing.GetBitmap;
        }

        private void getMinimum_MouseDown(object sender, MouseEventArgs e)
        {
            getMinimum.Image = global::GraphMinimumWay.Properties.Resources.iknowdaway_pointed;
        }

        private void getMinimum_MouseUp(object sender, MouseEventArgs e)
        {
            getMinimum.Image = global::GraphMinimumWay.Properties.Resources.iknowdaway;
        }

        private void textBox1_TextChanged (object sender, EventArgs e)
        {

        }

        private void verdexList_SelectedIndexChanged (object sender, EventArgs e)
        {

        }
    }
}
