using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLivraria.Models
{
    public class AutorLivro
    {
        public Guid AutorId { get; set; }
        public Autor Autor { get; set; }

        public Guid LivroId { get; set; }
        public Livro Livro { get; set; }
    }
}
