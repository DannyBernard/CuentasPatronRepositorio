using CuentasDetalleRepositirio.BLL;
using CuentasDetalleRepositirio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuentasDetalleRepositirio.UI
{
    public partial class RCuentas : Form
    {
        private RepositorioBase<Cuentas> repositorio;
        public RCuentas()
        {
            InitializeComponent();
        }

        public void Limpiar()
        {
            CuentaIdnumericUpDown.Value = 0;
            DescripsiontextBox.Text = string.Empty;
            MontonumericUpDown.Value = 0;
        }


        public Cuentas Llenaclase()
        {
            Cuentas cuentas = new Cuentas();
            cuentas.CuentasId = Convert.ToInt32(CuentaIdnumericUpDown.Value);
            cuentas.Descripcion = DescripsiontextBox.Text;
            cuentas.Monto = Convert.ToDouble(MontonumericUpDown.Value);

            return cuentas;
        }

        public void LlenarCampo(Cuentas cuentas)
        {
            CuentaIdnumericUpDown.Value = cuentas.CuentasId;
            DescripsiontextBox.Text = cuentas.Descripcion;
            MontonumericUpDown.Value = Convert.ToDecimal(cuentas.Monto);
        }

        private bool ExiteEnLaDb()
        {
            repositorio = new RepositorioBase<Cuentas>();
            Cuentas cuentas = repositorio.Buscar((int)CuentaIdnumericUpDown.Value);
            return (cuentas != null);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }


        public bool GValidar()
        {
            bool paso = true;
            if (string.IsNullOrWhiteSpace(DescripsiontextBox.Text))
            {
                errorProvider1.SetError(DescripsiontextBox, "Campo vacio");
                paso = false;
            }
            if (MontonumericUpDown.Value == 0)
            {
                errorProvider1.SetError(MontonumericUpDown, "Valor en 0");
                paso = false;
            }
            return paso;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            repositorio = new RepositorioBase<Cuentas>();
            Cuentas cuentas;
            bool paso = false;

            cuentas = Llenaclase();
            if (!GValidar())
                return;
            if (CuentaIdnumericUpDown.Value >= 0)
                paso = repositorio.Guardar(cuentas);
            else
            {
                if (!ExiteEnLaDb())
                    MessageBox.Show("No Exite No es Modificable", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            paso = repositorio.Modificar(cuentas);

            if (paso)
            {
                MessageBox.Show("Guardado con Exito", "Guardo!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("No Guado ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id;
            repositorio = new RepositorioBase<Cuentas>();
            int.TryParse(CuentaIdnumericUpDown.Text, out id);
            if (!ExiteEnLaDb())
            {
                errorProvider1.SetError(CuentaIdnumericUpDown, "No Exite!!");
                CuentaIdnumericUpDown.Focus();
                return;
            }
            if (repositorio.Eliminar(id))
            {
                MessageBox.Show("Eliminado");
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se Elimino");
            }
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id;
            repositorio = new RepositorioBase<Cuentas>();
            Cuentas cuentas = new Cuentas();
            int.TryParse(CuentaIdnumericUpDown.Text, out id);
            cuentas = repositorio.Buscar(id);

            if (cuentas != null)
            {
                MessageBox.Show("Cuenta Encotrada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarCampo(cuentas);
            }
            else
                MessageBox.Show("no exite");
        }
    }
}
