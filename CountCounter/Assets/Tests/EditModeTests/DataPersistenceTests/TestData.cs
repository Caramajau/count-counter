using UnityEngine;

namespace DataPersistenceTests
{
    [System.Serializable]
    internal class TestData
    {
        [field: SerializeField]
        public int IntValue { get; set; }

        [field: SerializeField]
        public string StringValue { get; set; }
    }
}
