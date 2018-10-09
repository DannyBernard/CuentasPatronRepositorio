using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentasDetalleRepositirio.Entidades
{
    class TiposDeCuentas
    {
        [Key]
        public int TipoCuentas { get; set; }
        public string Desripcion { get; set; }

        public TiposDeCuentas()
        {
            TipoCuentas = 0;
            Desripcion = string.Empty;

        }
    }
}
