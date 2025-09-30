using UnityEngine;

namespace DataPersistence.DataClasses
{
    [System.Serializable]
    public abstract class Data
    {
        [field: SerializeField]
        public long LastUpdated { get; set; }
    }
}
