using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentasDetalleRepositirio.Entidades
{
   public class TiposDeCuentas
    {
        [Key]
        public int TipoCuentasID { get; set; }
        public string Desripcion { get; set; }

        public TiposDeCuentas()
        {
            TipoCuentasID = 0;
            Desripcion = string.Empty;

        }
    }
}
