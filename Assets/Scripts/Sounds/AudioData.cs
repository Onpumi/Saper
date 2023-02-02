using System;
using System.Collections.Generic;
using UnityEngine;


public class AudioData
{
    private const string Key = "AudioKey";
    private AudioSetups _audioSetups;
    private PlayerPrefSettings _settings;

    public AudioData()
    {
        _audioSetups = new AudioSetups();
        _settings = new PlayerPrefSettings();
    }

    public AudioSetups Load()
    {
       // PlayerPrefs.DeleteAll();
        
        if (_settings.Exists(Key))
        {
            _audioSetups = _settings.Load(Key, _audioSetups);
        }
        else
        {
            CreateNewSetups();
            Save();
        }

        return _audioSetups;
    }

    public void Save()
    {
        _settings.Save(Key,_audioSetups);
    }

    private void CreateNewSetups()
    {
        _audioSetups.CreateNewSetups();
    }

    public void SetupValue( TypeSave typeSave, bool value )
    {
        _audioSetups.SetupValue(typeSave,value);
        Save();
    }

    public bool GetValue(TypeSave typeSave)
    {
        return _audioSetups.GetValue(typeSave);
    }


}

[System.Serializable]
public class AudioSetups
{
    public bool ClickCellOn;
    public bool ExplodeOn;
    public bool FlagOn;
    public bool EmptyOn;
    


    public AudioSetups()
    {

    }

    public void CreateNewSetups()
    {
        ClickCellOn = true;
        ExplodeOn = true;
        FlagOn = true;
        EmptyOn = true;
    }

    public void SetupValue( TypeSave typeSave, bool value )
    {
        switch (typeSave)
        {
            case TypeSave.Click : ClickCellOn = value; break;
            case TypeSave.Empty : EmptyOn = value; break;
            case TypeSave.Explode : ExplodeOn = value; break;
            case TypeSave.Flag : FlagOn = value; break;
        }
    }

    public bool GetValue(TypeSave typeSave)
    {
        switch (typeSave)
        {
            case TypeSave.Click : return ClickCellOn; 
            case TypeSave.Empty : return EmptyOn; 
            case TypeSave.Explode : return ExplodeOn; 
            case TypeSave.Flag : return FlagOn; 
        }
        return true;
    }
    
    
    
}


