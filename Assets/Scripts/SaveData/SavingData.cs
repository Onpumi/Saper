
namespace SaveData
{
    public abstract class SavingData<T> where T : new()
    {
        protected virtual string Key { get; set; }
        protected T DataSetups;
        private readonly PlayerPrefSettings _settings;

        protected SavingData()
        {
            DataSetups = new T();
            _settings = new PlayerPrefSettings();
        }

        public T Load()
        {
        
            if (_settings.Exists(Key))
                DataSetups = _settings.Load(Key, DataSetups);
            else
                Save();

            return DataSetups;
        }

        protected void Save() => _settings.Save(Key, DataSetups);

        public void DeleteAll() => UnityEngine.PlayerPrefs.DeleteAll();

    }

}