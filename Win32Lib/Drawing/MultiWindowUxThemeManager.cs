using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Drawing.ThemeRoutines
{
    public class MultiWindowUxThemeManager : IDisposable
    {
        private bool m_bDisposed;
        private Dictionary<Control, UxThemeManager> m_dControlToManager;

        private Control m_cParent;
        public Control Parent
        {
            get { return m_cParent; }
        }

        public MultiWindowUxThemeManager(Control Parent)
        {
            m_cParent = Parent;
            m_bDisposed = false;
            m_dControlToManager = new Dictionary<Control, UxThemeManager>();
        }

        ~MultiWindowUxThemeManager()
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
                    foreach (KeyValuePair<Control, UxThemeManager> entry in m_dControlToManager)
                    {
                        UxThemeManager temp = (UxThemeManager)entry.Value;
                        temp.Dispose();
                    }

                    m_dControlToManager.Clear();

                    m_bDisposed = true;
                }
            }
        }

        public static bool VisualStylesEnabled()
        {
            return UxThemeManager.VisualStylesEnabled();
        }

        private UxThemeManager GetControlsManager(Control cont)
        {
            UxThemeManager Manager;

            if (!m_dControlToManager.TryGetValue(cont, out Manager))
            {
                Manager = new UxThemeManager(cont);
                m_dControlToManager.Add(cont, Manager);
            }

            return Manager;
        }

        public UxThemeManager this[Control control]
        {
            get
            {
                return GetControlsManager(control);
            }
        }
    }
}
