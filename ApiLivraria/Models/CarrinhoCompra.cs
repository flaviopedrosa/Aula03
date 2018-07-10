using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiLivraria.Models
{
    public class CarrinhoCompra
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public IList<Livro> Livros { get; set; }
    }
}