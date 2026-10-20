using ProjetoFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoFinal.Data
{
    public class Contexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Host=projetoscti.com.br;" +
                                      "Port=54432;" +
                                      "Username=ra2557007;" +
                                      "Password=TRXHxbFzzRpRKUHs;" +
                                      "Database=cti_db");
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Conversa> Conversas { get; set; }
        public DbSet<UsuarioConversa> UsuarioConversas { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
    }
}