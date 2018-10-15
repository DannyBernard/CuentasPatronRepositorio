using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentasDetalleRepositirio.Entidades
{
    class Presupuesto
    {
        [Key]
        public int PresupuestoId { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }

        public Presupuesto()
        {
            PresupuestoId = 0;
            Descripcion = string.Empty;
            Fecha = DateTime.Now;
            Monto = 0;
        }
    }
}
