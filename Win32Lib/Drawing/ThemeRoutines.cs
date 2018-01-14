using System;
using System.Runtime.InteropServices;
using Win32Lib;

namespace Drawing.ThemeRoutines
{
    public enum ToolTipStandardState : int
    {
        TTSS_LINK = 2,
        TTSS_NORMAL = 1
    };

    public enum ThemeSize : uint
    {
        Minimum,
        True,
        Draw,
    }

    public enum AnimationStyle : uint
    {
        None,
        Linear,
        Cubic,
        Sine,
    }


    /// <summary>
    /// Parts available for ToolTip.
    /// </summary>
    public enum ToolTipPart : int
    {
        /// <summary>
        /// TTP_BALLOON
        /// </summary>
        Balloon = 3,
        /// <summary>
        /// TTP_BALLOONTITLE
        /// </summary>
        BalloonTitle = 4,
        /// <summary>
        /// TTP_CLOSE
        /// </summary>
        Close = 5,
        /// <summary>
        /// TTP_STANDARD
        /// </summary>
        Standard = 1,
        /// <summary>
        /// TTP_STANDARDTITLE
        /// </summary>
        StandardTitle = 2
    };

    /// <summary>
    /// The integer properties of a visual style element.
    /// </summary>
    public enum IntegerProperty : int
    {
        /// <summary>
        /// The number of state images in multiple-image file (eg. TMT_IMAGECOUNT)
        /// </summary>
        ImageCount = 2401,
        /// <summary>
        /// The alpha value for an icon, between 0 and 255 (eg. TMT_ALPHALEVEL)
        /// </summary>
        AlphaLevel = 2402,
        /// <summary>
        /// The size of the border line for elements with a filled-border background (eg. TMT_BORDERSIZE)
        /// </summary>
        BorderSize = 2403,
        /// <summary>
        /// A percentage value that represents the width of a rounded corner, from 0 to 100 (eg. TMT_ROUNDCORNERWIDTH)
        /// </summary>
        RoundCornerWidth = 2404,
        /// <summary>
        /// A percentage value that represents the height of a rounded corner, from 0 to 100 (eg. TMT_ROUNDCORNERHEIGHT)
        /// </summary>
        RoundCornerHeight = 2405,
        /// <summary>
        /// The amount of ColorProperty.GradientColor1 to use in a color gradient.
        /// The sum of the five GradientRatio properties must equal 255 (eg. TMT_GRADIENTRATIO1)
        /// </summary>
        GradientRatio1 = 2406,
        /// <summary>
        /// The amount of ColorProperty.GradientColor2 to use in a color gradient.
        /// The sum of the five GradientRatio properties must equal 255 (eg. TMT_GRADIENTRATIO2)
        /// </summary>
        GradientRatio2 = 2407,
        /// <summary>
        /// The amount of ColorProperty.GradientColor3 to use in a color gradient.
        /// The sum of the five GradientRatio properties must equal 255 (eg. TMT_GRADIENTRATIO3)
        /// </summary>
        GradientRatio3 = 2408,
        /// <summary>
        /// The amount of ColorProperty.GradientColor4 to use in a color gradient.
        /// The sum of the five GradientRatio properties must equal 255 (eg. TMT_GRADIENTRATIO4)
        /// </summary>
        GradientRatio4 = 2409,
        /// <summary>
        /// The amount of ColorProperty.GradientColor5 to use in a color gradient.
        /// The sum of the five GradientRatio properties must equal 255 (eg. TMT_GRADIENTRATIO5)
        /// </summary>
        GradientRatio5 = 2410,
        /// <summary>
        /// The size of progress bar elements (eg. TMT_PROGRESSCHUNKSIZE)
        /// </summary>
        ProgressChunkSize = 2411,
        /// <summary>
        /// The size of spaces between progress bar elements (eg. TMT_PROGRESSSPACESIZE)
        /// </summary>
        ProgressSpaceSize = 2412,
        /// <summary>
        /// The amount of saturation for an image, between 0 and 255 (eg. TMT_SATURATION)
        /// </summary>
        Saturation = 2413,
        /// <summary>
        /// The size of the border around text characters (eg. TMT_TEXTBORDERSIZE)
        /// </summary>
        TextBorderSize = 2414,
        /// <summary>
        /// The minimum alpha value of a solid pixel, between 0 and 255 (eg. TMT_ALPHATHRESHOLD)
        /// </summary>
        AlphaThreshold = 2415,
        /// <summary>
        /// The width of an element (eg .TMT_WIDTH)
        /// </summary>
        Width = 2416,
        /// <summary>
        /// The height of an element (eg. TMT_HEIGHT)
        /// </summary>
        Height = 2417,
        /// <summary>
        /// The index into the font for font-based glyphs (eg. TMT_GLYPHINDEX)
        /// </summary>
        GlyphIndex = 2418,
        /// <summary>
        /// A percentage value indicating how far a fixed-size element will stretch when the target exceeds the source (eg. TMT_TRUESIZESTRETCHMARK)
        /// </summary>
        TrueSizeStretchMark = 2419,
        /// <summary>
        /// The minimum dots per inch (DPI) that FilenameProperty.ImageFile1 was designed for (eg. TMT_MINDPI1)
        /// </summary>
        MinDpi1 = 2420,
        /// <summary>
        /// The minimum DPI that FilenameProperty.ImageFile2 was designed for (eg. TMT_MINDPI2)
        /// </summary>
        MinDpi2 = 2421,
        /// <summary>
        /// The minimum DPI that FilenameProperty.ImageFile3 was designed for (eg. TMT_MINDPI3)
        /// </summary>
        MinDpi3 = 2422,
        /// <summary>
        /// The minimum DPI that FilenameProperty.ImageFile4 was designed for (eg. TMT_MINDPI4)
        /// </summary>
        MinDpi4 = 2423,
        /// <summary>
        /// The minimum DPI that FilenameProperty.ImageFile5 was designed for (eg. TMT_MINDPI5)
        /// </summary>
        MinDpi5 = 2424
    };

