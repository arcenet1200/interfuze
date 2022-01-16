using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloodDataProcesser.Operation;
namespace FloodDataProcesser.Factory
{
    public class ProcessFactory
    {
        private IProcessData _processData;

        public IProcessData ProcessData
        {
            get
            {
                if (_processData == null)
                {
                    _processData = new ProcessData();
                }
                return _processData;
            }
        }
    }
}
