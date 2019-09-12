using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Treino.Models;
using Treino.Persistences;

namespace Treino.Controllers
{
    public class CondominioController : Controller
    {
        private BancoContext _context;

        public CondominioController(BancoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return View(_context.Condominios.ToList());
        }

        [HttpPost]
        public IActionResult Cadastrar(Condominio condominio)
        {
            _context.Condominios.Add(condominio);
            _context.SaveChanges();
            TempData["msg"] = "Cadastrado";
            return RedirectToAction("Listar");

        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var condominio = _context.Condominios.Find(id);
            return View(condominio);
        }

        [HttpPost]
        public IActionResult Editar(Condominio condominio)
        {
            _context.Attach(condominio).State = EntityState.Modified;
            _context.SaveChanges();
            TempData["msg"] = "Editado";
            return RedirectToAction("Listar");
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            var condominio = _context.Condominios.Find(id);
            _context.Remove(condominio);
            _context.SaveChanges();
            TempData["msg"] = "Removido";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public IActionResult Pesquisar(String termoPesquisa)
        {
            var lista = _context.Condominios.Where(c => c.Nome.Contains(termoPesquisa)).ToList();
            return View("Listar", lista);
        }
    }
}
