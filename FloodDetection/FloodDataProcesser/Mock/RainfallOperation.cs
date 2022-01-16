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
    public class RainfallOperation: IRainfallOperation
    {
        public List<RainfallData> GetRainfallData()
        {
            List<RainfallData> rainfallData = new List<RainfallData>();

            RainfallData rainfallDataItem = new RainfallData();
            rainfallDataItem.DeviceId = "10451";
            rainfallDataItem.Time = DateTime.Now;
            rainfallDataItem.Rainfall = 30;

            rainfallData.Add(rainfallDataItem);

            return rainfallData;
        }
    }
}
