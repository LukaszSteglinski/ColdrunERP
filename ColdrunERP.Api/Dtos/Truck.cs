using ColdrunERP.Core.Enums;
using ColdrunERP.Core.Interfaces.Dtos;

namespace ColdrunERP.Api.Dtos
{
    public class Truck : ITruck
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get;  set ; }
        public TruckStatus Status { get; set; }
        public string? Description { get; set; }
    }
}
