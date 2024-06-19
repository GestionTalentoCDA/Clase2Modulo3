using System.ComponentModel.DataAnnotations;

namespace Clase02Modulo03.Domain.DTOs
{
    public class ActorDTO //Request-Response
    {
        [Required]
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreArtistico { get; set; }
        public int Edad { get; set; }
        public string Nacionalidad { get; set; }
        [MaxLength( 1, ErrorMessage = "El largo máximo debe ser de 1 caracter" )]
        public string Genero { get; set; }
    }
}
