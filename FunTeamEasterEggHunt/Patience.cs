using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FunTeamEasterEggHunt
{
    public static class Patience
    {
        const int WAIT_SECONDS = 57;
        static bool timeExpired = false;
        static bool patient = false;
        static object _locker = new object();

        static Thread waitThread;
        static Thread readThread;

        public static void startTest()
        {
            Console.Clear();
            timeExpired = false;
            bool end = false;

            Title.Clouds1();

            waitThread = new Thread(WaitThread);
            waitThread.Start();

            readThread = new Thread(ReadThread);
            readThread.Start();

            while (!end)
            {
                lock (_locker)
                {
                    end = patient;
                }
                Thread.Sleep(100);
            }

            if (end)
            {
                Utilities.WriteInfoPrompt("Congratulations, you have been patient.");
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Read Thread - reads any user input, resets if you haven't been patient!
        /// </summary>
        public static void ReadThread()
        {
            while (!timeExpired)
            {
                Utilities.ClearConsoleInput();
                Console.ReadKey(false);

                if (!timeExpired)
                {
                    Utilities.WriteInfoPrompt("You have not been patient!");
                    Console.Clear();

                    timeExpired = true;
                    Thread.Sleep(1000);
                    startTest();
                }
            }
        }

        /// <summary>
        /// WaitThread - spins and subtracts the start time from the current time until the difference is 30 seconds.
        /// </summary>
        public static void WaitThread()
        {
            var startTime = DateTime.Now.TimeOfDay;
            bool expired = false;

            while (!expired)
            {
                Thread.Sleep(500);
                var currentTime = DateTime.Now.TimeOfDay;
                var diffTime = currentTime.Subtract(startTime);

                switch (diffTime.Seconds)
                {
                    case 10:
                        Console.Clear();
                        Title.Clouds2();
                        break;
                    case 20:
                        Console.Clear();
                        Title.Clouds3();
                        break;
                    case 30:
                        Console.Clear();
                        Title.Clouds4();
                        break;
                    case 40:
                        Console.Clear();
                        Title.Clouds5();
                        break;
                    case 50:
                        Console.Clear();
                        Title.Clouds6();
                        break;
                }


                if (currentTime.Subtract(startTime).Seconds >= WAIT_SECONDS)
                {
                    lock (_locker)
                    {
                        timeExpired = true;
                        patient = true;
                    }
                }

                lock (_locker)
                {
                    expired = timeExpired;
                }
            }
        }
    }

}