using ColdrunERP.Core.Enums;
using ColdrunERP.Core.Interfaces.Filters;
using System.Runtime.InteropServices;

namespace ColdrunERP.Api.Filters
{
    public class TruckFilter : ITruckFilter
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public TruckStatus? Status { get; set; }
        public string? Description { get; set; }
    }
}
