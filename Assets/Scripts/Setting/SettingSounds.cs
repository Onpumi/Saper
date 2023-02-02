using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingSounds<T>:ISettings
{
    private Sounds _sounds;
    private TypeSave _typeSave;
    
    public bool Exists(string key)
    {
        return PlayerPrefs.HasKey(key);
    }


    public SettingSounds(Sounds sounds, TypeSave typeSave)
    {
        _sounds = sounds;
        _typeSave = typeSave;
    }

    public void Save<T>(string key, T saveObject)
    {
        //_sounds.SetResolveSound(_soundType, value );
        
    }

    public T Load<T>(string key, T loadObject)
    {
        return loadObject; 
    }
    
}
