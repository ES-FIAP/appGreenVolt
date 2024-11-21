using greenVolt.Data.Interfaces;
using greenVolt.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace greenVolt.Aplicacao
{
    public class UsuarioService
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioService(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        /* LOGIN */
        public Usuario Autenticar_User(string email, string senha)
        {
            var usuario = _usuarioRepositorio.ObterPorEmail(email);
            if (usuario == null)
                throw new UnauthorizedAccessException("Usuário não encontrado.");

            if (usuario.senha_hash != GerarHashSenha(senha))
                throw new UnauthorizedAccessException("Senha inválida.");

            return usuario;
        }

        //public Usuario AutenticarComGoogle(string googleId)
        //{
        //    var usuario = _usuarioRepositorio.ObterPorEmail(googleId);
        //    if (usuario == null)
        //        throw new UnauthorizedAccessException("Usuário não encontrado.");

        //    return usuario;
        //}

        /* CRIAR CONTA */
        public Usuario Registrar_User(string nome, string email, string senha)
        {
            if (_usuarioRepositorio.ExisteEmail(email))
                throw new InvalidOperationException("O email já está em uso.");

            var senhaHash = GerarHashSenha(senha);
            var usuario = Usuario.CriarUsuario(nome, email, senhaHash);

            _usuarioRepositorio.Adicionar(usuario);

            return usuario;
        }

        //public Usuario RegistrarComGoogle(string nome, string email, string googleId)
        //{
        //    if (_usuarioRepositorio.ExisteEmail(email))
        //        throw new InvalidOperationException("O email já está em uso.");

        //    var usuario = Usuario.CriarUsuario(nome, email, null, googleId);
        //    _usuarioRepositorio.Adicionar(usuario);

        //    return usuario;
        //}


        /* GERAR HASH SENHA*/
        private string GerarHashSenha(string senha)
        {
            // Usar biblioteca BCrypt para hashing de senhas 
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(senha));
        }

    }
}

    