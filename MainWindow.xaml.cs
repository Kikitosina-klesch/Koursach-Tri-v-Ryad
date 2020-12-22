using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Koursach_Tri_v_Ryad
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int bSize = 60;

        
        BitmapImage[] typedpic = new BitmapImage[] 
        {

            new BitmapImage(new Uri(@"pack://application:,,,/imgs/0.png", UriKind.Absolute)),
            new BitmapImage(new Uri(@"pack://application:,,,/imgs/1.png", UriKind.Absolute)),
            new BitmapImage(new Uri(@"pack://application:,,,/imgs/2.png", UriKind.Absolute)),
            new BitmapImage(new Uri(@"pack://application:,,,/imgs/3.png", UriKind.Absolute)),
            new BitmapImage(new Uri(@"pack://application:,,,/imgs/4.png", UriKind.Absolute)),
            new BitmapImage(new Uri(@"pack://application:,,,/imgs/5.png", UriKind.Absolute)),

        };

        Element[,] elfield = new Element[w, w];

        GameLogic GameLog;

        Random rng = new Random();

        const int w = 8;
        const int nulltipe = -99;
        int score;

        public MainWindow()
        {
            InitializeComponent();

            unigrid.Rows = w;
            unigrid.Columns = w; 

            unigrid.Width = w * (bSize + 4);
            unigrid.Height = w * (bSize + 4);

            unigrid.Margin = new Thickness(5, 5, 5, 5);

            GameLog = new GameLogic(elfield);
            GameLog.Falled += Falled;

            for (int i = 0; i < w; i++)
                for (int j = 0; j < w; j++)
                {
                    elfield[i, j] = new Element(rng.Next(0, 6), i + j * w);
                    StackPanel stackPanel = new StackPanel();
                    //stackPanel.Children.Add(pic);
                    stackPanel.Margin = new Thickness(1);
                    elfield[i, j].b.Click += Btn_Click;    
                    unigrid.Children.Add(elfield[i, j].b);
                }

            //GameLog.TriVRyad();
            
            //for (int j = w - 1; j >= 0; j--)
            //    for (int i = w - 2; i >= 0; i--)
            //    {
            //        if (elfield[i, j].typeofb == 9)
            //            GameLog.FallCells();
            //    }

            Update();
        }

        private void Falled(object sender, EventArgs args)
        {
            Application.Current.Dispatcher.Invoke(delegate
            {
                Update();
            });

            
        }

        void Update()
        {
            for (int i = 0; i < w; i++)
                for (int j = 0; j < w; j++)
                {         
                    StackPanel stack = new StackPanel();
                    //stack.Children.Add(elfield[i, j].setType());

                    int typeel = elfield[i, j].typeofpic;
                    if(typeel != nulltipe)
                    {
                        BitmapImage image = typedpic[typeel];
                        stack = getPanel(image);
                    }

                    elfield[i, j].b.Content = stack;
                }

            //GameLog.TriVRyad();
            //for (int j = w - 1; j >= 0; j--)
            //    for (int i = w - 2; i >= 0; i--)
            //    {
            //        if (elfield[i, j].typeofb == 9)
            //            GameLog.FallCells();
            //    }
        }

        StackPanel getPanel(BitmapImage picture)
        {
            StackPanel stackPanel = new StackPanel();
            Image image = new Image();            
            image.Source = picture;
            stackPanel.Children.Add(image);
            stackPanel.Margin = new Thickness(1);

            return stackPanel; 
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            int index = (int)(((Button)sender).Tag);

            int i = index % w;
            int j = index / w;

            GameLog.moveCell(i, j);

            //score += GameLog.moveCell(i, j).Count * 5;
            //totalscore.Content = "ВАШ СЧЕТ: " + Convert.ToString(score);

            Update();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void TriDyad_Click(object sender, RoutedEventArgs e)
        {
            GameLog.TriVRyad();

            //score += GameLog.TriVRyad().Count * 5;
            totalscore.Content = "ВАШ СЧЕТ: " + Convert.ToString(GameLog.score);

            Update();
        }

        private void Fall_Click(object sender, RoutedEventArgs e)
        {            
            GameLog.FallCells();

            Update();
        }
    }
}
