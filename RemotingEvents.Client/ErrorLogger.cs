using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RemotingEvents.Client
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
