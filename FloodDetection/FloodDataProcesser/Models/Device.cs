using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace FloodDataProcesser.Models
{
    public class Device
    {
        private string device_id;
        private string device_name;

        [CsvHelper.Configuration.Attributes.Name("Device ID")]
        public string DeviceId { get => device_id; set => device_id = value; }

        [CsvHelper.Configuration.Attributes.Name("Device Name")]
        public string DeviceName { get => device_name; set => device_name = value; }
        public string Location { get; set; }
    }
}
