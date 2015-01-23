using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MovieSimulator.Common.Menu.TileMenu
{
    public partial class Menu : UserControl, INotifyPropertyChanged
    {
        #region Ctor

        public Menu()
        {
            InitializeComponent();
            Loaded += Menu_Loaded;
        }

        void Menu_Loaded(object sender, RoutedEventArgs e)
        {
            hasBeenLoaded = true;
            if (waitLoaded) rebuildMenu();
        }

        #endregion

        #region fields
        private List<Button> buttons;
        private bool hasBeenLoaded;
        private bool waitLoaded;

        #endregion

        #region properties

        #region public MenuEntries
        /// <summary>
        /// List of menu entries
        /// </summary>
        [Category("Data"), Description("List of menu entries")]
        public List<MenuEntry> MenuEntries
        {
            get { return (List<MenuEntry>)GetValue(MenuEntriesProperty); }
            set { SetValue(MenuEntriesProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="MenuEntries"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty MenuEntriesProperty =
            DependencyProperty.Register(
                "MenuEntries",
                typeof(List<MenuEntry>),
                typeof(Menu),
                new PropertyMetadata(null, onMenuEntriesPropertyChanged));

        /// <summary>
        /// <see cref="MenuEntries"/> Property property changed handler.
        /// </summary>
        /// <param name="d"><see cref="Menu"/> that changed its MenuEntries.</param>
        /// <param name="e">Event arguments.</param>
        private static void onMenuEntriesPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var source = d as Menu;
            if (source == null) return;
            // var value = (List<MenuEntry>)e.NewValue;
            source.rebuildMenu();
        }
        #endregion public MenuEntries

        #region public BackgroundImageUriString
        /// <summary>
        /// Menu backgroup image (uniform fill will be applied)
        /// </summary>
        [Category("Appearance"), Description("Menu backgroup image (uniform fill will be applied)")]
        public string BackgroundImageUriString
        {
            get { return (string)GetValue(BackgroundImageUriStringProperty); }
            set { SetValue(BackgroundImageUriStringProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="BackgroundImageUriString"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BackgroundImageUriStringProperty =
            DependencyProperty.Register(
                "BackgroundImageUriString",
                typeof(string),
                typeof(Menu),
                new PropertyMetadata(null, onBackgroundImagePropertyChanged));

        /// <summary>
        /// <see cref="BackgroundImageUriString"/> Property property changed handler.
        /// </summary>
        /// <param name="d"><see cref="Menu"/> that changed its BackgroundImage.</param>
        /// <param name="e">Event arguments.</param>
        private static void onBackgroundImagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var source = d as Menu;
            if (source == null) return;
            var value = (string)e.NewValue;
            //source.imgBackground.Source = new BitmapImage(new Uri(value));
        }

        #endregion public BackgroundImage

        #region public IsHorizontalScrollbarVisible
        /// <summary>
        /// Is the horizontal scroll bar visible when some groups are outside the view frame
        /// </summary>
        [Category("Appearance"), Description("Is the horizontal scroll bar visible when some groups are outside the view frame")]
        public bool IsHorizontalScrollbarVisible
        {
            get { return (bool)GetValue(IsHorizontalScrollbarVisibleProperty); }
            set { SetValue(IsHorizontalScrollbarVisibleProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="IsHorizontalScrollbarVisible"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsHorizontalScrollbarVisibleProperty =
            DependencyProperty.Register(
                "IsHorizontalScrollbarVisible",
                typeof(bool),
                typeof(Menu),
                new PropertyMetadata(false, onIsHorizontalScrollbarVisiblePropertyChanged));

        /// <summary>
        /// <see cref="IsHorizontalScrollbarVisible"/> Property property changed handler.
        /// </summary>
        /// <param name="d"><see cref="Menu"/> that changed its IsHorizontalScrollbarVisible.</param>
        /// <param name="e">Event arguments.</param>
        private static void onIsHorizontalScrollbarVisiblePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var source = d as Menu;
            if (source == null) return;
            var value = (bool)e.NewValue;
            source.scrlMain.HorizontalScrollBarVisibility = value
                ? ScrollBarVisibility.Auto
                : ScrollBarVisibility.Hidden;

        }
        #endregion public IsHorizontalScrollbarVisible

        /// <summary>
        /// Fires when user click a tile. Returns the command name.
        /// </summary>
        public event EventHandler<TileMenuClickEventArgs> MenuClick;

        /// <summary>
        /// INotifyPropertyChanged event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region private stuff

        // rebuilds the menu from the list of entries
        private void rebuildMenu()
        {
            //if (!hasBeenLoaded) throw new Exception("MENU HAS NOT BEEN LOADED");
            if (!hasBeenLoaded)
            {
                waitLoaded = true;
                return;
            }

            // remove buttons event handler
            // before clearing button list
            if (buttons != null)
            {
                foreach (var button in buttons)
                {
                    button.Tag = null;
                    button.Click -= buttonClick;
                }
                buttons.Clear();
            }
            buttons = new List<Button>();

            // remove all groups in the main stack panel
            spMain.Children.Clear();

            // exit if menu is empty
            if (MenuEntries == null) return;
            if (MenuEntries.Count < 1) return;

            // built the entries groups
            var orderedMenu = from me in MenuEntries where me.IsVisible orderby me.GroupName, me.Order, me.Name ascending select me;
            var groups = from me in orderedMenu
                         group me by me.GroupName
                             into megroups
                             select new { GroupName = megroups.Key, Entries = megroups };

            // built the graphical tree for each group
            var converter = new GridLengthConverter();
            foreach (var g in groups)
            {
                // base grid that will hold the group
                var gBase = new Grid { Margin = new Thickness(10) };
                // title row and tiles row
                var convertFromString = converter.ConvertFromString("10*");
                if (convertFromString != null)
                {
                    // var rowDef1 = new RowDefinition { Height = (GridLength)convertFromString };
                    var fromString = converter.ConvertFromString("90*");
                    if (fromString != null)
                    {
                        var rowDef2 = new RowDefinition { Height = (GridLength)fromString };
                        //gBase.RowDefinitions.Add(rowDef1);
                        gBase.RowDefinitions.Add(rowDef2);
                    }
                }

                var wrap = new WrapPanel { Orientation = Orientation.Vertical };
                gBase.Children.Add(wrap);
                Grid.SetRow(wrap, 0);

                // a bit of calculations to fix the wrap panel width

                // main stackpanel height - 10% (group title) - top/bottom group margin
                wrap.Height = (spMain.ActualHeight * 0.9) - (2 * 10);

                // how much lines can stand in the available height ?
                var lines = (int)Math.Truncate(wrap.Height / (MenuEntry.Height + MenuEntry.Margin.Bottom + MenuEntry.Margin.Top)); // how much tiles by row in the wrap panel

                // so, how much columns this group will use ?
                var cols = (int)Math.Truncate(g.Entries.Count() * 1d / lines);

                if ((g.Entries.Count() % lines) != 0) cols++;

                // the wrap panel width is then the number of columns multiplied by the size of a tile (width+margin)
                wrap.Width = cols * (MenuEntry.Width + MenuEntry.Margin.Left + MenuEntry.Margin.Right);

                // ok, so we can create the buttons (tiles) of the group now !
                foreach (var b in g.Entries.Select(me => new Button
                                                             {
                                                                 Height = MenuEntry.Height,
                                                                 Width = MenuEntry.Width,
                                                                 Margin = MenuEntry.Margin,
                                                                 Background = me.TileBrush,
                                                                 Foreground = me.TextColor,
                                                                 FontSize = me.FontSize,
                                                                 Content = me.Name,
                                                                 IsEnabled = me.IsEnabled,
                                                                 Tag = me,
                                                                 Template = FindResource("TileButtonTemplate") as ControlTemplate
                                                             }))
                {
                    b.Click += buttonClick;
                    wrap.Children.Add(b);
                    buttons.Add(b); // to easily drop the event handler and avoid memory leaks
                }

                // add the group to the stack panel
                spMain.Children.Add(gBase);
            }
        }

        // holds the click on each tile (command name is stored in the Tag of each tile)
        void buttonClick(object sender, RoutedEventArgs e)
        {
            var m = MenuClick;
            if (m == null) return;
            var b = (sender as Button);
            if (b == null) return;
            if (b.Tag == null) return;
            var me = b.Tag as MenuEntry;
            if (me == null) return;
            m(this, new TileMenuClickEventArgs { Command = me.CommandName, Entry = me });
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        // rebuilds the menu when size of container is changed
        private void spMainSizeChanged(object sender, SizeChangedEventArgs e)
        {
            rebuildMenu();
        }

        // Holds the mouse Wheel to scroll the menu left/right like Windows 8
        private void scrollViewerPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            // this is based on a "120" delta for each wheel step.
            // if some mouses return other values, the speed calculation should be modified...
            if (e.Delta > 0) for (var i = 0; i <= Math.Abs(e.Delta); i += 30) scrlMain.LineLeft();
            if (e.Delta < 0) for (var i = 0; i <= Math.Abs(e.Delta); i += 30) scrlMain.LineRight();
            e.Handled = true;
        }
        #endregion
    }
}
