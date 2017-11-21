using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Udemy.Context;
using Udemy.Controllers.Resources;
using Udemy.Models;
using Udemy.Repository;

namespace Udemy.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
       
        private readonly IVehicleRepository repository;
        public readonly IUnitOfWork unitOfWork;
        public VehiclesController(IMapper mapper, IVehicleRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;

        }

       /* [HttpGet]
        public async Task<IEnumerable<Vehicle>> GetVehicles(){
            var vehicle =  await repository.GetVehicles();
            
            return  mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleResource>>(vehicle);
        }*/

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await repository.GetVehicle(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            var vr = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(vr);

        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource vr)
        {   //Input validations ==> Strings, atributos obtrigatorios etc...
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);

            }
            /*Busines validations ==> são outra validações que fogem das inputs validations;
                ex:
                    if(true){
                        ModelState.AddModelError("mensagem", "error");
                        return BadRequest(ModelState);
                    }
           */
            var model = await repository.GetModel(vr.modelId);
            if (model == null)
            {
                ModelState.AddModelError("ModelId", "Invalid modelId");
                return BadRequest(ModelState);

            }

            var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vr);
            vehicle.LastUpdate = DateTime.Now;
            repository.AddVehicle(vehicle);
            await unitOfWork.CompleteAsync();

            vehicle = await repository.GetVehicle(vehicle.Id);

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleResource vr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var vehicle = await repository.GetVehicle(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            var model = await repository.GetModel(vr.modelId);
            if (model == null)
            {
                ModelState.AddModelError("ModelId", "Invalid modelId");
                return BadRequest(ModelState);

            }

            mapper.Map<SaveVehicleResource, Vehicle>(vr, vehicle);
            vehicle.LastUpdate = DateTime.Now;
            await unitOfWork.CompleteAsync();
            
            vehicle = await repository.GetVehicle(vehicle.Id);

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            //return Ok(result);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await repository.GetVehicle(id, false);
            if (vehicle == null)
            {
                return NotFound();
            }
            repository.RemoveVehicle(vehicle);
            await unitOfWork.CompleteAsync();
            return Ok(id);
        }
    }
}