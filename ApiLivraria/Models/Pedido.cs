using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiLivraria.Models
{
    public class Pedido
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public IList<Livro> Livros { get; set; }

        [Required]
        public DateTime DataRetirada { get; set; }
        [Required]
        public String Status { get; set; }
    }
}
