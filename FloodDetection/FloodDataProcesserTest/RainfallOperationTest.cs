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
    public class RainfallOperationTest
    {
        [TestMethod]
        public void RainfallData_Call_Atleast_Once()
        {
            Mock<IRainfallOperation> mockRainfallData = new Mock<IRainfallOperation>();

            mockRainfallData.Setup(mock => mock.GetRainfallData());
            mockRainfallData.Object.GetRainfallData();
            mockRainfallData.Verify(mock => mock.GetRainfallData(), Times.Once());
        }
    }
}
