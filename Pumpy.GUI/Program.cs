﻿#region

using System;
using System.Windows.Forms;

#endregion

namespace Pumpy.GUI
{
    internal static class Program
    {
        /// <summary>
        ///     Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}