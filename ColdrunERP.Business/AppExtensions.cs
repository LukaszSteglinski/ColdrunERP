using ColdrunERP.Business.Dtos;
using ColdrunERP.Data.EntityModels;

namespace ColdrunERP.Core
{
    public static class AppExtensions
    {
        public static Truck ToDto(this TruckEntity entity)
        {
            return new Truck()
            {
                Id = entity.Id,
                Code = entity.Code,
                Name = entity.Name,
                Status = entity.Status,
                Description = entity.Description
            };
        }

        public static TruckEntity ToEntity(this Truck dto)
        {
            return new TruckEntity()
            {
                Id = dto.Id,
                Code = dto.Code,
                Name = dto.Name,
                Status = dto.Status,
                Description = dto.Description
            };
        }
    }
}
