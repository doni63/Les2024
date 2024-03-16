﻿using SwitchSelect.Data;
using SwitchSelect.Models.ViewModels;
using SwitchSelect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;
using Microsoft.EntityFrameworkCore;

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
            cliente.Cartoes.Add(cartao);
            _context.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<ClienteViewModel> ObterClientePorIdAsync(int id)
        {
            var cliente = await _context.Clientes
                .Include(c => c.Telefones)
                .Include(c => c.Enderecos)
                     .ThenInclude(e => e.Bairro)
                     .ThenInclude(b => b.Cidade)
                     .ThenInclude(c => c.Estado)
                .Include(c => c.Cartoes)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
            {
                return null;
            }

            var clienteViewModel = new ClienteViewModel
            {
                //dados cliente
                Nome = cliente.Nome,
                Email = cliente.Email,
                Genero = cliente.Genero,
                Cpf = cliente.Cpf,
                RG = cliente.RG,
                NumeroTelefone = cliente.Telefones.FirstOrDefault()?.NumeroTelefone,
                TipoTelefone = (TipoTelefone)cliente.Telefones.FirstOrDefault()?.TipoTelefone,
                DDD = cliente.Telefones.FirstOrDefault()?.DDD,
                Estado = cliente.Enderecos.FirstOrDefault()?.Bairro.Cidade.Estado.Descricao,
                Cidade = cliente.Enderecos.FirstOrDefault()?.Bairro.Cidade.Descricao,
                Bairro = cliente.Enderecos.FirstOrDefault()?.Bairro.Descricao,
                Logradouro = cliente.Enderecos.FirstOrDefault()?.Logradouro,
                Numero = cliente.Enderecos.FirstOrDefault()?.Numero,
                CEP = cliente.Enderecos.FirstOrDefault()?.CEP,
                TipoEndereco = (TipoEndereco)cliente.Enderecos.FirstOrDefault()?.TipoEndereco,
                TipoLogradouro = (TipoLogradouro)cliente.Enderecos.FirstOrDefault()?.TipoLogradouro,
                TipoResidencia = (TipoResidencia)cliente.Enderecos.FirstOrDefault()?.TipoResidencia,
                Complemento = cliente.Enderecos.FirstOrDefault()?.Complemento,
                TipoCartao = (TipoCartao)cliente.Cartoes.FirstOrDefault()?.TipoCartao,
                NumeroCartao = cliente.Cartoes.FirstOrDefault()?.NumeroCartao,
                TitularDoCartao = cliente.Cartoes.FirstOrDefault()?.TitularDoCartao,
                CpfTitularCartao = cliente.Cartoes.FirstOrDefault()?.CpfTitularCartao,
                DataValidade = (DateTime)(cliente.Cartoes.FirstOrDefault()?.DataValidade),
                CVV = cliente.Cartoes.FirstOrDefault()?.CVV,



            };
            return clienteViewModel;
        }

        public async Task<bool> EditarClienteAsync(int id, ClienteViewModel model)
        {
            var cliente = await _context.Clientes
                .Include(c => c.Telefones)
                .Include(c => c.Cartoes)
                .Include(c => c.Enderecos)
                .ThenInclude(e => e.Bairro)
                .ThenInclude(b => b.Cidade)
                .ThenInclude(c => c.Estado)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null) return false;

            // Atualiza as propriedades do cliente
            cliente.Nome = model.Nome;
            cliente.Email = model.Email;
            cliente.Genero = model.Genero;
            cliente.Cpf = model.Cpf;
            cliente.RG = model.RG;

            //Telefones           
            var telefone = cliente.Telefones.FirstOrDefault();
            if (telefone != null)
            {
                telefone.NumeroTelefone = model.NumeroTelefone;
                telefone.TipoTelefone = model.TipoTelefone;
                telefone.DDD = model.DDD;
            }
            else
            {
                // Adiciona um novo telefone
                cliente.Telefones.Add(new Telefone
                {
                    NumeroTelefone = model.NumeroTelefone,
                    DDD = model.DDD,
                    TipoTelefone = model.TipoTelefone
                });
            }
            //Enderecos



            var endereco = cliente.Enderecos.FirstOrDefault();
            if (endereco != null)
            {
                endereco.TipoResidencia = model.TipoResidencia;
                endereco.TipoLogradouro = model.TipoLogradouro;
                endereco.Logradouro = model.Logradouro;
                endereco.Numero = model.Numero;
                endereco.CEP = model.CEP;
                endereco.Cliente = cliente;

                var bairro = endereco.Bairro;
                if (bairro != null)
                {
                    bairro.Descricao = model.Bairro;
                    endereco.Bairro = bairro;

                    var cidade = bairro.Cidade;
                    if (cidade != null)
                    {
                        cidade.Descricao = model.Cidade;
                        bairro.Cidade = cidade;

                        var estado = cidade.Estado;
                        if (estado != null)
                        {
                            estado.Descricao = model.Estado;
                        }
                    }
                }
            }
            

            try
            {
                _context.Update(cliente);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id)) return false;
                else throw;
            }
        }


        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }

        public List<Cliente> ListarClientes()
        {
            return _context.Clientes.ToList();
        }


    }
}
