﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentasDetalleRepositirio.Entidades
{
   public class Cuentas
    {
        [Key]
        public int CuentasId { get; set; }
        public string Descripcion { get; set; }
        public double Monto { get; set; }

        public Cuentas()
        {
            CuentasId = 0;
            Descripcion = string.Empty;
            Monto = 0;

        }
    }
}
