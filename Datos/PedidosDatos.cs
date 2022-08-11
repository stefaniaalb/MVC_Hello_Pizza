using MVC_Pizzeria.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Pizzeria.Datos
{
    public class PedidosDatos
    {
        public List<PedidoCliente> ListarPedidos()
        {
            var listaPedidos = new List<PedidoCliente>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("listarPedidos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        listaPedidos.Add(new PedidoCliente()
                        {
                            Id = Convert.ToInt32(dr["id"]),
                            Direccion = dr["direccion"].ToString(),
                            Telefono = dr["telefono"].ToString(),
                            PizzaId = Convert.ToInt32(dr["pizzaId"]),
                        });
                    }
                }
                conexion.Close();
            }
            return listaPedidos;
        }

        public PedidoCliente obtenerPedido(int id)
        {
            var pedido = new PedidoCliente();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("obtenerPedido", conexion);
                cmd.Parameters.AddWithValue("id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader()) 
                {
                    while(reader.Read())
                    {
                        pedido.Id = Convert.ToInt32(reader["id"]);
                        pedido.Direccion = reader["direccion"].ToString();
                        pedido.Telefono = reader["telefono"].ToString();
                        pedido.PizzaId = Convert.ToInt32(reader["pizzaId"]);


                    }
                }
                conexion.Close();
            }
            return pedido;
        }


        public bool AgregarPedido(PedidoCliente pedido)
        {
            bool pudeAgregar;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("agregarPedido", conexion);
                    cmd.Parameters.AddWithValue("direccion", pedido.Direccion);
                    cmd.Parameters.AddWithValue("telefono", pedido.Telefono);
                    cmd.Parameters.AddWithValue("pizzaId", pedido.PizzaId);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                }
                pudeAgregar = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                pudeAgregar = false;
            }
            return pudeAgregar;
            
        }

        public bool EditarPedido(PedidoCliente pedido)
        {
            bool pudeEditar;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("editarPedido", conexion);
                    cmd.Parameters.AddWithValue("id", pedido.Id);
                    cmd.Parameters.AddWithValue("direccion", pedido.Direccion);
                    cmd.Parameters.AddWithValue("telefono", pedido.Telefono);
                    cmd.Parameters.AddWithValue("pizzaId", pedido.PizzaId);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                }
                pudeEditar = true;
            }
            catch(Exception e)
            {
                string error = e.Message;
                pudeEditar = false;
            }
            return pudeEditar;
        }

        public bool EliminarPedido(int id)
        {
            bool pudeEliminar;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("eliminarPedido", conexion);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                }
                pudeEliminar = true;
            }
            catch(Exception e)
            {
                string error = e.Message;
                pudeEliminar = false;
            }
            return pudeEliminar;

        }
       
    }




    
}
