using System.IO;

namespace CounterLogic
{
    public class TextFileHandler : ICounterSaver
    {
        private readonly string textPath;

        public TextFileHandler(string textPath)
        {
            this.textPath = textPath;
        }

        public int ReadCounter()
        {
            int counter;
            if (!File.Exists(textPath))
            {
                counter = 0;
                WriteCounter(counter);
                return counter;
            }

            using StreamReader reader = new(textPath);
            string content = reader.ReadToEnd();
            return int.TryParse(content, out counter) ? counter : 0;
        }

        public void WriteCounter(int counter)
        {
            using StreamWriter writer = new(textPath, false);
            writer.Write(counter);
        }
    }
}
