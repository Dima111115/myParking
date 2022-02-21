using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolParking.BL.Interfaces;
using CoolParking.BL.Models;

namespace CoolParking.BL.Services
{
    class ParkingService : IParkingService                 
    {
        private bool disposedValue;
        public void AddVehicle(Vehicle vehicle)                 
        {
            Parking.numbers.Add(vehicle);
        }
        public decimal GetBalance()
        {
            throw new NotImplementedException();
        }
        public int GetCapacity()                                  
        {
            int lensparc = Convert.ToInt32(Console.ReadLine()); 
            Parking.numbers.Capacity = lensparc;
            return lensparc;
        }
        public int GetFreePlaces()                                
        {
            return Parking.lensparcs - Parking.numbers.Count;
        }

        int i = 0;
        public TransactionInfo[] GetLastParkingTransactions()  
        {
            TransactionInfo[] TransactionInfoCar = new TransactionInfo[Parking.lensparcs];  
            foreach (Vehicle car in Parking.numbers)
            {
                if (car.Balance <= 0) { car.Balance -= Parking.fine; Parking.Balans += Parking.fine; }
                if (car.VehicleType == VehicleType.Bus)
                {
                    car.Balance -= Parking.rateBus;
                    Parking.Balans += Parking.rateBus;
                }
                else if (car.VehicleType == VehicleType.Truck)
                {
                    car.Balance -= Parking.rateTruck;
                    Parking.Balans += Parking.rateTruck;
                }
                else if (car.VehicleType == VehicleType.PassengerCar)
                {
                    car.Balance -= Parking.ratePassengerCar;
                    Parking.Balans += Parking.ratePassengerCar;
                }
                else if (car.VehicleType == VehicleType.Motorcycle)
                {
                    car.Balance -= Parking.rateMotorcycle;
                    Parking.Balans += Parking.rateMotorcycle;
                }
                TransactionInfoCar[i] = new TransactionInfo(Parking.Balans, DateTime.Now, car); 
                i++;
            }
            i = 0;
            return TransactionInfoCar;
        }
        public ReadOnlyCollection<Vehicle> GetVehicles()  
        {
            return Parking.numbers.AsReadOnly();
        }
        public string ReadFromLog()                       
        {
            throw new NotImplementedException();
        }
        public void RemoveVehicle(string vehicleId)   
        {
            bool Lighthouse1 = true;
            foreach (Vehicle cars in Parking.numbers)
            {
                if (cars.Id == vehicleId)
                {
                    Console.WriteLine($"id: {cars.Id }  | баланс {cars.Balance} | {cars.VehicleType}");
                    Parking.numbers.Remove(cars);
                    Console.WriteLine("машина снята с парковки ");
                    Lighthouse1 = false;
                    break;
                }
            }
            while (Lighthouse1)
            {
                Console.WriteLine("вы ввели неправильный ид, такой машины нет на парковке !!! "); break;
            }
        }
        public void TopUpVehicle(string vehicleId, decimal sum) 
        {
            bool Lighthouse2 = true;
            foreach (Vehicle carss in Parking.numbers)
            {
                if (carss.Id == vehicleId)
                {
                    Console.WriteLine($"id - {carss.Id}  | баланс - {carss.Balance}  |  тип авто - { carss.VehicleType} ");
                    carss.Balance += sum;
                    Console.WriteLine($"общая сумма - {carss.Balance}");
                    Lighthouse2 = false;
                    break;
                }
            }
            while (Lighthouse2)
            {
                Console.WriteLine("такой машины нет на парковке !!! "); break;
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
