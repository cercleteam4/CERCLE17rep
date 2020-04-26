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

    public partial class frmMttoARTICULOS : Form
    {
        public frmMttoARTICULOS()
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
                GloblaVar.gUTIL.ATraza(texto);
            }
        }        

        private void Cargar()
        {
            if (CnO != null)
            {
                string strQ = "SELECT ArtCod, ArtDes, Tipo1, Tipo2, EtiqOblig FROM ARTICULOS ORDER BY ArtCod";
                ArrayList listArticulos = new ArrayList();

                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(strQ, CnO);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        clase_articulo articulo = new clase_articulo();

                        articulo.ArtCod = myReader["ArtCod"].ToString();
                        articulo.ArtDes = myReader["ArtDes"].ToString();
                        articulo.Tipo1 = myReader["Tipo1"].ToString();
                        articulo.Tipo2 = myReader["Tipo2"].ToString();
                        articulo.EtiqOblig = myReader["EtiqOblig"].ToString();

                        listArticulos.Add(articulo);
                    }

                    myReader.Close();

                    //this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    //dataGridView1.AutoGenerateColumns = false;

                    dataGridView1.DataSource = listArticulos;

                    dataGridView1.AutoGenerateColumns = false;

                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dataGridView1.Columns[0].ReadOnly = true;
                        dataGridView1.Columns[0].HeaderText = "CÓDIGO";
                        dataGridView1.Columns[0].Name = "ArtCod";
                        dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[1].ReadOnly = true;
                        dataGridView1.Columns[1].HeaderText = "NOMBRE";
                        dataGridView1.Columns[1].Name = "ArtDes";
                        dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dataGridView1.Columns[2].ReadOnly = true;
                        dataGridView1.Columns[2].HeaderText = "TIPO";
                        dataGridView1.Columns[2].Name = "Tipo1";
                        dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;                        
                        dataGridView1.Columns[3].ReadOnly = true;
                        dataGridView1.Columns[3].HeaderText = "ALIMENTAC.";
                        dataGridView1.Columns[3].Name = "Tipo2";
                        dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;                        
                        dataGridView1.Columns[4].ReadOnly = true;
                        dataGridView1.Columns[4].HeaderText = "ETIQ.OBLIG.";
                        dataGridView1.Columns[4].Name = "EtiqOblig";
                        dataGridView1.Columns[5].Visible = false;
                        dataGridView1.Columns[6].Visible = false;
                        dataGridView1.Columns[7].Visible = false;

                        for (int x = 0; x < dataGridView1.Rows.Count; x++)
                        {
                            if (dataGridView1.Rows[x].Cells[3].Value != null)
                            {
                                //if (dataGridView1.Rows[x].Cells[2].Value.ToString().Trim() == "F")
                                //{
                                //    dataGridView1.Rows[x].Cells[2].Value = "Fresco";
                                //}
                                //else if (dataGridView1.Rows[x].Cells[2].Value.ToString().Trim() == "C")
                                //{
                                //    dataGridView1.Rows[x].Cells[2].Value = "Congelado";
                                //}//if (dataGridView1.Rows[x].Cells[2].Value.ToString().Trim() == "F")

                                if (dataGridView1.Rows[x].Cells[3].Value.ToString().Trim() == "W")
                                {
                                    dataGridView1.Rows[x].Cells[3].Value = "SALVAJE";
                                }

                                if (dataGridView1.Rows[x].Cells[3].Value.ToString().Trim() == "C")
                                {
                                    dataGridView1.Rows[x].Cells[3].Value = "CRIANZA";
                                } //if (dataGridView1.Rows[x].Cells[3].Value.ToString().Trim() == "W")                           

                            }  //if (dataGridView1.Rows[x].Cells[2].Value != null)

                            if (dataGridView1.Rows[x].Cells[4].Value != null)
                            {
                                if (dataGridView1.Rows[x].Cells[4].Value.ToString().Trim() == "True")
                                {
                                    dataGridView1.Rows[x].Cells[4].Value = "SI";
                                }
                                else //if (dataGridView1.Rows[x].Cells[4].Value.ToString().Trim() == "C")
                                {
                                    dataGridView1.Rows[x].Cells[4].Value = "NO";
                                } //if (dataGridView1.Rows[x].Cells[4].Value.ToString().Trim() == "W")
                            }                            

                        }  //for (int x = 0; x < dataGridView1.Rows.Count; x++)
                    }   //if (dataGridView1.Rows.Count > 0)
                }
                catch (Exception ex)
                {
                    Mostrar(ex.ToString());

                }
            }  //if (CnO != null)
        }  //Cargar()

        private void frmMttoARTICULOS_Load(object sender, EventArgs e)
        {
            GloblaVar.gUTIL.CartelTraza("ENTRADA a " + this.GetType().FullName);

            label_ID.ForeColor = panel_Datos.BackColor;
            mensajes = frmPpal.mensajes;

            comboBox_Tipo1.Items.Add("");
            comboBox_Tipo1.Items.Add("C1"); //Congelado 1
            comboBox_Tipo1.Items.Add("C2"); //Congelado 2
            comboBox_Tipo1.Items.Add("C3"); //Congelado 3
            comboBox_Tipo1.Items.Add("F1"); //Fresco 1
            comboBox_Tipo1.Items.Add("F2"); //Fresco 2
            comboBox_Tipo1.Items.Add("F3"); //Fresco 3

            comboBox_Tipo2.Items.Add("");
            comboBox_Tipo2.Items.Add("CRIANZA");
            comboBox_Tipo2.Items.Add("SALVAJE");
            
            Cargar();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                label_ID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox_ArtCod.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox_ArtDes.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();               
                comboBox_Tipo1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();                 

                if(dataGridView1.Rows[e.RowIndex].Cells[3].Value != null)
                {
                    comboBox_Tipo2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                    //if(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString().Trim() == "W")
                    //{
                    //    comboBox_Tipo2.Text = "SALVAJE";
                    //}

                    //if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString().Trim() == "C")                    
                    //{
                    //    comboBox_Tipo2.Text = "CRIANZA";
                    //}
                }

                if(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()=="SI")
                {
                    ckbEtiquetaObligatoria.Checked = true;
                }
                else
                {
                    ckbEtiquetaObligatoria.Checked = false;
                }
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
                //GloblaVar.gUTIL.ATraza(ex.ToString());
            }

            return res;
        }     

        private void button_Aceptar_Click(object sender, EventArgs e)
        {
            string Tipo1 = "";
            string Tipo2 = "";
            //insert o update
            if (textBox_ArtCod.Text != "")
            {

                //El Tipo2 será invariable bien sea UPDATE o INSERT ya que tiene una situación de defecto
                Tipo2 = comboBox_Tipo2.Text;
                switch (Tipo2)
                {
                    //case "":
                    //    Tipo2 = "C";
                    //    break;
                    case "CRIANZA":
                        Tipo2 = "C";
                        break;
                    case "SALVAJE":
                        Tipo2 = "W";
                        break;
                } //switch (Tipo2 )
                
                if (textBox_ArtDes.Text != "")
                {                      
                    if (label_ID.Text == "")
                    {
                        //insert                       
                        string insert = "";


                        if (comboBox_Tipo1.Text != "")
                        {
                            //if (comboBox_Tipo1.Text=="Congelado")
                            //{
                            //    tipo1 = "C";
                            //}
                            //else if (comboBox_Tipo1.Text=="Fresco")
                            //{
                            //    tipo1 = "F";
                            //}

                            Tipo1 = comboBox_Tipo1.Text;
                            
                            //insert = "INSERT INTO ARTICULOS (ArtCod, ArtDes, Tipo1, Tipo2, EtiqOblig) ";
                            //insert += " VALUES(" + textBox_ArtCod.Text + ", '" + textBox_ArtDes.Text + "', '" + Tipo1  +"', '" + Tipo2  + "', '" + ckbEtiquetaObligatoria.Checked.ToString() + "')";
                        }
                        //else
                        //{
                        //    insert = "INSERT INTO ARTICULOS (ArtCod, ArtDes, Tipo2, EtiqOblig) ";
                        //    insert += " VALUES(" + textBox_ArtCod.Text + ", '" + textBox_ArtDes.Text + "', '" + Tipo2 + "', '" + ckbEtiquetaObligatoria.Checked.ToString() + "')";
                        //}

                        insert = "INSERT INTO ARTICULOS (ArtCod, ArtDes, Tipo1, Tipo2, EtiqOblig)";
                        insert += " VALUES(" + textBox_ArtCod.Text + ", '" + textBox_ArtDes.Text + "', '" + Tipo1 + "', '" + Tipo2 + "', '" + ckbEtiquetaObligatoria.Checked.ToString() + "')";

                        int res1 = EjecutaNonQuery(insert);

                        if (res1 == 1)
                        {
                            MessageBox.Show("Artículo " + textBox_ArtCod.Text + "-" + textBox_ArtDes.Text + " insertado");
                            GloblaVar.gUTIL.ATraza("Artículo " + textBox_ArtCod.Text + "-" + textBox_ArtDes.Text + " insertado");       
                            Cargar();
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show("Artículo " + textBox_ArtCod.Text + "-" + textBox_ArtDes.Text + " NO PUEDE SER insertado");
                            GloblaVar.gUTIL.ATraza(insert);
                            GloblaVar.gUTIL.ATraza("Artículo " + textBox_ArtCod.Text + "-" + textBox_ArtDes.Text + " NO PUEDE SER insertado");
                        }                       
                    }
                    else
                    {
                        //update
                        string update = "";
                           
                        //no se cambia el ArtCod
                        if (comboBox_Tipo1.Text != "")
                        {
                            //if (comboBox_Tipo1.Text == "Congelado")
                            //{
                            //    tipo1 = "C";
                            //}
                            //else if (comboBox_Tipo1.Text == "Fresco")
                            //{
                            //    tipo1 = "F";
                            //}

                            Tipo1 = comboBox_Tipo1.Text;

                            //update = "UPDATE ARTICULOS SET ArtDes ='" + textBox_ArtDes.Text +"'";
                            //update += ", Tipo1='" + Tipo1 + "'";
                            //update += ", Tipo2='" + Tipo2 + "'";
                            //update += ", EtiqOblig='" + ckbEtiquetaObligatoria.Checked.ToString() + "'";
                            //update += " WHERE";
                            //update += " ArtCod=" + label_ID.Text;
                        }
                        //else
                        //{
                        //    update = "UPDATE ARTICULOS SET ArtDes ='" + textBox_ArtDes.Text + "'";
                        //    update += ", Tipo1=null ";
                        //    update += ", Tipo2='" +Tipo2 +"'";
                        //    update += ", EtiqOblig='" + ckbEtiquetaObligatoria.Checked.ToString() + "'";
                        //    update += " WHERE";
                        //    update += " ArtCod=" + label_ID.Text;
                        //}

                        update = "UPDATE ARTICULOS SET ArtDes ='" + textBox_ArtDes.Text + "'";
                        update += ", Tipo1='" + Tipo1 + "'";
                        update += ", Tipo2='" + Tipo2 + "'";
                        update += ", EtiqOblig='" + ckbEtiquetaObligatoria.Checked.ToString() + "'";
                        update += " WHERE";
                        update += " ArtCod=" + label_ID.Text;

                        int res = EjecutaNonQuery(update);

                        if (res == 1)
                        {
                            MessageBox.Show("Articulo " + textBox_ArtCod.Text + "-" + textBox_ArtDes.Text + " ACTUALIZADO");
                            GloblaVar.gUTIL.ATraza("Articulo " + textBox_ArtCod.Text + "-" + textBox_ArtDes.Text + " ACTUALIZADO");   
                            Cargar();
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show("Articulo " + textBox_ArtCod.Text + "-" + textBox_ArtDes.Text + " NO PUDO ACTUALIZADO");
                            GloblaVar.gUTIL.ATraza(update);
                            GloblaVar.gUTIL.ATraza("Articulo " + textBox_ArtCod.Text + "-" + textBox_ArtDes.Text + " NO PUDO ACTUALIZADO");
                        }
                    }
                       
                   
                }
                else
                {
                    MessageBox.Show("Falta nombre del artículo");
                    GloblaVar.gUTIL.ATraza("Falta Nombre del Artículo");
                }
            }
            else
            {
                MessageBox.Show("Falta código del artículo");
                GloblaVar.gUTIL.ATraza("Falta código del Artículo");
            }            

        }

        private void Limpiar()
        {
            label_ID.Text = "";
            textBox_ArtCod.Text = "";
            textBox_ArtDes.Text = "";
            //comboBox_Tipo1.Text = "";
            comboBox_Tipo1.SelectedItem = null;
            comboBox_Tipo2.SelectedItem = null;
            ckbEtiquetaObligatoria.Checked = false;
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            //borrar datos
            Limpiar();
        }

        private void btnSALIR_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza("-----------------SALIENDO DE " + this.GetType().FullName);
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }  //private void btnSALIR_Click(object sender, EventArgs e)
      
    }
        
}
