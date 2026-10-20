using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal.Models
{
    [Table("usuario_conversas", Schema = "public")]
    public class UsuarioConversa
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        [Column("conversa_id")]
        public int ConversaId { get; set; }

        [Column("saiu_em")]
        public DateTime? SaiuEm { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario? Usuario { get; set; }

        [ForeignKey("ConversaId")]
        public virtual Conversa? Conversa { get; set; }
    }
}