
namespace Final_Task.SaveLoadData
{
    public interface ISaveLoadService<T>
    {
        public abstract void SaveData(T data, string filename);
        public abstract T LoadData(string filename);
    }

}
