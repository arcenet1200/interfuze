using FloodDataProcesser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodDataProcesser.Operation
{
    internal interface IRainfallOperation
    {
        List<RainfallData> GetRainfallData(string fileName);
    }
}
