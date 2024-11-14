using PinkPlate.Domain.Entitys;
using System.ComponentModel.DataAnnotations;

namespace PinkPlate.Domain.Produto.Models
{
    public class Produto : Entity
    {
        [Required]
        [StringLength(15)]
        public string Codigo { get; private set; }

        [StringLength(500)]
        public string Descricao { get; private set; }
    }
}
