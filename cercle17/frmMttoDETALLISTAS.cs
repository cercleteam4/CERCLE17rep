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
    public partial class frmMttoDETALLISTAS : Form
    {
        public frmMttoDETALLISTAS()
        {
            InitializeComponent();
        }    

        public SqlConnection CnO;
        private bool mensajes;
       
        private void Mostrar(string texto)
        {
            if (mensajes)
            {
                MessageBox.Show(texto);
            }
        }        

        private void Cargar()
        {
            if (CnO != null)
            {
                string strQ = "SELECT DetCod, DetNom, DetRec FROM DETALLISTAS ORDER BY DetNom";
                ArrayList listDetallistas = new ArrayList();

                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(strQ, CnO);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        clase_detallista detallista = new clase_detallista();

                        detallista.DetCod  = myReader["DetCod"].ToString();
                        detallista.DetNom = myReader["DetNom"].ToString();
                        detallista.DetRec = myReader["DetRec"].ToString();                       

                        listDetallistas.Add(detallista);
                    }

                    myReader.Close();

                    //this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    this.dataGridView1.AutoGenerateColumns = true;

                    dataGridView1.DataSource = listDetallistas;

                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[0].ReadOnly = true;
                        dataGridView1.Columns[0].HeaderText = "CÓDIGO";
                        dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dataGridView1.Columns[1].ReadOnly = true;
                        dataGridView1.Columns[1].HeaderText = "NOMBRE";
                        dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[2].ReadOnly = true;
                        dataGridView1.Columns[2].HeaderText = "TIPO";
                    }
                }
                catch (Exception ex)
                {
                    Mostrar(ex.ToString());
                }
            }
        }

        private void frmMttoDETALLISTAS_Load(object sender, EventArgs e)
        {
            GloblaVar.gUTIL.CartelTraza("ENTRADA a " + this.GetType().FullName);

            label_ID.ForeColor = panel_Datos.BackColor;
            mensajes = frmPpal.mensajes;
            //Carga_Combos();
            Cargar();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                label_ID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox_DetCod.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox_DetNom.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();               
                comboBox_DetRec.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();                
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
      

        private void button_Aceptar_Click(object sender, EventArgs e)
        {
            //insert o update
            if (textBox_DetCod.Text != "")
            {
                if (textBox_DetNom.Text != "")
                {  
                    if (comboBox_DetRec.Text != "")
                    {
                        if (label_ID.Text == "")
                        {
                            //insert
                            //string id_vendedor = Nuevo_Vendedor();

                            //if (id_vendedor != "")
                            //{

                                string insert = "INSERT INTO DETALLISTAS (DetCod, DetNom, DetRec) ";
                                insert += " VALUES(" + textBox_DetCod.Text  + ", '" + textBox_DetNom.Text + "', '" + comboBox_DetRec.Text + "')";

                                int res1 = EjecutaNonQuery(insert);

                                if (res1 == 1)
                                {
                                    MessageBox.Show("Detallista insertado");                                    
                                    Cargar();
                                    Limpiar();
                                }
                                else
                                {
                                    MessageBox.Show("Detallista no pudo ser insertado");
                                }
                            //}
                            //else
                            //{
                            //    MessageBox.Show("Vendedor no pudo ser generado");
                            //}
                        }
                        else
                        {
                            //update
                            string update = "";
                           
                            //no se cambia la clave
                            update = "UPDATE DETALLISTAS SET DetNom ='" + textBox_DetNom.Text + "', DetRec='" + comboBox_DetRec.Text + "' WHERE DetCod=" + label_ID.Text;
                            
                                
                            int res = EjecutaNonQuery(update);

                            if (res == 1)
                            {
                                MessageBox.Show("Detallista actualizado");                                
                                Cargar();
                                Limpiar();
                            }
                            else
                            {
                                MessageBox.Show("Detallista no pudo ser actualizado");
                            }
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("Falta seleccionar Tipo");
                    }
                }
                else
                {
                    MessageBox.Show("Falta nombre de detallista");
                }
            }
            else
            {
                MessageBox.Show("Falta código de detallista");
            }            

        }

        private void Limpiar()
        {
            label_ID.Text = "";
            textBox_DetCod.Text = "";
            textBox_DetNom.Text = "";            
            comboBox_DetRec.Text = "";            
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            //borrar datos
            Limpiar();
        }

      
    }
}
