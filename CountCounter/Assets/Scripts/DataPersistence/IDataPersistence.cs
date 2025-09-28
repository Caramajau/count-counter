using DataPersistence.DataClasses;

namespace DataPersistence
{
    public interface IDataPersistence<T> where T : Data, new()
    {
        void LoadData(T data);
        void SaveData(T data);
    }
}
