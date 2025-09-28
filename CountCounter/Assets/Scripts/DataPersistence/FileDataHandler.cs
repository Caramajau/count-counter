using System;
using System.IO;
using UnityEngine;

namespace DataPersistence
{
    public class FileDataHandler<T>
    {
        private readonly string dataDirPath;
        private readonly string dataFileName;

        public FileDataHandler(string dataDirPath, string dataFileName)
        {
            this.dataDirPath = dataDirPath;
            this.dataFileName = dataFileName + ".json";
        }

        public T Load()
        {
            string fullPath = Path.Combine(dataDirPath, dataFileName);

            T loadedData = default;
            if (File.Exists(fullPath))
            {
                try
                {
                    string dataToLoad;

                    using FileStream stream = new(fullPath, FileMode.Open);
                    using StreamReader reader = new(stream);
                    dataToLoad = reader.ReadToEnd();

                    // deserialize the data
                    loadedData = JsonUtility.FromJson<T>(dataToLoad);
                }
                catch (Exception e)
                {
                    Debug.LogError($"Error occurred when trying to load file {fullPath} \n{e}");
                }
            }
            return loadedData;
        }

        public void Save(T data)
        {
            string fullPath = Path.Combine(dataDirPath, dataFileName);

            try
            {
                string directoryName = Path.GetDirectoryName(fullPath);
                Directory.CreateDirectory(directoryName);

                string dataToStore = JsonUtility.ToJson(data, true);

                using FileStream stream = new(fullPath, FileMode.Create);
                using StreamWriter writer = new(stream);
                writer.Write(dataToStore);
            }
            catch (Exception e)
            {
                Debug.LogError($"Error occurred when trying to save file {fullPath} \n{e}");
            }
        }
    }
}
