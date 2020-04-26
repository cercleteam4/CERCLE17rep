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
    public partial class frmMttoBARCOS : Form
    {
        public frmMttoBARCOS()
        {
            InitializeComponent();
        }

        public SqlConnection CnO;
        public ArrayList Lista_proveedores;



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
                MessageBox.Show(ex.ToString());
            }

            return res;
        }

        private void Cargar()
        {
            string strQ = "SELECT Matricula, Nombre, ProCod FROM BARCOS Order by Matricula";
            ArrayList Listado_Barcos = new ArrayList();

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    clase_barco barco = new clase_barco();

                    barco.Matricula = myReader["Matricula"].ToString();
                    barco.Nombre = myReader["Nombre"].ToString();
                    barco.ProCod = myReader["ProCod"].ToString();

                    if (Lista_proveedores != null)
                    {
                        for (int x = 0; x < Lista_proveedores.Count; x++)
                        {
                            clase_proveedor prove = (clase_proveedor)Lista_proveedores[x];

                            if (prove.CODIGO == barco.ProCod)
                            {
                                barco.Proveedor = prove.PROVEEDOR;
                            }

                        }
                    }

                    Listado_Barcos.Add(barco);

                }
                myReader.Close();

                dataGridView1.DataSource = Listado_Barcos;

                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmMttoBARCOS_Load(object sender, EventArgs e)
        {
            GloblaVar.gUTIL.CartelTraza("ENTRADA a " + this.GetType().FullName);

            if (CnO != null)
            {
                //array de proveedores
                Lista_proveedores = new ArrayList();
                string strQ = "SELECT * FROM PROVEEDORES order by ProCod";

                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(strQ, CnO);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        clase_proveedor prove = new clase_proveedor();
                        prove.CODIGO = myReader["ProCod"].ToString();
                        prove.PROVEEDOR = myReader["ProNom"].ToString();
                        Lista_proveedores.Add(prove);
                    }
                    myReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                Cargar();
            }
        }

        private void button_Buscar_Click(object sender, EventArgs e)
        {
            //buscar proveedores
            FormConsulta Consulta = new FormConsulta();
            Consulta.Lista_proveedores = Lista_proveedores;
            if (Consulta.ShowDialog() == DialogResult.OK)
            {
                if (Consulta.Pro_Cod != "")
                {
                    textBox_ProCod.Text = Consulta.Pro_Cod;
                    textBox_Proveedor.Text = Consulta.Nombre_Pro;
                }
            }
        }

        private void button_Agregar_Click(object sender, EventArgs e)
        {
            //agregar barco
            if (textBox_Matricula.Text != "")
            {
                if (textBox_Nombre.Text != "")
                {
                    if (Funciones.numerales(textBox_ProCod.Text) != "")
                    {
                        //comprobar si el proveedor existe
                        bool seguir = false;
                        if (Lista_proveedores != null)
                        {
                            for (int x = 0; x < Lista_proveedores.Count; x++)
                            {
                                clase_proveedor proveedor = (clase_proveedor)Lista_proveedores[x];

                                if (proveedor.CODIGO == textBox_ProCod.Text)
                                {
                                    seguir = true;
                                }
                            }
                        }

                        if (seguir == true)
                        {
                            string insert = "INSERT INTO BARCOS(Matricula, ProCod, Nombre) VALUES('" + textBox_Matricula.Text.Replace("'", "''") + "', " + textBox_ProCod.Text + ", '" + textBox_Nombre.Text.Replace("'", "''") + "')";

                            int res = EjecutaNonQuery(insert);

                            if (res == 1)
                            {
                                MessageBox.Show("Barco agregado con éxito");
                            }
                            else
                            {
                                MessageBox.Show("Ocurrió algún problema al agregar el barco");
                            }

                            Limpiar();
                            Cargar();

                        }
                    }
                    else
                    {
                        MessageBox.Show("No se ha dado un valor numérico de código de proveedor");
                    }
                }
                else
                {
                    MessageBox.Show("No se ha dado nombre al barco");
                }
            }
            else
            {
                MessageBox.Show("No se ha introducido un valor de Matrícula");
            }
        }

        private void button_MismoProv_Click(object sender, EventArgs e)
        {
            //agregar barco al mismo proveedor
        }

        private void button_MismoBarco_Click(object sender, EventArgs e)
        {
            //agregar proveedor al mismo barco
        }

        private void Limpiar()
        {
            textBox_Matricula.Text = "";
            textBox_Nombre.Text = "";
            textBox_ProCod.Text = "";
            textBox_Proveedor.Text = "";
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void button_Eliminar_Click(object sender, EventArgs e)
        {
            if (textBox_Matricula.Text != "")
            {
                if (textBox_ProCod.Text != "")
                {
                    if (MessageBox.Show("¿Desea borrar el Barco con Matrícula '" + textBox_Matricula.Text + "' y Código Prov. " + textBox_ProCod.Text + " ?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string delete = "DELETE FROM BARCOS WHERE Matricula='" + textBox_Matricula.Text + "' AND ProCod=" + textBox_ProCod.Text;

                        int res = EjecutaNonQuery(delete);

                        if (res == 1)
                        {
                            MessageBox.Show("Barco borrado con éxito");
                        }
                        else
                        {
                            MessageBox.Show("Problema al borrar barco");
                        }

                        Limpiar();
                        Cargar();

                    }
                }
                else
                {
                    MessageBox.Show("Falta código de proveedor");
                }
            }
            else
            {
                MessageBox.Show("Pulse dos veces sobre el barco que desea borrar para que se carguen sus datos en los cuadros de texto");
            }
        }

        private void button_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox_Matricula.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox_Nombre.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox_ProCod.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox_Proveedor.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }
    }
}
