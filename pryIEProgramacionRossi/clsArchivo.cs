using System;
using System.Collections.Generic;
using System.Drawing;
//Agrego libreria para leer archivo
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void RecorrerGrilla(DataGridView Grilla, string RubroSel)
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
                if (vecRubros[3] == RubroSel)
                {
                    decimal costo = Convert.ToDecimal(vecRubros[2]);
                    Int32 stock = Convert.ToInt32(vecRubros[4]);
                    decimal valorStock = costo * stock;

                    //Una vez que calculo la columna de valor en stock la agrego en grilla
                    Grilla.Rows.Add(vecRubros[0], vecRubros[1], vecRubros[2], vecRubros[4], valorStock);
                }
                DatoLeido = AD.ReadLine();
            }
            //Cierro
            AD.Close();
            AD.Dispose();
        }
        public void CantArticulos(Label lblCantidad, string RubroSel)
        {
            if (!File.Exists(NombreArc)) return;
            Int32 cont = 0;
            string DatoLeido = "";
            StreamReader AD = new StreamReader(NombArc);
            DatoLeido = AD.ReadLine();
            string[] vecRubros = new string[5];

            while (DatoLeido != null)
            {
                vecRubros = DatoLeido.Split(';');
                if (vecRubros[3] == RubroSel)
                {
                    cont++;
                }
                DatoLeido = AD.ReadLine();

            }
            lblCantidad.Text = cont.ToString();   

            //Cierro
            AD.Close();
            AD.Dispose();

        }

        public void TotalGeneral(Label lblTotal, string RubroSel)
        {
            if (!File.Exists(NombreArc)) return;
            decimal total = 0;  
            string DatoLeido = "";
            string[] vecRubros = new string[5];
            StreamReader AD = new StreamReader(NombArc);
            DatoLeido = AD.ReadLine();

            while (DatoLeido != null)
            {
                vecRubros = DatoLeido.Split(';');
                if (vecRubros[3] == RubroSel)
                {
                    total = Convert.ToDecimal(vecRubros[2]) * Convert.ToInt32(vecRubros[4]);
                }
                DatoLeido = AD.ReadLine();
            }
            lblTotal.Text = total.ToString();

            //Cierro
            AD.Close();
            AD.Dispose();
        }

      
        public void ExportarDatos(string RubroSel)
        {
                
            StreamWriter ArchiReporte = new StreamWriter("Reporte.csv", false, Encoding.UTF8);
            ArchiReporte.WriteLine("REPORTE DE ARTICULOS SEGUN RUBRO");
            ArchiReporte.WriteLine("\n");
            ArchiReporte.WriteLine("Código; Descripción; Costo; Stock; Valor en Stock");

            string DatoLeido = "";
            string[] vecRubros = new string[5];
            StreamReader AD = new StreamReader(NombArc);
            DatoLeido = AD.ReadLine();

            Int32 cont = 0;
            decimal total = 0;

            while (DatoLeido != null)
            {
                vecRubros = DatoLeido.Split(';');
                if (vecRubros[3] == RubroSel)
                {
                    decimal costo = Convert.ToDecimal(vecRubros[2]);
                    Int32 stock = Convert.ToInt32(vecRubros[4]);
                    decimal valorStock = costo * stock;                 

                    ArchiReporte.Write(vecRubros[0]); 
                    ArchiReporte.Write(";");
                    ArchiReporte.Write(vecRubros[1]);
                    ArchiReporte.Write(";");
                    ArchiReporte.Write(vecRubros[2]);
                    ArchiReporte.Write(";");
                    ArchiReporte.Write(vecRubros[4]);
                    ArchiReporte.Write(";");                   
                    ArchiReporte.WriteLine(valorStock);

                    cont++;
                    total += valorStock;
                }
                DatoLeido = AD.ReadLine();
            }
            
            //Cerrar
            AD.Close ();
            AD.Dispose ();

            ArchiReporte.WriteLine(";");
            ArchiReporte.Write("CANTIDAD DE ARTICULOS:;;");
            ArchiReporte.WriteLine(cont);
            ArchiReporte.Write("TOTAL DE STOCK:;;");
            ArchiReporte.WriteLine(total);

            //Cerrar
            ArchiReporte.Close();
            ArchiReporte.Dispose();
        }
         
    }
}
