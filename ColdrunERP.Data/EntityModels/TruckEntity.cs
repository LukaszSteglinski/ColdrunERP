using ColdrunERP.Core.Enums;

namespace ColdrunERP.Data.EntityModels
{
    public class TruckEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get;  set ; }
        public TruckStatus Status { get; set; }
        public string? Description { get; set; }
    }
}
