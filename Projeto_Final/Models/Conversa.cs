using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal.Models
{
    [Table("conversas", Schema = "public")]
    public class Conversa
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("titulo")]
        public string Titulo { get; set; } = string.Empty;

        [Column("criado_por")]
        public int CriadoPor { get; set; }

        [Column("criado_em")]
        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}