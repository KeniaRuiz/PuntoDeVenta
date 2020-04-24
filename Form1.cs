using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace PuntoDeVenta
{
    public partial class Form1 : Form
    {
        Conexion c = null;
        List<Producto> productos = null;
        String aux;
        bool producto;
        int auxcant;
        bool existe;
        private float total()
        {
            float total = 0.0f;
            for(int i = 0; i< dataGridView1.Rows.Count; i++)
            {
                total += float.Parse(dataGridView1[3, i].Value.ToString());

            }
            label3.Text = "Total = \n $" + total;
            textBox1.Clear();
            textBox1.Focus();
            
            return total;
        }

        private void buscarProductos()
        {
            if (textBox1.Text.IndexOf('*') != -1)
            {
                String[] sarray = textBox1.Text.Split('*');

                if (sarray[0].Length < sarray[1].Length)
                {
                    for (int i = 0; i < productos.Count; i++)
                    {
                        try
                        {
                            if (sarray[1].Equals(productos[i].Codigo))
                            {
                                existe = true;
                                Producto p = productos[i];
                                if (dataGridView1.Rows.Count == 0)
                                {
                                    dataGridView1.Rows.Add(sarray[0], p.Nombre, p.Precio, float.Parse(sarray[0]) * (float)p.Precio);
                                    total();
                                    break;
                                }
                                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                                {
                                    aux = dataGridView1[1, j].Value.ToString();
                                    if (aux.Equals(p.Nombre))
                                    {
                                        producto = true;
                                        auxcant = j;
                                        break;
                                    }
                                    else
                                    {
                                        producto = false;
                                    }

                                }
                                if (producto)
                                {
                                    dataGridView1[0, auxcant].Value = int.Parse(dataGridView1[0, auxcant].Value.ToString()) + int.Parse(sarray[0]);
                                    dataGridView1[3, auxcant].Value = int.Parse(dataGridView1[0, auxcant].Value.ToString()) * (float)p.Precio;
                                    total();
                                    break;
                                }
                                else
                                {
                                    dataGridView1.Rows.Add(sarray[0], p.Nombre, p.Precio, float.Parse(sarray[0]) * (float)p.Precio);
                                    total();
                                    break;
                                }
                               
                            }
                            else
                            {
                                existe = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ingrese una cantidad válida" + ex);
                            textBox1.Clear();
                        }
                    }
                    if(existe){
                        error.Text = "";
                    }
                    else
                    {
                        error.Text = "NO SE ENCONTRO PRODUCTO \n       VERIFIQUE EL CÓDIGO";
                    }
                }
                else
                {
                    for (int i = 0; i < productos.Count; i++)
                    {
                        try
                        {
                            if (sarray[0].Equals(productos[i].Codigo))
                            {
                                existe = true;
                                Producto p = productos[i];

                                if (dataGridView1.Rows.Count == 0)
                                {
                                    dataGridView1.Rows.Add(sarray[1], p.Nombre, p.Precio, float.Parse(sarray[1]) * (float)p.Precio);
                                    total();
                                    break;
                                }

                                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                                {
                                    aux = dataGridView1[1, j].Value.ToString();
                                    if (aux.Equals(p.Nombre))
                                    {
                                        producto = true;
                                        auxcant = j;
                                        break;
                                    }
                                    else
                                    {
                                        producto = false;
                                    }
                                }

                                if (producto)
                                {
                                    dataGridView1[0, auxcant].Value = int.Parse(dataGridView1[0, auxcant].Value.ToString()) + int.Parse(sarray[1]);
                                    dataGridView1[3, auxcant].Value = int.Parse(dataGridView1[0, auxcant].Value.ToString()) * (float)p.Precio;
                                    total();
                                    break;
                                }
                                else
                                {
                                    dataGridView1.Rows.Add(sarray[1], p.Nombre, p.Precio, float.Parse(sarray[1]) * (float)p.Precio);
                                    total();
                                    break;
                                }
                                
                            }
                            else
                            {
                                existe = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ingrese una cantidad válida" + ex.Message);
                            textBox1.Clear();
                        }
                    }
                    if (existe)
                    {
                        error.Text = "";
                    }
                    else
                    {
                        error.Text = "NO SE ENCONTRO PRODUCTO \n       VERIFIQUE EL CÓDIGO";
                    }
                }        
            }
            else
            {
                for (int i = 0; i < productos.Count; i++)
                {
                    try
                    {
                        existe = true;
                        Producto p = productos[i];

                        if (textBox1.Text.Equals(productos[i].Codigo))
                        {
                            if (dataGridView1.Rows.Count == 0)
                            {
                                dataGridView1.Rows.Add("1", p.Nombre, p.Precio, p.Precio);
                                total();
                                break;
                            }

                            for (int j = 0; j < dataGridView1.Rows.Count; j++)
                            {
                                aux = dataGridView1[1, j].Value.ToString();
                                if (aux.Equals(p.Nombre))
                                {
                                    producto = true;
                                    auxcant = j;
                                    break;
                                }
                                else
                                {
                                    producto = false;
                                }
                                
                            }

                            if (producto)
                            {
                                dataGridView1[0, auxcant].Value = int.Parse(dataGridView1[0, auxcant].Value.ToString()) + 1;
                                dataGridView1[3, auxcant].Value = int.Parse(dataGridView1[0, auxcant].Value.ToString()) * (float)p.Precio;
                                total();
                                break;
                            }
                            else
                            {
                                dataGridView1.Rows.Add("1", p.Nombre, p.Precio, p.Precio);
                                total();
                                break;
                            }

                            
                        }
                        else
                        {
                            existe = false;
                        }
                        
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Ingrese un código válido"+e);
                        textBox1.Clear();
                    }
                }
                if (existe)
                {
                    error.Text = "";
                }
                else
                {
                    error.Text = "NO SE ENCONTRO PRODUCTO \n       VERIFIQUE EL CÓDIGO";
                }

            }
            this.ActiveControl = textBox1;
            productos = c.getProductos();
        }
        public Form1()
        {
            
            InitializeComponent();
           
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.ActiveControl = textBox1;
            
            c = new Conexion();
            productos = c.getProductos();
            
            label3.Text = "Total =";

        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            fecha.Text=String.Format("{0:dd/MM/yyyy}", dt);
            hora.Text = DateTime.Now.ToLongTimeString();
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 18);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 18);
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            

        }

       private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                productos = c.getProductos();
                buscarProductos();
                dataGridView1.ClearSelection();
                textBox1.Text = String.Empty;
            }
            if(e.KeyCode  == Keys.Escape)
            {
                if (dataGridView1.Rows.Count >= 1)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);;
                    total();
                }
                
            }
            if (e.KeyCode == Keys.P)
            {
                DialogResult dialogResult = MessageBox.Show("¡Venta realizada con éxito!  \n Total: " + total(), "VENTA COMPLETADA", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (dataGridView1.Rows.Count == 0)
                    {
                        MessageBox.Show("No hay productos marcados para vender", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        dataGridView1.Rows.Clear();
                        label3.Text = "Total = ";
                    }

                }
                else if (dialogResult == DialogResult.No)
                {
                    textBox1.Clear();
                }

            }
            if (e.KeyCode == Keys.S)
            {
                DialogResult dialogResult = MessageBox.Show("¿Seguro que desea salir?", "Salir", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else if (dialogResult == DialogResult.No)
                {
                    textBox1.Clear();
                }

            }
            if (e.KeyCode == Keys.B)
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Selecciones un producto para eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                    textBox1.Focus();
                    textBox1.Clear();
                }
            }
        }


        private void pagar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos marcados para vender", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("¡Venta realizada con éxito!  \n Total: " + total(), "VENTA COMPLETADA");
                if (dialogResult == DialogResult.Yes)
                {
                    dataGridView1.Rows.Clear();
                    label3.Text = "Total = ";
                }
                else if (dialogResult == DialogResult.No)
                {
                    textBox1.Clear();
                }
            }
            
        }

        private void borrar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos marcados");
            }
            else
            {
                if(dataGridView1.CurrentRow==null)
                {
                    MessageBox.Show("Seleccione un producto para eliminar");
                }
                else
                {
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                    textBox1.Focus();
                    textBox1.Clear();
                }
                
            }
            
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Seguro que desea salir?", "Salir", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                textBox1.Clear();
            }
        }


        private void Ayuda_Click(object sender, EventArgs e)
        {
            var Form2 = new Form2();
            Form2.StartPosition = FormStartPosition.CenterScreen;
            Form2.Shown += (o, args) => { this.Enabled = false; };
            Form2.FormClosed += (o, args) => { this.Enabled = true; };
            Form2.Show();
        }
    }
}
