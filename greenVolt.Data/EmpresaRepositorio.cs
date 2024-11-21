using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using greenVolt.Dominio;
using System.Threading.Tasks;
using greenVolt.Data.Interfaces;

namespace greenVolt.Data
{
    internal class EmpresaRepositorio : IEmpresaRepositorio
    {
        private readonly GreenVoltDbContext _context;

        public EmpresaRepositorio(GreenVoltDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Empresa> ObterTodas()
        {
            return _context.Empresas.ToList();
        }

        public IEnumerable<Empresa> Filtrar(string filtro, string valor)
        {
            // Exemplo básico de filtro por nome ou origem_energia.
            return filtro.ToLower() switch
            {
                //"nome" => _context.Empresas.Where(e => e.Nome.Contains(valor)).ToList(),
                "origem_energia" => _context.Empresas.Where(e => e.Origem_Energia.Contains(valor)).ToList(),
                _ => _context.Empresas.ToList()

            };
        }

        public void Adicionar(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            _context.SaveChanges();
        }

        public Empresa ObterPorId(int id_empresa)
        {
            return _context.Empresa.Find(id_empresa);
        }


    }
}

