using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Pizzeria.Models
{
    public class PedidoCliente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo dirección es obligatorio")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El campo telefono es obligatorio")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Debe seleccionar una pizza")]
        public int PizzaId { get; set; }



    }
}
