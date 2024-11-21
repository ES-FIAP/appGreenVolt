using greenVolt.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static greenVolt.Dominio.Favoritos;

namespace greenVolt.Data
{
    public class FavoritoRepositorio : IFavoritoRepositorio
    {
        private readonly Connection _context;

        public FavoritoRepositorio(Connection context)
        {
            _context = context;
        }

        public void Adicionar(Favorito favorito)
        {
            _context.Favoritos.Add(favorito);
            _context.SaveChanges();
        }

        public void Remover(Favorito favorito)
        {
            _context.Favoritos.Remove(favorito);
            _context.SaveChanges();
        }

        public IEnumerable<Favorito> ObterPorUsuario(int idUsuario)
        {
            return _context.Favoritos.Where(f => f.IdUsuario == idUsuario).ToList();
        }

        // Implementação do método faltante
        public Favorito ObterPorUsuarioEEmpresa(int idUsuario, int idEmpresa)
        {
            return _context.Favoritos.FirstOrDefault(f => f.IdUsuario == idUsuario && f.IdEmpresa == idEmpresa);
        }
    }
}
