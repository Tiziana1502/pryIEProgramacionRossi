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
            if (cmbRubro.SelectedIndex != -1 ) //Valido que un rubro haya sido seleccioando
            {
                string RubroSel = cmbRubro.Text;
                objRubro.NombreArc = "ARTICULOS.csv"; //Instancio el archivo para utilizarlo
                objRubro.RecorrerGrilla(dgvDatos, RubroSel);
                objRubro.CantArticulos(lblCantidad, RubroSel);
                objRubro.TotalGeneral(lblTotal, RubroSel);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un rubro", "Seleccione Rubro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }        
        }        

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (cmbRubro.SelectedIndex != -1)
            {
                objRubro.NombreArc = "ARTICULOS.csv";
                objRubro.ExportarDatos(cmbRubro.Text);
                MessageBox.Show("Reporte generado con éxito", "Exportado con Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un rubro", "Seleccione Rubro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
