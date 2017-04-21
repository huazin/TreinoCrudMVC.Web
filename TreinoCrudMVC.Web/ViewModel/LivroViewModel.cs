using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TreinoCrudMVC.Domain;

namespace TreinoCrudMVC.Web.ViewModel
{
    public class LivroViewModel
    {
        [Key]
        public int LivroId { get; set; }

        [Required(ErrorMessage = "Titulo é obrigatorio")]
        [MaxLength(150, ErrorMessage ="Tamanho maximo 150 caracteres")]
        public string Titulo { get; set; }

        [DisplayName("Editora")]
        public int EditoraId { get; set; }

        [DisplayName("Genero")]
        public int GeneroId { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataDeCadastro { get; set; }

        public virtual Editora Editora { get; set; }

        public virtual Genero Genero { get; set; }

    }
}