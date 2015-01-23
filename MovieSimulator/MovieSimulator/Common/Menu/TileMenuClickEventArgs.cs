using System;

namespace MovieSimulator.Common.Menu.TileMenu
{
    /// <summary>
    /// Click event on menu
    /// </summary>
    public class TileMenuClickEventArgs : EventArgs
    {
        /// <summary>
        /// Command name
        /// </summary>
        public string Command { get; set; }
        /// <summary>
        /// the original Menu Entry
        /// </summary>
        public MenuEntry Entry { get; set; }
    }
}