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
        Task<IEnumerable<Empresa>> Filtrar(string filtro, string valor);
        Task Adicionar(Empresa empresa);

        Task<Empresa> ObterPorId(int id_empresa); // Buscar empresa por ID

    }
}

