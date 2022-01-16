using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodDataProcesser.Models
{
    public class RainfallData
    {
        private string device_id;

        [CsvHelper.Configuration.Attributes.Name("Device ID")]
        public string DeviceId { get => device_id; set => device_id = value; }
        public DateTime Time { get; set; }
        public double Rainfall { get; set; }
    }
}
