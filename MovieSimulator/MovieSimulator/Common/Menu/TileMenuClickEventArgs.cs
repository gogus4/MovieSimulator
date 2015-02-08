using System;

namespace MovieSimulator.Common.Menu.TileMenu
{
    public class TileMenuClickEventArgs : EventArgs
    {
        public string Command { get; set; }

        public MenuEntry Entry { get; set; }
    }
}