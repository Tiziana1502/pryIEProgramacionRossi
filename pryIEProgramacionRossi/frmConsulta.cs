using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Agrego libreria para leer archivo
using System.IO;
using System.Windows.Forms;


namespace pryIEProgramacionRossi
{
    public partial class frmConsulta : Form
    {
        public frmConsulta()
        {
            InitializeComponent();
        }

        clsArchivo objRubro = new clsArchivo();

        private void frmConsulta_Load(object sender, EventArgs e)
        {
    
            clsArchivo AD = new clsArchivo();
            AD.CargarCombo(cmbRubro);
            btnExportar.Enabled = false;
            btnMostrar.Enabled = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(" Analista de Sistemas" +
                "\n Laboratorio de Programación " +
                "\n 1º Instancia Evaluativa " +
                "\n 47583152 – Rossi Tiziana", ("Informacion"), 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            objRubro.RecorrerGrilla(dgvDatos, cmbRubro.Text);
        }        

        private void btnExportar_Click(object sender, EventArgs e)
        {

        }

        private void cmbRubro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRubro.Text != "")
            {
                btnMostrar.Enabled = true;
                btnExportar.Enabled = true;
            }
            else
            {
                btnMostrar.Enabled = false;
                btnExportar.Enabled = false;
            }
        }

    }
}