    public enum ButtonPart : uint
    {
        Pushbutton = 1,
        RadioButton = 2,
        Checkbox = 3,
        Groupbox = 4,
        UserButton = 5
        /*
        /// <summary>
        /// Command link (BP_COMMANDLINK)
        /// </summary>
        CommandLink = 6,
        /// <summary>
        /// Command link glyph (BP_COMMANDLINKGLYPH)
        /// </summary>
        CommandLinkGlyph = 7
        */
    }

    /// <summary>
    /// Parts available for "Header" components.
    /// </summary>
    public enum HeaderPart : uint
    {
        /// <summary>
        /// HP_HEADERITEM
        /// </summary>
        HeaderItem = 1,
        /// <summary>
        /// HP_HEADERITEMLEFT
        /// </summary>
        HeaderItemLeft = 2,
        /// <summary>
        /// HP_HEADERITEMRIGHT
        /// </summary>
        HeaderItemRight = 3,
        /// <summary>
        /// HP_HEADERSORTARROW
        /// </summary>
        HeaderSortArrow = 4
        /*
        HP_HEADERDROPDOWN,
        HP_HEADERDROPDOWNFILTER,
        HP_HEADEROVERFLOW
        */
    };

    public enum HeaderSortArrowState : int
    {
        /// <summary>
        /// HSAS_SORTEDUP
        /// </summary>
        SortedUp = 1,
        /// <summary>
        /// HSAS_SORTEDDOWN
        /// </summary>
        SortedDown = 2,
    }

    public enum HeaderItemState : int
    {
        /// <summary>
        /// HIS_NORMAL
        /// </summary>
        Normal = 1,
        /// <summary>
        /// HIS_HOT
        /// </summary>
        Hot = 2,
        /// <summary>
        /// HIS_PRESSED
        /// </summary>
        Pressed = 3
    };

