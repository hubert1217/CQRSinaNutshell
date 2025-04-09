using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Responses
{
    public enum ResponseStatus
    {
        Success = 0,
        NotFound = 1,
        BadQueryRequest = 2,
        ValidationError = 3,
        Exception = 4,
        DataBaseError = 5,
        OtherClientApiError = 6
    }
}
