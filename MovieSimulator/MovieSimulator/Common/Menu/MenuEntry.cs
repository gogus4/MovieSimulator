using System.Windows;
using System.Windows.Media;

namespace MovieSimulator.Common.Menu.TileMenu
{
    public class MenuEntry
    {
        #region private static
        // internal counter use to create default names
        private static int cpt=1;
        #endregion

        #region static Parameters
        /// <summary>
        /// Height of a Tile
        /// </summary>
        public static double Height { get; set; }
        /// <summary>
        /// Width of Tile
        /// </summary>
        public static double Width { get; set; }
        /// <summary>
        /// Margin applied to each Tile
        /// </summary>
        public static Thickness Margin { get; set; }
        /// <summary>
        /// Minimum width of a group
        /// </summary>
        public static double MinGroupWidth { get; set; }
        /// <summary>
        /// Font size for Group names
        /// </summary>
        public static double GroupFontSize { get; set; }
        /// <summary>
        /// Brush of Group names
        /// </summary>
        public static Brush GroupForeground { get; set; }
        #endregion

       
        public string Name { get; set; }

        public string GroupName { get; set; }

        public string CommandName { get; set; }

        public bool IsVisible { get; set; }

        public bool IsEnabled { get; set; }

        public int Order { get; set; }

        public Brush TileBrush { get; set; }

        public Brush TextColor { get; set; }

        public double FontSize { get; set; }

        public object Tag { get; set; }

        public bool IsScreenReadOnly { get; set; }

        public MenuEntry()
        {
            TileBrush = new SolidColorBrush(Colors.DodgerBlue);
            TextColor = new SolidColorBrush(Colors.White);
            FontSize = 36;
            Order = 1000;
            IsVisible = true;
            IsEnabled = true;
            Name = "Command #" + ++cpt;
            GroupName = "";
            CommandName = Name;
        }

        static MenuEntry()
        {
            Height = 200;
            Width = 400;
            Margin = new Thickness(5);
            MinGroupWidth = 100;
            GroupForeground = new SolidColorBrush(Colors.White);
            GroupFontSize = 20;
        }
    }
}