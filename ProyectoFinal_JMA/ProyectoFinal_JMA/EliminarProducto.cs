using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static void EliminarProducto (Producto producto)
{
    string connectionString = @"Server=JQS\SQLEXPRESS01;DataBase=coderhouse;Trusted_Connection = true";
    var query = "delete from Producto where Id = @Id";

    using (SqlConnection conexion = new SqlConnection(connectionString))
    {
        conexion.Open();
        using (SqlCommand comando = new SqlCommand(query, conexion))
        {
            comando.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = producto.Id});
        }
        conexion.Close();
    }
}
