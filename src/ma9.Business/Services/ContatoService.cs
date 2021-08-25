using ma9.Business.Interfaces;
using ma9.Business.Models;
using System;
using System.Threading.Tasks;

namespace ma9.Business.Services
{
    public class ContatoService : ContatoValidationsBaseService, IContatoService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository,
                              INotificador notificador,
                              IClienteRepository clienteRepository) : base(contatoRepository, notificador, clienteRepository)
        {
            _contatoRepository = contatoRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Adicionar(Contato contato)
        {
            if (!ProntoParaAdicionar(contato))
            {
                return false;
            }
            await _contatoRepository.Adicionar(contato);
            return true;
        }

        public async Task<bool> Atualizar(Guid id, Contato contatoAtualizado)
        {
            bool contatoPronto = ProntoParaAtualizar(id, contatoAtualizado);
            if (!contatoPronto)
            {
                return false;
            }
            
            var contato = await _contatoRepository.ObterPorId(id);

            contato.DDD = contatoAtualizado.DDD;
            contato.Telefone = contatoAtualizado.Telefone;
            contato.Email = contatoAtualizado.Email;

            await _contatoRepository.Atualizar(contato);
            return true;
        }

        public async Task<bool> RemoverPorId(Guid id)
        {
            bool cadastrado = ContatoCadastrado(id);
            if (!cadastrado)
            {
                return false;
            }
            await _contatoRepository.RemoverPorId(id);
            return true;
        }

        public void Dispose()
        {
            _clienteRepository?.Dispose();
        }
    }
}
