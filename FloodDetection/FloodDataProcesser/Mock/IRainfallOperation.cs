using FloodDataProcesser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodDataProcesser.Mock
{
    public interface IRainfallOperation
    {
        List<RainfallData> GetRainfallData();
    }
}
