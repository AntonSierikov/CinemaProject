using MovieDomain.Abstract;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace MoviesDomain.Entities
{
    public class ExceptionLog 
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public string Source { get; set; }

        public string StackTrace { get; set; }

        public DateTime TimeException { get; set; }

        //----------------------------------------------------------------//

        public ExceptionLog()
        {
            TimeException = DateTime.Now;
        }

        //----------------------------------------------------------------//

        public ExceptionLog(string message, string source, string stackTrace)
            : this()
        {
            Message = message;
            Source = source;
            StackTrace = stackTrace;
        }

        //----------------------------------------------------------------//

        public ICollection<ExceptionLog> InnerExceptionTo { get; set; }

        public ICollection<ExceptionLog> InnerExceptionFrom { get; set; }

        //----------------------------------------------------------------//

    }
}
