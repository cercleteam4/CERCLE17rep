using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cercle17
{
    public partial class frmMttoVENDEDORES : Form
    {
        public frmMttoVENDEDORES()
        {
            InitializeComponent();
        }

        public SqlConnection CnO;
        private bool mensajes;
        private ArrayList Listado_Almacenes;
        private int MAX_VENDEDORES_TPV = 6;


        private class Almacenes
        {
            public string AlmMay;
            public string AlmNom;
        }

        private void Mostrar(string texto)
        {
            if (mensajes)
            {
                MessageBox.Show(texto);
            }
        }

        private void Carga_Combos()
        {
            comboBox_Perfil.Items.Clear();
            comboBox_AlmMay.Items.Clear();
            Listado_Almacenes = new ArrayList();

            if (CnO != null)
            {
                string strQ = "SELECT Perfil FROM PERFILES_SEG";

                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(strQ, CnO);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        comboBox_Perfil.Items.Add(myReader["Perfil"].ToString());
                    }
                    myReader.Close();
                }
                catch (Exception ex)
                {
                    Mostrar(ex.ToString());
                }

                strQ = "SELECT AlmMay, AlmNom FROM ALMACENES";

                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(strQ, CnO);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        comboBox_AlmMay.Items.Add(myReader["AlmNom"].ToString());

                        Almacenes almacen = new Almacenes();
                        almacen.AlmMay = myReader["AlmMay"].ToString();
                        almacen.AlmNom = myReader["AlmNom"].ToString();

                        Listado_Almacenes.Add(almacen);
                    }
                    myReader.Close();
                }
                catch (Exception ex)
                {
                    Mostrar(ex.ToString());
                }
            }
        }

        private void Carga_Terminales()
        {
            string strQ = "SELECT * FROM TERMINAL_VENDEDOR order by IdVendedor";
            ArrayList Vendedores = new ArrayList();

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    string idvendedor = myReader["IdVendedor"].ToString();
                    string terminal = myReader["IdTerminal"].ToString();

                    for (int x = 0; x < dataGridView1.Rows.Count; x++)
                    {
                        string idv = dataGridView1.Rows[x].Cells[0].Value.ToString();

                        if (idv == idvendedor)
                        {
                            string casilla_terminales = dataGridView1.Rows[x].Cells[5].Value.ToString();
                            casilla_terminales += terminal + ", ";

                            dataGridView1.Rows[x].Cells[5].Value = casilla_terminales;
                        }
                    }

                }
                myReader.Close();

                //quitar las comas sobrantes
                for (int y = 0; y < dataGridView1.Rows.Count; y++)
                {
                    string casilla_terminales = dataGridView1.Rows[y].Cells[5].Value.ToString();
                    if (casilla_terminales.Length > 2)
                    {
                        casilla_terminales = casilla_terminales.Substring(0, casilla_terminales.Length - 2);
                        dataGridView1.Rows[y].Cells[5].Value = casilla_terminales;
                    }
                }

            }
            catch (Exception ex)
            {
                Mostrar(ex.ToString());
            }
        }

        private void Cargar()
        {
            if (CnO != null)
            {
                string strQ = "SELECT * FROM VENDEDORES order by IdVendedor";
                ArrayList Vendedores = new ArrayList();

                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(strQ, CnO);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        clase_vendedor vendor = new clase_vendedor();

                        vendor.IdVendedor = myReader["IdVendedor"].ToString();
                        vendor.Vendedor = myReader["Vendedor"].ToString();
                        vendor.Tfno = myReader["Tfno"].ToString();
                        vendor.AlmMay = myReader["AlmMay"].ToString();
                        vendor.Perfil = myReader["Perfil"].ToString();
                        vendor.Foto = myReader["PathFoto"].ToString();
                        vendor.Terminales = "";

                        Vendedores.Add(vendor);
                    }
                    myReader.Close();

                    dataGridView1.DataSource = Vendedores;

                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[2].Visible = false;
                        dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        Carga_Terminales();

                        //poner nombre de almacén en lugar de código
                        if (Listado_Almacenes != null)
                        {
                            for (int x = 0; x < dataGridView1.Rows.Count; x++)
                            {
                                if (dataGridView1.Rows[x].Cells[3].Value != null)
                                {
                                    for (int y = 0; y < Listado_Almacenes.Count; y++)
                                    {
                                        Almacenes almacen = (Almacenes)Listado_Almacenes[y];

                                        if (almacen.AlmMay == dataGridView1.Rows[x].Cells[3].Value.ToString().Trim())
                                        {
                                            dataGridView1.Rows[x].Cells[3].Value = almacen.AlmNom;
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    Mostrar(ex.ToString());
                }
            }
        }

        private void frmMttoVENDEDORES_Load(object sender, EventArgs e)
        {
            GloblaVar.gUTIL.CartelTraza("ENTRADA a " + this.GetType().FullName);

            label_ID.ForeColor = panel_Datos.BackColor;
            mensajes = frmPpal.mensajes;
            Carga_Combos();
            Cargar();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                label_ID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox_Nombre.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox_Clave.Text = "*********";
                comboBox_AlmMay.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboBox_Perfil.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox_Terminales.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBox_PathFoto.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
        }

        private int EjecutaNonQuery(string NonQuery)
        {
            int res = 0;

            try
            {
                SqlCommand myCommand = new SqlCommand(NonQuery, CnO);
                res = myCommand.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                Mostrar(ex.ToString());
            }

            return res;
        }

        private string Nuevo_Vendedor()
        {
            string numero = "";
            string strQ = "select MAX(IdVendedor) from VENDEDORES";
            string ident = "0";

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    if (myReader[0].ToString() != "")
                    {
                        ident = myReader[0].ToString();
                    }
                }
                myReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            int aux = 0;
            if (System.Int32.TryParse(ident, out aux))
            {
                aux++;
                numero = aux.ToString();
            }

            return numero;
        }

        private int Cuenta_Vendedores(string id_terminal)
        {
            int resultado = 0;
            string strQ = "select * from TERMINAL_VENDEDOR WHERE IdTerminal=" + id_terminal;

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    resultado++;
                }
                myReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return resultado;
        }

        private void Actualizar_Terminales(string id_vendedor, string terminales)
        {
            if (id_vendedor != "")
            {
                //Delete de todos los terminales de este vendedor, antes de actualizar
                string delete = "DELETE FROM TERMINAL_VENDEDOR WHERE IdVendedor=" + id_vendedor;
                
                int res = EjecutaNonQuery(delete);

                if (res >= 0)   //no se prosigue si el delete da error, pero sí si no tenía filas que borrar
                {
                    if (terminales != "")
                    {
                        string[] cada_terminal = terminales.Split(',');

                        for (int x = 0; x < cada_terminal.Length; x++)
                        {
                            //comprobación de que este terminal tenga 4 o menos vendedores asignados
                            string id_terminal = Funciones.numerales(cada_terminal[x]);

                            if (id_terminal != "")
                            {
                                int contador = Cuenta_Vendedores(id_terminal);

                                if (contador < MAX_VENDEDORES_TPV)
                                {
                                    //se puede añadir
                                    string insert = "INSERT INTO TERMINAL_VENDEDOR(IdVendedor, IdTerminal) ";
                                    insert += " VALUES(" + id_vendedor + ", " + id_terminal + ")";

                                    int res2 = EjecutaNonQuery(insert);
                                }
                                else
                                {
                                    MessageBox.Show("El terminal " + id_terminal + " no puede tener más de " + MAX_VENDEDORES_TPV.ToString() + " vendedores");
                                }
                            }
                        }
                    }
                }

            }
        }

        private void button_Aceptar_Click(object sender, EventArgs e)
        {
            //insert o update
            if (textBox_Nombre.Text != "")
            {
                if (textBox_Clave.Text != "")
                {
                    if (comboBox_AlmMay.Text != "")
                    {
                        string almacen_almmay = "";
                        if (Listado_Almacenes != null)
                        {
                            for (int x = 0; x < Listado_Almacenes.Count; x++)
                            {
                                Almacenes almacen = (Almacenes)Listado_Almacenes[x];

                                if (almacen.AlmNom == comboBox_AlmMay.Text)
                                {
                                    almacen_almmay = almacen.AlmMay;
                                }
                            }
                        }

                        if (comboBox_Perfil.Text != "")
                        {
                            //crear clave en MD5
                            string nueva_clave = Funciones.GetMd5(textBox_Clave.Text);

                            //comprobar Terminales
                            string terminales = "";
                            string[] cada_terminal = textBox_Terminales.Text.Split(',');

                            for (int x = 0; x < cada_terminal.Length; x++)
                            {
                                if (Funciones.numerales(cada_terminal[x]) != "")
                                {
                                    terminales += Funciones.numerales(cada_terminal[x]) + ",";
                                }
                            }
                            if (terminales.Length > 1) { terminales = terminales.Substring(0, terminales.Length - 1); }

                            string path_foto = textBox_PathFoto.Text;
                            if (path_foto.Length > 150) { path_foto = ""; }

                            if (label_ID.Text == "")
                            {
                                //insert

                                string id_vendedor = Nuevo_Vendedor();

                                if (id_vendedor != "")
                                {

                                    string insert = "INSERT INTO VENDEDORES(IdVendedor, Vendedor, Password, AlmMay, Perfil, PathFoto) ";
                                    insert += " VALUES(" + id_vendedor + ", '" + textBox_Nombre.Text + "', '" + nueva_clave + "', '" + almacen_almmay + "', '" + comboBox_Perfil.Text + "', '" + path_foto + "')";

                                    int res1 = EjecutaNonQuery(insert);

                                    if (res1 == 1)
                                    {
                                        MessageBox.Show("Vendedor actualizado");
                                        Actualizar_Terminales(id_vendedor, terminales);
                                        Cargar();
                                        Limpiar();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Vendedor no pudo ser actualizado");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Vendedor no pudo ser generado");
                                }
                            }
                            else
                            {
                                //update
                                string update = "";

                                if (textBox_Clave.Text != "*********")
                                {
                                    update = "UPDATE VENDEDORES SET Vendedor='" + textBox_Nombre.Text + "', Password='" + nueva_clave + "', AlmMay='" + almacen_almmay + "', Perfil='" + comboBox_Perfil.Text + "', PathFoto='" + path_foto + "' WHERE IdVendedor=" + label_ID.Text;
                                }
                                else
                                {
                                    //no se cambia la clave
                                    update = "UPDATE VENDEDORES SET Vendedor='" + textBox_Nombre.Text + "', AlmMay='" + almacen_almmay + "', Perfil='" + comboBox_Perfil.Text + "', PathFoto='" + path_foto + "' WHERE IdVendedor=" + label_ID.Text;
                                }
                                
                                int res = EjecutaNonQuery(update);

                                if (res == 1)
                                {
                                    MessageBox.Show("Vendedor actualizado");
                                    Actualizar_Terminales(label_ID.Text, terminales);
                                    Cargar();
                                    Limpiar();
                                }
                                else
                                {
                                    MessageBox.Show("Vendedor no pudo ser actualizado");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta seleccionar perfil");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta seleccionar Almacén");
                    }
                }
                else
                {
                    MessageBox.Show("Falta escribir clave");
                }
            }
            else
            {
                MessageBox.Show("Falta nombre de vendedor");
            }            

        }

        private void Limpiar()
        {
            label_ID.Text = "";
            textBox_Nombre.Text = "";
            textBox_Clave.Text = "";
            comboBox_AlmMay.Text = "";
            comboBox_Perfil.Text = "";
            textBox_PathFoto.Text = "";
            textBox_Terminales.Text = "";
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            //borrar datos
            Limpiar();
        }

        private void button_Terminales_Click(object sender, EventArgs e)
        {
            //mostrar listado de terminales-vendedores
            frmListaTerminales Terminales = new frmListaTerminales();
            Terminales.CnO = CnO;
            Terminales.Show();
        }

        private void button_Perfiles_Click(object sender, EventArgs e)
        {
            //mostrar listado de permisos por perfil
            frmListaPerfil Perfiles = new frmListaPerfil();
            Perfiles.CnO = CnO;
            Perfiles.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //abrir file dialog
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_PathFoto.Text = openFileDialog1.FileName;
            }
        }
    }
}
