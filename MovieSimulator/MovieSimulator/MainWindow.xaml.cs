using MovieSimulator.Common;
using MovieSimulator.Common.BoardGame.Area;
using MovieSimulator.Common.BoardGame.Characters;
using MovieSimulator.HungerGames;
using MovieSimulator.HungerGames.Characters;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using MovieSimulator.HungerGames.Area;

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

            for (int i = 0; i < GamingEnvironment.Instance.boardGame.size; i++)
            {
                Grid.ColumnDefinitions.Add(new ColumnDefinition());
                Grid.RowDefinitions.Add(new RowDefinition());
            }

            FillBoardGame();

            _instance = this;
        }

        public void UpdateArea(AreaAbstract area)
        {
            for (int i = 0; i < Grid.Children.Count; i++)
            {
                Rectangle e = Grid.Children[i] as Rectangle;

                if (Grid.GetRow(e) == area.x && Grid.GetColumn(e) == area.y)
                    e.Fill = area.Color;
            }
        }

        public void UpdateCharacter(Character character)
        {
            for (int i = 0; i < Grid.Children.Count; i++)
            {
                Rectangle e = Grid.Children[i] as Rectangle;

                if (Grid.GetRow(e) == character.x && Grid.GetColumn(e) == character.y)
                     e.Fill = Brushes.Gold;
            }
        }

        public void FillBoardGame()
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

        private void UpdateSquare_Click(object sender, RoutedEventArgs e)
        {
            GamingEnvironment.Instance.boardGame.areas[1] = new Wall();
            GamingEnvironment.Instance.boardGame.areas[1].UpdateGraphic();
        }

        private void UpdatePersonnage_Click(object sender, RoutedEventArgs e)
        {
            foreach (Character character in GamingEnvironment.Instance.boardGame.characters)
            {
                character.Move();
            }
        }
    }
}