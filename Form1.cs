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
        private float total()
        {
            float total = 0.0f;
            for(int i = 0; i< dataGridView1.Rows.Count; i++)
            {
                total += float.Parse(dataGridView1[3, i].Value.ToString());

            }
            label3.Text = "Total = " + total;
            textBox1.Clear();
            textBox1.Focus();
            
            return total;
        }

        private void buscarProductos()
        {
            if (textBox1.Text.IndexOf('*') != -1)
            {
                String[] sarray = textBox1.Text.Split('*');

                if (sarray[0].Length<sarray[1].Length)
                {
                    for (int i = 0; i < productos.Count; i++)
                    {
                        try
                        {
                            if (sarray[1].Equals(productos[i].Codigo))
                            {
                                Producto p = productos[i];
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
                                    total();
                                }
                                else
                                {
                                    dataGridView1.Rows.Add(sarray[0], p.Nombre, p.Precio, float.Parse(sarray[0]) * (float)p.Precio);
                                    total();
                                }

                                if (dataGridView1.Rows.Count == 0)
                                {
                                    dataGridView1.Rows.Add(sarray[0], p.Nombre, p.Precio, float.Parse(sarray[0]) * (float)p.Precio);
                                    total();
                                }

                            }
                        }
                        catch
                        {
                            MessageBox.Show("Ingrese una cantidad válida");
                            textBox1.Clear();
                        }
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
                                Producto p = productos[i];
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
                                    total();
                                }
                                else
                                {
                                    dataGridView1.Rows.Add(sarray[1], p.Nombre, p.Precio, float.Parse(sarray[1]) * (float)p.Precio);
                                    total();
                                }
                                if (dataGridView1.Rows.Count == 0)
                                {
                                    dataGridView1.Rows.Add(sarray[1], p.Nombre, p.Precio, float.Parse(sarray[1]) * (float)p.Precio);
                                    total();
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Ingrese una cantidad válida");
                            textBox1.Clear();
                        }
                }
                }         
            }
            else
            {
                for (int i = 0; i < productos.Count; i++)
                {
                    try
                    {
                        

                        if (textBox1.Text.Equals(productos[i].Codigo))
                        {
                            Producto p = productos[i];
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
                                total();
                            }
                            else
                            {
                                dataGridView1.Rows.Add("1", p.Nombre, p.Precio, p.Precio);
                                total();
                            }
                            if (dataGridView1.Rows.Count==0){
                                dataGridView1.Rows.Add("1", p.Nombre, p.Precio, p.Precio);
                                total();
                            }

                        }
                        
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Ingrese un código válido");
                        textBox1.Clear();
                    }
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

            //label1.Location = new Point((this.Width / 2) - label1.Width / 2, 5);
            //label2.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
            //label2.Location = new Point(label4.Width, label1.Height + 10);
            //dataGridView1.Width = this.Width - 20;
            //dataGridView1.Height = this.Height * 3 / 4;
            //dataGridView1.Location = new Point(10, label2.Height + label1.Height + 25);
            //textBox1.Width = this.Width - 20;
            //textBox1.Location = new Point(10, this.Height - textBox1.Height - 10);

            //label3.Location = new Point(this.Width - dataGridView1.Columns[3].Width, label1.Height + label2.Height + dataGridView1.Height + 35);
            //label4.Location = new Point((this.Width * 3 / 4), label1.Height + 10);

            
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                productos = c.getProductos();
                buscarProductos();
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
                float subtotal = total();
                DialogResult dialogResult = MessageBox.Show("¿Listo para pagar?  \n Total: " + total(), "Pagar", MessageBoxButtons.YesNo);
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
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                textBox1.Focus();
                textBox1.Clear();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pagar_Click(object sender, EventArgs e)
        {
            float subtotal = total();
            DialogResult dialogResult = MessageBox.Show("¿Listo para pagar?  \n Total: "+total(), "Pagar", MessageBoxButtons.YesNo);
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

        private void borrar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            textBox1.Focus();
            textBox1.Clear();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
