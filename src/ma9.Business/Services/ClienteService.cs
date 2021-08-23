using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using ma9.Business.Interfaces;
using ma9.Business.Models;
using ma9.Business.Models.Validations;
using ma9.Business.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ma9.Business.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Adicionar(Cliente cliente)
        {
            //Validar Model

            await _clienteRepository.Adicionar(cliente);
            return true;
        }

        public async Task<bool> Atualizar(Guid id, Cliente clienteAtualizado)
        {
            //Validar Model
            var cliente = await _clienteRepository.ObterClienteComContato(id);

            cliente.Nome = clienteAtualizado.Nome;
            cliente.Sobrenome = clienteAtualizado.Sobrenome;
            cliente.Cpf = clienteAtualizado.Cpf;
            cliente.Sexo = clienteAtualizado.Sexo;
            cliente.Contato.DDD = clienteAtualizado.Contato.DDD;
            cliente.Contato.Telefone = clienteAtualizado.Contato.Telefone;
            cliente.Contato.Email = clienteAtualizado.Contato.Email;

            await _clienteRepository.Atualizar(cliente);
            return true;
        }

        public async Task<bool> RemoverPorId(Guid id)
        {
            var cliente = await _clienteRepository.ObterClienteComContato(id);
            if (cliente == null)
            {
                return false;
            }

            await _clienteRepository.RemoverPorId(id);
            return true;
        }

        public void Dispose()
        {
            _clienteRepository?.Dispose();
        }
    }
}
