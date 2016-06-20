using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISING.STAR.Entities.Results
{
    public class Result
    {

        public string message { get; set; }
        public string guid { get; set; }

        public Result(string _message, string _guid)
        {
            message = _message;
            guid = _guid;
        }

    }
}
