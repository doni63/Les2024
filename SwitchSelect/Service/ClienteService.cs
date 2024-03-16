using SwitchSelect.Data;
using SwitchSelect.Models.ViewModels;
using SwitchSelect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace SwitchSelect.Service
{
    public class ClienteService
    {
        private readonly SwitchSelectContext _context;

        public ClienteService(SwitchSelectContext context)
        {
            _context = context;
        }

        public async Task CriarClienteAsync(ClienteViewModel model)
        {
            var cliente = new Cliente
            {
                Nome = model.Nome,
                Genero = model.Genero,
                Email = model.Email,
                Cpf = model.Cpf,
                RG = model.RG,


            };

            var telefone = new Telefone
            {
                TipoTelefone = model.TipoTelefone,
                DDD = model.DDD,
                NumeroTelefone = model.NumeroTelefone,
                Cliente = cliente
            };

            var cartao = new Cartao
            {
                NumeroCartao = model.NumeroCartao,
                TitularDoCartao = model.TitularDoCartao,
                CpfTitularCartao = model.CpfTitularCartao,
                DataValidade = model.DataValidade,
                CVV = model.CVV,
                TipoCartao = model.TipoCartao,
                Cliente = cliente
            };

            var estado = new Estado
            {
                Descricao = model.Estado
            };

            var cidade = new Cidade
            {
                Descricao = model.Cidade,
                Estado = estado
            };

            var bairro = new Bairro
            {
                Descricao = model.Bairro,
                Cidade = cidade
            };

            var endereco = new Endereco
            {
                TipoEndereco = model.TipoEndereco,
                TipoLogradouro = model.TipoLogradouro,
                Logradouro = model.Logradouro,
                Numero = model.Numero,
                CEP = model.CEP,
                TipoResidencia = model.TipoResidencia,
                Complemento = model.Complemento,
                Cliente = cliente,
                Bairro = bairro
            };

            cliente.Enderecos.Add(endereco);
            cliente.Telefones.Add(telefone);
            cliente.cartaos.Add(cartao);
            _context.Add(cliente);
            await _context.SaveChangesAsync();
        }

       

        public List<Cliente> ListarClientes()
        {
            return _context.Clientes.ToList();
        }

       
    }
}
