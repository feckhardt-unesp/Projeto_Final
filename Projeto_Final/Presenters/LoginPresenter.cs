using BCrypt.Net;
using ProjetoFinal;         
using ProjetoFinal.Data;    
using ProjetoFinal.Models;  
using System;
using System.Linq;

namespace ProjetoFinal.Presenters
{
    public class LoginPresenter
    {
        public bool AuthenticateOrRegister(string codigo, string pin, Func<bool> confirmCreateUser)
        {
            if (string.IsNullOrWhiteSpace(codigo) || string.IsNullOrWhiteSpace(pin))
            {
                throw new Exception("Por favor, preencha o Código e o PIN.");
            }

            if (pin.Length != 4)
            {
                throw new Exception("O PIN deve conter exatamente 4 caracteres.");
            }

            using var db = new Contexto();
            var usuario = db.Usuarios.FirstOrDefault(u => u.Codigo == codigo);

            if (usuario == null)
            {
                if (confirmCreateUser())
                {
                    string pinHash = BCrypt.Net.BCrypt.HashPassword(pin);

                    var novoUsuario = new Usuario
                    {
                        Codigo = codigo,
                        Pin = pinHash
                    };

                    db.Usuarios.Add(novoUsuario);
                    db.SaveChanges();

                    Session.UsuarioAtual = novoUsuario;
                    return true;
                }

                return false;
            }

            bool pinValido = BCrypt.Net.BCrypt.Verify(pin, usuario.Pin);
            if (!pinValido)
            {
                throw new Exception("PIN incorreto! Acesso negado.");
            }

            Session.UsuarioAtual = usuario;
            return true;
        }
    }
}