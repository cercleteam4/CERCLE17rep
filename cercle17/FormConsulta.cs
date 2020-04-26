using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cercle17
{
    public partial class FormConsulta : Form
    {
        public FormConsulta()
        {
            InitializeComponent();
        }

        public ArrayList Lista_proveedores;
        public string Pro_Cod, Nombre_Pro;



        private void Recarga()
        {
            if (Lista_proveedores != null)
            {
                this.Cursor = Cursors.WaitCursor;
                
                ArrayList Auxiliar = new ArrayList();
                
                for (int x = 0; x < Lista_proveedores.Count; x++)
                {
                    //utilizamos clase proveedor para hacer una tabla con dos columnas: código y proveedor

                    clase_proveedor prov = (clase_proveedor)Lista_proveedores[x];
                    bool agregar = true;

                    //aplicamos un filtro usando los textbox, si no se cumple el filtro no se agregan

                    if (prov.CODIGO.ToUpper().Contains(textBox_ProCod.Text.ToUpper()) == false) { agregar = false; }
                    if (prov.PROVEEDOR.ToUpper().Contains(textBox_Pronom.Text.ToUpper()) == false) { agregar = false; }

                    if (agregar)
                    {
                        Auxiliar.Add(prov);
                    }
                }

                dataGridView1.DataSource = Auxiliar;
                
                if (dataGridView1.RowCount > 0)
                {
                    dataGridView1.Columns[0].Width = 100;
                    dataGridView1.Columns[1].Width = 400;
                }
                
                this.Cursor = Cursors.Default;
            }
        }

        private void FormConsulta_Load(object sender, EventArgs e)
        {
            Pro_Cod = "";
            if (Lista_proveedores != null)
            {
                dataGridView1.DataSource = Lista_proveedores; 
                
                if (dataGridView1.RowCount > 0)
                {
                    dataGridView1.Columns[0].Width = 100;
                    dataGridView1.Columns[1].Width = 350;
                }
            }

            textBox_Pronom.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //recupera procod
            Pro_Cod = textBox_ProCod.Text;
            Nombre_Pro = textBox_Pronom.Text;
        }         

        private void textBox_Pronom_TextChanged(object sender, EventArgs e)
        {
            Recarga();
        }

        private void textBox_ProCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            //filtro por código
            Recarga();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //selección de fila del grid
            if (e.RowIndex >= 0)
            {
                //localizar código y nombre
                textBox_ProCod.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox_Pronom.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                Pro_Cod = textBox_ProCod.Text;
                Nombre_Pro = textBox_Pronom.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //localizar código y nombre
                textBox_ProCod.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox_Pronom.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                Pro_Cod = textBox_ProCod.Text;
                Nombre_Pro = textBox_Pronom.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }       

        private void textBox_Pronom_Enter(object sender, EventArgs e)
        {
            textBox_Pronom.BackColor = Color.Yellow;
            textBox_ProCod.BackColor = Color.White;
        }

        private void textBox_ProCod_Enter(object sender, EventArgs e)
        {
            textBox_Pronom.BackColor = Color.White;
            textBox_ProCod.BackColor = Color.Yellow;
        }

  

    }
}
