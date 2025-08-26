using CounterLogic;
using System.Numerics;
using UnityEngine;

namespace CounterLogicTests
{
    public class CounterSaverTestClass : ICounterSaver
    {
        public BigInteger ReadCounter()
        {
            return 0;
        }

        public void WriteCounter(BigInteger counter)
        {
            Debug.Log($"Would have saved counter: {counter}");
        }
    }
}
