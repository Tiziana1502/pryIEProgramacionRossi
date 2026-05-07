using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Agrego libreria para leer archivo
using System.IO;
using System.Windows.Forms;

//Creo una clase que me permita cargar el archivo de rubros y articulos para luego usarlo en el formulario

namespace pryIEProgramacionRossi
{
    internal class clsArchivo
    {
        public string NombreArc = "RUBROS.csv";
        public string NombArc = "ARTICULOS.csv";

        public void CargarCombo(ComboBox combo)
        {
            if (!File.Exists(NombreArc)) return;
            string DatoLeido = "";
            combo.Items.Clear();
            StreamReader AD = new StreamReader(NombreArc);
            DatoLeido = AD.ReadLine();
            while (DatoLeido != null)
            {
                combo.Items.Add(DatoLeido);
                DatoLeido = AD.ReadLine();
            }
            AD.Close();
        }

        //Procedimiento para mostrar los archivos segun rubro seleccionado
        public void RecorrerGrilla(DataGridView Grilla, string RubroSelect)
        {
            if (!File.Exists(NombreArc)) return;
            string DatoLeido = "";       
            string[] vecRubros = new string[5];

            StreamReader AD = new StreamReader(NombArc);
            DatoLeido = AD.ReadLine();
            Grilla.Rows.Clear();

            while (DatoLeido != null)
            {
                vecRubros = DatoLeido.Split(';');

                Grilla.Rows.Add(vecRubros[0], vecRubros[1], vecRubros[2], vecRubros[4]);
                DatoLeido = AD.ReadLine();
            }
            //Cierro
            AD.Close();
            AD.Dispose();
        }

        public void ExportarDatos()
        { 
        }
         
    }
}
