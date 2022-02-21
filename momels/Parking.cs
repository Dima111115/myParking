
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolParking.BL.Models
{
   static class Parking  
    {
        public static decimal Balans = 0;
        public static List<Vehicle> numbers = new List<Vehicle>() {};
        public static int lensparcs;

        public static decimal fine = 2.5M;

        public static decimal ratePassengerCar = 2M;
        public static decimal rateTruck = 5M;
        public static decimal rateBus = 3.5M;
        public static decimal rateMotorcycle = 1M;


    }
}