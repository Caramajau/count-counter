using System.IO;
using NUnit.Framework;
using UnityEngine;
using DataPersistence;

namespace DataPersistenceTests
{
    [TestFixture]
    public class FileDataHandlerTests
    {
        private string testDir;
        private string filePath;

        private FileDataHandler<TestData> handler;

        [SetUp]
        public void SetUp()
        {
            testDir = Path.Combine(Application.persistentDataPath, "UnitTestData");
            string testFileName = "testfile";
            filePath = Path.Combine(testDir, testFileName + ".json");

            handler = new FileDataHandler<TestData>(testDir, testFileName);
            
            Directory.CreateDirectory(testDir);
            
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        [Test]
        public void Save_GivenValidData_CreatesFileWithTheData()
        {
            TestData data = new() { IntValue = 1337, StringValue = "hello" };
            handler.Save(data);

            Assert.That(File.Exists(filePath), Is.True);

            string json = File.ReadAllText(filePath);
            TestData loadedData = JsonUtility.FromJson<TestData>(json);

            Assert.That(data.IntValue, Is.EqualTo(loadedData.IntValue));
            Assert.That(data.StringValue, Is.EqualTo(loadedData.StringValue));
        }

        [Test]
        public void Load_GivenValidData_ReturnsTheData()
        {
            TestData data = new() { IntValue = 99, StringValue = "world" };
            handler.Save(data);

            TestData loadedData = handler.Load();

            Assert.That(data.IntValue, Is.EqualTo(loadedData.IntValue));
            Assert.That(data.StringValue, Is.EqualTo(data.StringValue));
        }

        [Test]
        public void Load_GivenNoFile_ReturnsNull()
        {
            TestData loadedData = handler.Load();
            Assert.That(loadedData, Is.Null);
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            if (Directory.Exists(testDir))
            {
                Directory.Delete(testDir, true);
            }
        }
    }
}
