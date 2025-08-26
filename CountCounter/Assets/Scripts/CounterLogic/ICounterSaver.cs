using System.Numerics;

namespace CounterLogic
{
    public interface ICounterSaver
    {
        BigInteger ReadCounter();
        void WriteCounter(BigInteger counter);
    }
}
