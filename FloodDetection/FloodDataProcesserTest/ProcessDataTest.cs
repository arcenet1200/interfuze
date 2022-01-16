using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using FloodDataProcesser.Mock;
using FloodDataProcesser.Models;
using System.Collections.Generic;
using FloodDataProcesser.Operation;

namespace FloodDataProcesserTest
{
    [TestClass]
    public class ProcessDataTest
    {
        [TestMethod]
        public void ProcessData_Process()
        {
            Mock<DeviceOperation> mockDevices = new Mock<DeviceOperation>();
            Mock<RainfallOperation> mockRainfallData = new Mock<RainfallOperation>();
            IProcessDataMock processDataMock = new ProcessData();
            processDataMock.Process(mockDevices.Object.GetDevices(), mockRainfallData.Object.GetRainfallData());
        }

    }
}
