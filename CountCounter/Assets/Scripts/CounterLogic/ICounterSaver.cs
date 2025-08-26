namespace CounterLogic
{
    public interface ICounterSaver
    {
        long ReadCounter();
        void WriteCounter(long counter);
    }
}
