//game code from https://www.codeproject.com/Articles/5252990/Space-Invaders-in-Csharp-WinForm
//modified by sarah

/**
 * https://learn.microsoft.com/en-us/windows/win32/gdiplus/-gdiplus-introduction-to-gdi--about
 *GDI+ stands for 'graphic design interface' and allows applications to be made independent 
 *to the device it will run on. GDI+ is an API to displays the code to screens/printers
 *
 *Double-buffering is useful in graphic/game applications as if helps prevent image 'flickering'
 *this means that instead of printing the graphics to screen instantly, it sends this information
 *to a memory buffer to smooth out the majority of the remaining flickering
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Invaders
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
