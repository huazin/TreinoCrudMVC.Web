using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TreinoCrudMVC.Domain
{
    public class Livro
    {
        public int LivroId { get; set; }
        public string Titulo { get; set; }
        public DateTime DataDeCadastro { get; set; }

        public int EditoraId { get; set; }

        [ForeignKey("EditoraId")]
        public virtual Editora Editora { get; set; }
        
        public int GeneroId { get; set; }

        [ForeignKey("GeneroId")]
        public virtual Genero Genero { get; set; }

    }
}
