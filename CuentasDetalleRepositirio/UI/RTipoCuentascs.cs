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
    public partial class RTipoCuentascs : Form
    {
        RepositorioBase<TiposDeCuentas> repositorio;
        public RTipoCuentascs()
        {
            InitializeComponent();
        }
        public void Limpiar()
        {
            TipoIDnumericUpDown.Value = 0;
            DescripciontextBox.Text = string.Empty;
        }

       public TiposDeCuentas LlenaClase()
        {
            TiposDeCuentas tiposDeCuentas = new TiposDeCuentas();
            tiposDeCuentas.TipoCuentasID = Convert.ToInt32(TipoIDnumericUpDown.Value);
           tiposDeCuentas.Desripcion= DescripciontextBox.Text;
            return tiposDeCuentas;
        }
        public void Llenacampo(TiposDeCuentas tiposDeCuentas)
        {
            TipoIDnumericUpDown.Value = tiposDeCuentas.TipoCuentasID;
            DescripciontextBox.Text = tiposDeCuentas.Desripcion;
        }

        private bool ExiteEnlaDB()
        {
            repositorio = new RepositorioBase<TiposDeCuentas>();
            TiposDeCuentas tiposDeCuentas = repositorio.Buscar((int)TipoIDnumericUpDown.Value);
            return (tiposDeCuentas != null);

        }

        public bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(DescripciontextBox.Text))
            
                errorProvider1.SetError(DescripciontextBox, "Expacio en blanco");
                paso = false;
           

            return paso;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

      

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id;
            repositorio = new RepositorioBase<TiposDeCuentas>();
            int.TryParse(TipoIDnumericUpDown.Text, out id);
            if (!ExiteEnlaDB())
            {
                errorProvider1.SetError(TipoIDnumericUpDown , "No exite");
                TipoIDnumericUpDown.Focus();
                return;
            }
            if (repositorio.Eliminar(id))
            {
                MessageBox.Show("Elimino con Exito!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("No exite", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id;
            repositorio = new RepositorioBase<TiposDeCuentas>();
            TiposDeCuentas tiposDeCuentas = new TiposDeCuentas();
            int.TryParse(TipoIDnumericUpDown.Text, out id);
            tiposDeCuentas= repositorio.Buscar(id);

            if(tiposDeCuentas!= null)
            {
                MessageBox.Show("Econtado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Llenacampo(tiposDeCuentas);
            }
            else
            {
                MessageBox.Show("No Exite!!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
             repositorio = new RepositorioBase<TiposDeCuentas>();
           
            TiposDeCuentas tiposDeCuentas;
            bool paso = false;
            tiposDeCuentas = LlenaClase();
            if (!Validar())
                return;

            if (TipoIDnumericUpDown.Value >= 0)
            {

                paso = repositorio.Guardar(tiposDeCuentas);

            }
            else
            {
                if (!ExiteEnlaDB())
                {
                    MessageBox.Show("no exite ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                paso = repositorio.Modificar(tiposDeCuentas);
            }
                if (paso)
                {
                    MessageBox.Show("Guardo Correctamente!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                    MessageBox.Show(" no Guardo !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            
        }
    }
}
