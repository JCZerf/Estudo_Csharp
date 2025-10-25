using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estudo_C_.Models
{
    [Table("Usuarios")]
    public class Usuarios

    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Campo Obrigatório")]
        public String Nome { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Password)]
        public String Senha { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public Perfil Perfil { get; set; }
    }

    public enum Perfil
    {
        Admin,
        User
    }
}
