﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vocabulator
{
    static class Program
    {
        /// <summary>
        /// main thread
        /// @author m1Gd70bH
        /// </summary>
        [STAThread]
        static void Main()
        {
            //run app
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TeacherForm());
        }
    }
}