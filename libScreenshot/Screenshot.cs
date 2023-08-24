using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace libScreenshot
{
    /// <summary>
    /// A static class that provides methods for capturing screenshots of the desktop.
    /// </summary>
    public static class Screenshot
    {

        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);

        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(IntPtr hDestDC, int xDest, int yDest, int
            wDest, int hDest, IntPtr hSrcDC, int xSrc, int ySrc, CopyPixelOperation dwRop);

        [DllImport("user32.dll")]
        private static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll")]
        private static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);

        /// <summary>
        /// Captures a screenshot of the entire desktop and saves it to a PNG file in the "My Pictures" folder.
        /// </summary>
        public static void Take()
        {
            IntPtr desktop = GetDesktopWindow();
            IntPtr hdc = GetWindowDC(desktop);
            IntPtr hdcMem = CreateCompatibleDC(hdc);

            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;

            IntPtr hBitmap = CreateCompatibleBitmap(hdc, width, height);
            IntPtr hOld = SelectObject(hdcMem, hBitmap);
            BitBlt(hdcMem, 0, 0, width, height, hdc, 0, 0, CopyPixelOperation.SourceCopy);
            SelectObject(hdcMem, hOld);
            DeleteDC(hdcMem);
            ReleaseDC(desktop, hdc);
            Image img = Image.FromHbitmap(hBitmap);
            for (int i = 1; i < int.MaxValue; i++)
            {
                string fname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "Screenshot (" + i.ToString() + ").png");
                if (!File.Exists(fname))
                {
                    img.Save(fname, ImageFormat.Png);
                    break;
                }
            }
            DeleteObject(hBitmap);
        }

        /// <summary>
        /// Captures a screenshot of the entire desktop and saves it to the specified file in PNG format.
        /// </summary>
        /// <param name="filename">The path and filename to save the screenshot to.</param>
        public static void Take(string filename)
        {
            IntPtr desktop = GetDesktopWindow();
            IntPtr hdc = GetWindowDC(desktop);
            IntPtr hdcMem = CreateCompatibleDC(hdc);

            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;

            IntPtr hBitmap = CreateCompatibleBitmap(hdc, width, height);
            IntPtr hOld = SelectObject(hdcMem, hBitmap);
            BitBlt(hdcMem, 0, 0, width, height, hdc, 0, 0, CopyPixelOperation.SourceCopy);
            SelectObject(hdcMem, hOld);
            DeleteDC(hdcMem);
            ReleaseDC(desktop, hdc);
            Image img = Image.FromHbitmap(hBitmap);
            img.Save(filename, ImageFormat.Png);
            DeleteObject(hBitmap);
        }

        /// <summary>
        /// Captures a screenshot of the entire desktop and saves it to the specified file using the specified image format.
        /// </summary>
        /// <param name="filename">The path and filename to save the screenshot to.</param>
        /// <param name="format">The format in which to save the screenshot (e.g., JPEG, PNG).</param>
        public static void Take(string filename, ImageFormat format)
        {
            IntPtr desktop = GetDesktopWindow();
            IntPtr hdc = GetWindowDC(desktop);
            IntPtr hdcMem = CreateCompatibleDC(hdc);

            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;

            IntPtr hBitmap = CreateCompatibleBitmap(hdc, width, height);
            IntPtr hOld = SelectObject(hdcMem, hBitmap);
            BitBlt(hdcMem, 0, 0, width, height, hdc, 0, 0, CopyPixelOperation.SourceCopy);
            SelectObject(hdcMem, hOld);
            DeleteDC(hdcMem);
            ReleaseDC(desktop, hdc);
            Image img = Image.FromHbitmap(hBitmap);
            img.Save(filename, format);
            DeleteObject(hBitmap);
        }

        /// <summary>
        /// Captures a screenshot of a specified region of the desktop and saves it to the specified file in PNG format.
        /// </summary>
        /// <param name="filename">The path and filename to save the screenshot to.</param>
        /// <param name="width">The width of the screenshot.</param>
        /// <param name="height">The height of the screenshot.</param>
        public static void Take(string filename, int width, int height)
        {
            IntPtr desktop = GetDesktopWindow();
            IntPtr hdc = GetWindowDC(desktop);
            IntPtr hdcMem = CreateCompatibleDC(hdc);
            IntPtr hBitmap = CreateCompatibleBitmap(hdc, width, height);
            IntPtr hOld = SelectObject(hdcMem, hBitmap);
            BitBlt(hdcMem, 0, 0, width, height, hdc, 0, 0, CopyPixelOperation.SourceCopy);
            SelectObject(hdcMem, hOld);
            DeleteDC(hdcMem);
            ReleaseDC(desktop, hdc);
            Image img = Image.FromHbitmap(hBitmap);
            img.Save(filename, ImageFormat.Png);
            DeleteObject(hBitmap);
        }

        /// <summary>
        /// Captures a screenshot of a specified region of the desktop and saves it to the specified file using the specified image format.
        /// </summary>
        /// <param name="filename">The path and filename to save the screenshot to.</param>
        /// <param name="width">The width of the screenshot.</param>
        /// <param name="height">The height of the screenshot.</param>
        /// <param name="format">The format in which to save the screenshot (e.g., JPEG, PNG).</param>
        public static void Take(string filename, int width, int height, ImageFormat format)
        {
            IntPtr desktop = GetDesktopWindow();
            IntPtr hdc = GetWindowDC(desktop);
            IntPtr hdcMem = CreateCompatibleDC(hdc);
            IntPtr hBitmap = CreateCompatibleBitmap(hdc, width, height);
            IntPtr hOld = SelectObject(hdcMem, hBitmap);
            BitBlt(hdcMem, 0, 0, width, height, hdc, 0, 0, CopyPixelOperation.SourceCopy);
            SelectObject(hdcMem, hOld);
            DeleteDC(hdcMem);
            ReleaseDC(desktop, hdc);
            Image img = Image.FromHbitmap(hBitmap);
            img.Save(filename, format);
            DeleteObject(hBitmap);
        }
    }
}
