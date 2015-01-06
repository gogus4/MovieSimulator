using MovieSimulator.Common;
using MovieSimulator.Common.BoardGame;
using MovieSimulator.Common.BoardGame.Area;
using MovieSimulator.HungerGames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace MovieSimulator
{
    public partial class MainWindow : Window
    {
        private static MainWindow _instance;
        public static MainWindow Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainWindow();

                return _instance;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            GamingEnvironment.Instance.CreateBoardGame(new FactoryBoardGameHungerGames(), 20);

            Grid.ShowGridLines = true;
            for (int i = 0; i < GamingEnvironment.Instance.boardGame.size; i++)
            {
                Grid.ColumnDefinitions.Add(new ColumnDefinition());
                Grid.RowDefinitions.Add(new RowDefinition());
            }

            Refresh();

            AreaAbstract area = new Square();
            area.Color = Brushes.Black;
            area.x = 0;
            area.y = 0;
        }

        public void Update(AreaAbstract area)
        {
            Rectangle ai = new Rectangle();
            ai.AllowDrop = true;
            ai.Fill = area.Color;
            Grid.SetRow(ai, area.x);
            Grid.SetColumn(ai, area.y);

            Grid.Children.Add(ai);
        }

        public void Refresh()
        {
            for (int i = 0; i < GamingEnvironment.Instance.boardGame.areas.Count; i++)
            {
                Rectangle ai = new Rectangle();
                ai.AllowDrop = true;
                ai.Fill = GamingEnvironment.Instance.boardGame.areas[i].Color;
                Grid.SetRow(ai, GamingEnvironment.Instance.boardGame.areas[i].x);
                Grid.SetColumn(ai, GamingEnvironment.Instance.boardGame.areas[i].y);

                Grid.Children.Add(ai);
            }
        }
    }
}
