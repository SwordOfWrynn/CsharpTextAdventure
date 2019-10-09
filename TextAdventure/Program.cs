using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

//  ______              _____         
//  ___  / _______________  /_        
//  __  /  _  __ \_  ___/  __/        
//  _  /___/ /_/ /(__  )/ /_          
//  /_____/\____//____/ \__/          
//                                    
//  ________                          
//  ____  _/______                    
//   __  / __  __ \                   
//  __/ /  _  / / /                   
//  /___/  /_/ /_/                    
//                                    
//  ________                          
//  __  ___/_____________ ___________ 
//  _____ \___  __ \  __ `/  ___/  _ \
//  ____/ /__  /_/ / /_/ // /__ /  __/
//  /____/ _  .___/\__,_/ \___/ \___/ 
//         /_/                        

namespace TextAdventure
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Text Adventure";

            Console.WriteLine("Starting Console...");

            Console.WriteLine("App version {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            try
            {
                GameStarter.PrepareGame();
            }
            catch(Exception ex)
            {
                ErrorReporter.Instance.Report("Exception caught in main!");
                ErrorReporter.Instance.Report(ex);
                Console.WriteLine("An exception was unhandled");
                Console.WriteLine(string.Format("Exception of type {0}", ex.GetType().Name));
                Console.WriteLine("Exception Message: {0}", ex.Message);
                Console.WriteLine("Exception stack trace: \n{0}", ex.StackTrace);
                Console.WriteLine("Error Report Generated");
                ErrorReporter.Instance.OutputReport();
                Console.WriteLine("Hit any key to terminate the console");
            }
            Console.Read();
        }

    }

}
