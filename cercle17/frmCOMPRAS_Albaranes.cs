using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cercle17
{
    public partial class frmCOMPRAS_Albaranes : Form
    {
        private string _comCpa;
        private string _anyo;

        public frmCOMPRAS_Albaranes()
        {
            InitializeComponent();
        }

        public string NumAlbaran 
        {
            get { return _comCpa; }
        }

        public string AnyoAlbaran
        {
            get { return _anyo; }
        }

        private void frmALBARANES_COMPRAS_Load(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = Convert.ToDateTime ("01/01/" + DateTime.Now.Year);

            dgvAlbaranes.AutoGenerateColumns = false;
            dgvAlbaranes.DataSource = Funciones.LlenarDataTable(string.Format("SELECT Al.ComCpa, Al.Anyo, Al.ComCfa, Pr.ProNom, (SELECT sum(ComLim) FROM COMALB_LINEAS WHERE ComLpa=Al.ComCpa and Anyo=Al.Anyo) as Total FROM COMALB_CABE Al LEFT JOIN PROVEEDORES Pr on Al.ProCod=Pr.ProCod WHERE  Convert(date, Al.ComCfa, 103)>='{0}' and  Convert(date, Al.ComCfa, 103)<='{1}' ORDER BY Al.ComCpa desc, Al.Anyo desc", dtpFechaInicio.Value.ToString("dd/MM/yyyy"), dtpFechaFin.Value.ToString("dd/MM/yyyy")));


            dgvAlbaranes.Columns["ComCpa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvAlbaranes.Columns["Anyo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvAlbaranes.Columns["ComCfa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvAlbaranes.Columns["ComCfa"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvAlbaranes.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvAlbaranes.Columns["Total"].DefaultCellStyle.Format = "0.00";

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(tbProCod.Text=="")
            {
                dgvAlbaranes.DataSource = Funciones.LlenarDataTable(string.Format("SELECT Al.ComCpa, Al.Anyo, Al.ComCfa, Pr.ProNom, (SELECT sum(ComLim) FROM COMALB_LINEAS WHERE ComLpa=Al.ComCpa and Anyo=Al.Anyo) as Total FROM COMALB_CABE Al LEFT JOIN PROVEEDORES Pr on Al.ProCod=Pr.ProCod WHERE  Convert(date, Al.ComCfa, 103)>='{0}' and  Convert(date, Al.ComCfa, 103)<='{1}' ORDER BY Al.ComCpa desc, Al.Anyo desc", dtpFechaInicio.Value.ToString("dd/MM/yyyy"), dtpFechaFin.Value.ToString("dd/MM/yyyy")));
            }
            else
            {
                dgvAlbaranes.DataSource = Funciones.LlenarDataTable(string.Format("SELECT Al.ComCpa, Al.Anyo, Al.ComCfa, Pr.ProNom, (SELECT sum(ComLim) FROM COMALB_LINEAS WHERE ComLpa=Al.ComCpa and Anyo=Al.Anyo) as Total FROM COMALB_CABE Al LEFT JOIN PROVEEDORES Pr on Al.ProCod=Pr.ProCod WHERE Convert(date, Al.ComCfa, 103)>='{0}' and  Convert(date, Al.ComCfa, 103)<='{1}' and Al.ProCod={2} ORDER BY Al.ComCpa desc, Al.Anyo desc", dtpFechaInicio.Value.ToString("dd/MM/yyyy"), dtpFechaFin.Value.ToString("dd/MM/yyyy"), tbProCod.Text));
            }            
        }
        
        //Al cancelar carga el grid sin filtros
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dgvAlbaranes.DataSource = Funciones.LlenarDataTable("SELECT Al.ComCpa, Al.Anyo, Al.ComCfa, Pr.ProNom, (SELECT sum(ComLim) FROM COMALB_LINEAS WHERE ComLpa=Al.ComCpa and Anyo=Al.Anyo) as Total FROM COMALB_CABE Al LEFT JOIN PROVEEDORES Pr on Al.ProCod=Pr.ProCod ORDER BY Al.ComCpa desc, Al.Anyo desc");
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
            tbProCod.Text = string.Empty;
            tbProNom.Text = string.Empty;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }       

        private void dgvAlbaranes_DoubleClick(object sender, EventArgs e)
        {
            _comCpa = dgvAlbaranes.CurrentRow.Cells["ComCpa"].Value.ToString();
            _anyo = dgvAlbaranes.CurrentRow.Cells["Anyo"].Value.ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void tbProCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {

                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    tbProNom.Text = Funciones.DameNomPro(tbProCod.Text);                   
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }
        }

        private void btnProvBuscar_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {
                GloblaVar.TIPO_CONSULTA = "PROVEEDORES";

                frmCONSULTA frmC = new frmCONSULTA();

                if (frmC.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    tbProCod.Text = GloblaVar.Cod_Buscado;
                    tbProNom.Text = GloblaVar.Nom_Buscado;                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }
        }

        
        
    }
}
