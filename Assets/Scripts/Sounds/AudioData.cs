

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

    public void SetupValue( TypesAudio typesAudio, bool value )
    {
        _audioSetups.SetupValue(typesAudio,value);
        Save();
    }

    public bool GetValue(TypesAudio typesAudio)
    {
        return _audioSetups.GetValue(typesAudio);
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

    public void SetupValue( TypesAudio typesAudio, bool value )
    {
        switch (typesAudio)
        {
            case TypesAudio.SoundClick : ClickCellOn = value; break;
            case TypesAudio.SoundEmpty : EmptyOn = value; break;
            case TypesAudio.SoundExplode : ExplodeOn = value; break;
            case TypesAudio.SoundFlag : FlagOn = value; break;
        }
    }

    public bool GetValue(TypesAudio typesAudio)
    {
        switch (typesAudio)
        {
            case TypesAudio.SoundClick : return ClickCellOn; 
            case TypesAudio.SoundEmpty : return EmptyOn; 
            case TypesAudio.SoundExplode : return ExplodeOn; 
            case TypesAudio.SoundFlag : return FlagOn; 
        }
        return true;
    }
    
    
    
}


