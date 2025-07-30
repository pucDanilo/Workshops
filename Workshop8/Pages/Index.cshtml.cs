using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Workshop8.Data;
using Workshop8.Infrastructure;
using Workshop8.Models;

namespace Workshop8.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IClientRepository _repository;
        private readonly LogService _logService;

        public IndexModel(IClientRepository repository, LogService logService)
        {
            _repository = repository;
            _logService = logService;
        }

        public IEnumerable<Cliente> Clientes { get; set; }

        [BindProperty]
        public Cliente Input { get; set; }

        public async Task OnGetAsync()
        {
            Clientes = await _repository.GetAllClientsAsync();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid) return Page();
            Input.CriadoEm = System.DateTime.Now;
            await _repository.AddClientAsync(Input);
            await _logService.WriteProviderLogAsync($"Cliente criado: {Input.Nome}");
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid) return Page();
            await _repository.UpdateClientAsync(Input);
            await _logService.WriteProviderLogAsync($"Cliente editado: {Input.Id}");
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _repository.DeleteClientAsync(id);
            await _logService.WriteProviderLogAsync($"Cliente excluído: {id}");
            return RedirectToPage();
        }
    }
}
