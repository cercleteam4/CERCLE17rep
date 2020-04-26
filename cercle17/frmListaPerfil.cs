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
    public partial class frmListaPerfil : Form
    {
        public frmListaPerfil()
        {
            InitializeComponent();
        }

        public SqlConnection CnO;

        private void Cargar()
        {
            //se mostrarán los perfiles que tenemos disponibles en la base de datos
            //para que el usuario vea los permisos que tiene cada perfil

            if (CnO != null)
            {
                string strQ = "SELECT * FROM PERFILES_SEG";
                ArrayList Perfiles = new ArrayList();

                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(strQ, CnO);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        clase_perfil perfil = new clase_perfil();

                        perfil.Perfil = myReader["Perfil"].ToString();
                        perfil.Caja = false; if (myReader["Caja"].ToString() == "True") { perfil.Caja = true; }
                        perfil.Cobros = false; if (myReader["Cobros"].ToString() == "True") { perfil.Cobros = true; }
                        perfil.Compras = false; if (myReader["Compras"].ToString() == "True") { perfil.Compras = true; }
                        perfil.Cuadres = false; if (myReader["Cuadres"].ToString() == "True") { perfil.Cuadres = true; }
                        perfil.Mayoristas = false; if (myReader["Mayoristas"].ToString() == "True") { perfil.Mayoristas = true; }
                        perfil.TPV = false; if (myReader["TPV"].ToString() == "True") { perfil.TPV = true; }

                        Perfiles.Add(perfil);
                    }
                    myReader.Close();

                    dataGridView1.DataSource = Perfiles;

                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void frmListaPerfil_Load(object sender, EventArgs e)
        {
            GloblaVar.gUTIL.CartelTraza("ENTRADA a " + this.GetType().FullName);

            Cargar();
        }

        private void button_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
