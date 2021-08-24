using ma9.Business.Interfaces;
using ma9.Business.Models;
using System;
using System.Threading.Tasks;

namespace ma9.Business.Services
{
    public class ClienteService : ClienteValidationsBaseService , IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository, INotificador notificador) : base(clienteRepository, notificador)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Adicionar(Cliente cliente)
        {
            if (!ClienteProntoParaAdicionar(cliente))
            {
                return false;
            }
            await _clienteRepository.Adicionar(cliente);
            return true;
        }

        public async Task<bool> Atualizar(Guid id, Cliente clienteAtualizado)
        {
            bool clientePronto = await ClienteProntoParaAtualizar(id, clienteAtualizado);
            if (!clientePronto)
            {
                return false;
            }
            
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
            bool cadastrado = await ClienteCadastrado(id);
            if (!cadastrado)
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
