using CounterLogic;
using UnityEngine;

namespace CounterLogicTests
{
    public class CounterSaverTestClass : ICounterSaver
    {
        public int ReadCounter()
        {
            return 0;
        }

        public void WriteCounter(int counter)
        {
            Debug.Log($"Would have saved counter: {counter}");
        }
    }
}
