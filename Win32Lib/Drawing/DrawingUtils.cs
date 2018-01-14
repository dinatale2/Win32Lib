using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Drawing
{
    public class DrawingFunctions
    {
        public static uint ColorToUInt(Color color)
        {
            return (uint)((color.R << 16) | (color.G << 8) | (color.B << 0));
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DRAWTEXTPARAMS
        {
            public uint cbSize;
            public int iTabLength;
            public int iLeftMargin;
            public int iRightMargin;
            public uint uiLengthDrawn;
        }
    }
}