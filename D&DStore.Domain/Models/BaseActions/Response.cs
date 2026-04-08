using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_DStore.Domain.Models.BaseActions
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
