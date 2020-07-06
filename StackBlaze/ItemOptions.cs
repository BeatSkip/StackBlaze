using System;
using System.Collections.Generic;
using System.Text;

namespace StackBlaze
{
    public class ItemOptions
    {

        public bool autoPosition { get; set; } = true;
        public int initialX { get; set; } = -1;
        public int initialY { get; set; } = -1;
        public int X { get; set; } = -1;
        public int Y { get; set; } = -1;
        public int Width { get; set; } = 1;
        public int minWidth { get; set; } = 1;
        public int maxWidth { get; set; } = 6;
        public int Height { get; set; } = 1;
        public int minHeight { get; set; } = 1;
        public int maxHeight { get; set; } = 6;
        public bool locked { get; set; } = false;
        public bool noResize { get; set; } = false;
        public bool noMove { get; set; } = false;
    }
}
