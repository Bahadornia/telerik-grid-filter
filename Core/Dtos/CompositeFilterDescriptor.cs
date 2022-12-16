using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class CompositeFilterDescriptor
    {
        public string? Logic { get; set; }
        public IReadOnlyList<FilterDescriptor>? Filters { get; set; }

    }
}
