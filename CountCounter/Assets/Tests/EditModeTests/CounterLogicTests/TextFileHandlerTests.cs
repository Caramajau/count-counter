using CounterLogic;
using NUnit.Framework;
using System.IO;

namespace CounterLogicTests
{
    [TestFixture]
    public class TextFileHandlerTests
    {
        private string testFilePath;
        private TextFileHandler textFileHandler;

        [SetUp]
        public void SetUp()
        {
            testFilePath = Path.GetTempFileName();
            textFileHandler = new(testFilePath);
        }

        [Test]
        public void ReadCounter_GivenFileContainsValidInt_ReturnsInt()
        {
            File.WriteAllText(testFilePath, "1337");
            int result = textFileHandler.ReadCounter();

            Assert.That(result, Is.EqualTo(1337));
        }

        [Test]
        public void ReadCounter_GivenFileContainsInvalidInt_ReturnsZero()
        {
            File.WriteAllText(testFilePath, "notanumber");
            int result = textFileHandler.ReadCounter();

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void ReadCounter_GivenFileDoesNotExist_CreatesFileAndReturnsZero()
        {
            File.Delete(testFilePath);
            int result = textFileHandler.ReadCounter();

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void WriteCounter_WritesIntToFile()
        {
            textFileHandler.WriteCounter(123);
            string content = File.ReadAllText(testFilePath);

            Assert.That(content, Is.EqualTo("123"));
        }

        [Test]
        public void WriteCounter_GivenFileDoesNotExist_CreatesFileAndWritesInt()
        {
            File.Delete(testFilePath);
            textFileHandler.WriteCounter(456);
            string content = File.ReadAllText(testFilePath);

            Assert.That(content, Is.EqualTo("456"));
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }
    }
}
