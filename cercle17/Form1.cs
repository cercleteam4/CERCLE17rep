using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Windows.Forms;

namespace cercle17
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// The backgroundworker object on which the time consuming operation shall be executed
        /// </summary>
        BackgroundWorker m_oWorker;

        public Form1()
        {
            InitializeComponent();
            m_oWorker = new BackgroundWorker();
            m_oWorker.DoWork += new DoWorkEventHandler(m_oWorker_DoWork);
            m_oWorker.ProgressChanged += new ProgressChangedEventHandler(m_oWorker_ProgressChanged);
            m_oWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(m_oWorker_RunWorkerCompleted);
            m_oWorker.WorkerReportsProgress = true;
            m_oWorker.WorkerSupportsCancellation = true;
        }

        /// <summary>
        /// On completed do the appropriate task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_oWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //If it was cancelled midway
            if (e.Cancelled)
            {
                lblStatus.Text = "Task Cancelled.";
            }
            else if (e.Error != null)
            {
                lblStatus.Text = "Error while performing background operation.";
            }
            else
            {
                lblStatus.Text = "Task Completed...";
            }
            btnStartAsyncOperation.Enabled = true;
            btnCancel.Enabled = false;
        }

        /// <summary>
        /// Notification is performed here to the progress bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_oWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Here you play with the main UI thread
            progressBar1.Value = e.ProgressPercentage;
            lblStatus.Text = "Processing......" + progressBar1.Value.ToString() + "%";
        }

        /// <summary>
        /// Time consuming operations go here </br>
        /// i.e. Database operations,Reporting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_oWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //NOTE : Never play with the UI thread here...

            //time consuming operation
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                m_oWorker.ReportProgress(i);

                //If cancel button was pressed while the execution is in progress
                //Change the state from cancellation ---> cancel'ed
                if (m_oWorker.CancellationPending)
                {
                    e.Cancel = true;
                    m_oWorker.ReportProgress(0);
                    return;
                }

            }
            
            //Report 100% completion on operation completed
            m_oWorker.ReportProgress(100);
        }

        private void btnStartAsyncOperation_Click(object sender, EventArgs e)
        {
            btnStartAsyncOperation.Enabled  = false;
            btnCancel.Enabled               = true;
            //Start the async operation here
            m_oWorker.RunWorkerAsync();

            string mensaje = "";

            //mensaje = Funciones.PreparaListado(dtpFechaDesde.Value, dtpFechaHasta.Value, GloblaVar.gConRem);

            if (mensaje == "")
            {
                string sql = "SELECT ArtCod as A, ArtDes as F, CuentaVentas as AF ";
                sql += "FROM ARTICULOS ";
                sql += "ORDER BY ArtCod asc";

                string path = obtenerPath();

                if (!string.IsNullOrEmpty(path))
                {
                    clase_excel excel = new clase_excel();

                    excel.CnO = GloblaVar.gConRem;
                    excel.Query = sql;
                    excel.Path = path;
                    excel.NombreFichero = "ART";

                    //lblExcel.Visible = true;

                    //timer1.Start();

                    mensaje = excel.exportarExcelArticulos(DateTime.Now.Date);

                    //lblExcel.Visible = false;

                    if (mensaje != "")
                    {
                        MessageBox.Show(mensaje);
                    }
                    else
                    {
                        MessageBox.Show("La exportación de " + excel.NombreFichero + " a excel se ha realizado correctamente");
                    }
                }
                else
                {
                    MessageBox.Show("La ubicación de los ficheros es obligatoria. Debe rellenar el campo 'ConPathExcell' de la tabla 'CONTROL");
                }

            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private string obtenerPath()
        {
            string path = "";

            using (SqlCommand cmd = new SqlCommand("SELECT ConPathExcell FROM CONTROL", GloblaVar.gConRem))
            {
                path = Convert.ToString(cmd.ExecuteScalar());
            }

            return path;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (m_oWorker.IsBusy)
            {
                //Stop/Cancel the async operation here
                m_oWorker.CancelAsync();
            }
        }
    }
}
