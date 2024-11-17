using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace greenVolt.Services
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public string? ErroMessage { get; set; }
        public bool HasError => !string.IsNullOrEmpty(ErroMessage);
    }
}


