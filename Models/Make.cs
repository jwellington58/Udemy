using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy.Models
{   [Table("tbMake")]//define o nome que a entidade sera persistida no banco de dados
    public class Make
    {
        public int Id { get; set; }
       [Required] //Define que o atributo não permite null
       [StringLength(255)] //Define o tamnho maximo da string
        public string Name { get; set; }
        public ICollection<Model> Models {get; set;}

        public Make(){
            Models = new Collection<Model>();
        }
    }
}