using GEA.AvaliacaoTecnica.Domain.Interfaces;
using GEA.AvaliacaoTecnica.Domain.Interfaces.Services;
using GEA.AvaliacaoTecnica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA.AvaliacaoTecnica.Domain.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRespository;
        public EmpresaService(IEmpresaRepository empresaRespository)
        {
            _empresaRespository = empresaRespository;
        }
        public Empresa Adicionar(Empresa empresa)
        {
            empresa.RazaoSocial = empresa.RazaoSocial.ToUpper().Trim();
            empresa.Email = empresa.Email.ToUpper().Trim();
            return _empresaRespository.Adicionar(empresa);
        }
        public Empresa Atualizar(Empresa empresa)
        {
            return _empresaRespository.Atualizar(empresa);
        }
        public IEnumerable<Empresa> ObterPorRazaoSocial(string razaoSocial)
        {
            razaoSocial = razaoSocial.Trim();
            return _empresaRespository.Buscar(e => e.RazaoSocial == razaoSocial);
        }
        public void Remover(Guid id)
        {
            _empresaRespository.Remover(id);
        }
        public void Dispose()
        {
            _empresaRespository.Dispose();
        }


    }
}
