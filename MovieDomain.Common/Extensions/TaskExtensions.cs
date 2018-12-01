using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace MovieDomain.Common.Extensions
{
    public static class TaskExtensions
    {

        //----------------------------------------------------------------//

        public static string GetExceptionLog(this Task task)
        {
            if(task.Exception != null)
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(task.Status.ToString());
                builder.Append(Thread.CurrentThread.ManagedThreadId);
                builder.AppendExceptionLog(task.Exception);
                task.Exception.InnerExceptions.ForEach(e => builder.AppendExceptionLog(e));
                return builder.ToString();
            }

            return String.Empty;
        }

        //----------------------------------------------------------------//

    }
}
