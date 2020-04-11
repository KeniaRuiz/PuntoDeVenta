
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PuntoDeVenta
{
    class Conexion
    {
        SqlConnection cn;
      //  SqlCommand cmd;
        //SqlDataReader dr;
        DataTable dt;
        SqlDataAdapter da;
        public Conexion()
        {
            try
            {
                cn = new SqlConnection("Data Source=la-guadalupana.chmhdwsd417m.us-west-2.rds.amazonaws.com;Initial Catalog=PuntoDeVenta;Persist Security Info=True;User ID=pvadmin;Password=ingsoftware2");
                cn.Open();
                MessageBox.Show("Conectado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conecto la base de datos: " + ex.ToString());
            }

        }

        public void MostrarProductos(DataGridView dgv)
        {
            try
            {
                da = new SqlDataAdapter("Select * from Productos", cn);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se puedo llenar la tabla:" + ex);
            }


        }


        public List<Producto> getProductos()
        {
            String query = "SELECT * FROM productos";
            List<Producto> productos = new List<Producto>();

            try
            {
                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Producto p = new Producto();
                    p.Id = (int)dr["id"];
                    p.Codigo = (String)dr["codigo"];
                    p.Nombre = (String)dr["nombre"];
                    p.Precio = (decimal)dr["precio"];
                    productos.Add(p);
                }
                dr.Close();
                cn.Close();
                cn.Open();
                return productos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conecto a la base de datos:" + ex);
                return productos;
            }

        }
    }
}
 
            
