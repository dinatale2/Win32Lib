using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using Win32Lib;

namespace Drawing.ThemeRoutines
{
    public enum UxThemeElements
    {
        BUTTON,
        CLOCK,
        COMBOBOX,
        EDIT,
        EXPLORERBAR,
        HEADER,
        LISTVIEW,
        MENU,
        MENUBAND,
        PAGE,
        PROGRESS,
        REBAR,
        SCROLLBAR,
        SPIN,
        STARTPANEL,
        STATUS,
        TAB,
        TASKBAND,
        TASKBAR,
        TOOLBAR,
        TOOLTIP,
        TRACKBAR,
        TRAYNOTIFY,
        TREEVIEW,
        WINDOW,
    }

    public class UxThemeManager : IDisposable
    {
        private Dictionary<string, IntPtr> m_pLoadedThemes;
        private Control m_cParent;
        private bool m_bDisposed;

        public UxThemeManager(Control Parent)
        {
            m_pLoadedThemes = new Dictionary<string, IntPtr>();
            m_cParent = Parent;
            m_bDisposed = false;
        }

        ~UxThemeManager()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!m_bDisposed)
            {
                if (disposing)
                {
                    foreach (KeyValuePair<string, IntPtr> entry in m_pLoadedThemes)
                    {
                        ThemeRoutines.CloseThemeData(entry.Value);
                    }

                    m_pLoadedThemes.Clear();

                    m_bDisposed = true;
                }
            }
        }

        public static bool VisualStylesEnabled()
        {
            // Check if RenderWithVisualStyles property is available in the Application class (New feature in NET 2.0)
            Type t = typeof(Application);
            System.Reflection.PropertyInfo pi = t.GetProperty("RenderWithVisualStyles");

            if (pi == null)
            {
                // NET 1.1
                OperatingSystem os = System.Environment.OSVersion;
                if (os.Platform == PlatformID.Win32NT && (((os.Version.Major == 5) && (os.Version.Minor >= 1)) || (os.Version.Major > 5)))
                {
                    DLLVersionInfo version = new DLLVersionInfo();
                    version.cbSize = Marshal.SizeOf(typeof(DLLVersionInfo));
                    if (Win32.DllGetVersion(ref version) == 0)
                    {
                        return (version.dwMajorVersion > 5) && ThemeRoutines.IsThemeActive() && ThemeRoutines.IsAppThemed();
                    }
                }

                return false;
            }
            else
            {
                // NET 2.0
                bool result = (bool)pi.GetValue(null, null);
                return result;
            }
        }

        private bool EnsureTheme(string strName)
        {
            if (ThemeRoutines.IsThemeActive() && !m_pLoadedThemes.ContainsKey(strName))
            {
                IntPtr pTheme = IntPtr.Zero;

                pTheme = ThemeRoutines.OpenThemeData(m_cParent.Handle, strName);

                if (pTheme != IntPtr.Zero)
                {
                    m_pLoadedThemes.Add(strName, pTheme);
                    return true;
                }

                return false;
            }

            return true;
        }

        public IntPtr GetTheme(UxThemeElements eName)
        {
            string strName = Enum.GetName(typeof(UxThemeElements), eName);

            if (EnsureTheme(strName))
            {
                IntPtr pTheme;

                if (m_pLoadedThemes.TryGetValue(strName, out pTheme))
                    return pTheme;
            }

            return IntPtr.Zero;
        }

        public bool DrawThemeBackground(UxThemeElements eName, IntPtr hDC, int nPartID, int nStateID, ref Rectangle BGRect, ref Rectangle ClipRect)
        {
            IntPtr hTheme = GetTheme(eName);

            if (hTheme != IntPtr.Zero)
            {
                RECT BGRECT = BGRect;
                RECT ClipRECT = ClipRect;

                return (ThemeRoutines.DrawThemeBackground(hTheme, hDC, nPartID, nStateID, ref BGRECT, ref ClipRECT) == 0);
            }

            return false;
        }

        public bool DrawThemeBackground(UxThemeElements eName, IntPtr hDC, int nPartID, int nStateID, ref RECT BGRect, IntPtr pClipRect)
        {
            IntPtr hTheme = GetTheme(eName);

            if (hTheme != IntPtr.Zero)
            {
                return (ThemeRoutines.DrawThemeBackground(hTheme, hDC, nPartID, nStateID, ref BGRect, pClipRect) == 0);
            }

            return false;
        }

        public bool DrawThemeBackground(UxThemeElements eName, IntPtr hDC, int nPartID, int nStateID, ref Rectangle BGRect, IntPtr pClipRect)
        {
            IntPtr hTheme = GetTheme(eName);

            if (hTheme != IntPtr.Zero)
            {
                RECT BGRECT = BGRect;

                return (ThemeRoutines.DrawThemeBackground(hTheme, hDC, nPartID, nStateID, ref BGRECT, pClipRect) == 0);
            }

            return false;
        }

        public bool IsThemeBackgroundPartiallyTransparent(UxThemeElements eName, int nPartID, int nStateID)
        {
            IntPtr hTheme = GetTheme(eName);

            return (ThemeRoutines.IsThemeBackgroundPartiallyTransparent(hTheme, nPartID, nStateID) == 0);
        }

        public bool DrawThemeParentBackground(IntPtr hDC, ref RECT pRect)
        {
            return (ThemeRoutines.DrawThemeParentBackground(m_cParent.Handle, hDC, ref pRect) == 0);
        }

        public bool DrawThemeParentBackground(IntPtr hDC, ref Rectangle pRect)
        {
            RECT BGRECT = pRect;
            return (ThemeRoutines.DrawThemeParentBackground(m_cParent.Handle, hDC, ref BGRECT) == 0);
        }

        public bool GetThemeBackgroundContentRect(UxThemeElements eName, IntPtr hDC, int nPartID, int nStateID, ref RECT windowRect, out RECT contentRect)
        {
            IntPtr hTheme = GetTheme(eName);

            return (ThemeRoutines.GetThemeBackgroundContentRect(hTheme, hDC, nPartID, nStateID, ref windowRect, out contentRect) == 0);
        }

        public bool GetThemeBackgroundRegion(UxThemeElements eName, IntPtr hDC, int nPartID, int nStateID, Rectangle windowRect, out IntPtr pRegion)
        {
            RECT winRECT = windowRect;
            return GetThemeBackgroundRegion(eName, hDC, nPartID, nStateID, ref winRECT, out pRegion);
        }

        public bool GetThemeBackgroundRegion(UxThemeElements eName, IntPtr hDC, int nPartID, int nStateID, ref RECT windowRect, out IntPtr pRegion)
        {
            IntPtr hTheme = GetTheme(eName);
            return (ThemeRoutines.GetThemeBackgroundRegion(hTheme, hDC, nPartID, nStateID, ref windowRect, out pRegion) == 0);
        }

        public bool GetThemeInt(UxThemeElements eName, int nPartID, int nStateID, int nPropID, out int nPropVal)
        {
            IntPtr hTheme = GetTheme(eName);

            return (ThemeRoutines.GetThemeInt(hTheme, nPartID, nStateID, nPropID, out nPropVal) == 0);
        }
    }
}
