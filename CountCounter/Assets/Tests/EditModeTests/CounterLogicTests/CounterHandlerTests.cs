using CounterLogic;
using NUnit.Framework;

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
            long oldCounter = counterHandler.Counter;
            counterHandler.IncrementCounter();
            long newCounter = counterHandler.Counter;
            Assert.That(newCounter, Is.EqualTo(oldCounter + 1));
        }

        [Test]
        public void ResetCounter_ResetsCounter()
        {
            counterHandler.IncrementCounter();
            long oldCounter = counterHandler.Counter;
            counterHandler.ResetCounter();
            long newCounter = counterHandler.Counter;
            Assert.That(newCounter, Is.LessThan(oldCounter));
            Assert.That(newCounter, Is.EqualTo(0));
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
