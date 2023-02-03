using UnityEngine;

public class AudioData : SavingData<AudioSetups>
{
    
    public AudioData( string key )
    {
        base.Key = key;
    }
    
    public void SetupValue( TypesAudio typesAudio, bool value )
    {
        _dataSetups.SetupValue(typesAudio,value);
        Save();
    }

    public bool GetValue(TypesAudio typesAudio)
    {
        return _dataSetups.GetValue(typesAudio);
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


