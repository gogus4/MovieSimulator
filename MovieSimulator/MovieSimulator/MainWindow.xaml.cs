using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using MovieSimulator.Common;
using MovieSimulator.Common.BoardGame.Factory;
using MovieSimulator.Common.Menu.TileMenu;
using MovieSimulator.HungerGames;

namespace MovieSimulator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Tiles.MenuEntries = Configuration.Instance.GetSimulators();
        }

        private void Tiles_MenuClick(object sender, TileMenuClickEventArgs e)
        {
            string simulator = e.Entry.Name.Replace(" ", "");
            Configuration.Instance.CurrentSimulator = simulator;

            Type type = Assembly.GetExecutingAssembly().GetType("MovieSimulator." + simulator + ".FactoryBoardGame" + simulator);
            object factory = Activator.CreateInstance(type);
            GamingEnvironment.Instance.CreateBoardGame((FactoryBoardGameAbstract)factory, 20);

            GameSimulator gs = new GameSimulator();
            gs.Show();

            this.Close();
        }
    }
}
