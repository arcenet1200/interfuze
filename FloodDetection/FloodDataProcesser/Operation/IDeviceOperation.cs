using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FloodDataProcesser.Models;

namespace FloodDataProcesser.Operation
{
    internal interface IDeviceOperation
    {
        List<Device> GetDevices();
    }
}
