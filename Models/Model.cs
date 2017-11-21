using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy.Models
{   [Table("tbModel")] //Define o nome  que a tabela vai ser persisitida no banco de dados
    public class Model
    {
      
        public int Id { get; set; }
        [Required] //Define que o atributo não permite null
        [StringLength(255)] //Define o tamnho maximo da string
        public string Name { get; set; }

        public Make Make {get;set;}
        public int MakeId { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }

        Model(){
            Vehicles = new Collection<Vehicle>();
        }
                        
    }
}