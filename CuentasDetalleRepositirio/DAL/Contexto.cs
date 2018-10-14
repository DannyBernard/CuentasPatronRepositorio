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
        public DbSet<Cuentas>Cuentas { get; set; }
        public DbSet<Presupuesto> Presupuesto { get; set; }
        public DbSet<TiposDeCuentas> TiposDeCuentas { get; set; }

        public Contexto(): base("ConStr")
        {

        }
    }
}