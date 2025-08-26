using CounterLogic;
using UnityEngine;

namespace CounterLogicTests
{
    public class CounterSaverTestClass : ICounterSaver
    {
        public long ReadCounter()
        {
            return 0;
        }

        public void WriteCounter(long counter)
        {
            Debug.Log($"Would have saved counter: {counter}");
        }
    }
}
