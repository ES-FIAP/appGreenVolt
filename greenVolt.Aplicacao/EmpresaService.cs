using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using greenVolt.Dominio;
using System.Collections.Generic;
using greenVolt.Data.Interfaces;
using greenVolt.Data;

namespace greenVolt.Aplicacao
{
    public class EmpresaService
    {
        private readonly IEmpresaRepositorio _empresaRepositorio;

        public EmpresaService(IEmpresaRepositorio empresaRepositorio)
        {
            _empresaRepositorio = empresaRepositorio;
        }

        public async Task<IEnumerable<Empresa>> ObterTodas()
        {
            return await _empresaRepositorio.ObterTodas();
        }

        public async Task<Empresa> ObterPorId(int id)
        {
            return await _empresaRepositorio.ObterPorId(id);
        }
        public async Task<IEnumerable<Empresa>> FiltrarEmpresas(string filtro, string valor)
        {
            return await _empresaRepositorio.Filtrar(filtro, valor);
        }

        public async Task<Empresa> Adicionar(Empresa novaEmpresa)
        {
            if (novaEmpresa == null)
                throw new ArgumentNullException(nameof(novaEmpresa), "A empresa não pode ser nula.");

            if (string.IsNullOrWhiteSpace(novaEmpresa.nome_empresa))
                throw new ArgumentException("O nome da empresa é obrigatório.", nameof(novaEmpresa.nome_empresa));

            if (string.IsNullOrWhiteSpace(novaEmpresa.cnpj))
                throw new ArgumentException("O CNPJ da empresa é obrigatório.", nameof(novaEmpresa.cnpj));

            //var empresasExistentes = await _empresaRepositorio.Filtrar("cnpj", novaEmpresa.cnpj);
            //if (empresasExistentes.Any())
            //    throw new InvalidOperationException("Já existe uma empresa cadastrada com este CNPJ.");

            await _empresaRepositorio.Adicionar(novaEmpresa);

            return novaEmpresa; 
        }
    }
}

