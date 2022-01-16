using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;
using CsvHelper;
using System.IO;
using FloodDataProcesser.Factory;
using FloodDataProcesser.Operation;

namespace FloodDetection
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessFactory processFactory = new ProcessFactory();
            processFactory.ProcessData.Process();
            
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }
    }
}
