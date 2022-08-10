using CREDITOAUTO.TEST;

namespace CREDITOAUTO.TESTUNIT
{
    public class UnitTestCargacsv
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CargarCliente()
        {
            var archivo = @"C:\DEV_NET\CREDITOAUTO.API\CREDITOAUTO.API\Files\CrediticioCliente.csv";
            Cliente cli = new Cliente();
            var result = cli.CargarCliente(archivo);
            Assert.IsTrue(result);
        }

        [Test]
        public void CargarMarca()
        {
            var archivo = @"C:\DEV_NET\CREDITOAUTO.API\CREDITOAUTO.API\Files\CrediticioMarcaVehiculo.csv";
            MarcaVehiculo mar = new MarcaVehiculo();
            var result = mar.CargarMarca(archivo);
            Assert.IsTrue(result);
        }

        [Test]
        public void CargarEjecutivo()
        {
            var archivo = @"C:\DEV_NET\CREDITOAUTO.API\CREDITOAUTO.API\Files\CrediticioEjecutivo.csv";
            Ejecutivo eje = new Ejecutivo();
            var result = eje.CargarEjecutivo(archivo);
            Assert.IsTrue(result);
        }
    }
}