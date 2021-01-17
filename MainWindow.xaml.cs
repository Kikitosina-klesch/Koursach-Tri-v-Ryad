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

        Element[,] elfield = new Element[w, w]; //массив игровых ячеек
        GameLogic GameLog; //переменная класса игровой механики
        
        
        const int w = 8; //константа размера поля
        const int nulltipe = -99; //константа пустого типа ячеек
        const int missscore = 5 * ((w - 2) * 3 * w * 2); //константа погрешности при подсчете очков
        const int moves = 10; //константа числа ходов

        JsonSaveLoadProgress j = new JsonSaveLoadProgress(); // переменная класса сохранения и загрузки прогресса

        Player p; //переменная класса игрока
        List<Player> ratelist = new List<Player>(); //список рейтинга игроков
       
        //при запуске программы создается пустое поле
        public MainWindow()
        {
            ratelist.Clear();

            InitializeComponent();

            unigrid.Rows = w;
            unigrid.Columns = w;

            unigrid.Width = w * (bSize + 4);
            unigrid.Height = w * (bSize + 4);

            unigrid.Margin = new Thickness(5, 5, 5, 5);

            GameLog = new GameLogic(elfield);

            
        }

        //специальный метод для реализации автоматического падения
        private void Falled(object sender, EventArgs args)
        {
            Application.Current.Dispatcher.Invoke(delegate
            {
                Update();
            });
        }

        //вызывается при каждом изменении данных о типе картинок в игровом поле и отображает эти изменения,
        //также отображает число очков и оставшиеся ходы
        //при истеченнии ходов очищает игровое поле
        void Update()
        {            
            for (int i = 0; i < w; i++)
                for (int j = 0; j < w; j++)
                {         
                    StackPanel stack = new StackPanel();
                   
                    int typeel = elfield[i, j].typeofpic;
                    if(typeel != nulltipe)
                    {
                        BitmapImage image = typedpic[typeel];
                        stack = getPanel(image);

                    }

                    elfield[i, j].b.Content = stack;
                }

            totalscore.Content = Convert.ToString(GameLog.getScore() - missscore);
            Lefthod.Content = "ОСТАЛОСЬ ХОДОВ: " + GameLog.movesleft;

            if (GameLog.getMovesleft() == 0)
                unigrid.Children.Clear();
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

            totalscore.Content = Convert.ToString(GameLog.getScore() - missscore);
            Update();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            string name = Convert.ToString(PlayerName.Content); //получает введенное имя игрока из лейбла имени 

            //если имя игрока присутсвует, то генерируется игровое поле 
            //иначе сообщается, что имя не было введено
            if (name != "Вы играете за: ")
            {
                for (int i = 0; i < w; i++)
                    for (int j = 0; j < w; j++)
                    {
                        elfield[i, j] = new Element(nulltipe, i + j * w);
                        StackPanel stackPanel = new StackPanel();
                        stackPanel.Margin = new Thickness(1);
                        elfield[i, j].b.Click += Btn_Click;
                        unigrid.Children.Add(elfield[i, j].b);
                    }


                GameLog.GameSetScore(0); //устанавливается начальный счет
                GameLog.setMovesLeft(moves); //устанавливается начальное чилсо ходов
                GameLog.Falled += Falled;
                Update();
                GameLog.StartFall();
            }
            else
                MessageBox.Show("У вас пустое имечко(((");               
        }

        
        private void NameChange_Click(object sender, RoutedEventArgs e)
        {
            bool proverka = true;
            AddName win2 = new AddName();
            if (win2.ShowDialog() == true)
            {
                
                foreach (Player pl in ratelist)
                    if (win2.Name.Text == pl.name)
                    {
                        MessageBox.Show("Это имя уже занято >:(");

                        proverka = false;
                    }
                if (proverka == true)
                {
                    GameLog.GameSetScore(0);
                    p = new Player(win2.Name.Text, 0);
                    PlayerName.Content = "Вы играете за: " + p.getName();
                }               
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Rate.Items.Clear();
            p.setScore(Convert.ToInt32(totalscore.Content));

            ratelist.Add(p);

            var sortedPlayers = from r in ratelist
                                orderby r.score descending
                                select r;

            foreach (Player p in sortedPlayers)
                Rate.Items.Add(p.name + ":     " + p.score);

            PlayerName.Content = "";
            totalscore.Content = "";

            j.SaveFile(ratelist);
        }

        private void Load_Click_1(object sender, RoutedEventArgs e)
        {
            Rate.Items.Clear();

            ratelist = j.LoadFile();

            //сортировка списка рейтинга по убыванию числа набранных очков
            var sortedPlayers = from r in ratelist
                                orderby r.score descending
                                select r;

            foreach (Player p in sortedPlayers)
                Rate.Items.Add(p.name + ":     " + p.score);
        }
    }
}
