using FloodDataProcesser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodDataProcesser.Mock
{
    public class ProcessData : IProcessDataMock
    {
        public void Process(List<Device> devices, List<RainfallData> rainfallData)
        {
            this.FindThreshold(devices, rainfallData);
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
