using CounterLogic;
using NUnit.Framework;
using System.Numerics;

namespace CounterLogicTests
{
    public class CounterHandlerTests
    {
        private CounterHandler counterHandler;

        [SetUp]
        public void SetUp()
        {
            counterHandler = new CounterHandler(new CounterSaverTestClass());
        }

        [Test]
        public void IncrementCounter_IncrementsCounter()
        {
            BigInteger oldCounter = counterHandler.Counter;
            counterHandler.IncrementCounter();
            BigInteger newCounter = counterHandler.Counter;
            Assert.That(newCounter, Is.EqualTo(oldCounter + 1));
        }

        [Test]
        public void ResetCounter_ResetsCounter()
        {
            counterHandler.IncrementCounter();
            BigInteger oldCounter = counterHandler.Counter;
            counterHandler.ResetCounter();
            BigInteger newCounter = counterHandler.Counter;
            Assert.That(newCounter, Is.LessThan(oldCounter));
            Assert.That(newCounter, Is.EqualTo(BigInteger.Zero));
        }

        // NOTE: This test is very dependent on what CounterSaver class is used.
        [Test]
        public void SaveCounter_GivenValidCounter_DoesNotThrowAnException()
        {
            counterHandler.IncrementCounter();
            Assert.DoesNotThrow(() => counterHandler.SaveCounter());
        }
    }
}
