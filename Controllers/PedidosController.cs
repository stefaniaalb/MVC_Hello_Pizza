using Microsoft.AspNetCore.Mvc;
using MVC_Pizzeria.Datos;
using MVC_Pizzeria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Pizzeria.Controllers
{
    public class PedidosController : Controller
    {
        PedidosDatos pedidos = new PedidosDatos();
        PizzaDatos pizza = new PizzaDatos();
        

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var lista = pedidos.ListarPedidos();
            return View(lista);
        }

        [HttpPost]
        public IActionResult EnviarPedido(PedidoCliente pedido)
        {
            var respuesta = pedidos.AgregarPedido(pedido);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        // Retorna solamente la vista con el formulario
        public IActionResult GuardarForm()
        {
            var listaPizzas = pizza.ListarPizzas();
            ViewBag.pizzas = listaPizzas;
            return View();
        }

        // Hace el post de guardar pedido
        [HttpPost]
        public IActionResult GuardarForm(PedidoCliente pedido)
        {

            if (!ModelState.IsValid)
            {
                return GuardarForm();
            }
            var respuesta = pedidos.AgregarPedido(pedido);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return GuardarForm();
            }
        }

        public IActionResult EditarPedido(int id)
        {
            var pedido = pedidos.obtenerPedido(id);
            var listaPizzas = pizza.ListarPizzas();
            ViewBag.pizzas = listaPizzas;
            return View(pedido);
        }

        [HttpPost]
        public IActionResult EditarPedido(PedidoCliente pedido)
        {
            if(!ModelState.IsValid)
            {
                return EditarPedido(pedido.Id);
            }
            var respuesta = pedidos.EditarPedido(pedido);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return EditarPedido(pedido.Id);
            }
            
        }

        public IActionResult EliminarPedido(int id)
        {
            var pedido = pedidos.obtenerPedido(id);
            return View(pedido);
        }

        [HttpPost]
        public IActionResult EliminarPedido(PedidoCliente pedido)
        {
            var respuesta = pedidos.EliminarPedido(pedido.Id);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        } 

    }
}
