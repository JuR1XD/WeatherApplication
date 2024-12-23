using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApplication
{
    public class NoItemsInListBoxException : Exception
    {

        public NoItemsInListBoxException() { }

        public NoItemsInListBoxException(string message) : base(message) { }

        public NoItemsInListBoxException(string message, Exception innerException) : base(message, innerException) { }

    }
}
