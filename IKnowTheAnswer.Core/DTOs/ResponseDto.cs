using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKnowTheAnswer.Core.DTOs
{
    public class ResponseDto<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }
        public bool Success { get; set; } = false;
    }
}
