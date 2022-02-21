using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolParking.BL.Interfaces;
using CoolParking.BL.Services;
using CoolParking.BL.Models;

namespace CoolParking.BL
{
    class Program
    {
        static void Main(string[] args)
        {
           // Console.Beep(523, 500);   // звук компютера (высота ,длинна)
            Console.ForegroundColor = ConsoleColor.Yellow;    
            Console.BackgroundColor = ConsoleColor.DarkBlue;  
           
            Console.WriteLine("           добро пожаловать в программу учета машин на парковке !!!");
            Console.ResetColor();                       

            Settings WorkParking = new Settings();
            WorkParking.Settingsaa();

            Console.ReadKey();
        }
    }
}
