using System;
using System.ComponentModel.DataAnnotations;

namespace ApiLivraria.Models
{
    public class Comentario
    {
        public Comentario()
        {
            Id = new Guid();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public String Descricao { get; set; }
        [Required]
        public Livro  Livro { get; set; }
    }
}