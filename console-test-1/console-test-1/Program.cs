using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using CommandLine;
using System.ComponentModel;

namespace console_test_1
{
    class Program
    {
        public class Options
        {
            [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
            public bool Verbose { get; set; }
        }

        void StartTekla()
        {

        }
        static void Main(string[] args)
        {
            Options options = null;
            bool parseRes = true;
            CommandLine.Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(opts => options = opts)
                .WithNotParsed(errors => {
                    parseRes = false;
                });
            if (!parseRes)
                return;

            //foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(options))
            //{
            //    string name = descriptor.Name;
            //    object value = descriptor.GetValue(options);
            //    Console.WriteLine("{0}={1}", name, value);
            //}
            //Console.WriteLine($"Verbose: {options.Verbose}");
            //return;
            Console.WriteLine("Starting");
            Process myProcess = Process.Start("Notepad.exe");
            Console.WriteLine("Sleeping 5s");
            Thread.Sleep(5000);
            // Discard cached information about the process.
            myProcess.Refresh();
            if (!myProcess.HasExited)
            {
                Console.WriteLine("Closing");
                // Close process by sending a close message to its main window.
                myProcess.CloseMainWindow();
                // Free resources associated with process.
                myProcess.Close();
            }
            myProcess.Dispose();
            Console.WriteLine("Done");
        }
    }
}
