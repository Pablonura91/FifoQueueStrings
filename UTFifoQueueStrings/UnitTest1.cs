using FifoQueueStrings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UTFifoQueueStrings
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AnadirUnNuevoValorEnqueue()
        {
            // Preparación
            // prueba
            var resultado = QueueStrings.Count();

            // Verificación
            Assert.AreEqual(resultado, 7);
        }

        [TestMethod]
        public void ExtraerUnValorDequeue()
        {
            // Preparación
            // prueba
            var resultado = QueueStrings.Dequeue();

            // Verificación
            Assert.AreEqual(resultado, "8");
        }
    }
}
