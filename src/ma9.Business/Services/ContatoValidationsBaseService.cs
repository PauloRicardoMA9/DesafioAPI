using ma9.Business.Interfaces;
using ma9.Business.Models;
using System;
using System.Linq;

namespace ma9.Business.Services
{
    public abstract class ContatoValidationsBaseService : BaseService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IContatoRepository _contatoRepository;

        protected ContatoValidationsBaseService(IContatoRepository contatoRepository,
                                                INotificador notificador,
                                                IClienteRepository clienteRepository) : base(notificador)
        {
            _contatoRepository = contatoRepository;
            _clienteRepository = clienteRepository;
        }

        protected bool ProntoParaAdicionar(Contato contato)
        {
            if (!ClienteCadastrado(contato.ClienteId))
                return false;

            if (ClientePossuiContato(contato.ClienteId))
                return false;

            if (NaoValidar(contato))
                return false;

            return true;
        }

        protected bool ProntoParaAtualizar(Guid id, Contato contato)
        {
            if (!IdsIguais(id, contato))
                return false;

            if (NaoValidar(contato))
                return false;

            bool cadastrado = ContatoCadastrado(id);
            if (!cadastrado)
                return false;

            return true;
        }

        protected bool NaoValidar(Contato contato)
        {
            return !ExecutarValidacao(new ContatoValidation(), contato);
        }

        protected bool IdsIguais(Guid id, Contato contato)
        {
            var iguais = (id == contato.Id);
            if (!iguais)
            {
                Notificar("O id informado não é o mesmo que foi passado na query.");
            }
            return iguais;
        }

        protected bool ClienteCadastrado(Guid clienteId)
        {
            var cadastrado = _clienteRepository.Buscar(cliente => cliente.Id == clienteId).Result.Any();
            if (!cadastrado)
            {
                Notificar("Não existe um cliente cadastrado com o id informado.");
            }
            return cadastrado;
        }

        protected bool ContatoCadastrado(Guid id)
        {
            var cadastrado = _contatoRepository.Buscar(contato => contato.Id == id).Result.Any();
            if (!cadastrado)
            {
                Notificar("Não existe um contato cadastrado com o id informado.");
            }
            return cadastrado;
        }

        protected bool ClientePossuiContato(Guid clienteId)
        {
            var contatoCadastrado = _contatoRepository.Buscar(contato => contato.ClienteId == clienteId).Result.Any();
            if (contatoCadastrado)
            {
                Notificar("O cliente informado já possui um contato cadastrado.");
            }
            return contatoCadastrado;
        }
    }
}
