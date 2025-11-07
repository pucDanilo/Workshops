using PocketApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocketApp.Application.Services
{
     

    public interface ITagAppService : IDisposable
    {
        Task<IEnumerable<TagViewModel>> ObterTodos();

        Task AdicionarTag(TagViewModel viewModel);

        Task AtualizarTag(TagViewModel viewModel);
    }
}