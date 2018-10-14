using CuentasDetalleRepositirio.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuentasDetalleRepositirio
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void registroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RCuentas rCuentas = new RCuentas();
            rCuentas.Show();
            rCuentas.MdiParent = this;
        }
    }
}
