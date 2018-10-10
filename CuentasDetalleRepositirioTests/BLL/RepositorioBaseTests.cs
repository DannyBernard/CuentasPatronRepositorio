using Microsoft.VisualStudio.TestTools.UnitTesting;
using CuentasDetalleRepositirio.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuentasDetalleRepositirio.Entidades;

namespace CuentasDetalleRepositirio.BLL.Tests
{
    [TestClass()]
    public class RepositorioBaseTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            
            Cuentas cuentas = new Cuentas();
            cuentas.CuentasId = 5;
            cuentas.Descripcion = "Ahorro";
            cuentas.TipoId = 5;
            RepositorioBase<Cuentas> repositorio;
            repositorio = new RepositorioBase<Cuentas>();
            Assert.IsTrue(repositorio.Guardar(cuentas));
        }
    }
}