using System.Collections.Generic;
using System.Threading.Tasks;
using Udemy.Models;

namespace Udemy.Repository
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetVehicles();

        Task<Vehicle> GetVehicle(int id, bool relatedInclude = true);
        void AddVehicle(Vehicle vehicle);
        void RemoveVehicle(Vehicle vehicle);

        Task<Model> GetModel(int id);
    }
}