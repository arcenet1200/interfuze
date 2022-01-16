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
using System.Configuration;

namespace FloodDataProcesser.Operation
{
    internal class DeviceOperation : IDeviceOperation
    {
        public List<Device> GetDevices()
        {
            List<Device> devices = new List<Device>();
            string sourceFile = ConfigurationManager.AppSettings["DeviceFile"];
            using (var reader = new StreamReader(sourceFile))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var device = csv.GetRecord<Device>();
                    if (device != null && !String.IsNullOrEmpty(device.DeviceId))
                        devices.Add(device);
                }
                return devices;
            }
        }
    }
}
