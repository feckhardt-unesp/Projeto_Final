using ProjetoFinal.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal.Models
{
    [Table("mensagens", Schema = "public")]
    public class Mensagem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("usu_conv_id")]
        public int UsuConvId { get; set; }

        [Column("texto")]
        public string Texto { get; set; } = string.Empty;

        [Column("data_hora")]
        public DateTime DataHora { get; set; } = DateTime.Now;

        [ForeignKey("UsuConvId")]
        public virtual UsuarioConversa? UsuarioConversa { get; set; }
    }
}