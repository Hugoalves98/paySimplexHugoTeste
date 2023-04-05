using System.ComponentModel.DataAnnotations;

namespace Infra.DTOs
{
    public class UsuarioDTO
    {
		[Required]
		public string? Nome { get; set; }

		[Required]
        public string? Email { get; set;}
    }
}
