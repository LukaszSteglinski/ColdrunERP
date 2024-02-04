using ColdrunERP.Core.Enums;

namespace ColdrunERP.Core.Interfaces.Filters
{
    public interface ITruckFilter
    {
        string Code { get; set; }
        string Name { get; set; }
        TruckStatus? Status { get; set; }
        string Description { get; set; }
    }
}
