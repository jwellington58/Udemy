using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Udemy.Context;
using Udemy.Models;

namespace Udemy.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly UdemyContext context;
        public VehicleRepository(UdemyContext context)
        {
            this.context = context;

        }
        public async Task<IEnumerable<Vehicle>> GetVehicles(){
            return await context.Vehicles
                         .Include(v=> v.Model).ThenInclude(m => m.Make)
                         .Include(v => v.Features).ThenInclude(vf => vf.Feature)
                         .ToListAsync();
        }
        public async Task<Vehicle> GetVehicle(int id, bool relatedInclude = true)
        {
            if(!relatedInclude){
                return await context.Vehicles.FindAsync(id);
            }
            return await context.Vehicles
            .Include(v => v.Features).ThenInclude(vf => vf.Feature)
            .Include(v => v.Model).ThenInclude(m => m.Make)
            .SingleOrDefaultAsync(v => v.Id == id);
        }

        public void AddVehicle(Vehicle vehicle){
            context.Vehicles.Add(vehicle);
        }
        public void RemoveVehicle(Vehicle vehicle){
             context.Remove(vehicle);
        }

        public async Task<Model> GetModel(int id){
            return await context.Models.FindAsync(id);
        }
    }
}