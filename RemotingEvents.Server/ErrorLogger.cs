using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RemotingEvents.Server
{
    /// <summary>
    /// class to write runTime errors to the file 
    /// </summary>
    class ErrorLogger
    {

        public static void ErrorLog(Exception ex)
        {
            try
            {
                MessageBox.Show("Exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);

                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);

                sw.WriteLine(DateTime.Now);
                sw.WriteLine("message : ");
                sw.WriteLine("");

                sw.WriteLine(ex.Message);
                sw.WriteLine("------------------------------------------------------------------------------------");
                sw.WriteLine("");

                sw.WriteLine("stack trace :");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine(ex.StackTrace);
                sw.WriteLine("------------------------------------------------------------------------------------");

                sw.WriteLine("");


                sw.Flush();
                sw.Close();
            }
            catch (Exception ex2)
            {
                ErrorLog(ex2);
            }
        }
    }
}
