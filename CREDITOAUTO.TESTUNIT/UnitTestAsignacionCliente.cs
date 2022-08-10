using CREDITOAUTO.TEST;

namespace CREDITOAUTO.TESTUNIT
{
    public class UnitTestAsignacionCliente
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
    }
}