using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using CoolParking.BL.Interfaces;
using CoolParking.BL.Models;

namespace CoolParking.BL.Services
{
    class TimerService : ITimerService
    {
        Timer timer = new Timer();                      
        public double Interval                           
        {
            get { return timer.Interval; }
            set { timer.Interval = value; }
        }
        public event ElapsedEventHandler Elapsed          
        {
            add { timer.Elapsed += value; }
            remove { timer.Elapsed -= value; }
        }
        public void Dispose()
        {
            Dispose();
        }
        public void Start()
        {
            Elapsed += OnTimer;
            timer.Enabled = true;
            timer.AutoReset = true;

            void OnTimer(object sender, ElapsedEventArgs args)
            {
                using (IParkingService inParkingService = new ParkingService())
                {
                    ILogService inLogService = new LogService();

                    TransactionInfo[] historyArray = inParkingService.GetLastParkingTransactions();
                    foreach (TransactionInfo historyCar in historyArray)
                    {
                        if (historyCar.Sum != 0)
                        {
                            inLogService.Write(Convert.ToString("Сумма паркинга :  " + historyCar.Sum + " |  Время :  " + historyCar.NowTime + "  | id автомобиля :  " + historyCar.carVehicle().Id));
                        }
                    }
                }
            }
            Stop();
            timer.Start();
        }
        public void Stop()
        {
            timer.Stop();
        }
    }
}
