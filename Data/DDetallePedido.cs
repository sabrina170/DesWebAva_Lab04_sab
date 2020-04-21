using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace Data
{
   public  class DDetallePedido
    {
        public List<DetallePedido> GetDetallePedidos(DetallePedido detallePedido) {

            SqlParameter[] parameters = null;
            String comandText = String.Empty;
            List<DetallePedido> detallePedidos= null;

            try {

                comandText = "USP_ListarDetalle";
                parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@IdPedido", SqlDbType.Int);
                parameters[0].Value = detallePedido.IdProducto;

                detallePedidos = new List<DetallePedido>();

                using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.Connection, "USP_FECHAFECHA",
                    CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        detallePedidos.Add(new DetallePedido
                        {
                            IdProducto = reader["IdProducto"] == null ? Convert.ToInt32(reader["IdProducto"]) : 0,
                            PrecioUnidad = reader["PrecioUnidad"] == null ? Convert.ToDecimal(reader["PrecioUnidad"]) : 0,
                            Cantidad = reader["Cantidad"] == null ? Convert.ToInt32(reader["Cantidad"]) : 0,
                            Descuento = reader["Descuento"] == null ? Convert.ToDecimal(reader["Descuento"]) : 0,
                        }); ;
                    }
                }

            }
            catch (Exception ex){ throw ex; }

            return detallePedidos;
        }
    }
}
