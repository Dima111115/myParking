
namespace CoolParking.BL.Models
{
    public class Vehicle  
    {
        private readonly string id;
        private readonly VehicleType vehicleType;
        private decimal balance;
        public Vehicle(string Id, VehicleType VehicleType, decimal Balance)
        {
            this.id = Id;
            this.vehicleType = VehicleType;
            this.balance = Balance;
        }
        public string Id { get { return id; } } 
        public VehicleType VehicleType { get { return vehicleType; } } 
        public decimal Balance { get { return balance; } set { balance = value; } } 
    }
}