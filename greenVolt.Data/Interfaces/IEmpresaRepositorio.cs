using greenVolt.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace greenVolt.Data.Interfaces
{
    public interface IEmpresaRepositorio
    {
        Task<IEnumerable<Empresa>> ObterTodas();
        IEnumerable<Empresa> Filtrar(string filtro, string valor);
        void Adicionar(Empresa empresa);

        Empresa ObterPorId(int id_empresa); // Buscar empresa por ID

    }
}
