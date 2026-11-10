using ProjetoFinal;
using ProjetoFinal.Data;
using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinal.Presenters
{
    public class ContatoPresenter
    {
        public List<Contato> ObterContatosDoUsuarioAtual()
        {
            if (Session.UsuarioAtual == null)
                throw new Exception("Nenhum usuário autenticado na sessão.");

            using var db = new Contexto();
            return db.Contatos
                     .Include(c => c.UsuarioContato)
                     .Where(c => c.UsuarioId == Session.UsuarioAtual.Id)
                     .ToList();
        }

        public void AdicionarContato(string codigoContato, string apelido)
        {
            if (Session.UsuarioAtual == null)
                throw new Exception("Sessão expirada. Faça login novamente.");

            if (string.IsNullOrWhiteSpace(codigoContato))
                throw new Exception("Informe o código do contato.");

            using var db = new Contexto();

         
            var usuarioAlvo = db.Usuarios.FirstOrDefault(u => u.Codigo == codigoContato);
            if (usuarioAlvo == null)
                throw new Exception("Usuário com esse código não foi encontrado.");

            if (usuarioAlvo.Id == Session.UsuarioAtual.Id)
                throw new Exception("Você não pode adicionar seu próprio código como contato.");

            bool jaExiste = db.Contatos.Any(c => c.UsuarioId == Session.UsuarioAtual.Id &&
                                                c.ContatoId == usuarioAlvo.Id);
            if (jaExiste)
                throw new Exception("Este usuário já está na sua lista de contatos.");

            var novoContato = new Contato
            {
                UsuarioId = Session.UsuarioAtual.Id,
                ContatoId = usuarioAlvo.Id,
                Nome = string.IsNullOrWhiteSpace(apelido) ? usuarioAlvo.Codigo : apelido
            };

            db.Contatos.Add(novoContato);
            db.SaveChanges();
        }

        public void EditarContato(int contatoId, string novoApelido)
        {
            if (string.IsNullOrWhiteSpace(novoApelido))
                throw new Exception("O apelido não pode ser vazio.");

            using var db = new Contexto();
            var contato = db.Contatos.FirstOrDefault(c => c.Id == contatoId && c.UsuarioId == Session.UsuarioAtual!.Id);

            if (contato == null)
                throw new Exception("Contato não encontrado.");

            contato.Nome = novoApelido;
            db.SaveChanges();
        }

        // Remover :-:
        public void ExcluirContato(int contatoId)
        {
            using var db = new Contexto();
            var contato = db.Contatos.FirstOrDefault(c => c.Id == contatoId && c.UsuarioId == Session.UsuarioAtual!.Id);

            if (contato != null)
            {
                db.Contatos.Remove(contato);
                db.SaveChanges();
            }
        }
    }
}
