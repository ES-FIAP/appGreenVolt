using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using greenVolt.Dominio;
using System.Threading.Tasks;
using greenVolt.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace greenVolt.Data
{
    public class EmpresaRepositorio : IEmpresaRepositorio
    {
        private readonly Connection _context;

        public EmpresaRepositorio(Connection context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empresa>> ObterTodas()
        {
          return await _context.Empresas.ToListAsync();
        }

        public IEnumerable<Empresa> Filtrar(string filtro, string valor)
        {
            // Exemplo básico de filtro por nome ou origem_energia.
            return filtro.ToLower() switch
            {
                //"nome" => _context.Empresas.Where(e => e.Nome.Contains(valor)).ToList(),
                "origem_energia" => _context.Empresas.Where(e => e.origem_energia.Contains(valor)).ToList(),
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
            return _context.Empresas.Find(id_empresa);
        }

        public IEnumerable<Empresa> ObterTodasAsync()
        {
            throw new NotImplementedException();
        }
    }
}

