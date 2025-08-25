namespace CounterLogic
{
    public interface ICounterSaver
    {
        int ReadCounter();
        void WriteCounter(int counter);
    }
}
