
using System;
using System.Collections.Generic;
using CoolParking.BL.Interfaces;
using CoolParking.BL.Services;
using System.Text.RegularExpressions;

namespace CoolParking.BL.Models
{
    class Settings
    {
        IParkingService ipService = new ParkingService();
        public void Settingsaa()
        {
            Parking.Balans = 0;
            while (true)
            {
                try
                {
                    Console.WriteLine("введите баланс парковки");
                    Parking.Balans = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("введите вместимость парковки");
                    Parking.lensparcs = ipService.GetCapacity();
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Message:  {0}", e.Message);
                }
            }
            ITimerService counter = new TimerService();           
            counter.Interval = 5000;                              //интервал
            counter.Start();

            bool flag = true;

            while (flag)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(@"                       нажмите цифру для следующей операции:
                
                1 добавить тр,      3 показать баланс паркинга ,        5 читать историю с журнала
                2 удалить тр,       4 пополнить щет автомобилю ,        6 настройки
                                                                        9 выход с программы ");
                Console.ResetColor();
                int Lighthouse = 0;
                try
                {
                    Lighthouse = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Message:  {0}", e.Message);
                }
                switch (Lighthouse)
                {
                    case 0: { break; }
                    case 1:
                        {
                            if (Parking.lensparcs > Parking.numbers.Count)          //свободны ли места
                            {
                                string id = "00000000";
                                bool flags = true;
                                const string limitation = "[A-Z][A-Z][0-9][0-9][0-9][0-9][A-Z][A-Z]";
                                var limitations = new Regex(limitation);
                                while (flags)
                                {
                                    Console.WriteLine("введите ид автомобиля (формат ввода XX0000XX):");
                                    id = Console.ReadLine().ToUpper();
                                    flags = !limitations.IsMatch(id);
                                }
                                decimal Balance = 0;
                                while (true)
                                {
                                    try
                                    {
                                        Console.WriteLine("баланс авто");
                                        Balance = Convert.ToDecimal(Console.ReadLine());
                                        break;
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("Message:  {0}", e.Message);
                                    }
                                }
                                int carType = 0;
                                while (!(carType > 0 && carType <= 4))
                                {
                                    try
                                    {
                                        Console.WriteLine("введите тип авто : легковой = 1, грузовик = 2, автобус = 3, мотоцикл =4,");
                                        carType = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("Message:  {0}", e.Message);
                                    }
                                }
                                VehicleType VehicleTy = (VehicleType)carType;

                                ipService.AddVehicle(new Vehicle(id, VehicleTy, Balance));
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("введите id - объекта  который нужно удалить (формат ввода XX0000XX):");
                            ipService.RemoveVehicle(Console.ReadLine().ToUpper());
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine($"Баланс  паркинга - {Parking.Balans }");
                            Console.WriteLine("количество занятых мест");
                            {
                                Console.WriteLine(Parking.numbers.Count);
                            }
                            Console.WriteLine($"сколько свободных мест - {ipService.GetFreePlaces()}");

                            Console.WriteLine("для подробной информации о всех транспортных средствах нажмите 1");
                            int hhhh = Convert.ToInt32(Console.ReadLine());
                            if (hhhh == 1)
                            {
                                Console.WriteLine("транспортные стредства : ");
                                foreach (Vehicle c in Parking.numbers)
                                {
                                    Console.WriteLine($"id - {c.Id} |    баланс - {c.Balance} |   тип авто - { c.VehicleType}");
                                }
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("введите id автомобиля (формат ввода XX0000XX):");
                            string vehicleId = Console.ReadLine().ToUpper();
                            decimal sum;
                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine("введите сумму оплаты");
                                    sum = Convert.ToDecimal(Console.ReadLine());
                                    break;
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Message:  {0}", e.Message);
                                }
                            }
                            ipService.TopUpVehicle(vehicleId, sum);
                            break;
                        }
                    case 5:
                        {
                            ILogService xx = new LogService();
                            string cc = xx.Read();
                            break;
                        }
                    case 6:
                        {
                            bool flag2 = true;
                            while (flag2)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(@"                       нажмите цифру для следующей операции:
                
                1 инкассация                   3  изменить размер тарифа            8 выход из меню настроек
                2 изменить размер штрафа       4 изменить период списания денег              ");

                                Console.ResetColor();
                                int beaconSettings = 0;
                                try
                                {
                                    beaconSettings = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Message:  {0}", e.Message);
                                }
                                switch (beaconSettings)
                                {
                                    case 0: { break; }
                                    case 1:
                                        {
                                            decimal seizure = 0;
                                            Console.WriteLine($"Баланс  паркинга - {Parking.Balans }");
                                            Console.WriteLine("введите сумму изъятия");
                                            try
                                            {
                                                seizure = Convert.ToDecimal(Console.ReadLine());
                                                while (seizure <= Parking.Balans) { Parking.Balans -= seizure; break; }
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine("Message:  {0}", e.Message);
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine($"размер пени - {Parking.fine }");
                                            Console.WriteLine("введите новый размер пени");
                                            try
                                            {
                                                Parking.fine = Convert.ToDecimal(Console.ReadLine());
                                                Console.WriteLine($"размер пени - {Parking.fine }");
                                                break;
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine("Message:  {0}", e.Message);
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            bool flag3 = true;
                                            while (flag3)
                                            {
                                                Console.WriteLine($@"нажмите цифру для смены тарифа :
                
                                           1   Пассажирский автомобиль стоимость:{Parking.ratePassengerCar}          
                                           2   Грузовой автомобиль стоимость:{Parking.rateTruck}   
                                           3   Автобус стоимость:{Parking.rateBus}
                                           4   Мотоцикл стоимость:{Parking.rateMotorcycle}
                                           7   выход  ");
                                                int lighthouseFare = 0;
                                                try
                                                {
                                                    lighthouseFare = Convert.ToInt32(Console.ReadLine());
                                                }
                                                catch (Exception e)
                                                {
                                                    Console.WriteLine("Message:  {0}", e.Message);
                                                }
                                                switch (lighthouseFare)
                                                {
                                                    case 0: { break; }
                                                    case 1:
                                                        {
                                                            Console.Write("Пассажирский автомобиль стоимость услуг= ");
                                                            Console.WriteLine(Parking.ratePassengerCar);
                                                            Console.WriteLine("введите новы тариф:");
                                                            try
                                                            {
                                                                Parking.ratePassengerCar = Convert.ToDecimal(Console.ReadLine());
                                                                Console.Write("Пассажирский автомобиль стоимость услуг= ");
                                                                Console.WriteLine(Parking.ratePassengerCar);
                                                            }
                                                            catch (Exception e)
                                                            {
                                                                Console.WriteLine("Message:  {0}", e.Message);
                                                            }
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            Console.Write("грузовой автомобиль стоимость услуг= ");
                                                            Console.WriteLine(Parking.rateTruck);
                                                            Console.WriteLine("введите новы тариф:");
                                                            try
                                                            {
                                                                Parking.rateTruck = Convert.ToDecimal(Console.ReadLine());
                                                                Console.Write("грузовой автомобиль стоимость услуг= ");
                                                                Console.WriteLine(Parking.rateTruck);
                                                            }
                                                            catch (Exception e)
                                                            {
                                                                Console.WriteLine("Message:  {0}", e.Message);
                                                            }
                                                            break;
                                                        }
                                                    case 3:
                                                        {
                                                            Console.Write("автобус стоимость услуг= ");
                                                            Console.WriteLine(Parking.rateBus);
                                                            Console.WriteLine("введите новы тариф:");
                                                            try
                                                            {
                                                                Parking.rateBus = Convert.ToDecimal(Console.ReadLine());
                                                                Console.Write("автобус стоимость услуг= ");
                                                                Console.WriteLine(Parking.rateBus);
                                                            }
                                                            catch (Exception e)
                                                            {
                                                                Console.WriteLine("Message:  {0}", e.Message);
                                                            }
                                                            break;
                                                        }
                                                    case 4:
                                                        {
                                                            Console.Write("мотоцикл стоимость услуг= ");
                                                            Console.WriteLine(Parking.rateMotorcycle);
                                                            Console.WriteLine("введите новы тариф:");
                                                            try
                                                            {
                                                                Parking.rateMotorcycle = Convert.ToDecimal(Console.ReadLine());
                                                                Console.Write("мотоцикл стоимость услуг= ");
                                                                Console.WriteLine(Parking.rateMotorcycle);
                                                            }
                                                            catch (Exception e)
                                                            {
                                                                Console.WriteLine("Message:  {0}", e.Message);
                                                            }
                                                            break;
                                                        }
                                                    case 7: { flag3 = false; break; }
                                                    default:
                                                        {
                                                            Console.WriteLine("вы ввели недопустимое число");
                                                            break;
                                                        }
                                                }
                                            }
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.WriteLine($"период списания = {counter.Interval} ");
                                            Console.WriteLine(@"введите новый период в формате: 1 сек.= 1000 Млc., 1 Час = 3600000 Млc., 1 День = 86400000 Млc.");
                                            int timeWriteOffs = 0;
                                            try
                                            {
                                                timeWriteOffs = Convert.ToInt32(Console.ReadLine());
                                                counter.Interval = timeWriteOffs;
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine("Message:  {0}", e.Message);
                                            }
                                            Console.WriteLine($" новый период  ={counter.Interval}");
                                            break;
                                        }
                                    case 8: { flag2 = false; break; }
                                    default:
                                        {
                                            Console.WriteLine("вы ввели недопустимое число");
                                            break;
                                        }
                                }
                            }
                            break;
                        }
                    case 9:
                        {
                            flag = false; break;
                        }
                    default:
                        {
                            Console.WriteLine("вы ввели недопустимое число");
                            break;
                        }
                }
            }
        }
    }
}

