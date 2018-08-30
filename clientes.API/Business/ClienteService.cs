using System;
using System.Collections.Generic;
using System.Linq;
using clientes.API.Data;
using clientes.API.Models;

namespace clientes.API.Business
{
    public class ClienteService
    {
        private ApplicationDbContext _context;
        public ClienteService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Cliente> ListarTodos()
        {
            return _context.Clientes
                .OrderBy(c => c.Nome).ToList();
        }
        public Resultado Incluir(Cliente dadosCliente)
        {
            Resultado resultado = DadosValidos(dadosCliente);
            resultado.Acao = "Inclusão de Cliente";

            if (resultado.Inconsistencias.Count == 0 &&
                _context.Clientes.Where(
                p => p.Nome == dadosCliente.Nome).Count() > 0)
            {
                resultado.Inconsistencias.Add(
                    "Nome já cadastrado");
            }

            if (resultado.Inconsistencias.Count == 0)
            {
                _context.Clientes.Add(dadosCliente);
                _context.SaveChanges();
            }

            return resultado;
        }
        private Resultado DadosValidos(Cliente cliente)
        {
            var resultado = new Resultado();
            if (cliente == null)
            {
                resultado.Inconsistencias.Add(
                    "Preencha os Dados do Cliente");
            }
            else
            {
                if (String.IsNullOrWhiteSpace(cliente.Nome))
                {
                    resultado.Inconsistencias.Add(
                        "Preencha o nome do cliente");
                }
                if (String.IsNullOrWhiteSpace(cliente.DataNascimento.ToString()))
                {
                    resultado.Inconsistencias.Add(
                        "Preencha a data de nascimento do cliente");
                }
                if (cliente.Salario < 954)
                {
                    resultado.Inconsistencias.Add(
                        "O salário deve ser maior que 954 reais");
                }
            }

            return resultado;
        }
    }
}
