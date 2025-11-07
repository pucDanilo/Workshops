using AutoMapper;
using PocketApp.Application.ViewModels;
using PocketApp.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocketApp.Application.Services
{ /*
    public class TagAppService : ITagAppService
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        public TagAppService(ITagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task AdicionarTag(TagViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarTag(TagViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TagViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<TagViewModel>>(await _repository.ObterTodos());
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }
    }*/

    public class FluxoCaixaAppService : IFluxoCaixaAppService
    {
        private readonly IFluxoCaixaRepository _fluxoCaixaRepository;
        private readonly IMapper _mapper;

        public FluxoCaixaAppService(IFluxoCaixaRepository fluxoCaixaRepository, IMapper mapper)
        {
            _fluxoCaixaRepository = fluxoCaixaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FluxoCaixaViewModel>> ObterPorCategoria(TipoCategoria codigo)
        {
            return _mapper.Map<IEnumerable<FluxoCaixaViewModel>>(await _fluxoCaixaRepository.ObterPorCategoria(codigo));
        }

        public async Task<FluxoCaixaViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<FluxoCaixaViewModel>(await _fluxoCaixaRepository.ObterPorId(id));
        }

        public async Task<IEnumerable<FluxoCaixaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<FluxoCaixaViewModel>>(await _fluxoCaixaRepository.ObterTodos());
        }

        public async Task<IEnumerable<MovimentacaoViewModel>> ObterMovimentacoes(Guid id)
        {
            return _mapper.Map<IEnumerable<MovimentacaoViewModel>>(await _fluxoCaixaRepository.ObterMovimentacoes(id));
        }

        public async Task AdicionarFluxoCaixa(FluxoCaixaViewModel fluxoCaixaViewModel)
        {
            var fluxoCaixa = _mapper.Map<FluxoCaixa>(fluxoCaixaViewModel);
            _fluxoCaixaRepository.Adicionar(fluxoCaixa);

            await _fluxoCaixaRepository.UnitOfWork.Commit();
        }

        public async Task AtualizarFluxoCaixa(FluxoCaixaViewModel fluxoCaixaViewModel)
        {
            var fluxoCaixa = _mapper.Map<FluxoCaixa>(fluxoCaixaViewModel);
            _fluxoCaixaRepository.Atualizar(fluxoCaixa);

            await _fluxoCaixaRepository.UnitOfWork.Commit();
        }

        public Task<FluxoCaixaViewModel> IncluirMovimentacao(Guid id, MovimentacaoViewModel viewModel)
        {
            var movimentacao = _mapper.Map<Movimentacao>(viewModel);

            _fluxoCaixaRepository.AdicionarMovimentacao(id, movimentacao);

            return ObterPorId(id);
        }

        public void Dispose()
        {
            _fluxoCaixaRepository?.Dispose();
        }
         
    }
}