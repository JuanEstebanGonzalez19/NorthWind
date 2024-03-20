using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Exceptions
{
    public class GeneralException
    {
        public string Details { get; set; }
        public GeneralException() { }
        public GeneralException(string message) : base(message){ }
        public GeneralException(string message, 
            Exception innerException) : base(
                message, innerException) { }
    }
}
