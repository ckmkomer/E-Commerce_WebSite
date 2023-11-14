using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.CoreLayer.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message, bool success) : base(message, success)
        {
        }
        public SuccessResult() : base(true)
        {

        }
    }
}