    /// <summary>
    /// Parts available for combobox control.
    /// </summary>
    public enum ComboBoxPart : uint
    {
        /// <summary>
        /// Drop-down button (CP_DROPDOWNBUTTON)
        /// </summary>
        DropDownButton = 1,
        /// <summary>
        /// CP_BACKGROUND
        /// </summary>
        Background = 2,
        /// <summary>
        /// CP_TRANSPARENTBACKGROUND
        /// </summary>
        TransparentBackground = 3,
        /// <summary>
        /// CP_BORDER
        /// </summary>
        Border = 4,
        /// <summary>
        /// CP_READONLY
        /// </summary>
        ReadOnly = 5,
        /// <summary>
        /// CP_DROPDOWNBUTTONRIGHT
        /// </summary>
        DropDownButtonRight = 6,
        /// <summary>
        /// CP_DROPDOWNBUTTONLEFT
        /// </summary>
        DropDownButtonLeft = 7,
        /// <summary>
        /// CP_CUEBANNER
        /// </summary>
        Cuebanner = 8
    };

    public enum ComboBoxState : int
    {
        /// <summary>
        /// The combo box is disabled
        /// </summary>
        Disabled = 4,
        /// <summary>
        /// The combo box is pressed.
        /// </summary>
        Pressed = 3,
        /// <summary>
        /// The combo box is hot.
        /// </summary>
        Hot = 2,
        /// <summary>
        /// The combo box has the default appearance.
        /// </summary>
        Normal = 1
    };

    public enum PushButtonState : int
    {
        Default = 5,
        Disabled = 4,
        Hot = 2,
        Normal = 1,
        Pressed = 3
    }

    public enum CheckBoxState : int
    {
        CheckedDisabled = 8,
        CheckedHot = 6,
        CheckedNormal = 5,
        CheckedPressed = 7,
        MixedDisabled = 12,
        MixedHot = 10,
        MixedNormal = 9,
        MixedPressed = 11,
        UncheckedDisabled = 4,
        UncheckedHot = 2,
        UncheckedNormal = 1,
        UncheckedPressed = 3
    }

    public enum DrawThemeBackgroundFlags : uint
    {
        ClipRect = 0x00000001,
        DrawSolid = 0x00000002,
        OmitBorder = 0x00000004,
        OmitContent = 0x00000008,
        ComputingRegion = 0x00000010,
        MirrorDC = 0x00000020
    }

