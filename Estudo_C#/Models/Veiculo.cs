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
        public string placa { get; set; }
        [Required(ErrorMessage = "Ano de fabricação é obrigatório!")]
        public int anoFabricacao { get; set; }
        [Required(ErrorMessage = "Ano do modelo é obrigatório!")]
        public int anoModelo { get; set; }
    }
}
