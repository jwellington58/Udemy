using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Udemy.Models;

namespace Udemy.Controllers.Resources
{
    public class SaveVehicleResource
    {
        public int Id { get; set; }

        public bool IsRegistered { get; set; }
        [Required]
        public ContactResource Contact { get; set; }
       
        public ICollection<int> Features { get; set; }

        public int modelId { get; set; }

        

        public SaveVehicleResource()
        {
               Features = new Collection<int>();   
        }
    }
}