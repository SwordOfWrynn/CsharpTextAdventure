using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextAdventure
{
    class ErrorReporter
    {
        const string ERROR_OUTPUT_DIR = @"\ErrorLogs";
        bool done;

        #region singleton
        private static readonly Lazy<ErrorReporter> m_Instance = new Lazy<ErrorReporter>(() => new ErrorReporter());
     
        private ErrorReporter()
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(OutputReport);
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OutputReport);

            errorMessages = new List<string>();

            DateTime date = DateTime.Now.Date;
            Report($@"
               Error Log 
               generated on {date.ToLongDateString()}
            ");
        }

        public static ErrorReporter Instance
        {
            get
            {
                return m_Instance.Value;
            }
        }
        #endregion

        List<string> errorMessages;

        public void Report(string message)
        {
            errorMessages.Add(message + "\n");
        }

        public void Report(Exception ex)
        {
            errorMessages.Add("Exception Type: " + ex.GetType().Name);
            errorMessages.Add(ex.Message);
            errorMessages.Add("StackTrace:");
            errorMessages.Add(ex.StackTrace + "\n");
        }

        public void OutputReport(object sender, EventArgs args)
        {
            OutputReport();
        }

        public void OutputReport()
        {
            if (done)
                return;
            done = true;

            string directory = Directory.GetCurrentDirectory() + ERROR_OUTPUT_DIR;

            if (Directory.Exists(directory) == false)
            {
                Directory.CreateDirectory(directory);
            }

            DateTime time = DateTime.Now;

            string path = directory + "\\" + time.ToString(@"MM/dd/yyyy HH:mm:ss").Replace('/', '-').Replace(':', '-').Replace(' ', '_') + ".txt";

            string[] text = errorMessages.ToArray();

            File.WriteAllLines(path, text);
        }

    }
}
