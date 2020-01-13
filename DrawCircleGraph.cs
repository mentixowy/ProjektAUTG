using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Grafy
{
    public class DrawCircleGraph
    {
        Random rnd;
        private int[,] VertexArray;
        private int[,] VertexMatrix;

        private int counter;
        int[,] TablicaWag;

        public void DrawLines(int ile)
        {
            UIGlobal.MainPage.sp.Children.Clear();
            double r = 200;
            draw.circle(100, 100, 400, 400, UIGlobal.MainPage.sp);

            counter = 0;

            //dodawanie wierzchołkow do combo box
            AddingVertex AddVertex = new AddingVertex();
            AddVertex.Send(ile);

            TablicaWag = new int[ile, ile];
            VertexArray = new int[ile, ile];
            double kat = 360 / ile;
            double radians = kat / 180 * Math.PI;
            for (int i = 0; i < ile; i++)
            {
                int left, top;
                left = (int) (r * Math.Cos(kat + i) + 290);
                top = (int) (r * Math.Sin(kat + i) + 290);

                //wpisujemy do tablicy

                VertexArray[i, 1] = left;
                VertexArray[i, 2] = top;
            }
            VertexMatrix=new int[ile,ile];
            for (int i = 0; i < ile; i++)
            {
                for (int j = 0; j < ile; j++)
                {
                    VertexMatrix[i, j] = 0;
                }
            }
            int RandomDraw;
            rnd = new Random();
            for (int i = 0; i < ile; i++)
            {
                for (int j = 0; j < ile; j++)
                {
                    if (i != j)
                    {
                        RandomDraw = rnd.Next(0, 100);
                        if (RandomDraw < UIGlobal.MainPage.slider.Value && VertexMatrix[i, j] == 0)
                        {
                            //by nie rysować2 razy tej samej krawedzi
                            VertexMatrix[i, j] = 1;
                            VertexMatrix[j, i] = 1;
                            var line = new Line();
                            line.Stroke = Brushes.Black;
                            line.X1 = VertexArray[i, 1] + 10;
                            line.Y1 = VertexArray[i, 2] + 10;
                            line.X2 = VertexArray[j, 1] + 10;
                            line.Y2 = VertexArray[j, 2] + 10;
                            ////////////////////////////////////////////
                            int temp = rnd.Next(1, 10);
                            TablicaWag[i, j] = temp;


                            TablicaWag[j, i] = temp;

                            //
                            //rywoanie wag w połowie lini
                            TextBlock waga = new TextBlock();
                            waga.Text = TablicaWag[i, j].ToString();
                            waga.Foreground = new SolidColorBrush(Colors.Red);
                            Canvas.SetLeft(waga, (Math.Abs((VertexArray[j, 1] + VertexArray[i, 1]) / 2)));
                            Canvas.SetTop(waga, (Math.Abs((VertexArray[j, 2] + VertexArray[i, 2]) / 2)));
                            UIGlobal.MainPage.sp.Children.Add(waga);
                            ///////////////////////////////////////////////
                            line.StrokeThickness = 2;
                            UIGlobal.MainPage.sp.Children.Add(line);

                            counter++;
                        }
                    }
                }
            }
        }

      

        public int[,] loadVertexMatrix()
        {
            return VertexMatrix;
        }

        public int loadCounter()
        {
            return counter;
        }

        public int[,] loadWagi()
        {
            return TablicaWag;
        }

        public void DrawButtons(int ile)
        {
            for (int i = 0; i < ile; i++)
            {
                var btn = new Button();
                TextBlock textBlock = new TextBlock()
                {
                    Text = i.ToString(),
                    TextAlignment = TextAlignment.Center,
                    FontSize = 10
                };
                btn.Content = textBlock;
                btn.Width = 20;
                btn.Height = 20;
                Thickness padd = new Thickness();
                padd.Left = 0;
                btn.Padding = padd;
                Thickness ts = new Thickness();
                ts.Left = VertexArray[i, 1];
                ts.Top = VertexArray[i, 2];
                btn.Margin = ts;
                UIGlobal.MainPage.sp.Children.Add(btn);
            }
        }
    }
}