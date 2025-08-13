using System.ComponentModel.DataAnnotations;

namespace FormularioMVC.Models
{
    public class Usuario
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
    }
}
