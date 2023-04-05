using System.ComponentModel.DataAnnotations;

namespace Infra.Entities
{
    public class Usuario : BaseEntity
    {
		[Required]
		public string? Nome { get; set; }

		[Required]
        public string? Email { get; set;}
    }
}
