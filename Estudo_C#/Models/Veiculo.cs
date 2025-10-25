using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estudo_C_.Models
{
    [Table("Veiculos")]
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Placa é obrigatório!")]
        [Display(Name = "Placa")]
        public string placa { get; set; }
        [Required(ErrorMessage = "Ano de fabricação é obrigatório!")]
        [Display(Name = "Ano de Fabricação")]
        public int anoFabricacao { get; set; }
        [Required(ErrorMessage = "Ano do modelo é obrigatório!")]
        [Display(Name = "Ano do Modelo")]
        public int anoModelo { get; set; }

        public ICollection<Consumos> Consumos {get; set;}
    }
}
