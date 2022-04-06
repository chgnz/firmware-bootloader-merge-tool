using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace gbox_ll_merge
{
    static class Program
    {    
        // defines for commandline output
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // command line
            if (Environment.GetCommandLineArgs().Length > 1)
            {
                AttachConsole(ATTACH_PARENT_PROCESS);
                Console.WriteLine();
                Console.WriteLine("run app with bootloader path, firmware path, output file path (*optional, default value : output.bin)");
                Console.WriteLine("generate fw_with_bootloader.bin : gbox ll merge.exe \"c:\\bootloader.bin\" \"c:\\fw.bin\" \"c:\\fw_with_bootloader.bin\"");


                string bootloader_location = "";
                string firmware_location = "";
                string output_location = "output.bin";
                
                string[] args = Environment.GetCommandLineArgs();

                Console.WriteLine("len : " + args.Length);

                if (args.Length > 1)
                {
                    bootloader_location = args[1];
                }

                if (args.Length > 2)                
                {
                    firmware_location = args[2];
                }

                if (args.Length > 3)             
                {
                    output_location = args[3];
                }


                Console.WriteLine("bootloader_location : " + bootloader_location);
                Console.WriteLine("firmware_location : " + firmware_location);
                Console.WriteLine("output_location : " + output_location);
                
                if (bootloader_location != "" && firmware_location != "")
                {
                    if (!File.Exists(bootloader_location) || !File.Exists(firmware_location))
                    {
                        Console.WriteLine("file doesnt exists");
                        return;
                    }

                    mapon_fw_merge n = new mapon_fw_merge();
                    n.create_output_file(bootloader_location, firmware_location, output_location);
                }
                else
                {
                    Console.WriteLine("incorrect filepath");
                }

            }
            else
            {
                Debug.WriteLine("ERROR, Arguments not set");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new mapon_fw_merge());
            }
        }
    }
}
