using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsers.Data.Dtos
{
    public class GeneralResponse <T>
    {
        public int Code { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get;set; }
    }
}
