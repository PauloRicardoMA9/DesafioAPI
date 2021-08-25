using AutoMapper;
using ma9.Business.Interfaces;
using ma9.Business.Models;
using ma9.Business.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ma9.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class ContatoController : MainController
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IContatoService _contatoService;
        private readonly IMapper _mapper;

        public ContatoController(IContatoRepository contatoRepository,
                                 IMapper mapper,
                                 IContatoService contatoService,
                                 INotificador notificador) : base(notificador)
        {
            _contatoRepository = contatoRepository;
            _mapper = mapper;
            _contatoService = contatoService;
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar(ContatoViewModel contatoViewModel)
        {
            var contato = _mapper.Map<Contato>(contatoViewModel);
            var Adicionado = await _contatoService.Adicionar(contato);

            if (Adicionado) return CreatedAtAction("Adicionar", null);
            return ReturnBadRequest();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Atualizar(Guid id, ContatoViewModel contatoAtualizadoViewModel)
        {
            var contatoAtualizado = _mapper.Map<Contato>(contatoAtualizadoViewModel);
            var Atualizado = await _contatoService.Atualizar(id, contatoAtualizado);

            if (Atualizado) return NoContent();
            return ReturnBadRequest();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Remover(Guid id)
        {
            var removido = await _contatoService.RemoverPorId(id);

            if (removido) return NoContent();
            return ReturnNotFound();
        }

        [HttpGet]
        public async Task<IEnumerable<ContatoViewModel>> ObterTodosOsContatos()
        {
            var contatos = await _contatoRepository.ObterTodos();
            var contatosViewModel = _mapper.Map<IEnumerable<ContatoViewModel>>(contatos);

            return contatosViewModel;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ContatoViewModel>> ObterContato(Guid id)
        {
            var contato = await _contatoRepository.ObterPorId(id);
            var contatoViewModel = _mapper.Map<ContatoViewModel>(contato);

            if(contatoViewModel == null) return ReturnNotFound();
            return contatoViewModel;
        }

    }
}
