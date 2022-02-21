using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolParking.BL.Interfaces;
using System.IO;

namespace CoolParking.BL.Services
{
    class LogService : ILogService
    {
        public string logPath = "text.txt";
        public string LogPath { get { return logPath; } }   
        public string Read()
        {
            using (var reader = new StreamReader(logPath, Encoding.GetEncoding(1251)))
            {
                string input;

                while ((input = reader.ReadLine()) != null)    
                {
                    Console.WriteLine(input);    
                }
                reader.Close();
                return input;
            }
        }
        public void Write(string logInfo)   
        {
            using (var file2 = new FileStream(logPath, FileMode.Append, FileAccess.Write))
            {
                var writer = new StreamWriter(file2, Encoding.GetEncoding(1251));
                writer.WriteLine(logInfo);
                writer.Close();
            }
        }
    }
}

