using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeBehind.PostGreSQL.Models;
using CodeBehind.PostGreSQL.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CodeBehind.PostGreSQL.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IEnumerable<Pessoa> Clientes { get; set; }
        private readonly IPessoaRepository _rep;


        public IndexModel(ILogger<IndexModel> logger, IPessoaRepository rep)
        {
            _logger = logger;
            _rep = rep;
        }

        public IActionResult OnGet()
        {
            _logger.LogInformation("Buscando dados");
            Clientes = _rep.Listar();

            return Page();
        }

    }
}
