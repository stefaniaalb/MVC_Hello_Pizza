using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Pizzeria.Models;
using System.Data.SqlClient;
using System.Data;

namespace MVC_Pizzeria.Datos
{
    public class PizzaDatos
    {
        public List<PizzaCliente> ListarPizzas()
        {
            var menuPizzas = new List<PizzaCliente>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("listarPizzas", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        menuPizzas.Add(new PizzaCliente()
                        {
                            Id = Convert.ToInt32(dr["id"]),
                            Nombre = dr["nombre"].ToString(),
                            Descripcion = dr["descripcion"].ToString(),
                            Precio = Convert.ToInt32(dr["precio"]),
                            Imagen = dr["imagenUrl"].ToString()
                        }); ;
                    }
                }
                conexion.Close();
            }
            return menuPizzas;
        }

    }
}
