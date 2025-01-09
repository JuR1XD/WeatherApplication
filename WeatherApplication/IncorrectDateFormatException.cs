using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApplication
{
    public class IncorrectDateFormatException : Exception
    {

        public IncorrectDateFormatException() { }

        public IncorrectDateFormatException(string message) : base(message) { }

        public IncorrectDateFormatException(string message, Exception innerException) : base(message, innerException) { }

    }
}
