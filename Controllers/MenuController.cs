using Microsoft.AspNetCore.Mvc;
using MVC_Pizzeria.Datos;
using MVC_Pizzeria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Pizzeria.Controllers
{
    public class MenuController : Controller
    {
        PizzaDatos pizzaDatos = new PizzaDatos();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listar()
        {
            var lista = pizzaDatos.ListarPizzas();
            return View(lista);
        }
    }
}
