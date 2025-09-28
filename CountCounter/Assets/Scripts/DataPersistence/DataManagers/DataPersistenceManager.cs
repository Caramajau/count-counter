using DataPersistence.DataClasses;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

// Data persistence classes are based on:
// https://www.youtube.com/playlist?list=PL3viUl9h9k7-tMGkSApPdu4hlUBagKial
// Note: the design is quite modified.

namespace DataPersistence.DataManagers
{
    public class DataPersistenceManager<T> : MonoBehaviour where T : Data, new()
    {
        private const FindObjectsSortMode noSort = FindObjectsSortMode.None;

        [Header("File Storage Configuration")]
        [SerializeField]
        private string fileName;

        private T saveData;
        private List<IDataPersistence<T>> dataPersistenceObjects;
        private FileDataHandler<T> dataHandler;

        public static DataPersistenceManager<T> Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            DontDestroyOnLoad(gameObject);

            dataHandler = new FileDataHandler<T>(Application.persistentDataPath, fileName);
        }

        protected virtual void OnEnable()
        {
            // Can't be done in start since the scene loads before it. 
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        protected virtual void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            dataPersistenceObjects = FindAllDataPersistenceObjects();
            LoadTheData();
        }

        protected void CreateNewData()
        {
            saveData = new T();
            foreach (IDataPersistence<T> dataPersistenceObject in dataPersistenceObjects)
            {
                dataPersistenceObject.LoadData(saveData);
            }
        }

        private void LoadTheData()
        {
            saveData = dataHandler.Load();

            if (saveData == null)
            {
                Debug.Log("No data found. New data has to be created before loading");
                return;
            }

            foreach (IDataPersistence<T> dataPersistenceObject in dataPersistenceObjects)
            {
                dataPersistenceObject.LoadData(saveData);
            }
        }

        protected void SaveTheData()
        {
            if (saveData == null)
            {
                Debug.Log("No data found. New data has to be created before it can be saved");
                return;
            }

            foreach (IDataPersistence<T> dataPersistenceObject in dataPersistenceObjects)
            {
                dataPersistenceObject.SaveData(saveData);
            }

            // Timestamp when last saved.
            saveData.LastUpdated = System.DateTime.Now.ToBinary();

            dataHandler.Save(saveData);
        }

        private void OnApplicationQuit()
        {
            SaveTheData();
        }

        private static List<IDataPersistence<T>> FindAllDataPersistenceObjects()
        {
            IEnumerable<IDataPersistence<T>> foundDataPersistenceObjects = FindObjectsByType<MonoBehaviour>(noSort).OfType<IDataPersistence<T>>();
            return new List<IDataPersistence<T>>(foundDataPersistenceObjects);
        }

        protected bool HasData()
        {
            return saveData != null;
        }
    }
}
