namespace CounterLogic
{
    public class CounterHandler
    {
        public int Counter { get; private set; }

        private readonly ICounterSaver counterSaver;

        public CounterHandler(ICounterSaver counterSaver)
        {
            this.counterSaver = counterSaver;
            Counter = counterSaver.ReadCounter();
        }

        public void IncrementCounter()
        {
            Counter++;
        }

        public void ResetCounter()
        {
            Counter = 0;
        }

        public void SaveCounter()
        {
            counterSaver.WriteCounter(Counter);
        }
    }
}
