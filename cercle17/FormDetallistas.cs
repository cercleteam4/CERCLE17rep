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
    public partial class FormDetallistas : Form
    {
        public FormDetallistas()
        {
            InitializeComponent();
        }

        public ArrayList Lista_detallistas, Listado;
        public string DetCod, Nombre_Det;

        private void Recarga()
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            if (Listado != null)
            {
                this.Cursor = Cursors.WaitCursor;
                
                ArrayList Auxiliar = new ArrayList();
                
                for (int x = 0; x < Listado.Count; x++)
                {
                    //utilizamos clase proveedor para hacer una tabla con dos columnas: código y proveedor

                    clase_proveedor prov = (clase_proveedor)Listado[x];
                    bool agregar = true;

                    //aplicamos un filtro usando los textbox, si no se cumple el filtro no se agregan

                    if (prov.CODIGO.ToUpper().Contains(textBox_DetCod.Text.ToUpper()) == false) { agregar = false; }
                    if (prov.PROVEEDOR.ToUpper().Contains(textBox_DetNom.Text.ToUpper()) == false) { agregar = false; }

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

        private void FormDetallistas_Load(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            DetCod = "";
            if (Lista_detallistas != null)
            {
                //crear Listado
                Listado = new ArrayList();

                for (int x = 0; x < Lista_detallistas.Count; x++)
                {
                    //aquí estamos pasando del tipo "detallista" que tiene varias columnas, al tipo "proveedor" que solo tiene dos
                    //porque nos interesa tener solo dos columnas

                    clase_detallista detallista = (clase_detallista)Lista_detallistas[x];

                    clase_proveedor prov = new clase_proveedor();

                    prov.CODIGO = detallista.DetCod;
                    prov.PROVEEDOR = detallista.DetNom;

                    Listado.Add(prov);
                }


                dataGridView1.DataSource = Listado;

                if (dataGridView1.RowCount > 0)
                {
                    dataGridView1.Columns[0].Width = 100;
                    dataGridView1.Columns[1].Width = 350;
                }
            }

            textBox_DetNom.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            DetCod = textBox_DetCod.Text;
            Nombre_Det = textBox_DetNom.Text;
        }

        private void textBox_DetNom_TextChanged(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            Recarga();
        }

        private void textBox_DetCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            Recarga();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            //selección de fila del grid
            if (e.RowIndex >= 0)
            {
                //localizar código y nombre
                textBox_DetCod.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox_DetNom.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                DetCod = textBox_DetCod.Text;
                Nombre_Det = textBox_DetNom.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            //selección de fila del grid
            if (e.RowIndex >= 0)
            {
                //localizar código y nombre
                textBox_DetCod.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox_DetNom.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                DetCod = textBox_DetCod.Text;
                Nombre_Det = textBox_DetNom.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void textBox_DetNom_Enter(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            textBox_DetNom.BackColor = Color.Yellow;
            textBox_DetCod.BackColor = Color.White;
        }

        private void textBox_DetCod_Enter(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            textBox_DetNom.BackColor = Color.White;
            textBox_DetCod.BackColor = Color.Yellow;
        }
    }
}
