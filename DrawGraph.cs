using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Grafy
{
    class DrawGraph
    {
        Random rnd;
        private int[,] VertexArray;
        private int[,] VertexMatrix;
        
        private int counter;
        int[,] TablicaWag;

        public void DrawLines(int ile)
        {
            VertexArray  = new int[ile,3];
            VertexMatrix   = new int[ile, ile];
           
            counter   = 0;
            
            
            UIGlobal.MainPage.sp.Children.Clear();
            rnd = new Random();
            for (int i = 0; i < ile; i++)
            {
                int left, top;
                left = rnd.Next(50, 500);
                top = rnd.Next(50, 500);

                VertexArray[i, 0] = i;
                VertexArray[i, 1] = left;
                VertexArray[i, 2] = top;

            }
            
            TablicaWag = new int[ile, ile];
            //inital with 0
            for (int i = 0; i < ile; i++)
            {
                for (int j = 0; j < ile; j++)
                {
                    VertexMatrix[i, j] = 0;
                }
            }
            int RandomDraw;

          
            for (int i=0; i<ile;i++)
            {
                for (int j = 0; j < ile; j++)
                {
                    if(i!=j)
                    {
                        RandomDraw = rnd.Next(0, 100);
                        if (RandomDraw <    UIGlobal.MainPage.slider.Value && VertexMatrix[i,j] == 0)
                        {
                            //by nie rysowac dwa razy tej samej linii
                            VertexMatrix[i, j] = 1;
                            VertexMatrix[j, i] = 1;
                            

                            var line = new Line();
                            line.Stroke = Brushes.Black;
                            line.X1 = VertexArray[i, 1] + 10;
                            line.Y1 = VertexArray[i, 2] + 10;
                            line.X2 = VertexArray[j, 1] + 10;
                            line.Y2 = VertexArray[j, 2] + 10;
                           //
                           if (VertexMatrix[i,j]==1)
                           {
                               //[K]waga w połowie

                               //Tablica wag 

                       
                               int temp=rnd.Next(1, 10);
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
                           }
                           
                            //
                            line.StrokeThickness = 2;
                            UIGlobal.MainPage.sp.Children.Add(line);
                            counter++; //liczymy ile krawedzi
                        }
                    }
                }
            }
        }
      
        public  int[,] loadVertexMatrix()
        {
            return VertexMatrix;
        } public  int loadCounter()
        {
            return counter;
        }
public  int[,] loadWagi()
        {
            return TablicaWag;
        }
        public void DrawButtons(int ile )
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
                ts.Left = VertexArray[i,1];
                ts.Top = VertexArray[i,2];
                btn.Margin = ts;
                UIGlobal.MainPage.sp.Children.Add(btn);
            }
        }
    }
   
    
    
    
    
}
