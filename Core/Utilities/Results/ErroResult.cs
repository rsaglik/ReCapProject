using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErroResult: Result
    {
        public ErroResult(string message) : base(false, message)
        {
        }
        public ErroResult() : base(false)
        {
        }
    }
}
