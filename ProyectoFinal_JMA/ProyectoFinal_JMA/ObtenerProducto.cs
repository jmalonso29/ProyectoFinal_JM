using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoClase

public static List<Producto> Listar Productos()

{
    List<Producto> lista = new List<Producto>();
    string connectionString = @"Server=JQS\SQLEXPRESS01;DataBase=coderhouse;Trusted_Connection = true";
    var query = "SELECT Id, Descripciones, Costo, PrecioVenta, Stock, IdUsuario FROM Producto";

    using (SqlConnection conexion = new SqlConnection(connectionString))
    {
        conecxion.Open();
        using (SqlCommand comando = new SqlCommand(query, conexion))
        {
            using (SqlDataReader dr = comando.ExecuteReader())

            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var producto = new Producto();
                        producto.Id = Convert.ToInt32(dr["Id"]);
                        producto.Descripciones = dr["Descripciones"].ToString();
                        producto.Costo = Convert.ToDecimal(dr["Costo"]);
                        producto.PrecioVenta = Convert.ToDecimal(dr['PrecioVenta']);
                        producto.Stock = Convert.ToDecimal(dr["Stock"]);
                        producto.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                        lista.Add(producto);
                    }
                }
            }
        }
    }
    return lista;
}
