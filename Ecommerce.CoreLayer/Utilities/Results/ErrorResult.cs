using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.CoreLayer.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message, bool success) : base(message, success)
        {
        }

        public ErrorResult() : base(false)
        {

        }
    }
}
