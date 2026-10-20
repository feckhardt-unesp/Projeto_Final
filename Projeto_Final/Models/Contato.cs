using ProjetoFinal.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal.Models
{
    [Table("contatos", Schema = "public")]
    public class Contato
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("contato_id")]
        public int ContatoId { get; set; }

        [Column("nome")]
        public string Nome { get; set; } = string.Empty;

        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario? Usuario { get; set; }

        [ForeignKey("ContatoId")]
        public virtual Usuario? UsuarioContato { get; set; }
    }
}