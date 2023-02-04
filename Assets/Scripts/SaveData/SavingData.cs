using System;using UnityEngine;

public abstract class SavingData<T,T1> where T : new() where T1 : System.Enum
{
    protected virtual string Key { get; set; }
    protected T _dataSetups;
    private PlayerPrefSettings _settings;

    public  SavingData( )
    {
        _dataSetups = new T();
        _settings = new PlayerPrefSettings();

    }
    
    public T Load()
    {
//        PlayerPrefs.DeleteAll();
        if (_settings.Exists(Key))
        {
            _dataSetups = _settings.Load(Key, _dataSetups);
            
        }
        else
        {
            Save();
        }

        return _dataSetups;
    }
    
    public void Save()
    {
        _settings.Save(Key,_dataSetups);
    }
    
    
    //public bool GetValue( T1 typeData)
    //{
//        return _dataSetups.GetValue(typeData);
//    }
    
 

}