using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class FilterDescriptor
    {
        public string? Field { get; set; }
        public FilterOperator Operator { get; set; }
        public object? value { get; set; }
    }
}
