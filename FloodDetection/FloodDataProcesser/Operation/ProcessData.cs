using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using CsvHelper.Configuration.Attributes;
using CsvHelper;
using System.IO;
using FloodDataProcesser.Models;
using FloodDataProcesser.Mock;
using System.Globalization;
using System.Configuration;

namespace FloodDataProcesser.Operation
{
    internal class ProcessData : IProcessData
    {
        public void Process()
        {
            var devices = this.GetDevices();

            // Getting files from folder
            string sourceFolder = ConfigurationManager.AppSettings["Sourcefolder"];
            string fileName = "";
            DirectoryInfo directoryInfo = new DirectoryInfo(sourceFolder);
            FileInfo[] Files = directoryInfo.GetFiles("Data*.csv");
            List<RainfallData> rainfallData = new List<RainfallData>();
            foreach (FileInfo file in Files)
            {
                fileName = Path.Combine(sourceFolder, file.Name);
                rainfallData.AddRange(this.GetRainfallData(fileName));
            }

            this.FindThreshold(devices, rainfallData);
        }

        
        private List<Device> GetDevices()
        {
            IDeviceOperation deviceOperation = new DeviceOperation();
            return deviceOperation.GetDevices();
        }

        private List<RainfallData> GetRainfallData(string fileName)
        {
            IRainfallOperation rainfallOperation = new RainfallOperation();
            return rainfallOperation.GetRainfallData(fileName);
        }

        private void FindThreshold(List<Device> devices, List<RainfallData> rainfallData)
        {
            DateTime maxTime = rainfallData.OrderByDescending(i => i.Time).First().Time;
            DateTime minTime = maxTime.AddHours(-4);

            foreach (var device in devices)
            {
                var rainfallForDevice = rainfallData.Where(r => r.DeviceId == device.DeviceId && r.Time >= minTime && r.Time <= maxTime).ToList();
                if (rainfallForDevice != null && rainfallForDevice.Count > 0)
                {
                    double average = rainfallForDevice.Sum(r => r.Rainfall) / rainfallForDevice.Count;
                    string threshold = "";
                    if (average < 10)
                    {
                        threshold = "Green";
                    }
                    else if (average < 15)
                    {
                        threshold = "Amber";
                    }
                    else if (average >= 15 || rainfallForDevice.Any(r => r.Rainfall > 30))
                    {
                        threshold = "Red";
                    }

                    Console.WriteLine("Device : {0}, Average Rainfall : {1}, Thresholds : {2}", device.DeviceName, average, threshold);
                }
            }
        }
    }
}
