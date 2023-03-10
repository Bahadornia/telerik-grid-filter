using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FilterOperator
    {
        Zero,
        Contains,
        Doesnotcontain,
        Doesnotendwith,
        Doesnotstartwith,
        Endswith,
        Eq,
        Gt,
        Gte,
        Isempty,
        Isnotempty,
        Isnotnull,
        Isnull,
        Lt,
        Lte,
        Neq,
        Startswith
    }
}
