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

        public int CurrentPageClients { get; set; }
        public int TotalPagesClients { get; set; }
        public int TotalClients { get; set; }
        public int PageSizeClients = 10;
        public int PageSizeLogs = 5;

        public IndexModel(IClientRepository repository, LogService logService)
        {
            _repository = repository;
            _logService = logService;
        }

        public IEnumerable<Cliente> Clientes { get; set; }
        public IEnumerable<string> Logs { get; private set; }

        [BindProperty]
        public Cliente Input { get; set; }

        public async Task OnGetAsync(int? pageClient)
        {
            CurrentPageClients = pageClient ?? 1;
            if (CurrentPageClients < 1) CurrentPageClients = 1;
            TotalClients = await _repository.GetTotalClientCountAsync();
            TotalPagesClients = (int)Math.Ceiling(TotalClients / (double)PageSizeClients);
            Clientes = await _repository.GetAllClientsAsync(CurrentPageClients, PageSizeClients);
            Logs = await _logService.GetMessagesAsync(1, PageSizeLogs);
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