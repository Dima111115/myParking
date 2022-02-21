
using System;

namespace CoolParking.BL.Models
{
    public struct TransactionInfo  
    {
        private DateTime nowTime;    
        private Vehicle vehicle;
        readonly decimal sum;
        public TransactionInfo(decimal carsum, DateTime timeMoney, Vehicle CarVehicle) 
        {
            sum = carsum; nowTime = timeMoney; vehicle = CarVehicle; 
        } 
        public decimal Sum { get { return sum; } }
        public DateTime NowTime { get { return nowTime; } }
        public Vehicle carVehicle()
        {
            return vehicle;
        }
    }
}





