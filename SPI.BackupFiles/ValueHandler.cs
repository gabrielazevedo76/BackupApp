using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPI.BackupFiles
{
    public class ValueHandler
    {

        public int Value { get; set; }

        public ValueHandler(){}

        public ValueHandler(int value)
        {
            Value = value;
        }
    }
}
