using CuentasDetalleRepositirio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentasDetalleRepositirio.DAL
{
    class Contexto : DbContext
    {
        public DbSet<Cuentas>Cuenta { get; set; }
        public DbSet<Presupuesto> Presupuesto { get; set; }
        public DbSet<TiposDeCuentas> TiposDeCuenta { get; set; }

        public Contexto(): base("ConStr")
        {

        }
    }
}
