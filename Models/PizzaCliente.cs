using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Pizzeria.Models
{
    public class PizzaCliente
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public string Imagen { get; set; }

        //public PizzaCliente(int id, string nombre, string descripcion, int precio, string imagenUrl)
        //{
        //    this.Id = id;
        //    this.Nombre = nombre;
        //    this.Descripcion = descripcion;
        //    this.Precio = precio;
        //    this.Imagen = imagenUrl;
        //}
        
    
    }
}
