using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoClase

public static void CrearProducto(Producto producto)
{ 
    string connectionString = @"Server=JQS\SQLEXPRESS01;DataBase=coderhouse;Trusted_Connection = true";
    var query = "insert into Producto (Descripciones, Costo, PrecioVenta, Stock, IdUsuario) values (@Descripciones, @Costo, @PrecioVenta, @Stock, @IdUsuario)";

using (SqlConnection conexion = new SqlConnection(connectionString))
    {
    conexion.Open();
    using (SqlCommand comando = new SqlCommand(query, conexion))
        {
            comando.Parameters.Add(new SqlParameter("Descripciones", SqlDbType.VarChar) {Value = producto.Descripciones });
            comando.Parameters.Add(new SqlParameter("Costo", SqlDbType.Money) { Value = producto.Costo });
            comando.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.Money) { Value = producto.Venta });
            comando.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = producto.Stock });
            comando.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.VarChar) { Value = producto.IdUsuario });
        }
    conexion.Close();
    }
}