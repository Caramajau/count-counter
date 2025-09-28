using UnityEngine;

namespace DataPersistence.DataClasses
{
    [System.Serializable]
    public abstract class Data
    {
        // The fields need to be SerializeField or public.
        // Intentionally not using [field: SerializeField] to make data more readable.
        // Might change in the future.
        [SerializeField]
        private long lastUpdated;
        public long LastUpdated { get => lastUpdated; set => lastUpdated = value; }
    }
}
