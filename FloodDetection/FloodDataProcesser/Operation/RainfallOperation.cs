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

namespace FloodDataProcesser.Operation
{
    internal class RainfallOperation: IRainfallOperation
    {
        public List<RainfallData> GetRainfallData(string fileName)
        {
            List<RainfallData> rainfallData = new List<RainfallData>();
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var rainfall = csv.GetRecord<RainfallData>();
                    if (rainfall != null && !String.IsNullOrEmpty(rainfall.DeviceId))
                        rainfallData.Add(rainfall);
                }

                return rainfallData;
            }
        }
    }
}
