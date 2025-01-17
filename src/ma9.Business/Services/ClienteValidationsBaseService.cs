﻿using ma9.Business.Interfaces;
using ma9.Business.Models;
using System;
using System.Linq;

namespace ma9.Business.Services
{
    public abstract class ClienteValidationsBaseService : BaseService
    {
        private readonly IClienteRepository _clienteRepository;

        protected ClienteValidationsBaseService(IClienteRepository clienteRepository, INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
        }

        protected bool ProntoParaAdicionar(Cliente cliente)
        {
            if (NaoValidar(cliente))
                return false;

            if (CpfJaCadastrado(cliente))
                return false;

            return true;
        }

        protected bool ProntoParaAtualizar(Guid id, Cliente cliente)
        {
            if (!IdsIguais(id, cliente))
                return false;

            if (!ProntoParaAdicionar(cliente))
                return false;

            bool cadastrado = ClienteCadastrado(id);
            if (!cadastrado)
                return false;

            return true;
        }

        protected bool NaoValidar(Cliente cliente)
        {
            return !ExecutarValidacao(new ClienteValidation(), cliente);
        }

        protected bool CpfJaCadastrado(Cliente cliente)
        {
            var cadastrado = _clienteRepository.Buscar(clienteBanco => clienteBanco.Cpf == cliente.Cpf && clienteBanco.Id != cliente.Id).Result.Any();
            if (cadastrado)
            {
                Notificar("Já existe um cliente cadastrado com o cpf informado.");
            }
            return cadastrado;
        }

        protected bool IdsIguais(Guid id, Cliente cliente)
        {
            var iguais = (id == cliente.Id);
            if (!iguais)
            {
                Notificar("O id informado não é o mesmo que foi passado na query.");
            }
            return iguais;
        }

        protected bool ClienteCadastrado(Guid id)
        {
            var cadastrado = _clienteRepository.Buscar(cliente => cliente.Id == id).Result.Any();
            if (!cadastrado)
            {
                Notificar("Não existe um cliente cadastrado com o id informado.");
            }
            return cadastrado;
        }
    }
}
