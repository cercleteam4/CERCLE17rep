using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace cercle17
{
    public partial class frmCONSULTA : Form
    {
        public frmCONSULTA()
        {
            InitializeComponent();
        }

        //SqlConnection connBase = new SqlConnection()=GloblaVar.gConRem  ;
        
        

        private void frmCONSULTA_Load(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.CartelTraza("ENTRADA EN frmCONSULTA de " + GloblaVar.TIPO_CONSULTA);
            switch (GloblaVar.TIPO_CONSULTA)
            {
                case "DETALLISTAS":
                    label2.Text = "Nombre Detallista";
                    label1.Text = "Código Detallista";
                    Recarga("");
                   
                    break;
                case "ARTICULOS":
                    label2.Text = "Nombre Artículo";
                    label1.Text = "Código Artículo";
                    Recarga("");

                    break;

                case "VENDEDORES":
                    label2.Text = "Nombre Vendedor";
                    label1.Text = "Código Vendedor";
                    Recarga("");

                    break;

                case "PROVEEDORES":
                    label2.Text = "Nombre Provedor";
                    label1.Text = "Código Proveedor";
                    Recarga("");

                    break;
            }   //switch (GloblaVar.TIPO_CONSULTA)
            textBox_Nombre.Focus();
        }   //private void frmCONSULTA_Load(object sender, EventArgs e)

        private void Recarga(string Filtro)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            switch (GloblaVar.TIPO_CONSULTA)
            {
                case "DETALLISTAS":
                    try
                    {
                        string strQ = "SELECT DetCod as Código,DetNom AS DETALLISTA FROM DETALLISTAS";
                        if (Filtro != "") { strQ += Filtro; }
                        DataTable dt = new DataTable();
                        SqlCommand cmd = new SqlCommand(strQ, GloblaVar.gcnO);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error de carga " + ex);
                    }
                    break;
                case "ARTICULOS":
                    try
                    {
                        string strQ = "SELECT ArtCod as Código,Artdes as ARTÍCULO FROM ARTICULOS";
                        if (Filtro != "") { strQ += Filtro; }
                        DataTable dt = new DataTable();
                        SqlCommand cmd = new SqlCommand(strQ, GloblaVar.gcnO);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error de carga " + ex);
                    }
                   
                    break;
                case "VENDEDORES":
                    try
                    {
                        string strQ = "SELECT IdVendedor as Código,Vendedor FROM VENDEDORES";
                        if (Filtro != "") { strQ += Filtro; }
                        DataTable dt = new DataTable();
                        SqlCommand cmd = new SqlCommand(strQ, GloblaVar.gcnO);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error de carga " + ex);
                    }
                    break;
                case "PROVEEDORES":
                    try
                    {
                        string strQ = "SELECT ProCod as Código, ProNom as PROVEEDOR FROM PROVEEDORES";
                        if (Filtro != "") { strQ += Filtro; }
                        DataTable dt = new DataTable();
                        SqlCommand cmd = new SqlCommand(strQ, GloblaVar.gcnO);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error de carga " + ex);
                    }
                    break;
            }   //switch (GloblaVar.TIPO_CONSULTA)
        } //Recarga

        private void textBox_Nombre_TextChanged(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            string Filtro;
            switch (GloblaVar.TIPO_CONSULTA)
            {
                case "DETALLISTAS":
                    Filtro = " WHERE DetNom LIKE '%" + textBox_Nombre.Text + "%'";
                    Recarga(Filtro);
                    break;
                case "ARTICULOS":
                    Filtro = " WHERE ArtDes LIKE '%" + textBox_Nombre.Text + "%'";
                    Recarga(Filtro);
                    break;
                case "VENDEDORES":
                    Filtro = " WHERE Vendedor LIKE '%" + textBox_Nombre.Text + "%'";
                    Recarga(Filtro);
                    break;
                case "PROVEEDORES":
                    Filtro = " WHERE ProNom LIKE '%" + textBox_Nombre.Text + "%'";
                    Recarga(Filtro);
                    break;

            }   //switch (GloblaVar.TIPO_CONSULTA)
        }   //  private void textBox_Nombre_TextChanged(object sender, EventArgs e)


        private void textBox_Codigo_TextChanged_1(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            string Filtro;
            switch (GloblaVar.TIPO_CONSULTA)
            {
                case "DETALLISTAS":
                    Filtro = " WHERE DetCod=" + textBox_Codigo.Text + "";
                    Recarga(Filtro);
                    break;
                case "ARTICULOS":
                    Filtro = " WHERE ArtCod=" + textBox_Codigo.Text + "";
                    Recarga(Filtro);
                    break;
                case "VENDEDORES":
                    Filtro = " WHERE IdVendedor=" + textBox_Codigo.Text + "";
                    Recarga(Filtro);
                    break;
                case "PROVEEDORES":
                    Filtro = " WHERE ProCod=" + textBox_Codigo.Text + "";
                    Recarga(Filtro);
                    break;
            }   //switch (GloblaVar.TIPO_CONSULTA)

        }

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //}

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            //textBox_Codigo.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //textBox_Nombre.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            GloblaVar.Cod_Buscado = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            GloblaVar.Nom_Buscado = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();

        }   //  private void textBox_Codigo_TextChanged(object sender, EventArgs e)
    }   //public partial class frmCONSULTA : Form
}
