using ColdrunERP.Core.Enums;

namespace ColdrunERP.Core.Interfaces.Dtos
{
    public interface ITruck
    {
        int Id { get; set; }
        string Code { get; set; }
        string Name { get; set; }
        TruckStatus Status { get; set; }
        string? Description { get; set; }
    }
}
