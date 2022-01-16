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
using System.Globalization;

namespace FloodDataProcesser.Mock
{
    public class DeviceOperation : IDeviceOperation
    {
        public List<Device> GetDevices()
        {
            List<Device> devices = new List<Device>();

            Device device = new Device();
            device.DeviceId = "10451";
            device.DeviceName = "Gauge 1";
            device.Location = "Biyamiti";

            devices.Add(device);

            return devices;
        }
    }
}
