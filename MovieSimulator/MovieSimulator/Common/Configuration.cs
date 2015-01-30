using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.Common.Menu.TileMenu;
using System.IO;

namespace MovieSimulator.Common
{
    public class Configuration
    {
        private static Configuration _instance { get; set; }
        public static Configuration Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Configuration();

                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        public string CurrentSimulator { get; set; }

        public string CurrentPath { get; set; }

        public Configuration()
        {
        }

        public List<String> GetHistorySavedGame()
        {
            return Directory.GetFiles(@"XML\").Where(x => x.Contains(CurrentSimulator) && x.Contains("_")).Select(x => x.Replace("XML\\","")).ToList();
        }

        public List<MenuEntry> GetSimulators()
        {
            List<MenuEntry> listMenuEntry = new List<MenuEntry>();

            foreach (string aValue in ConfigurationManager.AppSettings)
            {
                listMenuEntry.Add(new MenuEntry() { Name = ConfigurationManager.AppSettings[aValue] });
            }

            return listMenuEntry;
        }
    }
}
