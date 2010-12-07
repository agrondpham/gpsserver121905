using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;

namespace ListeningSocketGPS
{
    class GPSListeningConsole
    {
        static void Main(string[] args)
        {
            try
            {
                //open thread to receip data from devices
                Thread thread;
                thread = new Thread(new ThreadStart(ListenToGPS));
                thread.Start();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }
        private static void ListenToGPS()
        {
            try
            {
                //call method for listening information form devices
                SocketGPS socketGPS = new SocketGPS();
                socketGPS.CreateSocket();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }
    }
}
