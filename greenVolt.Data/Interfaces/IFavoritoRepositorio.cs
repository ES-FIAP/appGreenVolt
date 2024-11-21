using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static greenVolt.Dominio.Favoritos;

namespace greenVolt.Data.Interfaces
{
    public interface IFavoritoRepositorio
    {
        void Adicionar(Favorito favorito);
        void Remover(Favorito favorito);
        Favorito ObterPorUsuarioEEmpresa(int idUsuario, int idEmpresa);
        IEnumerable<Favorito> ObterPorUsuario(int idUsuario);


    }
}
