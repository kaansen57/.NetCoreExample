using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //private bool _success;
        //private string _messages;

        public Result(bool success, string messages):this(success)
        {
            /* sadece get olan propertyler yani readonly olanlar , setter olmadan constructorda set edilebilir. */
            Message = messages;
        }

        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
