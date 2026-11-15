using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Models;

namespace ProjetoFinal.Presenters
{
    public class ConversaPresenter
    {
        public List<UsuarioConversa> ObterConversasDoUsuarioAtual()
        {
            if (Session.UsuarioAtual == null)
                throw new Exception("Nenhum usuário autenticado.");

            using var db = new Contexto();
            return db.UsuarioConversas
                     .Include(uc => uc.Conversa)
                     .Where(uc => uc.UsuarioId == Session.UsuarioAtual.Id && uc.SaiuEm == null)
                     .OrderByDescending(uc => uc.Conversa!.CriadoEm)
                     .ToList();
        }

        public void CriarConversa(string titulo, List<int> contatosIds)
        {
            if (Session.UsuarioAtual == null)
                throw new Exception("Sessão expirada.");

            if (string.IsNullOrWhiteSpace(titulo))
                throw new Exception("Informe um título para a conversa.");

            if (contatosIds == null || contatosIds.Count == 0)
                throw new Exception("Adicione pelo menos um contato à conversa.");

            using var db = new Contexto();

            var novaConversa = new Conversa
            {
                Titulo = titulo.Trim(),
                CriadoPor = Session.UsuarioAtual.Id,
                CriadoEm = DateTime.UtcNow
            };

            db.Conversas.Add(novaConversa);
            db.SaveChanges();

            db.UsuarioConversas.Add(new UsuarioConversa
            {
                UsuarioId = Session.UsuarioAtual.Id,
                ConversaId = novaConversa.Id
            });

 
            var usuariosConvidadosIds = db.Contatos
                .Where(c => contatosIds.Contains(c.Id))
                .Select(c => c.ContatoId)
                .Distinct()
                .ToList();

            foreach (var usuId in usuariosConvidadosIds)
            {
                if (usuId != Session.UsuarioAtual.Id)
                {
                    db.UsuarioConversas.Add(new UsuarioConversa
                    {
                        UsuarioId = usuId,
                        ConversaId = novaConversa.Id
                    });
                }
            }

            db.SaveChanges();
        }

        public List<Mensagem> ObterMensagens(int conversaId)
        {
            using var db = new Contexto();
            return db.Mensagens
                     .Include(m => m.UsuarioConversa)
                        .ThenInclude(uc => uc!.Usuario)
                     .Where(m => m.UsuarioConversa!.ConversaId == conversaId)
                     .OrderBy(m => m.DataHora)
                     .ToList();
        }

        public void EnviarMensagem(int usuarioConversaId, string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return;

            using var db = new Contexto();
            var uc = db.UsuarioConversas.FirstOrDefault(x => x.Id == usuarioConversaId);
            if (uc == null || uc.SaiuEm != null)
                throw new Exception("Você não participa mais desta conversa.");

            var msg = new Mensagem
            {
                UsuConvId = usuarioConversaId,
                Texto = texto.Trim(),
                DataHora = DateTime.UtcNow
            };

            db.Mensagens.Add(msg);
            db.SaveChanges();
        }

        public void SairDaConversa(int usuarioConversaId)
        {
            using var db = new Contexto();
            var uc = db.UsuarioConversas.FirstOrDefault(x => x.Id == usuarioConversaId);
            if (uc != null && uc.SaiuEm == null)
            {
                uc.SaiuEm = DateTime.UtcNow;
                db.SaveChanges();
            }
        }
    }
}