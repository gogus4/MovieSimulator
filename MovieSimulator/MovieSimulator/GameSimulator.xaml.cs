using MovieSimulator.Common;
using MovieSimulator.Common.BoardGame.Area;
using MovieSimulator.Common.BoardGame.Characters;
using MovieSimulator.HungerGames;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using MovieSimulator.HungerGames.Area;
using System.Collections.Generic;
using MovieSimulator.Common.Statements;
using MovieSimulator.Common.BoardGame.Memento;
using System.Linq;
using MovieSimulator.Common.BoardGame.Observer;

namespace MovieSimulator
{
    public partial class GameSimulator : Window
    {
        private static GameSimulator _instance;
        public static GameSimulator Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameSimulator();

                return _instance;
            }
        }

        private StatementGame _statementGame;
        public StatementGame statementGame
        {
            get
            {
                return _statementGame;
            }
            set
            {
                _statementGame = value;
                if (_statementGame.GetType() == typeof(StatementGameFinish))
                {
                    _statementGame.Execute();
                }
            }
        }

        public Caretaker caretaker { get; set; }
        public Originator originator { get; set; }

        public GameSimulator()
        {
            InitializeComponent();

            //GamingEnvironment.Instance.CreateBoardGame(new FactoryBoardGameHungerGames(), 20);

            _instance = this;

            statementGame = new StatementGameInit();
            statementGame.Execute();

            caretaker = new Caretaker();
            originator = new Originator();
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
            statementGame.Execute();
        }

        private void SendMessageToAllPerson_Click(object sender, RoutedEventArgs e)
        {
            GamingEnvironment.Instance.boardGame.ChangeObserverMode(EMode.ListenMessage);
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            GamingEnvironment.Instance.boardGame.ChangeObserverMode(EMode.DoMyReport);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (caretaker.Current < caretaker.savedMemento.Count)
            {
                originator.RestoreFromMemento(caretaker.GetMemento(caretaker.Current));

                foreach (Character character in GamingEnvironment.Instance.boardGame.characters)
                {
                    var area = GamingEnvironment.Instance.boardGame.areas.Where(x => x.x == character.x && x.y == character.y).FirstOrDefault();
                    area.UpdateGraphic();
                }

                GamingEnvironment.Instance.boardGame.characters = originator.characters;

                foreach (Character character in GamingEnvironment.Instance.boardGame.characters)
                    character.command.UpdateCharacterBoardGame(character);
            }

            else
            {
                statementGame.Execute();

                originator.characters = new List<Character>(GamingEnvironment.Instance.boardGame.characters);
                caretaker.AddMemento(new Memento(GamingEnvironment.Instance.boardGame.characters));
            }

            caretaker.Current++;
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            if (caretaker.Current == 0) MessageBox.Show("Erreur impossible d'executer le bouton Précédent");

            else
            {
                caretaker.Current--;

                originator.RestoreFromMemento(caretaker.GetMemento(caretaker.Current));

                foreach (Character character in GamingEnvironment.Instance.boardGame.characters)
                {
                    var area = GamingEnvironment.Instance.boardGame.areas.Where(x => x.x == character.x && x.y == character.y).FirstOrDefault();
                    area.UpdateGraphic();
                }

                GamingEnvironment.Instance.boardGame.characters = originator.characters;

                foreach (Character character in GamingEnvironment.Instance.boardGame.characters)
                    character.command.UpdateCharacterBoardGame(character);
            }
        }

        private void NewSimulation_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}