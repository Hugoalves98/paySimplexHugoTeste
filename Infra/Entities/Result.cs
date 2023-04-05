using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Entities
{
    public class Result
    {
        public int Code { get; set; }
        
        public string? Message { get; set; }

        public object? Obj { get; set; }
    }
}
