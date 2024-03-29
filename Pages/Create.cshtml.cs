﻿//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CodeBehind.PostGreSQL.Models;
using Microsoft.Extensions.Logging;
using CodeBehind.PostGreSQL.Repository;

namespace CodeBehind.PostGreSQL.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;

        [BindProperty]
        public Pessoa cliente { get; set; }

        private readonly IPessoaRepository _rep;

        public string Mensagem { get; set; }

        public CreateModel(ILogger<CreateModel> logger, IPessoaRepository rep)
        {
            _logger = logger;
            _rep = rep;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
      
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                cliente.Id = Guid.NewGuid();
                _rep.Persistir(cliente);

                Mensagem = "Sucesso";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Create");
                Mensagem = ex.Message;
            }
            return Page();
        }
    }
}