    [Flags]
    public enum DrawTextFlags : uint
    {
        DT_TOP = 0x00000000,
        DT_LEFT = 0x00000000,
        DT_CENTER = 0x00000001,
        DT_RIGHT = 0x00000002,
        DT_VCENTER = 0x00000004,
        DT_BOTTOM = 0x00000008,
        DT_WORDBREAK = 0x00000010,
        DT_SINGLELINE = 0x00000020,
        DT_EXPANDTABS = 0x00000040,
        DT_TABSTOP = 0x00000080,
        DT_NOCLIP = 0x00000100,
        DT_EXTERNALLEADING = 0x00000200,
        DT_CALCRECT = 0x00000400,
        DT_NOPREFIX = 0x00000800,
        DT_INTERNAL = 0x00001000,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DTBGOPTS
    {
        public static readonly int SizeOf = Marshal.SizeOf(typeof(DTBGOPTS));

        public int dwSize;
        public DrawThemeBackgroundFlags dwFlags;
        public RECT rcClip;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct COLORREF
    {
        public byte R;
        public byte G;
        public byte B;
    }

    public class ThemeRoutines
    {
        #region Constants
        public const string BUTTON = "BUTTON";
        public const string CLOCK = "CLOCK";
        public const string COMBOBOX = "COMBOBOX";
        public const string EDIT = "EDIT";
        public const string EXPLORERBAR = "EXPLORERBAR";
        public const string HEADER = "HEADER";
        public const string LISTVIEW = "LISTVIEW";
        public const string MENU = "MENU";
        public const string MENUBAND = "MENUBAND";
        public const string PAGE = "PAGE";
        public const string PROGRESS = "PROGRESS";
        public const string REBAR = "REBAR";
        public const string SCROLLBAR = "SCROLLBAR";
        public const string SPIN = "SPIN";
        public const string STARTPANEL = "STARTPANEL";
        public const string STATUS = "STATUS";
        public const string TAB = "TAB";
        public const string TASKBAND = "TASKBAND";
        public const string TASKBAR = "TASKBAR";
        public const string TOOLBAR = "TOOLBAR";
        public const string TOOLTIP = "TOOLTIP";
        public const string TRACKBAR = "TRACKBAR";
        public const string TRAYNOTIFY = "TRAYNOTIFY";
        public const string TREEVIEW = "TREEVIEW";
        public const string WINDOW = "WINDOW";
        #endregion

        // TODO: Make an enum and a function to translate the enum to a string
        [DllImport("UxTheme.dll", CharSet = CharSet.Auto)]
        public static extern bool IsAppThemed();

        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr OpenThemeData(IntPtr hWnd, string classList);

        [DllImport("uxtheme.dll", ExactSpelling = true)]
        public extern static Int32 CloseThemeData(IntPtr hTheme);

        [DllImport("UxTheme.dll", CharSet = CharSet.Auto)]
        public static extern bool IsThemeActive();

        [DllImport("uxtheme.dll", ExactSpelling = true)]
        public extern static Int32 DrawThemeBackground(IntPtr hTheme, IntPtr hdc, int iPartId,
           int iStateId, ref RECT pRect, ref RECT pClipRect);

        [DllImport("uxtheme.dll", ExactSpelling = true)]
        public extern static Int32 DrawThemeEdge(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ref RECT pDestRect, uint egde, uint flags, out RECT pRect);

        [DllImport("uxtheme", ExactSpelling = true, CharSet = CharSet.Unicode)]
        public extern static Int32 DrawThemeText(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, String text, int textLength, UInt32 textFlags, UInt32 textFlags2, ref RECT pRect);

        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        public extern static Int32 DrawThemeTextEx(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, String text, int length, UInt32 flags, ref RECT rect, ref DTBGOPTS poptions);

        [DllImport("UxTheme.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Int32 GetThemeBackgroundRegion(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ref RECT pRect, out IntPtr pRegion);

        [DllImport("user32.dll")]
        public static extern bool ValidateRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("uxtheme", ExactSpelling = true)]
        public extern static Int32 GetThemeColor(IntPtr hTheme, int iPartId, int iStateId, int iPropId, out COLORREF pColor);

        [DllImport("uxtheme", ExactSpelling = true)]
        public extern static int DrawThemeParentBackground(IntPtr hWnd, IntPtr hdc, ref RECT pRect);

        [DllImport("uxtheme", ExactSpelling = true)]
        public extern static Int32 DrawThemeBackground(IntPtr hTheme, IntPtr hdc, int iPartId,
          int iStateId, ref RECT pRect, IntPtr pClipRect);

        [DllImport("uxtheme", ExactSpelling = true)]
        public extern static int IsThemeBackgroundPartiallyTransparent(IntPtr hTheme, int iPartId, int iStateId);

        [DllImport("uxtheme", ExactSpelling = true)]
        public extern static Int32 GetThemeBackgroundContentRect(IntPtr hTheme, IntPtr hdc
          , int iPartId, int iStateId, ref RECT pBoundingRect, out RECT pContentRect);

        [DllImport("uxtheme", ExactSpelling = true)]
        public extern static int GetThemeInt(IntPtr hTheme, int iPartId, int iStateId, int iPropId, out int piVal);
    }
}
