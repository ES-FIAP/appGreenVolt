using greenVolt.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static greenVolt.Dominio.Favoritos;

namespace greenVolt.Aplicacao
{
    public class FavoritoService
    {
        private readonly IFavoritoRepositorio _favoritoRepositorio;
        private readonly IEmpresaRepositorio _empresaRepositorio;
        // private readonly IUsuarioRepositorio _usuarioRepositorio;


        public FavoritoService(IFavoritoRepositorio favoritoRepositorio, IEmpresaRepositorio empresaRepositorio)
        {
            _favoritoRepositorio = favoritoRepositorio;
            _empresaRepositorio = empresaRepositorio;
        }

        public bool ToggleFavorito(int idUsuario, int idEmpresa)
        {
            // Verificar se a empresa existe
            var empresa = _empresaRepositorio.ObterPorId(idEmpresa);
            if (empresa == null)
            {
                throw new ArgumentException("Empresa não encontrada.");
            }

            // Verificar se o favorito já existe
            var favorito = _favoritoRepositorio.ObterPorUsuarioEEmpresa(idUsuario, idEmpresa);
            if (favorito != null)
            {
                _favoritoRepositorio.Remover(favorito);
                return false; // Foi removido
            }

            // Caso contrário, adiciona o favorito
            favorito = Favorito.Criar(idUsuario, idEmpresa);
            _favoritoRepositorio.Adicionar(favorito);
            return true; // Foi adicionado
        }

        //public void RemoverFavorito(int idUsuario, int idEmpresa)
        //{
        //    var favorito = _favoritoRepositorio.ObterPorUsuarioEEmpresa(idUsuario, idEmpresa);
        //    if (favorito == null)
        //        throw new InvalidOperationException("Favorito não encontrado.");

        //    _favoritoRepositorio.Remover(favorito);
        //}
    }
}
    