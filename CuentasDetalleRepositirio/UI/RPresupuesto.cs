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
    public partial class RPresupuesto : Form
    {
        RepositorioBase<Presupuesto> repositorio;
        public static int Pas = 0;
        public RPresupuesto()
        {
            InitializeComponent();
            if (Pas == 1)
                LlenarComboBox();

        }
        public void LlenarComboBox()
        {
            RepositorioBase<Presupuesto> repositrio = new RepositorioBase<Presupuesto>();
            TipocomboBox.DataSource = repositorio.GetList(x => true);
            TipocomboBox.ValueMember = "Descripcion";
        }

        public void limpiar()
        {
            IDnumericUpDown.Value = 0;
            DescrpciontextBox.Text = string.Empty;
            MontonumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;


        }

        private Presupuesto LlenaClase()
        {
            Presupuesto presupueso = new Presupuesto()
            {
                PresupuestoId = Convert.ToInt32(IDnumericUpDown.Value),
                Descripcion = DescrpciontextBox.Text,
                Monto = Convert.ToDouble(MontonumericUpDown.Value),
                Fecha = FechadateTimePicker.Value



            };
            return presupueso;
        }

        private void LlenaCampo(Presupuesto presupuesto)
        {
            IDnumericUpDown.Value = presupuesto.PresupuestoId;
            DescrpciontextBox.Text = presupuesto.Descripcion;
            MontonumericUpDown.Value =Convert.ToDecimal( presupuesto.Monto);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private bool Validar()
        {
            bool paso = true;
            if (string.IsNullOrWhiteSpace(DescrpciontextBox.Text))
            {
                errorProvider1.SetError(DescrpciontextBox, "Campo Vacio");
                paso = false;
            }
            if (MontonumericUpDown.Value == 0)
            {
                errorProvider1.SetError(MontonumericUpDown, "El valor tiene que mayor a cero");
                paso = false;

            }
            return paso;
        }

        private bool ExiteEnLaDb()
        {
            repositorio =new RepositorioBase<Presupuesto>();
            Presupuesto presupuesto = repositorio.Buscar((int)IDnumericUpDown.Value);
            return (presupuesto != null);

        }
        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            repositorio = new RepositorioBase<Presupuesto>();
            Presupuesto presupuesto;
            bool paso = false;

            presupuesto = LlenaClase();
            if (!Validar())
                return;

            if (IDnumericUpDown.Value >= 0)
                paso = repositorio.Guardar(presupuesto);
            else
            {
                if (!ExiteEnLaDb())
                {
                    MessageBox.Show("No se puede mosificar no Exite!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                paso = repositorio.Modificar(presupuesto);
            }
            if (paso)
            {
                MessageBox.Show("Guadado Exitosamente!!", "Guardo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiar();
            }
            else
            {
                MessageBox.Show("No Se Pudo Guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id;
            repositorio = new RepositorioBase<Presupuesto>();
            int.TryParse(IDnumericUpDown.Text, out id);
            if (!ExiteEnLaDb())
            {
                errorProvider1.SetError(IDnumericUpDown, "No Exite");
                IDnumericUpDown.Focus();
                return;
            }
            if (repositorio.Eliminar(id))
                MessageBox.Show("Eliminada Con Exito");
            else
            {
                MessageBox.Show("No se Elimino");
            }

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id;
            repositorio = new RepositorioBase<Presupuesto>();
            Presupuesto presupuesto = new Presupuesto();
            int.TryParse(IDnumericUpDown.Text, out id);
            presupuesto = repositorio.Buscar(id);
            if (presupuesto != null)
            {
                LlenaCampo(presupuesto);
                MessageBox.Show("Encotrada");
            }
            else
            {
                MessageBox.Show("No se Encotro");
            }
        }
    }
    }

