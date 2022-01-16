using FloodDataProcesser.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodDataProcesserTest
{
    [TestClass]
    public class DeviceTest
    {
        [TestMethod]
        public void Device_Call_Atleast_Once()
        {
            Mock<IDeviceOperation> mockDevices = new Mock<IDeviceOperation>();
            
            mockDevices.Setup(mock => mock.GetDevices());
            mockDevices.Object.GetDevices();
            mockDevices.Verify(mock => mock.GetDevices(), Times.Once());
        }
    }
}
