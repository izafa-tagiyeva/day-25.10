using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.helper.Exceptions
{
    public class PriceMustBeGratherThanZeroException:Exception
    {

        public PriceMustBeGratherThanZeroException() : base() { }


        public PriceMustBeGratherThanZeroException(string message) : base(message) { }



    }
}
