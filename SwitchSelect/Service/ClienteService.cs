﻿using SwitchSelect.Data;
using SwitchSelect.Models.Endereco;
using SwitchSelect.Models.ViewModels;
using SwitchSelect.Models;

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

            var cidade = new Cidade
            {
                Descricao = model.Cidade
            };

            var bairro = new Bairro
            {
                Descricao = model.Bairro,
                Cidade = cidade
            };

            var endereco = new Endereco
            {
                Logradouro = model.Logradouro,
                Numero = model.Numero,
                CEP = model.CEP,
                Complemento = model.Complemento,
                Cliente = cliente,
                Bairro = bairro
            };

            cliente.Enderecos.Add(endereco);

            _context.Add(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
