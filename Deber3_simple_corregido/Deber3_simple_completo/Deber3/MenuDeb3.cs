using System;
using System.Drawing;
using System.Windows.Forms;

namespace Deber3
{
    public partial class MenuDeb3 : Form
    {
        public MenuDeb3()
        {
            InitializeComponent();
            ClientSize = new Size(1100, 660);
            WindowState = FormWindowState.Maximized;

        }

        void Abrir(Form formulario)
        {
            formulario.MdiParent = this;
            formulario.WindowState = FormWindowState.Maximized;
            formulario.Show();
        }

        private void hexagonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir(new Hexagonofrm());
        }

        private void margaritaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir(new MargaritaFrm());
        }

        private void poligonosestrelladosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir(new Poli_estrelladoFrm());
        }

        private void pruebasToolStripMenuItem_Click(object sender, EventArgs e)
        {
}

        private void MenuDeb3_Load(object sender, EventArgs e)
        {

        }
    }
}
