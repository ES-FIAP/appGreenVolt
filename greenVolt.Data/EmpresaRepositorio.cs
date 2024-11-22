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

        public async Task<IEnumerable<Empresa>> Filtrar(string filtro, string valor)
        {
            if (string.IsNullOrWhiteSpace(filtro) || string.IsNullOrWhiteSpace(valor)) return await _context.Empresas.ToListAsync();
            
            // Exemplo básico de filtro por nome ou origem_energia.
            return filtro.ToLower() switch
            {
                //"nome" => _context.Empresas.Where(e => e.Nome.Contains(valor)).ToList(),
                "tipo_origem_energia" => await _context.Empresas.Where(e => e.tipo_origem_energia.Contains(valor)).ToListAsync(),
                _ => await _context.Empresas.ToListAsync()

            };
        }

        public async Task Adicionar(Empresa empresa)
        {
            if (empresa == null)
                throw new ArgumentNullException(nameof(empresa));

            await _context.Empresas.AddAsync(empresa);
            await _context.SaveChangesAsync();
        }

        public async Task<Empresa> ObterPorId(int id_empresa)
        {
            return await _context.Empresas.FirstOrDefaultAsync(e => e.id_empresa == id_empresa);
        }

    }
}

