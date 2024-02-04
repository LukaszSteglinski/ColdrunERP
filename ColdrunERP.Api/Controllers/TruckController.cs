using ColdrunERP.Api.Filters;
using ColdrunERP.Business.Dtos;
using ColdrunERP.Business.Services.Interfaces;
using ColdrunERP.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ColdrunERP.Api.Controllers
{
    [ApiController]
    [Route("api/trucks")]
    public class TruckController : ControllerBase
    {
        private readonly ITruckService _truckService;

        public TruckController(ITruckService truckService)
        {
            _truckService = truckService;
        }

        /// <summary>
        /// Gets a list of all trucks.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllTrucks()
        {
            var trucks = await _truckService.GetAllTrucksAsync();
            return Ok(trucks);
        }

        /// <summary>
        /// Gets a list of filtered trucks.
        /// </summary>
        /// <param name="filter">Parameters to filter Trucks.</param>
        [HttpPost("filter")]
        public async Task<IActionResult> GetAllTrucksByFilter([FromBody] TruckFilter filter)
        {
            var filteredTrucks = await _truckService.GetFilteredTrucksAsync(filter);
            return Ok(filteredTrucks);
        }

        /// <summary>
        /// Gets a specific truck by its Id.
        /// </summary>
        /// <param name="id">The id of the truck.</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTruckByCode(int id)
        {
            var truck = await _truckService.GetTruckByIdAsync(id);
            if (truck is null)
            {
                return NotFound();
            }

            return Ok(truck);
        }

        /// <summary>
        /// Adds a new truck.
        /// </summary>
        /// <param name="truck">The truck to add.</param>
        [HttpPost]
        public async Task<IActionResult> AddTruck([FromBody] Truck truck)
        {
            await _truckService.AddTruckAsync(truck);
            return CreatedAtAction(nameof(GetTruckByCode), new { id = truck.Id }, truck);
        }

        /// <summary>
        /// Updates an existing truck.
        /// </summary>
        /// <param name="id">The ID of the truck to update.</param>
        /// <param name="truck">The updated truck data.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTruck(int id, [FromBody] Truck truck)
        {
            await _truckService.UpdateTruckAsync(truck);
            return NoContent();
        }

        /// <summary>
        /// Deletes a specific truck by its ID.
        /// </summary>
        /// <param name="id">The id of the truck to delete.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTruck(int id)
        {
            await _truckService.DeleteTruckAsync(id);
            return NoContent();
        }


        /// <summary>
        /// Updates status of a specific truck by its ID.
        /// </summary>
        /// <param name="id">The id of the truck to update status.</param>
        [HttpPut("{id}/update-status")]
        public async Task<IActionResult> UpdateTruckStatus(int id, [FromBody] TruckStatus status)
        {
            var success = await _truckService.UpdateTruckStatusAsync(id, status);

            if (success)
            {
                return Ok("Truck status updated successfully");
            }

            return NotFound("Truck not found or invalid status transition");
        }
    }
}
