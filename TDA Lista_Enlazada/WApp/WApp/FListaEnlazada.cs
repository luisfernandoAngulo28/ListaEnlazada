using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CApp;

namespace WApp
{
    public partial class FListaEnlazada : Form
    {
        public FListaEnlazada()
        {
            InitializeComponent();
        }
       // clsLista Lista = new clsLista();
        clsLista L = new clsLista();

        private void button1_Click(object sender, EventArgs e)
        {
            int elemento = Convert.ToInt32(textBox1.Text);
            L = L.AddPrimero(elemento);
            label3.Text = L.View();
        }
    }
}
