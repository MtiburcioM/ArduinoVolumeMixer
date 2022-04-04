using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO.Ports;
using AudioSwitcher.AudioApi.CoreAudio;
using AudioSwitcher.AudioApi.Session;

namespace ConsoleMixer {
    class Program {
        static CoreAudioDevice ctrl = new CoreAudioController().DefaultPlaybackDevice;

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        static string browser = "brave";
        static string music = "spotify";
        static string vc = "discord";

        static int skipLen = 2;
        static string[] skipApps = { "idle", "steam", browser, music, vc };

        static void Main(string[] args) {
            Console.WriteLine("Enter COM Port Number (COMx): ");
            string portNumber = Console.ReadLine();

            Console.WriteLine("Loading AVM...");

            SerialPort sp = new SerialPort();

            sp.BaudRate = 9600;
            sp.PortName = "COM" + portNumber;

            try {
                sp.Open();
                Console.WriteLine("Running!");

                Console.WriteLine("Press any key to hide console!");
                Console.ReadKey();

                var handle = GetConsoleWindow();
                ShowWindow(handle, 0);
            } catch {
                Console.WriteLine("Please plug in your Arduino Volume Mixer Controle Module.");
            }

            while (true) {
                if (!sp.IsOpen) continue;

                string input = sp.ReadLine();
                char option = input[0];

                string inputBak = input;
                inputBak = inputBak.Remove(0, 1);

                int inputVal = Convert.ToInt32(inputBak);

                if (option == 'm') {
                    ctrl.Volume = Convert.ToDouble(inputVal);
                    continue;
                }

                foreach (IAudioSession session in ctrl.SessionController.All()) {
                    Process session_process = Process.GetProcessById(session.ProcessId);
                    string sessName = session_process.ProcessName.ToLower();

                    if (option == 'b' && sessName == browser) {
                        session.Volume = inputVal;
                        break;
                    } else if(option == 's' && sessName == music) {
                        session.Volume = inputVal;
                        break;
                    } else if(option == 'd' && sessName == vc) {
                        session.Volume = inputVal;
                        break;
                    } else if(option == 'g') {
                        bool b = true;
                        for(int i = 0; i < skipLen; i++) {
                            if(sessName != skipApps[i]) {
                                b = false;
                                break;
                            }
                        }

                        if(b) session.Volume = inputVal;
                    }
                }
            }
        }
    }
}
