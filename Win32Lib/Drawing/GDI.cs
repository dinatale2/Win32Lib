using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Text;
using Win32Lib;

namespace Drawing.GDI
{
    public class GDI : DrawingFunctions
    {
        [DllImport("gdi32.dll")]
        static extern bool GetTextExtentPoint(IntPtr hdc, string lpString, int strLen, ref SIZE lpSize);

        [DllImport("gdi32.dll", ExactSpelling = true, PreserveSig = true, SetLastError = true)]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObject);

        [DllImport("gdi32.dll")]
        static extern bool DeleteObject(IntPtr hObject);

        [DllImport("gdi32.dll")]
        public static extern int SetBkMode(IntPtr hdc, int mode);

        [DllImport("gdi32.dll")]
        public static extern int SetBkColor(IntPtr hdc, uint crColor);

        [DllImport("gdi32.dll")]
        public static extern int SetTextColor(IntPtr hdc, uint color);

        [DllImport("gdi32.dll")]
        public static extern int GetTextExtentPoint32(IntPtr hdc, string str, int len, ref Size size);

        [DllImport("gdi32.dll")]
        public static extern int ExtTextOut(IntPtr hdc, int x, int y, int options, ref RECT clip, string str, int len, IntPtr spacings);

        [DllImport("user32.dll")]
        public static extern int DrawTextEx(IntPtr hdc, StringBuilder lpchText, int cchText, ref RECT lprc, uint dwDTFormat, ref DRAWTEXTPARAMS lpDTParams);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int DrawText(IntPtr hdc, string lpStr, int nCount, ref RECT lpRect, int wFormat);
    }
}
