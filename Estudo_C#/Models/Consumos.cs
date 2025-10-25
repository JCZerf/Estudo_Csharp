using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estudo_C_.Models
{
    [Table("Consumos")]
    public class Consumos
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Obrigatório informar a descrição")]
        public String Descricao { get; set; }
        [Required(ErrorMessage = "Obrigatório informar a Data")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o valor")]
        public Decimal Valor { get; set; }
        [Required(ErrorMessage = "Obrigatório informar a quilometragem")]
        public int Km { get; set; }
        [Display(Name = "Tipo de combustível")]
        public TipoCombustivel Tipo { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o veículo")]
        [Display(Name = "Veículo")]
        public int VeiculoId { get; set; }
        [ForeignKey("VeiculoId")]
        public Veiculo Veiculo { get; set; }
    }
    public enum TipoCombustivel
    {
        Gasolina,
        Etanol,
        Diesel
    }
}
