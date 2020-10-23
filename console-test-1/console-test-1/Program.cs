using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using CommandLine;
using System.ComponentModel;
using Tekla.Structures.Model;

namespace console_test_1
{
    class Program
    {
        private static Process teklaProc = null;
        private static Model teklaModel = null;
        private static ModelHandler teklaModelHandler = null;

        public class Options
        {
            [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
            public bool Verbose { get; set; }
        }

        static bool test_me()
        {
            Model tempModel = new Model();
            return tempModel.GetConnectionStatus();
        }

        static void StartTekla()
        {
            Process[] localAll = Process.GetProcesses();
            if (Process.GetProcessesByName("TeklaStructures").Length == 0)
            {
                Console.WriteLine("Starting Tekla Structures");
                //teklaProc = Process.Start(
                //    "C:\\Program Files\\Tekla Structures\\2020.0\\nt\\bin\\TeklaStructures.exe",
                //    "-I c:\\Users\\vagrant\\Documents\\tekla_custom_settings.ini c:\\TeklaStructuresModels\\empty_model"
                //);
            }

            Console.WriteLine("Waiting for Tekla Structures API to become available");

            bool connected = false;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (!connected)
            {
                try
                {
                    //bool wtf = teklaModel.GetConnectionStatus();
                    //teklaModel.GetInfo();
                    connected = test_me();
                    //if (!connected)
                    //{
                    //    Console.WriteLine("dummy1");
                    //    teklaModel = null;
                    //    System.GC.Collect();
                    //    System.GC.WaitForPendingFinalizers();
                    //    teklaModel = new Model();
                    //}
                }
                catch
                {
                    Console.WriteLine("dummy");
                    teklaModel = null;
                    System.GC.Collect();
                }
                if (sw.ElapsedMilliseconds > 120000) throw new TimeoutException();
                System.Threading.Thread.Sleep(5000);
            }

            teklaModelHandler = new ModelHandler();
            teklaModel = new Model();
        }

        static void OpenModel()
        {
            ModelInfo modelInfo = teklaModel.GetInfo();
            Console.WriteLine($"Current model: {modelInfo.ModelName} ({modelInfo.ModelPath})");

            if (!String.Equals(modelInfo.ModelPath, "c:\\TeklaStructuresModels\\empty_model", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Closing current model");
                teklaModelHandler.Close();
                Console.WriteLine("Opening 'empty_model' model");
                teklaModelHandler.Open("c:\\TeklaStructuresModels\\empty_model");
            }
        }

        static void CloseTekla()
        {
            if (teklaProc != null)
            {
                teklaProc.Refresh();
                if (!teklaProc.HasExited)
                {
                    Console.WriteLine("Stopping Tekla Structures");
                    // Close process by sending a close message to its main window.
                    teklaProc.CloseMainWindow();
                    // Free resources associated with process.
                    teklaProc.Close();
                }
            }
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

            StartTekla();
            OpenModel();
            CloseTekla();
            return;
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
