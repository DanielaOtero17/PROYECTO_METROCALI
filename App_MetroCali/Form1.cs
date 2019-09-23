using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_MetroCali
{
    public partial class Form1 : Form
    {

        public List<Stops> Paradas = new List<Stops>();
        public  List<Stops> ParadasEstaciones = new List<Stops>();
        List<Stops> ParadasCalle = new List<Stops>();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void separarListasDeParadas()
        {
            for(int i = 0; i< Paradas.Count; i++)
            {

            }
        }

        public List<Stops> retornarLista()
        {

            return Paradas;
        }
    }
}
