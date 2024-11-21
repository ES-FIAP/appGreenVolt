using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using greenVolt.Dominio;
using System.Collections.Generic;
using greenVolt.Data.Interfaces;

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
        public IEnumerable<Empresa> FiltrarEmpresas(string filtro, string valor)
        {
            return _empresaRepositorio.Filtrar(filtro, valor);
        }

        public void InserirEmpresa(string nome, string cnpj, string contato, string descricao, string categoria, string localizacao, string origem_energia, double valor)
        {
            var empresa = Empresa.Criar_Empresa(nome, cnpj, contato, descricao, categoria, origem_energia,valor);
            _empresaRepositorio.Adicionar(empresa);
        }
    }
}

