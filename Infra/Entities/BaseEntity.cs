using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Entities
{
    public class BaseEntity
    {
        [Key]
        public int? Id { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public DateTime? DataCriacao { get; set; }

        public bool Deletado { get; set; }
    }
}
