using Contato.Business.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestePratico.Core;
using TestePratico.Models;

namespace TestePratico.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository contatoRepository;

        public ContatoController(IContatoRepository contatoRepository)
        {
            this.contatoRepository = contatoRepository;
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateContato([FromBody] ContatoRequest contato)
        {
            bool sucesso = false;
            if (contato.IsValido())
            {
                sucesso = contato.ID > 0 ? await contatoRepository.Update(contato) : await contatoRepository.Insert(contato);
                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", contato.Erros());

            return View();
        }


        [HttpPost]
        [Route("Contato/DeleteContato/{codigo}")]
        public async Task<IActionResult> DeleteContato(int codigo)
        {
            if (codigo > 0)
            {
                await contatoRepository.Delete(codigo);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = new List<ContatoModel>();

            foreach (var obj in await contatoRepository.ObterTodos())
            {
                list.Add(ContatoModel.ToModel(obj));
            }

            return View(list);
        }

    }
}
