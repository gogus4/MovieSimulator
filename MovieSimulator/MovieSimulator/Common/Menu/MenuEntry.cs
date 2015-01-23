using System.Windows;
using System.Windows.Media;

namespace MovieSimulator.Common.Menu.TileMenu
{
    /// <summary>
    /// Describes a menu entry
    /// The Menu control use a generic list of instances of this class.
    /// </summary>
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

       
        /// <summary>
        /// Display name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Group name
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// Command name
        /// </summary>
        public string CommandName { get; set; }
        /// <summary>
        /// Tile visibility
        /// </summary>
        public bool IsVisible { get; set; }
        /// <summary>
        /// Tile "IsEnabled" state
        /// </summary>
        public bool IsEnabled { get; set; }
        /// <summary>
        /// Sort order.
        /// Tiles are sorted by group, order, name.
        /// Default order is 1000 for all tiles.
        /// If a Tile must be the first in its group, a value gt 1000 must be assigned.
        /// If a Tile must be the latest in its group, a value lt 1000 must be assigned.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Allows for customization of the Tile background color
        /// </summary>
        public Brush TileBrush { get; set; }
        /// <summary>
        /// Allows for customization of the Tile text color
        /// </summary>
        public Brush TextColor { get; set; }
        /// <summary>
        /// Allows for customization of the Tile text font size
        /// </summary>
        public double FontSize { get; set; }

        /// <summary>
        /// Optional data that can be used by developer.
        /// Not used by the control.
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        /// Optional data that can be used by developer.
        /// Not used by the control.
        /// </summary>
        public bool IsScreenReadOnly { get; set; }

        /// <summary>
        /// Constructor with default values that can be customized 
        /// here in this code.
        /// </summary>
        public MenuEntry()
        {
            // TODO CAN BE CUSTOMIZED
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

        /// <summary>
        /// Static constructor with default values for all groups and tiles
        /// that can be customized here in code.
        /// </summary>
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